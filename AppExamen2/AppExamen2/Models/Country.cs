using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen2.Models
{
    public class Country
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";

        public Country()
        {
            //Users = new HashSet<User>();
        }

        public int CountryId { get; set; }
        public string CountryName { get; set; } = null!;

        //public virtual ICollection<User> Users { get; set; }
    }
}
