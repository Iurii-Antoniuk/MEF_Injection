using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF_Injection
{
    class Program
    {
        private MefHost _host;

        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();

            Console.ReadKey();
        }

        private void Run()
        {
            _host = new MefHost();
            HelloSayer service = _host.Container.GetExportedValue<HelloSayer>();
            service.SayHello();

        }
    }

    internal class MefHost
    {
        private CompositionContainer _container = null;
        public CompositionContainer Container
        {
            get
            {
                if (_container == null)
                {
                    var catalog = new DirectoryCatalog(".", "MEF_Injection.*");
                    _container = new CompositionContainer(catalog);
                }
                return _container;
            }
        }

    }

    [Export]
    internal class HelloSayer
    {
        public void SayHello()
        {
            Console.WriteLine("Bonjour ! Yob ty!");
        }
    }
}