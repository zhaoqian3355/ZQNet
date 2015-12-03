using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    public class ContainerBuilderFactory : IContainerBuilderFactory
    {
        private static IContainerBuilder containerBuilder;

        public IContainerBuilder ContainerBuilder
        {
            get
            {
                if (containerBuilder == null)
                {
                    containerBuilder= new FacContainerBuilder();
                }

                return containerBuilder;
            }
        }
    }
}