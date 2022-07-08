using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PM2T2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PM2T2.Ventanas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarInformacion : ContentPage
    {
        public MostrarInformacion(Firmas firma)
        {
            InitializeComponent();
            name.Text = firma.nombre;
            description.Text = firma.descripcion;
            imagenfirma.Source = ImageSource.FromStream(() => new MemoryStream(Convert.FromBase64String(firma.codigoimagen)));

        }
    }
}