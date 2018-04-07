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

namespace MonedaApp.Adapters
{
    public class CurrencyListAdapter : BaseAdapter<string>
    {
        string[] items;
        Activity context;

        public CurrencyListAdapter(Activity context, string[] items)
        {
            this.context = context;
            this.items = items;
        }

        public override string this[int position] => items[position];

        public override int Count => items.Length;

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            if (convertView == null)
                convertView = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).Text = item;
            return convertView;
        }
    }
}