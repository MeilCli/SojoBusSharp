using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using SojoBus.Core.ViewModel;
using Android.Support.V7.Widget;
using Reactive.Bindings;

namespace SojoBus.Android {

    public enum BusFragmentType {
        Tozan = 1, Gezan = 2
    }

    public static class BusFragmentTypeExtensions {
        public static Fragment CreateFrgment(this BusFragmentType type) {
            var fragment = new BusFragment();
            var bundle = new Bundle();
            bundle.PutInt(nameof(BusFragmentType),(int)type);
            fragment.Arguments = bundle;
            return fragment;
        }
    }

    public class BusFragment : Fragment {

        private BusViewModel busViewModel = new BusViewModel();
        public BusFragmentType Type { private set; get; }

        public override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater,ViewGroup container,Bundle savedInstanceState) {
            this.Type = (BusFragmentType)this.Arguments.GetInt(nameof(BusFragmentType),(int)BusFragmentType.Tozan);
            View view = inflater.Inflate(Resource.Layout.BusFragment,container,false);

            view.FindViewById<AppCompatTextView>(Resource.Id.TakatukiText).SetBinding(x => x.Text,busViewModel.Takatuki);
            view.FindViewById<AppCompatTextView>(Resource.Id.TondaText).SetBinding(x => x.Text,busViewModel.Tonda);
            view.FindViewById<AppCompatTextView>(Resource.Id.TakatukiDetailText).SetBinding(x => x.Text,busViewModel.TakatukiDetail);
            view.FindViewById<AppCompatTextView>(Resource.Id.TondaDetailText).SetBinding(x => x.Text,busViewModel.TondaDetail);
            if(Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
                view.FindViewById<View>(Resource.Id.BottomView).Visibility = ViewStates.Visible;
                if(view.Resources.Configuration.Orientation== global::Android.Content.Res.Orientation.Landscape) {
                    view.FindViewById<View>(Resource.Id.BottomView2).Visibility = ViewStates.Visible;
                }
            }
            return view;
        }

        public override void OnResume() {
            base.OnResume();
            load();
        }

        private void load() {
            if(this.Type == BusFragmentType.Tozan) {
                busViewModel.LoadToKanadaiFromTakatuki.Execute();
                busViewModel.LoadToKandaiFromTonda.Execute();
                busViewModel.LoadToKanadaiFromTakatukiDetail.Execute();
                busViewModel.LoadToKandaiFromTondaDetail.Execute();
            } else {
                busViewModel.LoadToTakatukiFromKandai.Execute();
                busViewModel.LoadToTondaFromKandai.Execute();
                busViewModel.LoadToTakatukiFromKandaiDetail.Execute();
                busViewModel.LoadToTondaFromKandaiDetail.Execute();
            }
        }
    }
}