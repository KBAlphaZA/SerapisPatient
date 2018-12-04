using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SerapisPatient.Controls
{
    public class HorizontalListView : ScrollView
    {
        readonly StackLayout _stack;

        int _selectedIndex;

        TapGestureRecognizer tapGestureRecognizer;

        public HorizontalListView()
        {
            Orientation = ScrollOrientation.Horizontal;

            _stack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,

            };

            Content = _stack;

            tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                var bindableObject = s as BindableObject;
                SelectedItem = bindableObject.BindingContext;
                UpdateSelectedIndex();
            };
        }
        
        public new IList<View> Children
        {
            get => _stack.Children;
            
        }

        private bool _layingOutChildren;
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, ItemWidthRequest, ItemHeightRequest);
            if (_layingOutChildren) return;

            _layingOutChildren = true;
            foreach (var child in Children) child.WidthRequest = ItemWidthRequest;
            _layingOutChildren = false;
        }

        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(HorizontalListView), 0, BindingMode.TwoWay,
                propertyChanged: async (bindable, oldValue, newValue) =>
                {
                    await ((HorizontalListView)bindable).UpdateSelectedItem();
                }
            );

        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndexProperty);
            }
            set
            {
                SetValue(SelectedIndexProperty, value);
            }
        }

        async Task UpdateSelectedItem()
        {
            await Task.Delay(300);
            SelectedItem = SelectedIndex > -1 ? Children[SelectedIndex].BindingContext : null;
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(HorizontalListView), null,
                propertyChanging: (bindableObject, oldValue, newValue) =>
                {
                    ((HorizontalListView)bindableObject).ItemsSourceChanging();
                },
                propertyChanged: (bindableObject, oldValue, newValue) =>
                {
                    ((HorizontalListView)bindableObject).ItemsSourceChanged();
                }
            );

        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        void ItemsSourceChanging()
        {
            if (ItemsSource == null) return;
            _selectedIndex = ItemsSource.IndexOf(SelectedItem);
        }

        void ItemsSourceChanged()
        {
            _stack.Children.Clear();
            foreach (var item in ItemsSource)
            {
                var view = (View)ItemTemplate.CreateContent();
                var bindableObject = view as BindableObject;
                if (bindableObject != null)
                    bindableObject.BindingContext = item;
                _stack.Children.Add(view);
                view.GestureRecognizers.Add(tapGestureRecognizer);
            }

            if (_selectedIndex >= 0) SelectedIndex = _selectedIndex;
        }

        public DataTemplate ItemTemplate
        {
            get;
            set;
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(HorizontalListView), null, BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    ((HorizontalListView)bindable).UpdateSelectedIndex();
                }
            );

        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        void UpdateSelectedIndex()
        {
            if (SelectedItem == BindingContext) return;

            SelectedIndex = Children
                .Select(c => c.BindingContext)
                .ToList()
                .IndexOf(SelectedItem);
        }

        public static readonly BindableProperty ItemWidthRequestProperty =
            BindableProperty.Create(nameof(ItemWidthRequest), typeof(Int32), typeof(HorizontalListView), 100, BindingMode.TwoWay);

        public Int32 ItemWidthRequest
        {
            set { SetValue(ItemWidthRequestProperty, value); }
            get { return (Int32)GetValue(ItemWidthRequestProperty); }
        }

        public static readonly BindableProperty ItemHeightRequestProperty =
            BindableProperty.Create(nameof(ItemHeightRequest), typeof(Int32), typeof(HorizontalListView), 100, BindingMode.TwoWay);

        public Int32 ItemHeightRequest
        {
            set { SetValue(ItemHeightRequestProperty, value); }
            get { return (Int32)GetValue(ItemHeightRequestProperty); }
        }
    }
}
