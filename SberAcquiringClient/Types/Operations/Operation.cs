using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using CoreLib.CORE.Helpers.StringHelpers;
using CoreLib.CORE.Resources;
using CoreLib.CORE.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using SberAcquiringClient.Resources;
using SberAcquiringClient.Types.Interfaces;

namespace SberAcquiringClient.Types.Operations
{
    public abstract class Operation<T> where T : OperationResult
    {
        /// <summary>
        /// Создание запроса к api платежного шлюза
        /// </summary>
        /// <param name="apiPath">Абсолютный адрес запроса к api платежного шлюза</param>
        protected Operation(string apiPath)
        {
            ApiPath = apiPath;
        }

        /// <summary>
        /// Абсолютный адрес запроса к api платежного шлюза
        /// </summary>
        [JsonIgnore] internal string ApiPath { get; }

        /// <summary>
        /// Язык в кодировке ISO 639-1
        /// </summary>
        /// <list type="bullets">
        /// <item>Максимальная длина: 2</item>
        /// </list>
        [Display(Name = "Язык в кодировке ISO 639-1")]
        [MaxLength(2, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Language { get; set; }

        /// <summary>
        /// Проверка текущего запроса
        /// </summary>
        /// <returns>Список ошибок</returns>
        protected virtual IEnumerable<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>(32);

            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            return validationResults;
        }

        /// <summary>
        /// Асинхронное выполнение текущего запроса
        /// </summary>
        /// <param name="apiSettings">Настройки подключения к api платежного шлюза</param>
        /// <returns>Задача, представляющая асинхронную операцию выполнения текущего запроса к api платежного шлюза</returns>
        public virtual async Task<T> ExecuteAsync(ISberAcquiringApiSettings apiSettings)
        {
            var requestUri = GenerateRequestUri(apiSettings);

            var request = (HttpWebRequest) WebRequest.Create(requestUri);
            request.Method = WebRequestMethods.Http.Post;
            request.Accept = "application/json";

            string responseResult;

            using (var response = (HttpWebResponse) await request.GetResponseAsync())
            {
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    responseResult = await sr.ReadToEndAsync();
                }

                if (response.StatusCode != HttpStatusCode.OK)
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
        /// Асинхронное выполнение текущего запроса при помощи <see cref="HttpClient"/>
        /// </summary>
        /// <param name="httpClient">HttpClient</param>
        /// <param name="apiSettings">Настройки подключения к api платежного шлюза</param>
        /// <returns>Задача, представляющая асинхронную операцию выполнения текущего запроса к api платежного шлюза</returns>
        public virtual async Task<T> ExecuteAsync(HttpClient httpClient, ISberAcquiringApiSettings apiSettings)
        {
            var requestUri = GenerateRequestUri(apiSettings);

            string responseResult;

            using (var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, requestUri)))
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
        /// Генерирует url-адрес текущего запроса к api платежного шлюза
        /// </summary>
        /// <param name="apiSettings">Настройки подключения к api платежного шлюза</param>
        /// <returns>Url-адрес текущего запроса к api платежного шлюза</returns>
        private Uri GenerateRequestUri(ISberAcquiringApiSettings apiSettings)
        {
            if (apiSettings == null)
            {
                throw new ArgumentNullException(nameof(apiSettings));
            }

            if (apiSettings.Token.IsNullOrEmptyOrWhiteSpace() &&
                (apiSettings.UserName.IsNullOrEmptyOrWhiteSpace() ||
                 apiSettings.Password.IsNullOrEmptyOrWhiteSpace()) ||
                apiSettings.ApiHost.IsNullOrEmptyOrWhiteSpace())
            {
                throw new InvalidOperationException(
                    ErrorStrings.ResourceManager.GetString("NoApiAuthenticationDataError"));
            }

            var validationResults = Validate();

            if (validationResults.Count() != 0)
            {
                throw new ExtendedValidationException(validationResults);
            }

            // Возможно, это не так быстро как использование рефлексии, зато удобнее и наглядней
            var jObject = JObject.FromObject(this, JsonSerializer.Create(new JsonSerializerSettings
            {
                Formatting = Formatting.None,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.None,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }));

            var builder = new UriBuilder(apiSettings.ApiHost + ApiPath);

            var query = HttpUtility.ParseQueryString(string.Empty, Encoding.UTF8);

            if (apiSettings.Token.IsNullOrEmptyOrWhiteSpace())
            {
                query["userName"] = apiSettings.UserName;
                query["password"] = apiSettings.Password;
            }
            else
            {
                query["token"] = apiSettings.Token;
            }

            foreach (var jp in jObject.Children().Cast<JProperty>().ToArray())
            {
                query[jp.Name] = jp.Value.ToString().Replace("\r\n", string.Empty);
            }

            builder.Query = query.ToString();

            return builder.Uri;
        }
    }
}