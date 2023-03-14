using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.BLL
{
    public class BLLModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(MapperProfiles).Assembly;

            builder.RegisterAssemblyTypes(assembly)
                .Where(type => type.Name.EndsWith("AppService"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
