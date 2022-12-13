using Microsoft.Extensions.Configuration;
using myFlightapp.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace myFlightapp.IServices
{
   
        public class Response
        {
            public bool status { get; set; }
            public string Error { get; set; }
            public string data { get; set; }
        }
        public interface IFlightService
        {
            Task<Response> CreateFlight(FlightModel createflight);
            Task<Response> DeleteFlight(long Id);
            Task<Response> UpdateFlight(FlightModel model);
    }

       

        public class FlightService : IFlightService
        {
            private readonly IConfiguration _config;
            public FlightService(IConfiguration config)
            {
                _config = config;
            }
            public async Task<Response> CreateFlight(FlightModel createflight)
            {
                 Response deseralize;

                var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/CreateFlight";

                var client = new HttpClient();
                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

                var data = JsonConvert.SerializeObject(createflight);
                var sendRequest = await client.PostAsync(url, new StringContent(data, Encoding.UTF8, "application/json"));

                var response = await sendRequest.Content.ReadAsStringAsync();

                deseralize = JsonConvert.DeserializeObject<Response>(response);
                return deseralize;
            }

        public async Task<Response> DeleteFlight(long Id)
        {

            Response deseralize;

            var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/deleteflight/Id";

            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            //var data = JsonConvert.SerializeObject();
            var sendRequest = await client.DeleteAsync(url);
                //(url, new StringContent( Encoding.UTF8, "application/json"));

            var response = await sendRequest.Content.ReadAsStringAsync();

            deseralize = JsonConvert.DeserializeObject<Response>(response);
            return deseralize;
        }

        public Task<Response> UpdateFlight(FlightModel model)
        {
            throw new System.NotImplementedException();
        }
    }
    
}
