using Autofac;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ZQNet.Infrastructure.Crosscutting.AOP.Ioc
{
    internal class FacContainerBuilder : IContainerBuilder
    {
        private static List<string> files;
        private static List<Assembly> assemblies;
        private static string dir = AppDomain.CurrentDomain.BaseDirectory;

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
        public void RegisterAssemblyTypes(Func<Type, bool> where)
        {
            if (files == null||files.Count<=0)
            {
                files = Directory.GetFiles(dir, "*.dll", SearchOption.TopDirectoryOnly).ToList();
            }

            if (assemblies == null || assemblies.Count <= 0)
            {
                assemblies = new List<Assembly>();
                files.ForEach(k =>
                {
                    assemblies.Add(Assembly.LoadFile(k));
                });
            }

            this.ContainerBuilder.RegisterAssemblyTypes(assemblies.ToArray()).Where(where).AsImplementedInterfaces();
        }

        /// <summary>
        /// this method is for registering the mvc controllers.
        /// </summary>
        /// <param name="mvcApplication">the type of MvcApplication</param>
        public void RegisterControllers(Type mvcApplication)
        {
            this.ContainerBuilder.RegisterControllers(mvcApplication.Assembly);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TImplementer"></typeparam>
        /// <param name="implementer"></param>
        public void RegisterModule<TImplementer>(TImplementer implementer) where TImplementer : ModuleBase
        {
            this.ContainerBuilder.RegisterModule(implementer);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RegisterModelBinders()
        {
            this.ContainerBuilder.RegisterModelBinders(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// 
        /// </summary>
        public void RegisterFilterProvider()
        {
            this.ContainerBuilder.RegisterFilterProvider();
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
        /// dispose the resource of using.
        /// </summary>
        public void Dispose()
        {
            this.Scope.Dispose();
        }
    }
}