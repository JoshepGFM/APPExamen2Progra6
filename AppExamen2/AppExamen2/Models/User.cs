using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AppExamen2.Models
{
    public class User
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public User()
        {
            
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; }
        public string UserPassword { get; set; } = null!;
        public int StrikeCount { get; set; }
        public string BackUpEmail { get; set; } = null!;
        public string JobDescription { get; set; }
        public int UserStatusId { get; set; }
        public int CountryId { get; set; }
        public int UserRoleId { get; set; }

        public virtual Country Country { get; set; } = null!;
        public virtual UserRole UserRole { get; set; } = null!;
        public virtual UserStatus UserStatus { get; set; } = null!;
        //public virtual ICollection<Answer> Answers { get; set; }
        //public virtual ICollection<Ask> Asks { get; set; }
        //public virtual ICollection<Chat> ChatReceivers { get; set; }
        //public virtual ICollection<Chat> ChatSenders { get; set; }
        //public virtual ICollection<Like> Likes { get; set; }

        public async Task<List<User>> GetUser()
        {

            try
            {
                string RouteSufix = string.Format("Users");
                string FinalURL = Services.CnnTo.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<User>>(response.Content);
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
        public async Task<User> GetUserData(int id)
        {
            try
            {
                string RouteSufix = string.Format("Users/GetUsersData?id={0}", id);

                string FinalURL = Services.CnnTo.ProductionURL + RouteSufix;

                RestClient client = new RestClient(FinalURL);

                request = new RestRequest(FinalURL, Method.Get);

                request.AddHeader(contentType, mimetype);

                RestResponse response = await client.ExecuteAsync(request);

                HttpStatusCode statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var list = JsonConvert.DeserializeObject<List<User>>(response.Content);

                    var item = list[0];

                    return item;
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
