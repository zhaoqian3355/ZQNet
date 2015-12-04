using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    public interface IContainerBuilder
    {
        void RegisterType<TImplementer, ITImplementer>()where TImplementer : class,new();

        void RegisterAssemblyTypes(Func<Type,bool> where);

        ITImplementer Resolve<ITImplementer>() where ITImplementer : class;

        void Dispose();

    }
}