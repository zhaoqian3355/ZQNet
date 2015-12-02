using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    public class FacContainerBuilder:IContainerBuilder
    {
        public void aa()
        {
            var a = new ContainerBuilder();
        }
    }
}