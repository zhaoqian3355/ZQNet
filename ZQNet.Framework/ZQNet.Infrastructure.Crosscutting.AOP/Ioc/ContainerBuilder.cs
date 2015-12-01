using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    public class ContainerBuilder1:IContainerBuilder
    {
        public void aa()
        {
            var a = new ContainerBuilder();
        }
    }
}
