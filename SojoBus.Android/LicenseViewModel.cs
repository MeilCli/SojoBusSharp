using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SojoBus.Core.Model;

namespace SojoBus.Android {
    public class LicenseViewModel : Core.ViewModel.LicenseViewModel {

        public LicenseViewModel() : base() { }

        public override List<LicenseModel> InitLicense() {
            var list =  base.InitLicense();
            list.Add(new LicenseModel("Xamarin.Android.Support.v4","https://components.xamarin.com/license/xamandroidsupportv4-18","http://developer.android.com/intl/ja/tools/support-library/index.html"));
            list.Add(new LicenseModel("Xamarin.Android.Support.v7.AppCompat","https://components.xamarin.com/license/xamandroidsupportv7appcompat","http://developer.android.com/intl/ja/tools/support-library/index.html"));
            list.Add(new LicenseModel("Xamarin.Android.Support.v7.CardView","https://components.xamarin.com/license/xamandroidsupportv7cardview","http://developer.android.com/intl/ja/tools/support-library/index.html"));
            list.Add(new LicenseModel("Xamarin.Android.Support.v7.RecyclerView","https://components.xamarin.com/license/xamandroidsupportv7recyclerview","http://developer.android.com/intl/ja/tools/support-library/index.html"));
            list.Add(new LicenseModel("Xamarin.Android.Support.Design","https://components.xamarin.com/license/xamandroidsupportdesign","http://developer.android.com/intl/ja/tools/support-library/index.html"));
            return list;
        }
    }
}