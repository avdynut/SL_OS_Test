using System;

namespace Virtuoso.Maintenance.Controls
{
    public partial class PatientDetailUserControl : PatientDetailUserControlBase
    {
        public PatientDetailUserControl()
        {
            InitializeComponent();
            //this.ItemSelected += new EventHandler(UserControl_ItemSelected);
            //CustomLayout = true;
        }

        void UserControl_ItemSelected(object sender, EventArgs e)
        {
            //this.DetailAreaScrollViewer.ScrollToVerticalOffset(0);
        }

        //public override void Cleanup()
        //{
        //    base.Cleanup();
        //    this.ItemSelected -= UserControl_ItemSelected;
        //}
    }
}