using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen2.Models
{
    public class Ask
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";
        public Ask()
        {
            //Answers = new HashSet<Answer>();
        }

        public long AskId { get; set; }
        public DateTime Date { get; set; }
        public string AskDescription { get; set; } = null!;
        public int UserId { get; set; }
        public int AskStatusId { get; set; }
        public bool? IsStrike { get; set; }
        public string? ImageUrl { get; set; }
        public string? AskDetail { get; set; }

        public virtual AskStatus? AskStatus { get; set; } = null!;
        public virtual User? User { get; set; } = null!;
        //public virtual ICollection<Answer> Answers { get; set; }

        public async Task<bool> AddAsk()
        {
            try
            {
                string RouteSufix = string.Format("Asks");
                string FinalURL = Services.CnnTo.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Post);

                request.AddHeader(contentType, mimetype);
                string SerialClass = JsonConvert.SerializeObject(this);

                request.AddBody(SerialClass, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.Created)
                {
                    return true;
                }
                else
                {
                    return false;
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
