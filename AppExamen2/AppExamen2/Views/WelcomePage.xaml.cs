using AppExamen2.Models;
using AppExamen2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamen2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        UserViewModel vm;
        public WelcomePage()
        {
            InitializeComponent();
            this.BindingContext = vm = new UserViewModel();
            LoadUsersList();
        }

        public async void LoadUsersList()
        {
            PckUsers.ItemsSource = await vm.GetUserList();
        }

        private async void BtnWelcome_Clicked(object sender, EventArgs e)
        {
            if (PckUsers.SelectedIndex != -1)
            {
                User User = PckUsers.SelectedItem as User;
                int IdRol = User.UserId;

                GlobalObjects.GlobalUser = await vm.GetUserData(IdRol);
                await Navigation.PushAsync(new HomePage());

            }
            else
            {
                PckUsers.Focus();
                await DisplayAlert("Error", "Select a user", "OK");
                return;
            }

        }
    }
}