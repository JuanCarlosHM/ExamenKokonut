
using Android.App;
using Android.OS;

namespace ExamenKokonut.Droid
{
    [Activity(Theme = "@style/theme.Splash", MainLauncher =true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(0);
            this.StartActivity(typeof(MainActivity));


            // Create your application here
        }
    }
}
