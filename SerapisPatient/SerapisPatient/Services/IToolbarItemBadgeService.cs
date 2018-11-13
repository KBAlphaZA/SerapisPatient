using System;
using System.Collections.Generic;
using System.Text;
using SerapisPatient.ViewModels;
using Xamarin.Forms;

namespace SerapisPatient.Services
{
    public interface IToolbarItemBadgeService
    {
        void SetBadge(Page page, ToolbarItem item, string value, Color backgroundColor, Color textColor);
        void SetBadge(ChatPageViewModel chatPageViewModel, object p, string v, Color red, Color white);
    }
}
