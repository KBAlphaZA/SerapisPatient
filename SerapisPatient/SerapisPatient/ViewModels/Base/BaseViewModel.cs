
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private const string EXECUTECOMMAND_SUFFIX = "_ExecuteCommand";
        private const string CANEXECUTECOMMAND_SUFFIX = "_CanExecuteCommand";


        public BaseViewModel()
        {
            this.commands =
                 this.GetType().GetTypeInfo().DeclaredMethods
                 .Where(dm => dm.Name.EndsWith(EXECUTECOMMAND_SUFFIX))
                 .ToDictionary(k => GetCommandName(k), v => GetCommand(v));
        }

        #region Propertychanged events

        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));

            }
        }

        #region Horizontalscroll code
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

        #region TLSSCROLL CODE
        /*
           Better and simplest. To accomplish this,
        //you can implement the GetValue and SetValue methods in the ViewModelBase class and stores the properties values in a Dictionary:
        */
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        protected void SetValue<T>(T value, [CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
            {
                properties.Add(propertyName, default(T));
            }

            var oldValue = GetValue<T>(propertyName);
            if (!EqualityComparer<T>.Default.Equals(oldValue, value))
            {
                properties[propertyName] = value;
                OnPropertyChanged(propertyName);
            }
        }

        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (!properties.ContainsKey(propertyName))
            {
                return default(T);
            }
            else
            {
                return (T)properties[propertyName];
            }
        }


        /*A further step forward in your ViewModelBase consists in develop an automatic and simple way to delegate the execution of commands.
         * In MVVM, a command is a piece of code executed in response of a view interaction.
         * To create a command, you must implement the ICommand interface and put your code in it.
         * The power of this approach helps you to create a code that can be used in multiple views,
         * but sometimes you need to use that command only one time.
         */
        private Dictionary<string, ICommand> commands = new Dictionary<string, ICommand>();

        //Im rewriting this method which is the same as SetValue<T>(on line 49) because i wanted to customized the picker on SelectBookingView

        //protected bool SetProperty<T>(ref T backfield,T value [CallerMemberName]string propertyName = null)
        //method goes here


        private string GetCommandName(MethodInfo mi)
        {
            return mi.Name.Replace(EXECUTECOMMAND_SUFFIX, "");
        }

        private ICommand GetCommand(MethodInfo mi)
        {
            var canExecute = this.GetType().GetTypeInfo().GetDeclaredMethod(GetCommandName(mi) + CANEXECUTECOMMAND_SUFFIX);
            var executeAction = (Action<object>)mi.CreateDelegate(typeof(Action<object>), this);
            var canExecuteAction = canExecute != null ? (Func<object, bool>)canExecute.CreateDelegate(typeof(Func<object, bool>), this) : state => true;
            return new Command(executeAction, canExecuteAction);
        }

        public ICommand this[string name]
        {
            get
            {
                var cmd = commands[name];
                return cmd;
            }
        }

        #endregion

        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return isBusy;
            }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsBusy");
                isBusy = value;
            }
        }
        // ShowUI is for the xamrin IsEnabled feature
        private bool showUI;
        public bool ShowUI
        {
            get
            {
                return showUI;
            }
            set
            {
                showUI = value;
                OnPropertyChanged("ShowUI");
                showUI = value;
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
                title = value;
            }
        }
        #endregion

        //Use this one for changing strings
        public void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
