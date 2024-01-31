using Appcompras.Modelo;
using Appcompras.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Appcompras.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Agregarcompra : ContentPage
    {
        public Agregarcompra(Mproductos parametrosTrae)
        {
            InitializeComponent();
            BindingContext = new VMagregarcompra(Navigation, parametrosTrae);
        }
    }
}