#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SberAcquiringClient.Resources;
using SberAcquiringClient.Types.Interfaces;

#endregion

namespace SberAcquiringClient.Types.Operations.PaymentSystems
{
    public abstract class PaymentSystemOperation<T> : Operation<T> where T : PaymentSystemOperationResult
    {
        protected PaymentSystemOperation(string apiPath) : base(apiPath) { }

        public override async Task<T> ExecuteAsync(HttpClient httpClient, ISberAcquiringApiSettings apiSettings)
        {
            var jsonData = ValidateAndGenerateJson(apiSettings);

            string responseResult;

            using (var response = await httpClient.PostAsync(apiSettings.ApiHost + ApiPath,
                       new StringContent(jsonData, Encoding.UTF8, "application/json")))
            {
                responseResult = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    throw new InvalidOperationException(string.Format(
                        ErrorStrings.ResourceManager.GetString("ApiRequestError"), responseResult));
                }
            }

            if (responseResult.IsNullOrEmptyOrWhiteSpace())
            {
                return null;
            }

            var result = JsonConvert.DeserializeObject<T>(responseResult);

            return result;
        }

        /// <summary>
        /// Проверяет данные запроса и сохраняет их в формате JSON
        /// </summary>
        /// <param name="apiSettings">Настройки подключения к api платежного шлюза</param>
        /// <returns>Данные запроса в формате JSON</returns>
        private string ValidateAndGenerateJson(ISberAcquiringApiSettings apiSettings)
        {
            if (apiSettings == null)
            {
                throw new ArgumentNullException(nameof(apiSettings));
            }

            if ((apiSettings.Token.IsNullOrEmptyOrWhiteSpace() &&
                 (apiSettings.UserName.IsNullOrEmptyOrWhiteSpace() ||
                  apiSettings.Password.IsNullOrEmptyOrWhiteSpace())) ||
                apiSettings.ApiHost.IsNullOrEmptyOrWhiteSpace())
            {
                throw new InvalidOperationException(
                    ErrorStrings.ResourceManager.GetString("NoApiAuthenticationDataError"));
            }

            var validationResults = new List<ValidationResult>(32);

            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            if (validationResults.Count() != 0)
            {
                throw new ExtendedValidationException(validationResults);
            }

            var jsonData = JsonConvert.SerializeObject(this,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    TypeNameHandling = TypeNameHandling.None,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });

            return jsonData;
        }
    }
}