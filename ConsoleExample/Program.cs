using Microsoft.Extensions.DependencyInjection;
using models;
using System;

namespace CustomIoC
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection collection = new ServiceCollection();

            //register services
            collection.AddScoped<ILog, ConsoleLog>();
            collection.AddTransient<ILogManager, LogManager>();
            collection.AddSingleton<IManagerContainer,ManagerContainer>();

            //get service
            using (ServiceProvider provider = collection.BuildServiceProvider()) {
                ILog log1 = provider.GetService<ILog>();
                ILog log2 = provider.GetService<ILog>();
                Console.WriteLine(log1 == log2);//true

                ILogManager logm1 = provider.GetService<ILogManager>();
                ILogManager logm2 = provider.GetService<ILogManager>();
                Console.WriteLine(logm1 == logm2); // false

                IManagerContainer logmc1 = provider.GetService<IManagerContainer>();
                IManagerContainer logmc2 = provider.GetService<IManagerContainer>();
                Console.WriteLine(logmc1 == logmc2); // true

                //scoped service lifetime related to a IServiceScope 
                //CreateScope() will create a new children scope, which is different with the default scope.
                using (var _ChildScope = provider.CreateScope()) {
                    ILog clog1 = _ChildScope.ServiceProvider.GetService<ILog>();
                    ILog clog2 = _ChildScope.ServiceProvider.GetService<ILog>();
                    Console.WriteLine(clog1 == clog2);//true
                    Console.WriteLine(clog1 == log1);//false
                    Console.WriteLine(clog2 == log2);//false


                    ILogManager clogm1 = _ChildScope.ServiceProvider.GetService<ILogManager>();
                    ILogManager clogm2 = _ChildScope.ServiceProvider.GetService<ILogManager>();
                    Console.WriteLine(clogm1 == clogm2); // false
                    Console.WriteLine(clogm1 == logm1); // false
                    Console.WriteLine(clogm2 == logm2); // false

                    IManagerContainer clogmc1 = _ChildScope.ServiceProvider.GetService<IManagerContainer>();
                    IManagerContainer clogmc2 = _ChildScope.ServiceProvider.GetService<IManagerContainer>();
                    Console.WriteLine(clogmc1 == clogmc2); // true
                    Console.WriteLine(clogmc1 == logmc1); // true
                    Console.WriteLine(clogmc1 == logmc2); // true
                }
            }
        }
    }
}
