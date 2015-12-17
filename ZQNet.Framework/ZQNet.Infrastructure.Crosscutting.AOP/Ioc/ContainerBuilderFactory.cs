using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    public class ContainerBuilderFactory : IContainerBuilderFactory
    {
        public readonly static IContainerBuilder containerBuilder=new FacContainerBuilder();

        public IContainerBuilder ContainerBuilder
        {
            get
            {
                return containerBuilder;
            }
        }
    }
}