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
using CoreLib.CORE.Helpers.ObjectHelpers;
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
        protected Operation(string apiPath)
        {
            ApiPath = apiPath;
        }

        [JsonIgnore] internal string ApiPath { get; }

        [Display(Name = "Язык в кодировке ISO 639-1")]
        [MaxLength(2, ErrorMessageResourceType = typeof(ValidationStrings),
            ErrorMessageResourceName = "StringMaxLengthError")]
        public string Language { get; set; }

        protected virtual IEnumerable<ValidationResult> Validate()
        {
            var validationResults = new List<ValidationResult>(32);

            Validator.TryValidateObject(this, new ValidationContext(this), validationResults, true);

            return validationResults;
        }

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