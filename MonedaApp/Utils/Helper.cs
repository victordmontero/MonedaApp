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

namespace MonedaApp.Utils
{
    public class Helper
    {
        public static void ShowMessageDialog(Activity context, string title, string text)
        {
            var alert = new AlertDialog.Builder(context).Create();
            alert.SetTitle(title);
            alert.SetMessage(text);
            alert.SetButton("Ok", (sender, ev) => { });
            alert.Show();
        }
    }
}