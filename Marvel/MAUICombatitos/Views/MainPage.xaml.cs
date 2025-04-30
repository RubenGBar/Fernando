using MAUICombatitos.VM;

namespace MAUICombatitos.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var miVM = (ListadoPersonajeConPuntuacion)BindingContext;
            if (miVM != null)
            {
                miVM.recargarLista();
            }

        }

    }

}
