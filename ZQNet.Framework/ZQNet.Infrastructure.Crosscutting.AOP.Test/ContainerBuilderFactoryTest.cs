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

           var dllFiles=Directory.GetFiles("\\","*.dll",SearchOption.TopDirectoryOnly);

           var AllAssemblies =BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();

            //var assmblies = Assembly.("bin");

            factory.ContainerBuilder.RegisterAssemblyTypes(AllAssemblies);

            ILogger log=factory.ContainerBuilder.Resolve<ILogger>();

            factory.ContainerBuilder.Dispose();

            var str=log.writer();
        }
    }
}