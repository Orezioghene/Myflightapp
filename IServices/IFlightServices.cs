using Microsoft.Extensions.Configuration;
using myFlightapp.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace myFlightapp.IServices
{
   
        public class Response
        {
            public bool isSuccessful { get; set; }
            public string Error { get; set; }
            public string data { get; set; }
        }
        public interface IFlightService
        {
        Task<Response> BookFlight(FlightBookingModel bookFlight);
        Task<Response> CancelBooking(string username);
        Task<Response> CreateFlight(FlightModel createflight);
            Task<Response> DeleteFlight(long Id);
        Task<List<FlightBookingModel>> GetAllBooking();
        Task<List<FlightModel>> GetAllFlight();
        Task<FlightBookingModel> GetBookingByUsername(string username);
        Task<FlightModel> GetFlight(int Id);
        Task<FlightModel> GetFlightByDestination(string destination);
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

            var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/deleteflight/Id/{Id}";

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
    
            public async Task<List<FlightModel>> GetAllFlight()
            {
                List<FlightModel> deserialize = null;
                var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/GetAllflights";

                var client = new HttpClient();
                //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

                var sendRequest = await client.GetAsync(url);

                var response = await sendRequest.Content.ReadAsStringAsync();

                deserialize = JsonConvert.DeserializeObject<List<FlightModel>>(response);
                return deserialize;
            }

        public async Task<FlightModel> GetFlight(int Id)
        {
            FlightModel deserialize = null;
            var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/GetFlightbyId";

            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            var sendRequest = await client.GetAsync($"{url}/{Id}");

            var response = await sendRequest.Content.ReadAsStringAsync();

            deserialize = JsonConvert.DeserializeObject<FlightModel>(response);
            return deserialize;
        }
        //

        public async Task<FlightBookingModel> GetBookingByUsername(string username)
        {
            FlightBookingModel deserialize = null;
            var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/GetBooking";

            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            var sendRequest = await client.GetAsync($"{url}/{username}");

            var response = await sendRequest.Content.ReadAsStringAsync();

            deserialize = JsonConvert.DeserializeObject<FlightBookingModel>(response);
            return deserialize;
        }

        public async Task<List<FlightBookingModel>> GetAllBooking()
        {
            List<FlightBookingModel> deserialize = null;
            var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/AllBookings";

            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            var sendRequest = await client.GetAsync($"{url}");

            var response = await sendRequest.Content.ReadAsStringAsync();

            deserialize = JsonConvert.DeserializeObject<List<FlightBookingModel>>(response);
            return deserialize;
        }

        public async Task<FlightModel> GetFlightByDestination(string destination)
        {
            FlightModel deserialize = null;
            var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/GetBooking";

            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            var sendRequest = await client.GetAsync($"{url}/{destination}");

            var response = await sendRequest.Content.ReadAsStringAsync();

            deserialize = JsonConvert.DeserializeObject<FlightModel>(response);
            return deserialize;
        }

        public async Task<Response> BookFlight(FlightBookingModel bookFlight)
        {
            Response deseralize;

            var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/BookFlight";

            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            var data = JsonConvert.SerializeObject(bookFlight);
            var sendRequest = await client.PostAsync(url, new StringContent(data, Encoding.UTF8, "application/json"));

            var response = await sendRequest.Content.ReadAsStringAsync();

            deseralize = JsonConvert.DeserializeObject<Response>(response);
            return deseralize;
        }

        public async Task<Response> CancelBooking(string username)
        {

            Response deseralize;

            var url = $"{_config.GetValue<string>("FlightApp:Url")}/api/Flight_/CancelBooking?Username={username}";

            var client = new HttpClient();
            //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

            //var data = JsonConvert.SerializeObject();
            var sendRequest = await client.DeleteAsync(url);
            //(url, new StringContent( Encoding.UTF8, "application/json"));

            var response = await sendRequest.Content.ReadAsStringAsync();

            deseralize = JsonConvert.DeserializeObject<Response>(response);
            return deseralize;
        }
    }

}
