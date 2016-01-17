using System;
using System.Linq;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Binding.Droid.Views;
using System.Collections;
using System.Linq;
using Cirrious.MvvmCross.Binding.ExtensionMethods;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using System.Collections.Specialized;
using Cirrious.CrossCore;

namespace Xamarin.Samples.Android.Adapter
{
    public class BindableExpandableListAdapter : MvxAdapter, IExpandableListAdapter
    {
        private IList _itemsSource;

        public BindableExpandableListAdapter(Context context, IMvxAndroidBindingContext bindingContext)
            : base(context,bindingContext)
        {

        }

        int groupTemplateId;
        public int GroupTemplateId
        {
            get { return groupTemplateId; }
            set
            {
                if (groupTemplateId == value)
                    return;
                groupTemplateId = value;

                // since the template has changed then let's force the list to redisplay by firing NotifyDataSetChanged()
                if (ItemsSource != null)
                    NotifyDataSetChanged();
            }
        }

        protected override void SetItemsSource(System.Collections.IEnumerable value)
        {
            Mvx.Trace("Setting itemssource");
            if (_itemsSource == value)
                return;
            var existingObservable = _itemsSource as INotifyCollectionChanged;
            if (existingObservable != null)
                existingObservable.CollectionChanged -= OnItemsSourceCollectionChanged;

            _itemsSource = value as IList;

            var newObservable = _itemsSource as INotifyCollectionChanged;
            if (newObservable != null)
                newObservable.CollectionChanged += OnItemsSourceCollectionChanged;

            if (value != null)
            {
                // dit weggehaald FlattenAndSetSource(value);
            }
            else
                base.SetItemsSource(null);
        }



        public int GroupCount { get { return (_itemsSource != null ? _itemsSource.Count : 0); } }
        public void OnGroupExpanded(int groupPosition)
        {
            // do nothing
        }

        public void OnGroupCollapsed(int groupPosition)
        {
            // do nothing
        }

        public bool IsChildSelectable(int groupPosition, int childPosition)
        {
            return true;
        }

        public View GetGroupView(int groupPosition, bool isExpanded, View convertView, ViewGroup parent)
        {
            var item = _itemsSource[groupPosition];
            return base.GetBindableView(convertView, item, GroupTemplateId);
        }

        public long GetGroupId(int groupPosition)
        {
            return groupPosition;
        }

        public Java.Lang.Object GetGroup(int groupPosition)
        {
            return null;
        }

        public long GetCombinedGroupId(long groupId)
        {
            return groupId;
        }

        public long GetCombinedChildId(long groupId, long childId)
        {
            return childId;
        }

        public object GetRawItem(int groupPosition, int position)
        {
            return ((_itemsSource[groupPosition]) as IEnumerable).Cast<object>().ToList()[position];
        }

        public View GetChildView(int groupPosition, int childPosition, bool isLastChild, View convertView, ViewGroup parent)
        {
            var sublist = ((_itemsSource[groupPosition]) as IEnumerable).Cast<object>().ToList();

            var item = sublist[childPosition];
            return base.GetBindableView(convertView, item, ItemTemplateId);
        }

        public int GetChildrenCount(int groupPosition)
        {
            return ((_itemsSource[groupPosition]) as IEnumerable).Cast<object>().ToList().Count();
        }

        public long GetChildId(int groupPosition, int childPosition)
        {
            return childPosition;
        }

        public Java.Lang.Object GetChild(int groupPosition, int childPosition)
        {
            return null;
        }
    }
}