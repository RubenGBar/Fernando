using MAUI.VM;

namespace MAUI.Views;

public partial class Juego : ContentPage
{
	public Juego()
	{
		InitializeComponent();

		if (BindingContext is Partida vm)
		{
			vm.Dispatcher = this.Dispatcher;
        }

	}
}