using System.Diagnostics;

namespace DemoProject.ViewModels
{
    public class TestViewModel
    {
        private int _number = 1;

        public int TestProperty
        {
            get
            {
                Debug.WriteLine($"Call {_number}. {new StackTrace()}");
                return _number++;
            }
        }

        public TestViewModel()
        {
        }
    }
}
