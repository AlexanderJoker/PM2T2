using PM2T2.Controles;
using SignaturePad.Forms;
using PM2T2.Ventanas;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PM2T2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2T2.Ventanas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarLista : ContentPage
    {
        string valueBase64;
        public AgregarLista()
        {
            InitializeComponent();
        }
        private async void GuardarButton_Clicked(object sender, EventArgs e)
        {
            Stream image = await PadView.GetImageStreamAsync(SignatureImageFormat.Png);
            var mStream = (MemoryStream)image;
            byte[] data = mStream.ToArray();
            valueBase64 = Convert.ToBase64String(data);


            if (String.IsNullOrWhiteSpace(name.Text) || String.IsNullOrWhiteSpace(description.Text))
            {
                await DisplayAlert("ERROR", "SE DEBEN DE LLENAR LOS DATOS DE NOMBRE Y DESCRIPCION PARA GUARDAR", "ACEPTAR");
            }

            var signatureToSave = new Firmas
            {
                codigoimagen = valueBase64,
                nombre = name.Text,
                descripcion = description.Text
            };

            var result = await App.BaseDatos.saveSignature(signatureToSave);

            if (result != 1)
            {
                await DisplayAlert("ERROR", "OCURRIO UN ERROR, INTENTE DE NUEVO", "ACEPTAR");
            }

            await DisplayAlert("AVISO", "GUARDADO CORRECTAMENTE", "ACEPTAR");
            limpiar();
        }

        private async void mostrarlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VerLista());
        }

        private void LimpiarButton_Clicked(object sender, EventArgs e)
        {
            limpiar();
        }
        void limpiar()
        {
            PadView.Clear();
            name.Text = "";
            description.Text = "";
        }
    }
}
