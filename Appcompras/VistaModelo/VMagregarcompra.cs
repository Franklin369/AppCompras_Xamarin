using Appcompras.Datos;
using Appcompras.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Appcompras.VistaModelo
{
    public class VMagregarcompra : BaseViewModel
    {
        #region VARIABLES
        int _Cantidad;
        string _Preciotexto;
        public Mproductos Parametrosrecibe { get; set; }
        #endregion
        #region CONSTRUCTOR
        public VMagregarcompra(INavigation navigation, Mproductos parametrosTrae)
        {
            Navigation = navigation;
            Parametrosrecibe = parametrosTrae;
            Preciotexto = "$" + Parametrosrecibe.Precio;
        }
        #endregion
        #region OBJETOS
        public string Preciotexto
        {
            get { return _Preciotexto; }
            set { SetValue(ref _Preciotexto, value); }
        }
        public int Cantidad
        {
            get { return _Cantidad; }
            set { SetValue(ref _Cantidad, value); }
        }
        #endregion
        #region PROCESOS
        public async Task Validarcompra()
        {
            var funcion = new Ddetallecompras();
            var listaXidproducto = await funcion.MostrarDcXidproducto(Parametrosrecibe.Idproducto);
       if(listaXidproducto.Count>0)
            {
                await Editardc();
            }
       else
            {
                await InsertarDc();
            }
        }
        public async Task Editardc()
        {
            if(Cantidad <1)
            {
                Cantidad = 1;
            }
            var funcion = new Ddetallecompras();
            var parametros = new Mdetallecompras();
            parametros.Cantidad = Cantidad.ToString();
            parametros.Idproducto = Parametrosrecibe.Idproducto;
            parametros.Preciocompra = Parametrosrecibe.Precio;
            await funcion.Editardetalle(parametros);
            await Volver();
        }
        public async Task InsertarDc()
        {
            if(Cantidad==0)
            {
                Cantidad = 1;
            }
            var funcion = new Ddetallecompras();
            var parametros = new Mdetallecompras();
            parametros.Cantidad = Cantidad.ToString();
            parametros.Idproducto = Parametrosrecibe.Idproducto;
            parametros.Preciocompra = Parametrosrecibe.Precio;
            double total = 0;
            double preciocompra =Convert.ToDouble( Parametrosrecibe.Precio);
            double cantidad =Convert.ToDouble( Cantidad);
            total = cantidad * preciocompra;
            parametros.Total = total.ToString();
            await  funcion.InsertarDc(parametros);
            await Volver();
        }
        public async Task Volver()
        {
            await Navigation.PopAsync();
        }
        public void Auementar()
        {
                Cantidad += 1;
        }
        public void Disminuir()
        {
            if (Cantidad > 0)
            {
                Cantidad -= 1;
            }
        }
        #endregion
        #region COMANDOS
        public ICommand Volvercommand => new Command(async () => await Volver());
        public ICommand Aumentarcommand => new Command(Auementar);
        public ICommand Disminuircommand => new Command(Disminuir);
        public ICommand Insertarcommand => new Command(async () => await Validarcompra());
        #endregion
    }
}
