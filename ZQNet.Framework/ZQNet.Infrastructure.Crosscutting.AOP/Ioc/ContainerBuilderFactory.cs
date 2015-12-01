using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    public class ContainerBuilderFactory : IContainerBuilderFactory
    {
        public IContainerBuilder containerBuilder
        {
            get;set;
        }

        public void CreateContainerBuilder()
        {
            this.containerBuilder = new ContainerBuilder1();
        }
    }
}
