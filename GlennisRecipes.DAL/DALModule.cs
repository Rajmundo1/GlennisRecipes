using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlennisRecipes.DAL
{
    public class DALModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ApplicationDbContext).Assembly;
            builder.RegisterAssemblyTypes(assembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
