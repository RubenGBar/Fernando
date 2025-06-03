namespace MAUI.Views
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnJuegoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Juego());
        }

        private async void OnRankingClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Ranking());
        }

        private async void OnInfoClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Info());
        }

    }

}
