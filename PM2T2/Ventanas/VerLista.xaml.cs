using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PM2T2.Ventanas;
using PM2T2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2T2.Ventanas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerLista : ContentPage
    {
        public VerLista()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {

            base.OnAppearing();
            LoadCollectionView();
        }
        private async void LoadCollectionView()
        {
            listfirmas.ItemsSource = await App.BaseDatos.GetListSignatures();
        }

        private async void listafirmas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var itemSelected = (Firmas)e.SelectedItem;

            var signatureObtained = await App.BaseDatos.GetSignatureByCode(itemSelected.codigo);

            var showSignatureInformationPage = new MostrarInformacion(signatureObtained);

            await Navigation.PushAsync(showSignatureInformationPage);
        }
    }
}
