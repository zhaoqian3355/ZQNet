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

        void RegisterControllers(Type mvcApplication);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TImplementer"></typeparam>
        /// <param name="implementer"></param>
        void RegisterModule<TImplementer>(TImplementer implementer) where TImplementer : ModuleBase;

        /// <summary>
        /// 
        /// </summary>
        void RegisterModelBinders();

        /// <summary>
        /// 
        /// </summary>
        void RegisterFilterProvider();

        ITImplementer Resolve<ITImplementer>() where ITImplementer : class;

        void Dispose();
    }
}