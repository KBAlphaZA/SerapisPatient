using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.behavious
{
    public sealed class ListItemSelected
    {
       
        public static readonly BindableProperty ItemTappedCommandProperty=
            BindableProperty.Create(
                "ItemTappedCommand", 
                typeof(ICommand), 
                typeof(ListItemSelected), 
                default(ICommand), 
                BindingMode.OneWay, 
                null,
                PropertyChanged);

        private static void PropertyChanged(BindableObject bindable, object newvalue, object oldValue)
        {
            var listview = bindable as ListView;

            if(listview != null)
            {
                listview.ItemTapped -= ListViewOnItemTapped;
                listview.ItemTapped += ListViewOnItemTapped;
            }
        }

        private static void ListViewOnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var list = sender as ListView;

            if(list !=null && list.IsEnabled && !list.IsRefreshing)
            {
                list.SelectedItem = null;
                var command = GetItemTappedCommand(list);
                if(command !=null && command.CanExecute(e.Item))
                {
                    command.Execute(e.Item);
                }
            }
        }

        private static ICommand GetItemTappedCommand(BindableObject bindableObject)
        {
            return (ICommand)bindableObject.GetValue(ItemTappedCommandProperty);
        }

        public static void SetItemTappedCommand(BindableObject bindable, object value)
        {
            bindable.SetValue(ItemTappedCommandProperty, value);
        }
    }
}
