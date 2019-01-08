using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;

namespace AppLinksSample.Droid
{
    [Activity(Label = "AppLinksSample", Icon = "@mipmap/icon", Theme = "@style/MainTheme",
              MainLauncher = true,  
              ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]

    //Invite App Link
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
                  DataScheme = "https",
                  DataHost = "xamboy.com",
                  DataPathPrefix = "/hello",
                  AutoVerify =true,
                  Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable })]
    [IntentFilter(new[] { Android.Content.Intent.ActionView },
                  DataScheme = "http",
                  DataHost = "xamboy.com",
                  AutoVerify = true,
                  DataPathPrefix = "/hello",
                  Categories = new[] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable })]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }
    }

    
}

