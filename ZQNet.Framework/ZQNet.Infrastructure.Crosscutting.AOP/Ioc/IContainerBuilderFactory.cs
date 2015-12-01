using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    public interface IContainerBuilderFactory
    {
        IContainerBuilder containerBuilder { get; set; }

        void CreateContainerBuilder();
    }
}
