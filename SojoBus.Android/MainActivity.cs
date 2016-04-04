﻿using System;
using SojoBus.Core.ViewModel;
using Android.App;
using SupportFragmentManager = Android.Support.V4.App.FragmentManager;
using SupportFragment = Android.Support.V4.App.Fragment;
using SupportAlertDialog = Android.Support.V7.App.AlertDialog;
using SupportToolbar = Android.Support.V7.Widget.Toolbar;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Reactive.Bindings;
using Android.Support.V7.App;
using Android.Support.V4.App;
using Java.Lang;
using JavaString = Java.Lang.String;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Widget;
using Android.Graphics;
using Android.Util;
using Android.Content.Res;

namespace SojoBus.Android {
    [Activity(Label = "SojoBus#",MainLauncher = true,Icon = "@drawable/Icon")]
    public class MainActivity : AppCompatActivity {

        private BusViewModel busViewModel = new BusViewModel();
        private LicenseViewModel licenseViewModel = new LicenseViewModel();
        private string licenseMenu= "ライセンス";
        private int originalViewPagerHeight = 0;

        protected override void OnCreate(Bundle bundle) {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MainActivity);

            var toolbar = FindViewById<SupportToolbar>(Resource.Id.Toolbar);
            this.SetSupportActionBar(toolbar);
            toolbar.SetBinding(x => x.Subtitle,busViewModel.Info);          

            var adapter = new BusPagerAdaper(SupportFragmentManager);
            var viewpager = FindViewById<ViewPager>(Resource.Id.ViewPager);
            viewpager.Adapter = adapter;

            FindViewById<TabLayout>(Resource.Id.TabLayout).SetupWithViewPager(viewpager);
        }

        public override void OnWindowFocusChanged(bool hasFocus) {
            base.OnWindowFocusChanged(hasFocus);
            if(Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop) {
                var viewpager = FindViewById<ViewPager>(Resource.Id.ViewPager);
                if(originalViewPagerHeight == 0) {
                    originalViewPagerHeight = viewpager.Height;
                }
                viewpager.LayoutParameters.Height = originalViewPagerHeight + GetActionbarSize();
            }
        }

        protected override void OnResume() {
            base.OnResume();
            busViewModel.LoadInfo.Execute();
        }

        public override bool OnCreateOptionsMenu(IMenu menu) {
            menu.Add(Menu.None,Menu.First+licenseMenu.GetHashCode(),0,licenseMenu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item) {
            if(item.ItemId==Menu.First+licenseMenu.GetHashCode()) {
                var builder = new SupportAlertDialog.Builder(this);
                builder.SetTitle(licenseMenu);
                builder.SetMessage(licenseViewModel.License.Value);
                builder.SetPositiveButton("OK",new DialogDismiss());
                builder.Show();
            }
            return base.OnOptionsItemSelected(item);
        }

        public int GetActionbarSize() {
            var tv = new TypedValue();
            int result = 0;
            if(this.Theme.ResolveAttribute(Resource.Attribute.actionBarSize,tv,true)) {
                result = TypedValue.ComplexToDimensionPixelSize(tv.Data,this.Resources.DisplayMetrics);
            }
            return result;
        }

    }

    class BusPagerAdaper : FragmentPagerAdapter {

        public BusPagerAdaper(SupportFragmentManager manager) : base(manager) { }

        public override int Count { get; } = 2;

        public override SupportFragment GetItem(int position) {
            if(position == 0) {
                return BusFragmentType.Tozan.CreateFrgment();
            } else {
                return BusFragmentType.Gezan.CreateFrgment();
            }
        }

        public override ICharSequence GetPageTitleFormatted(int position) {
            if(position == 0) {
                return new JavaString("登山");
            } else {
                return new JavaString("下山");
            }
        }
    }

    class DialogDismiss : Java.Lang.Object, IDialogInterfaceOnClickListener {
        public void OnClick(IDialogInterface dialog,int which) {
            dialog.Dismiss();
        }
    }
}

