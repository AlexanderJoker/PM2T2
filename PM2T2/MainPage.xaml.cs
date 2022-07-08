using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PM2T2.Ventanas;

namespace PM2T2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void AgregarLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarLista());
        }
        private async void Verlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerLista());
        }
    }
}
