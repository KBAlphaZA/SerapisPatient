﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisPatient.Views.NotificationViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationBoardExpanded : PopupPage
    {
        public NotificationBoardExpanded()
        {
            InitializeComponent();
        }
    }
}