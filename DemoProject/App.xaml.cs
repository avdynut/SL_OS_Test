using System;
using System.Windows;

namespace DemoProject
{
    public partial class App : Application
    {

        public App()
        {
            Startup += Application_Startup;
            UnhandledException += Application_UnhandledException;

#if OPENSILVER
            System.Diagnostics.Trace.Listeners.Add(new System.Diagnostics.TextWriterTraceListener(Console.Out));
            System.Diagnostics.Trace.AutoFlush = true;

            Host.Settings.ProgressiveRenderingChunkSize = 10;
            //Host.Settings.PopupMoveDelay = TimeSpan.FromMilliseconds(200);
            //Host.Settings.EnableOptimizationWhereCollapsedControlsAreNotLoaded = true;
            //Host.Settings.EnableBindingErrorsLogging = true;
            //Host.Settings.EnableProgressiveRendering = true;
            //Host.Settings.EnablePerformanceLogging = true;
            //Host.Settings.EnableWebRequestsLogging = true;
            //Host.Settings.EnableInteropLogging = true;
            //Host.Settings.ScrollDebounce = TimeSpan.FromMilliseconds(300);
#endif

            InitializeComponent();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            RootVisual = new MainPage();
        }

        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            // If the app is running outside of the debugger then report the exception using
            // the browser's exception mechanism. On IE this will display it a yellow alert 
            // icon in the status bar and Firefox will display a script error.
            if (!System.Diagnostics.Debugger.IsAttached)
            {

                // NOTE: This will allow the application to continue running after an exception has been thrown
                // but not handled. 
                // For production applications this error handling should be replaced with something that will 
                // report the error to the website and stop the application.
                e.Handled = true;
                Deployment.Current.Dispatcher.BeginInvoke(delegate { ReportErrorToDOM(e); });
            }
        }

        private void ReportErrorToDOM(ApplicationUnhandledExceptionEventArgs e)
        {
            try
            {
                string errorMsg = e.ExceptionObject.Message + e.ExceptionObject.StackTrace;
                errorMsg = errorMsg.Replace('"', '\'').Replace("\r\n", @"\n");

                System.Windows.Browser.HtmlPage.Window.Eval("throw new Error(\"Unhandled Error in Silverlight Application " + errorMsg + "\");");
            }
            catch (Exception)
            {
            }
        }
    }
}
