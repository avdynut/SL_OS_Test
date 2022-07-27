using DemoProject;
using OpenSilver.Simulator;
using System;

namespace SL_OS_Test.Simulator
{
    internal static class Startup
    {
        [STAThread]
        static int Main(string[] args)
        {
            return SimulatorLauncher.Start(typeof(App));
        }
    }
}
