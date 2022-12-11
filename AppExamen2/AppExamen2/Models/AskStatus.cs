using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen2.Models
{
    public class AskStatus
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public AskStatus()
        {
            //Asks = new HashSet<Ask>();
        }

        public int AskStatusId { get; set; }
        public string AskStatus1 { get; set; } = null!;

        //public virtual ICollection<Ask> Asks { get; set; }

        public async Task<List<AskStatus>> GetStatus()
        {

            try
            {
                string RouteSufix = string.Format("AskStatus");
                string FinalURL = Services.CnnTo.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<AskStatus>>(response.Content);
                    return list;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                throw;
            }
        }
    }
}
