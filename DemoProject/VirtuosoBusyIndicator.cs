using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Virtuoso.Core.Controls
{
    public class VirtuosoBusyIndicator : BusyIndicator
    {
        private Storyboard sb;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            sb = (Storyboard)GetTemplateChild("BusyAnimation");
            sb.Completed += Sb_Completed;
            SetBusyAnimationStoryboardFromIsBusy();
        }

        private void Sb_Completed(object sender, System.EventArgs e)
        {
            Debug.WriteLine("Completed");
        }

        protected override void OnIsBusyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnIsBusyChanged(e);
            SetBusyAnimationStoryboardFromIsBusy();
        }
        private void SetBusyAnimationStoryboardFromIsBusy()
        {
            if (IsBusy)
                sb.Begin();
            else
                sb.Stop();
        }
    }
}
