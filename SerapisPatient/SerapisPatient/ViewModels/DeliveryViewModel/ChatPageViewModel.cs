using SerapisPatient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SerapisPatient.ViewModels
{
    public class ChatPageViewModel
    {
        public bool ShowScrollTap { get; set; } = false;
        public bool LastMessageVisible { get; set; } = true;
        public int PendingMessageCount { get; set; } = 0;
        public bool PendingMessageCountVisible { get { return PendingMessageCount > 0; } }

        public Queue<Message> DelayedMessages { get; set; } = new Queue<Message>();
        public ObservableCollection<Message> Messages { get; set; } = new ObservableCollection<Message>();
        public string TextToSend { get; set; }
        public ICommand OnSendCommand { get; set; }
        public ICommand MessageAppearingCommand { get; set; }
        public ICommand MessageDisappearingCommand { get; set; }

        public ChatPageViewModel()
        {
            //DependencyService.Get<IToolbarItemBadgeService>().SetBadge(this, ToolbarItems.First(), "2", Color.Red, Color.White);
            #region messages
            Messages.Insert(0, new Message() { Text = "Hi im Serapis how can i help you?" });
            Messages.Insert(0, new Message() { Text = "i would like to reorder my prescription?", User = App.User });
            Messages.Insert(0, new Message() { Text = "okay i will check for you" });
            Messages.Insert(0, new Message() { Text = "I See your currently subscribed to Metformin and Thiazolidinediones, for your Diabetes condition)" });
            Messages.Insert(0, new Message() { Text = "I have currently added two items to your basket anything else?" });
            Messages.Insert(0, new Message() { Text = "No.", User = App.User });
            Messages.Insert(0, new Message() { Text = "but we see you ordered iburfan last week for your family, Dont you need another packet?" });
            Messages.Insert(0, new Message() { Text = "No.", User = App.User });
            Messages.Insert(0, new Message() { Text = "okay you may check out now, thank you" });
            #endregion
            MessageAppearingCommand = new Command<Message>(OnMessageAppearing);
            MessageDisappearingCommand = new Command<Message>(OnMessageDisappearing);

            OnSendCommand = new Command(() =>
            {
                if (!string.IsNullOrEmpty(TextToSend))
                {
                    Messages.Insert(0, new Message() { Text = TextToSend, User = App.User });
                    TextToSend = string.Empty;
                }

            });

            //Code to simulate reveing a new message procces
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                if (LastMessageVisible)
                {
                    Messages.Insert(0, new Message() { Text = "Hi im Serapis how can i help you?", User = "Mario" });
                }
                else
                {
                    DelayedMessages.Enqueue(new Message() { Text = "Hi im Serapis how can i help you?", User = "Mario" });
                    PendingMessageCount++;
                }
                return true;
            });
        }
        void OnMessageAppearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx <= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    while (DelayedMessages.Count > 0)
                    {
                        Messages.Insert(0, DelayedMessages.Dequeue());
                    }
                    ShowScrollTap = false;
                    LastMessageVisible = true;
                    PendingMessageCount = 0;
                });
            }
        }

        void OnMessageDisappearing(Message message)
        {
            var idx = Messages.IndexOf(message);
            if (idx >= 6)
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ShowScrollTap = true;
                    LastMessageVisible = false;
                });

            }
        }
    }
}
