using Autofac;
using Autofac.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    public class FacContainerBuilder : IContainerBuilder
    {
        /// <summary>
        /// get current ContainerBuilder
        /// </summary>
        private static ContainerBuilder Current;

        /// <summary>
        /// get current ILifetimeScope
        /// </summary>
        private ILifetimeScope scope;

        /// <summary>
        /// return the current ILifetimeScope
        /// </summary>
        private ILifetimeScope Scope
        {
            get
            {
                if (scope == null) {scope=this.ContainerBuilder.Build().BeginLifetimeScope(); }
                return scope;
            }
        }

        /// <summary>
        /// return the current ContainerBuilder
        /// </summary>
        private ContainerBuilder ContainerBuilder
        {
            get
            {
                if (Current == null) { Current = new ContainerBuilder(); }
                return Current;
            }
        }

        /// <summary>
        /// this method is used for registering the type.
        /// </summary>
        /// <typeparam name="TImplementer">Implementer</typeparam>
        /// <typeparam name="ITImplementer">the Interface</typeparam>
        public void RegisterType<TImplementer, ITImplementer>() where TImplementer : class, new()
        {
            this.ContainerBuilder.RegisterType<TImplementer>().As<ITImplementer>();
        }
        
        /// <summary>
        /// registerType by Assembly
        /// </summary>
        /// <param name="assembly"></param>
        public void RegisterAssemblyTypes(Assembly[] assemblies)
        {
            this.ContainerBuilder.RegisterAssemblyTypes(assemblies).Where(k => k.Name.EndsWith("Repository")).AsImplementedInterfaces();
        }

        /// <summary>
        /// this method is used for Resolving the type that we want to get.
        /// </summary>
        /// <typeparam name="ITImplementer"></typeparam>
        /// <returns></returns>
        public ITImplementer Resolve<ITImplementer>() where ITImplementer : class
        {
            return this.Scope.Resolve<ITImplementer>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose()
        {
            this.Scope.Dispose();
        }
    }
}