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
            svgEllipse.RenderUsingSvg = true;
            svgLine.RenderUsingSvg = true;
            svgPolyline.RenderUsingSvg = true;
            svgPolygon.RenderUsingSvg = true;
            svgRectangle.RenderUsingSvg = true;
            svgPath.RenderUsingSvg = true;
#endif
        }
    }
}
