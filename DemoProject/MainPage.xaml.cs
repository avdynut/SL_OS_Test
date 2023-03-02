using DemoProject.ViewModels;
using System.Windows.Controls;
using System.Windows.Media;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;

#if OPENSILVER
            svgEllipse.UseSvgRenderer = true;
            svgLine.UseSvgRenderer = true;
            svgPolyline.UseSvgRenderer = true;
            svgPolygon.UseSvgRenderer = true;
            svgRectangle.UseSvgRenderer = true;
            svgPath.UseSvgRenderer = true;
#endif
        }
    }
}
