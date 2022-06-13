using Xamarin.Forms;

namespace SerapisPatient.Controls.Triggers
{
    public class ExpandFrameTriggerAction : TriggerAction<Frame>
    {
        protected async override void Invoke(Frame frame)
        {
            await frame.ScaleTo(0.95, 50, Easing.CubicInOut);
            await frame.ScaleTo(1.1, 50, Easing.CubicIn); // change 1.1 => 1
        }
    }
}
