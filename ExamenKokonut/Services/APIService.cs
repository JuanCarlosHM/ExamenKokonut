namespace ExamenKokonut.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using Plugin.Connectivity;
    using ExamenKokonut.Model;

    public class APIService
    {
        #region Validate Connection
        public async Task<Response> CheckConnection()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                return new Response
                {
                    IsSucces = false,
                    Message = "Internet turn off, please configure in settings."
                };
            }

            var isReachable = await CrossConnectivity.Current.IsRemoteReachable(
                "google.com");

            if (!isReachable)
            {
                return new Response
                {
                    IsSucces = false,
                    Message = "Check your internet connection."
                };
            }


            return new Response
            {
                IsSucces = true,
                Message = "OK"
            };
        }
        #endregion


        #region LogInSErvices
        public async Task<LogInData> GetToken(
            string urlBase,
            string app_version,
            string lang,
            string accept,
            string username,
            string password)
        {

            try
            {
                var formContent = new FormUrlEncodedContent (
                    new[] { 
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    });
                   

                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Add("app_version", app_version);
                client.DefaultRequestHeaders.Add("Accept", accept);

                var response = await client.PostAsync("", formContent);

                var resultJSON = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<LogInData>(
                        resultJSON);

                return result;

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
                return null;
            }

        }

        #endregion


        #region MakeConsult  
        public async Task<Response> Get<T>(
            string urlBase,
            string servicePrefix,
            string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);

                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);

                var result = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {

                    return new Response
                    {
                        IsSucces = false,
                        Message = result
                    };

                }

                var model = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSucces = true,
                    Message = "OK",
                    Result = model
                };

            }



            catch (Exception ex)
            {
                return new Response
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }
        #endregion


        public async Task<Response> Get<T>(
           string urlBase,
           string servicePrefix,
           string controller,
            string app_version,
            string lang,
            string accept,
            string auth)
        {
            try
            {
                var client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Add("app_version", app_version);
                client.DefaultRequestHeaders.Add("lang", lang);
                client.DefaultRequestHeaders.Add("Accept", accept);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + auth);

                var url = string.Format("{0}{1}", servicePrefix, controller);
                var response = await client.GetAsync(url);

                var result = await response.Content.ReadAsStringAsync();


                if (!response.IsSuccessStatusCode)
                {

                    return new Response
                    {
                        IsSucces = false,
                        Message = result
                    };

                }

                var model = JsonConvert.DeserializeObject<T>(result);
                return new Response
                {
                    IsSucces = true,
                    Message = "OK",
                    Result = model
                };

            }

            catch (Exception ex)
            {
                return new Response
                {
                    IsSucces = false,
                    Message = ex.Message
                };
            }
        }

    } // end Class 
}
