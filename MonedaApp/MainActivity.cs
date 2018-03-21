using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Net;
using static Android.Widget.TextView;
using System.Linq;
using static Android.Widget.AdapterView;

namespace MonedaApp
{
    [Activity(Label = "MonedaApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        string[] currencies;
        TextView textView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Init();

            Spinner spinner = FindViewById<Spinner>(Resource.Id.currency_spinner);
            textView = FindViewById<TextView>(Resource.Id.result);
            Button button = FindViewById<Button>(Resource.Id.btnConvert);
            EditText editText = FindViewById<EditText>(Resource.Id.amount);

            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, currencies);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            button.Click += (sender, eventArgs) =>
            {
                try
                {
                    if (!editText.Text.Any(c => char.IsLetter(c)))
                    {
                        string curr = spinner.SelectedItem.ToString();
                        decimal amount = decimal.Parse(editText.Text);
                        string convertedValue = ConvertionService.ConvertUSD(curr, amount).ToString();
                        textView.SetText($"{convertedValue} {curr}", BufferType.Normal);
                    }
                    else
                        Toast.MakeText(this, GetText(Resource.String.exploit_msg), ToastLength.Long).Show();
                }
                catch (WebException)
                {
                    ShowMessageDialog("Error", GetText(Resource.String.network_err_msg));
                }
                catch (Exception ex)
                {
                    ShowMessageDialog("Error", GetText(Resource.String.other_error));
                }
            };
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
                ShowMessageDialog("Error", GetText(Resource.String.network_err_msg));
            }
        }

        private void ShowMessageDialog(string title, string text)
        {
            var alert = new AlertDialog.Builder(this).Create();
            alert.SetTitle(title);
            alert.SetMessage(text);
            alert.SetButton("Ok", (sender, ev) => { });
            alert.Show();
        }
    }
}

