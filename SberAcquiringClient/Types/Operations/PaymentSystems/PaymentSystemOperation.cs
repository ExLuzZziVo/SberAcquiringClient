#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Types;
using SberAcquiringClient.Resources;
using SberAcquiringClient.Types.Interfaces;

#endregion

namespace SberAcquiringClient.Types.Operations.PaymentSystems
{
    public abstract class PaymentSystemOperation<T> : Operation<T> where T : PaymentSystemOperationResult
    {
        protected new static readonly JsonSerializerOptions OperationJsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

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

            var result = JsonSerializer.Deserialize<T>(responseResult, OperationResultJsonSerializerOptions);

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

            var jsonData = JsonSerializer.Serialize(this, GetType(), OperationJsonSerializerOptions);

            return jsonData;
        }
    }
}