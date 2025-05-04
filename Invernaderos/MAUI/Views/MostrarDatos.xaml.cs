using MAUI.VM;

namespace MAUI.Views;
public partial class MostrarDatos : ContentPage
{
	public MostrarDatos(TemperaturaConNombreInvernadero viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}