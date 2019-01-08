using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AppLinksSample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnAppLinkRequestReceived(Uri uri)
        {
            if (uri.Host.EndsWith("xamboy.com", StringComparison.OrdinalIgnoreCase))
            {

                if (uri.Segments != null && uri.Segments.Length == 3)
                {
                    var action = uri.Segments[1].Replace("/", "");
                    var msg = uri.Segments[2];

                    switch (action)
                    {
                        case "hello":
                            if(!string.IsNullOrEmpty(msg)){
                                Device.BeginInvokeOnMainThread(async() =>
                                {
                                    await Current.MainPage.DisplayAlert("hello", msg.Replace("&", " "), "ok");
                                });
                            }
                              
                            break;

                        default:
                            Xamarin.Forms.Device.OpenUri(uri);
                            break;
                    }
                }
            }
        }
    }
}
