using System;
using Newtonsoft.Json;
using RestSharp;

namespace QuickstartAPI360
{
    public class APICalls
    {
        private static readonly string User = "";
        private static readonly string Password = "";
        private static readonly string Terminal = "";
        private static readonly string EndPoint = "http://api360dev.avomark.fr";

        private string Token;

        public void GetNewToken()
        {
            var client = new RestClient(EndPoint + "/api/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", "username="+User+"&password="+Password+"&terminal="+Terminal, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                dynamic tokenResponse = JsonConvert.DeserializeObject(response.Content);
                Token = tokenResponse.token_type + " " + tokenResponse.access_token;
            }
        }

        public void GetCardByNumber(string cardNumber)
        {
            var response = Call("/api/v1/cards/" + cardNumber, null, Method.GET);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            { 
                dynamic card = JsonConvert.DeserializeObject(response.Content);

                Console.WriteLine(card.balances[0].primaryLoyaltyBalance.label);
                Console.WriteLine(card.balances[0].primaryLoyaltyBalance.type);
                Console.WriteLine(card.balances[0].primaryLoyaltyBalance.value);
                Console.WriteLine("Customer Id = ");
                Console.WriteLine(card.customerId);
            }
            else
            {
                throw new Exception("Please, check the number card");
            }
        }

        public void GetCustomerById(int customerId)
        {
            var response = Call("/api/v1/customers/" + customerId, null, Method.GET);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                dynamic customer = JsonConvert.DeserializeObject(response.Content);

                Console.WriteLine(customer.civility);
                Console.WriteLine(customer.firstname);
                Console.WriteLine(customer.lastname);
            }
            else
            {
                throw new Exception("Please, check the customer id");
            }
        }

        private IRestResponse Call(string uri, string body, Method method)
        {
            var client = new RestClient(EndPoint + uri);
            var request = new RestRequest(method);
            request.AddHeader("Authorization", Token);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(body);
            IRestResponse response = client.Execute(request);

            // Check only HTTP Code 401 
            // = Token invalid or expired
            if(response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                GetNewToken();
                return Call(uri, body, method);
            }
            // Connection or server error
            else if(response.StatusCode == 0 || 
                response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                if(method == Method.POST || 
                    method == Method.PUT || 
                    method == Method.PATCH)
                {
                    // Save your variables (in memory/your database..) to send them later
                }

                if(response.StatusCode == 0)
                    throw new Exception("Please, check your connection");
            }

            return response;
        }
    }
}
