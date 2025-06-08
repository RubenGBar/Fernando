using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace MAUI
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Esta mierda se supone que es para quitar una barra blanca de arriba
            if (Build.VERSION.SdkInt >= BuildVersionCodes.R)
            {
                Window.SetDecorFitsSystemWindows(false);
                Window.InsetsController?.Hide(WindowInsets.Type.StatusBars());
            }
            else
            {
                Window.AddFlags(WindowManagerFlags.Fullscreen);
            }
        }
    }
}
