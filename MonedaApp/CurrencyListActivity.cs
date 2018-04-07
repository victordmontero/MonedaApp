using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MonedaApp.Adapters;
using MonedaApp.Utils;

namespace MonedaApp
{
    [Activity(Label = "CurrencyListActivity", MainLauncher = true)]
    public class CurrencyListActivity : Activity
    {
        ListView listView;
        string[] currencies;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CurrencyListView);

            Init();

            listView = FindViewById<ListView>(Resource.Id.currencyListView);
            listView.Adapter = new CurrencyListAdapter(this, currencies);
            listView.FastScrollEnabled = true;
        }

        private void Init()
        {
            try
            {
                currencies = ConvertionService.GetCurrencies();
            }
            catch (WebException wex)
            {
                currencies = new string[] { GetText(Resource.String.no_currency_msg) };
                Helper.ShowMessageDialog(this, "Error", GetText(Resource.String.network_err_msg));
            }
        }
    }
}