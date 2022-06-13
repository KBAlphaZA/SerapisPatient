using Xamarin.Forms;

namespace SerapisPatient.Controls.Triggers
{
    public class CustomButtonPressScaleAction : TriggerAction<VisualElement>
    {
        public double Scale { get; set; }

        public int Duration { get; set; }

        public CustomButtonPressScaleAction()
        {
            Scale = 2;
            Duration = 1000;
        }

        protected override async void Invoke(VisualElement sender)
        {
            await sender.ScaleTo(Scale, (uint)Duration / 2, Easing.SinOut);
            await sender.ScaleTo(Scale, (uint)Duration / 2, Easing.SinIn);
        }
    }
}
