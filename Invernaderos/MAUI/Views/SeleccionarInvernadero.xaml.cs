using BL;
using ENT;
using MAUI.VM;

namespace MAUI.Views
{
    public partial class SeleccionarInvernadero : ContentPage
    {
        private VM.SeleccionarInvernadero vm;
        public SeleccionarInvernadero()
        {
            InitializeComponent();
            vm = new VM.SeleccionarInvernadero();
            vm.FechaSeleccionada = DateTime.Now; // Fecha actual por defecto en el DatePicker
            BindingContext = vm;
        }

        private async void OnVerDatosClicked(object sender, EventArgs e)
        {
            int idInvernadero = ManejadoraBL.obtenerIdInvernaderoPorNombreBL(vm.NombreInvernaderoSeleccionado);
            Temperaturas temperaturasEnviar = ManejadoraBL.obtenerTemperaturasInvernaderoBL(idInvernadero, vm.FechaSeleccionada.Date);

            TemperaturaConNombreInvernadero temperaturasConNombreInvernadero = new TemperaturaConNombreInvernadero(temperaturasEnviar, vm.NombreInvernaderoSeleccionado);

            await Navigation.PushAsync(new MostrarDatos(temperaturasConNombreInvernadero));
        }

    }

}
