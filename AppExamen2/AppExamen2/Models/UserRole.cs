using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppExamen2.Models
{
    public  class UserRole
    {
        public RestRequest request { get; set; }
        const string mimetype = "application/json";
        const string contentType = "Content-Type";
        public UserRole()
        {
            //Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string UserRole1 { get; set; } = null!;
        public bool IsUserSelectable { get; set; }

        //public virtual ICollection<User> Users { get; set; }
    }
}
