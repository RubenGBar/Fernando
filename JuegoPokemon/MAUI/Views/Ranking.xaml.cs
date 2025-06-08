namespace MAUI.Views;

public partial class Ranking : ContentPage
{
	public Ranking()
	{
		InitializeComponent();
	}

    private async void OnVolverClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}