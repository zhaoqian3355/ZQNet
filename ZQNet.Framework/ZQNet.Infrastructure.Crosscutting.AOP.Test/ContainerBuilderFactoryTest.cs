using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Compilation;
using ZQNet.Infrastructure.Crosscutting.AOP.Ioc;
using ZQNet.Infrastructure.Crosscutting.AOP.Test.ITImplementer;
using ZQNet.Infrastructure.Crosscutting.AOP.Test.TImplementer;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Test
{
    [TestClass]
    public class ContainerBuilderFactoryTest
    {
        [TestMethod]
        public void DefaultIsEmpty()
        {
            var factory = new ContainerBuilderFactory();

            factory.ContainerBuilder.RegisterType<ConsoleLogger, ILogger>();

            factory.ContainerBuilder.RegisterAssemblyTypes(k => k.Name.EndsWith("Repository") || k.Name.EndsWith("Record"));

            var repository=factory.ContainerBuilder.Resolve<ITestRepository>();

            var record = factory.ContainerBuilder.Resolve<ITestRecord>();

            Console.WriteLine(repository.Write());
            Console.WriteLine(record.write());

            ILogger log=factory.ContainerBuilder.Resolve<ILogger>();

            factory.ContainerBuilder.Dispose();

            var str=log.writer();
        }

        [TestMethod]
        public void GetData()
        {
            var dir = AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}