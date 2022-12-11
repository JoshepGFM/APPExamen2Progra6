using AppExamen2.Models;
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
    public partial class AskPage : ContentPage
    {
        AskViewModel vm;
        public bool MyStrike = false;
        public AskPage()
        {
            InitializeComponent();
            BindingContext = vm = new AskViewModel();
            LoadStatus();
        }

        private async void LoadStatus()
        {
            PckStatus.ItemsSource = await vm.GetStatusList();
        }

        private async void SwIsStrike_Toggled(object sender, ToggledEventArgs e)
        {
            if (SwIsStrike.IsToggled)
            {
                MyStrike = true;
            }
            else
            {
                MyStrike = false;
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private bool UserInputValidation()
        {
            bool R = false;
            if (DpckDate.ToString() != null && !string.IsNullOrEmpty(DpckDate.ToString().Trim()) &&
                EdtAsk.Text != null && !string.IsNullOrEmpty(EdtAsk.Text.Trim()) &&
                TxtDetail.Text != null && !string.IsNullOrEmpty(TxtDetail.Text.Trim())
                && PckStatus.SelectedIndex > -1)
            {
                R = true;
            }
            else
            {
                if (DpckDate.ToString() == null || string.IsNullOrEmpty(DpckDate.ToString().Trim()))
                {
                    DpckDate.Focus();
                    DisplayAlert("Validation Error", "Date is required", "OK");
                    return false;
                }
                if (EdtAsk.Text == null || string.IsNullOrEmpty(EdtAsk.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "Question is required", "OK");
                    EdtAsk.Focus();
                    return false;
                }
                if (TxtDetail.Text == null || string.IsNullOrEmpty(TxtDetail.Text.Trim()))
                {
                    DisplayAlert("Validation Error", "Detail is required", "OK");
                    TxtDetail.Focus();
                    return false;
                }
            }
            return R;
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            if (UserInputValidation())
            {
                AskStatus status = PckStatus.SelectedItem as AskStatus;
                int statusId = status.AskStatusId;

                var answer1 = await DisplayAlert("Validation Error", "Are you sure to add?", "Yes", "No");
                if (answer1)
                {
                    bool R = false;
                    string URLImage = null;
                    if (TxtImagUrl.Text != null && !string.IsNullOrEmpty(TxtImagUrl.Text.Trim()))
                    {
                        URLImage = TxtImagUrl.Text.Trim();
                        R = true;
                    }
                    if (!R)
                    {
                        var answer2 = await DisplayAlert("Validation Error", "Are you sure you don't want to enter an image URL?", "Yes", "No");
                        if (answer2)
                        {
                            R = true;
                        }
                        else
                        {
                            TxtImagUrl.Focus();
                            return;
                        }
                    }
                    if (R)
                    {
                        bool Q = await vm.AddAsk(DpckDate.Date, EdtAsk.Text.Trim(),
                                            GlobalObjects.GlobalUser.UserId, statusId,
                                            URLImage, MyStrike, TxtDetail.Text.Trim());
                        if (Q)
                        {
                            await DisplayAlert(":)", "Everything is Ok", "Ok");
                            await Navigation.PopAsync();
                        }
                        else
                        {
                            await DisplayAlert(":(", "Something was wrong", "Ok");
                        }
                    }
                }
            }
        }
    }
}