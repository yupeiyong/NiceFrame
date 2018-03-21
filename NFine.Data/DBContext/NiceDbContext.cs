using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using NFine.Domain;


namespace Nice.Data.DBContext
{
    public class NiceDbContext : DbContext
    {
        public NiceDbContext()
            : base("NiceDbContext")
        {
            //this.Configuration.AutoDetectChangesEnabled = false;
            //this.Configuration.ValidateOnSaveEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;

            Configuration.ProxyCreationEnabled = true;
            Configuration.AutoDetectChangesEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.EnsureTransactionsForFunctionsAndCommands = false;
            Configuration.UseDatabaseNullSemantics = true;
            Configuration.ValidateOnSaveEnabled = true;

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<NiceDbContext, Configuration>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            modelBuilder.Conventions.Add(new DecimalPropertyConvention(18, 8));
            
            var modelTypes = new List<Type>();
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                try
                {
                    var types = assembly.GetTypes().Where(t => t.IsClass && t.IsPublic && !t.IsAbstract && (!t.IsNested && !t.IsGenericType) && t.GetInterfaces()
                    .Any(m => m.GetGenericTypeDefinition() == typeof(IEntity<>)));
                    modelTypes.AddRange(types);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            //获取映射模型
            var mapTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>)).ToList();
            mapTypes.ForEach(t =>
            {
                dynamic instance = Activator.CreateInstance(t);
                modelBuilder.Configurations.Add(instance);
            });

            modelTypes.ForEach(modelBuilder.RegisterEntityType);


            //string assembleFileName = Assembly.GetExecutingAssembly().CodeBase.Replace("NFine.Data.DLL", "NFine.Mapping.DLL").Replace("file:///", "");
            //Assembly asm = Assembly.LoadFile(assembleFileName);
            //var typesToRegister = asm.GetTypes()
            //.Where(type => !String.IsNullOrEmpty(type.Namespace))
            //.Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}

            base.OnModelCreating(modelBuilder);
        }
    }
}
