using AppExamen2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExamen2.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Detail : ContentPage
    {
        AskViewModel vm;
        public bool MyViewAll { get; set; }
        public Detail()
        {
            InitializeComponent();
            BindingContext = vm = new AskViewModel();
            LoadListAsk(true);
        }

        private async void LoadListAsk(bool R)
        {
            LvSAK.ItemsSource = await vm.GetFullAskList(R);
        }

        private async void LvSAK_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PopAsync();
        }

        private void SwVeiwAll_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwVeiwAll.IsToggled)
            {
                LoadListAsk(false);
            }
            else
            {
                LoadListAsk(true);
            }
        }
    }
}