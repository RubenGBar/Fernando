using BL;
using ENT;
using MAUI.VM;

namespace MAUI.Views
{
    public partial class SeleccionarInvernadero : ContentPage
    {
        private TemperaturaVM vm;
        public SeleccionarInvernadero()
        {
            InitializeComponent();
            vm = new TemperaturaVM();
            vm.FechaSeleccionada = DateTime.Now; // Fecha actual por defecto en el DatePicker
            BindingContext = vm;
        }

        private async void OnVerDatosClicked(object sender, EventArgs e)
        {
            int idInvernadero = ManejadoraBL.obtenerIdInvernaderoPorNombreDAL(vm.InvernaderoSeleccionado);
            Temperaturas temperaturasEnviar = ManejadoraBL.obtenerTemperaturasInvernaderoBL(idInvernadero, vm.FechaSeleccionada.Date);

            TemperaturaConNombreInvernadero temperaturasConNombreInvernadero = new TemperaturaConNombreInvernadero(temperaturasEnviar, vm.InvernaderoSeleccionado);

            await Navigation.PushAsync(new MostrarDatos(temperaturasConNombreInvernadero));
        }

    }

}
