using System;
using System.IO;

namespace Exceptions
{
    public class ExceptionGenerator
    {
        public void Generate()
        {
        }

        private void Run1() { Run2(); }
        private void Run2() { Run3(); }
        private void Run3()
        {
            try
            {
                Run4();
            }
            catch (ArgumentNullException ex)
            {
                throw new Exception("Что то пошло не так", ex);
            }
        }
        private void Run4() { Run5(); }
        private void Run5() { Run6(null); }
        private void Run6(string path) { File.ReadAllText(path); }
    }
}
