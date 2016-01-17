using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.Views;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using System.Collections.Generic;
using Xamarin.Samples.Core.Model;
using Xamarin.Samples.Core.ViewModels;
using Xamarin.Samples.Android.Adapter;
using Cirrious.CrossCore;

namespace Xamarin.Samples.Android
{
    [Activity(Label = "Xamarin.Samples.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : MvxActivity
    {
        int count = 1;
       
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            var myListView = FindViewById<MvxListView>(Resource.Id.MyListView);

            myListView.Adapter = new MyCustomAdapter(this,
                (IMvxAndroidBindingContext)BindingContext,
                (DataContext as MainViewModel));

            var myExpandableListView = new MyCustomExpandableAdapter(this,
                (IMvxAndroidBindingContext)BindingContext,
                DataContext as MainViewModel);
        }

        private class MyCustomAdapter : MvxAdapter
        {
            private List<Client> _clients;
            private readonly MainViewModel _viewModel;

            public MyCustomAdapter(Context context, IMvxAndroidBindingContext bindingContext, MainViewModel viewModel)
                : base(context, bindingContext)
            {
                _clients = viewModel.Clients;
                _viewModel = viewModel;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                var view = convertView;
                if (view == null)
                {
                    var client = _clients[position];
                    view = base.GetBindableView(convertView, client, Resource.Layout.my_list_template);
                    var button = view.FindViewById<Button>(Resource.Id.MyButton);
                    button.Click += (sender, e) =>
                    {
                        _viewModel.ShowClientDetailsCommand.Execute(client.Id);
                    };
                }
                return view;
            }

            public override int Count
            {
                get
                {
                    return _clients.Count;
                }
            }
        }

        private class MyCustomExpandableAdapter : BindableExpandableListAdapter
        {
            private readonly List<Client> _clients;
            private readonly MainViewModel _viewModel;

            public MyCustomExpandableAdapter(Context context,
                IMvxAndroidBindingContext bindingContext, MainViewModel viewModel)
                : base(context, bindingContext)
            {
                _viewModel = viewModel;
                _clients = viewModel.Clients;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                return base.GetView(position, convertView, parent);
            }

            public override View GetDropDownView(int position, View convertView, ViewGroup parent)
            {
                return base.GetDropDownView(position, convertView, parent);
            }
        }
    }
}

