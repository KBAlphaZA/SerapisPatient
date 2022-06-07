using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms.PancakeView.Droid;
using Plugin.FacebookClient;
using Android.Content;
using CarouselView.FormsPlugin.Droid;
using Microsoft.AppCenter.Distribute;

namespace SerapisPatient.Droid
{

    [Activity(Label = "SerapisPatient", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            Window.SetStatusBarColor(Android.Graphics.Color.ParseColor("#607d8b"));

            base.OnCreate(bundle);
            //ZXing.Net.Mobile.Forms.Android.Platform.Init();
            Rg.Plugins.Popup.Popup.Init(this, bundle);
            

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //global::Xamarin.Forms.FormsMaterial.Init(this,bundle);

            
            
            //Pancakeview package(gradients)
            PancakeViewRenderer.Init();

            //Location Services permission Android
            //Cros.Current.Init(this, bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);

            /*Distribute.SetEnabledForDebuggableBuild(true);            
            Microsoft.AppCenter.AppCenter.Start("d0703243-75a1-49fb-bd3e-3a9bf9fadd2f", typeof(Distribute));*/

            // Initialize Xamarin.Auth Presenters
            Xamarin.Auth.Presenters.XamarinAndroid.AuthenticationConfiguration.Init(this, bundle);
            
            LoadApplication(new App());
        }
        /*protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            GoogleClientManager.OnAuthCompleted(requestCode, resultCode, data);
        }*/

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
        //{
         //   base.OnActivityResult(requestCode, resultCode, intent);
         //   FacebookClientManager.OnActivityResult(requestCode, resultCode, intent);
         //   GoogleClientManager.OnAuthCompleted(requestCode, resultCode, intent);
        //}
        
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        {
            //Qr Code Scanner
            ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            //Gps locator
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

    }
}

