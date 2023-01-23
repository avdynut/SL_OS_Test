using DemoProject.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace DemoProject
{
    public partial class MainPage : UserControl
    {
        private readonly TestViewModel _viewModel = new TestViewModel();

        public MainPage()
        {
            InitializeComponent();
            DataContext = _viewModel;

            var xaml = @"<Grid xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation' xmlns:input='clr-namespace:SLExtensions.Input;assembly=SLExtensions' >    <Grid.ColumnDefinitions>        <ColumnDefinition Width='Auto' />        <ColumnDefinition Width='Auto' />        <ColumnDefinition Width='*' />        <ColumnDefinition Width='Auto' />        <ColumnDefinition Width='Auto' />        <ColumnDefinition Width='Auto' />    </Grid.ColumnDefinitions>    <Grid.RowDefinitions>        <RowDefinition Height='Auto' />    </Grid.RowDefinitions>    <TextBlock Text='Station' Style='{StaticResource FieldNameTextBlock}'/>    <TextBlock Grid.Column='1' Text='Reference' Style='{StaticResource FieldNameTextBlock}'/>    <TextBlock Grid.Column='2' Text='Description' Style='{StaticResource FieldNameTextBlock}'/>    <TextBlock Grid.Column='3' Text='Q' Style='{StaticResource FieldNameTextBlock}'/>    <TextBlock Grid.Column='4' Text='Measures' Style='{StaticResource FieldNameTextBlock}'/>    <TextBlock Grid.Column='5' Text='S1' Style='{StaticResource FieldNameTextBlock}'/></Grid>";

            try
            {
                var content = (UIElement)XamlReader.Load(xaml);
                Grid.SetRow(content, 1);
                LayoutRoot.Children.Add(content);
            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
