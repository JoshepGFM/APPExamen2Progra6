using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AppExamen2.Models
{
    public class UserStatus
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";
        public UserStatus()
        {
            //Users = new HashSet<User>();
        }

        public int UserStatusId { get; set; }
        public string Status { get; set; } = null!;

        //public virtual ICollection<User> Users { get; set; }
        
    }
}
