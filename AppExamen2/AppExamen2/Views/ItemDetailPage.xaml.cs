using AppExamen2.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppExamen2.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}