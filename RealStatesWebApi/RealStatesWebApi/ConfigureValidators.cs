//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;

//namespace WebAPI
//{
//    public class ConfigureValidator
//    {
//        /// <summary>
//        /// Register Repositories Assembly
//        /// </summary>
//        /// <param name="servicesCollection"></param>
//        public static void ConfigureValidators(IServiceCollection servicesCollection)
//        {
//            List<Type> repoAssemblyTypes = Assembly.Load("Models").ExportedTypes.Where(a => a.Name.ToLower().EndsWith("validator")).ToList();
//            //get service interfaces
//            List<Type> repoInterfaces = repoAssemblyTypes.Where(a => a.IsInterface).ToList();
//            //get service implementation
//            List<Type> repoImplementations = repoAssemblyTypes.Where(a => a.IsClass).ToList();
//            RegisterTypes(servicesCollection, repoInterfaces, repoImplementations);
//        }

//        /// <summary>
//        /// Register Types
//        /// </summary>
//        /// <param name="servicesCollection"></param>
//        /// <param name="interfaces"></param>
//        /// <param name="implementations"></param>
//        private static void RegisterTypes(IServiceCollection servicesCollection, List<Type> interfaces, List<Type> implementations)
//        {
//            foreach (Type interfaceType in interfaces)
//            {
//                Type serviceType = implementations.FirstOrDefault(imp => interfaceType.IsAssignableFrom(imp));
//                if (serviceType != null)
//                {
//                    servicesCollection.AddScoped(interfaceType, serviceType);
//                }
//            }
//        }
//    }
//}
