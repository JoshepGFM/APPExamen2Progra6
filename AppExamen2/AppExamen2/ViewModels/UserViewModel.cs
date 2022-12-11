using AppExamen2.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace AppExamen2.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        public User MyUser { get; set; }
        public Country MyCounty { get; set; }
        public UserRole MyUserRole { get; set; }
        public UserStatus MyUserStatus { get; set; }

        public UserViewModel()
        {
            MyUser= new User();
            MyCounty= new Country();
            MyUserRole= new UserRole();
            MyUserStatus= new UserStatus();
        }

        public async Task<List<User>> GetUserList()
        {
            try
            {
                List<User> list = new List<User>();

                list = await MyUser.GetUser();

                if (list == null)
                {
                    return null;
                }
                else
                {
                    return list;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<User> GetUserData(int id)
        {
            try
            {
                User user = new User();
                user = await MyUser.GetUserData(id);

                if (user == null)
                {
                    return null;
                }
                else
                {
                    return user;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
