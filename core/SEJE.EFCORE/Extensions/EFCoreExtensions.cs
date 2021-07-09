using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SEJE.CORE.Abstractions;
using SEJE.CORE.Model.Pager;
using SEJE.EFCORE.Middleware;
using SEJE.EFCORE.Options;
using SEJE.EFCORE.Repository;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SEJE.EFCORE.Extensions
{
    public static class EFCoreExtensions
    {

        public static void ConfigurationBase<TKey, TUserKey, TEntity>(this EntityTypeBuilder<TEntity> builder, bool userRequired = true, int maxLenghtUser = 256)
            where TEntity : class, IEntityBase<TKey, TUserKey>
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedById).HasMaxLength(maxLenghtUser).IsRequired(userRequired);
            builder.Property(x => x.CreationDate).IsRequired();
            builder.Property(x => x.ModifiedById).HasMaxLength(maxLenghtUser).IsRequired(userRequired);
            builder.Property(x => x.ModificationDate).IsRequired();
            builder.Property(x => x.Removed).IsRequired();
        }

        public static async Task<Pager<TEntity>> ToPageAsync<TEntity>(this IQueryable<TEntity> query, int currentPage, int pageSize)
            where TEntity : class, IEntityBase
        {
            if (currentPage < 1 || pageSize < 1)
                return default;

            var totalItems = await query.CountAsync();

            var skip = (currentPage - 1) * pageSize;

            var data = await query.Skip(skip).Take(pageSize).ToListAsync();

            return new Pager<TEntity>(totalItems, data, currentPage, pageSize);
        }

        public static void AddRepositories<TKey, TUserKey, TContext>(this IServiceCollection services)
           where TContext : DbContext
        {
            var assembly = typeof(TContext).GetTypeInfo().Assembly;

            var @types = assembly.GetTypes().Where(x => !x.IsNested && !x.IsInterface && typeof(IRepositoryBase<TKey, TUserKey>).IsAssignableFrom(x));

            foreach (var type in @types)
            {
                var @interface = type.GetInterface($"I{type.Name}", false);

                services.AddTransient(@interface, type);
            }
        }

        public static IServiceCollection AddEFCore(this IServiceCollection services, IConfiguration configuration, string section = "EFCore")
        {
            services.AddOptions();

            services.Configure<EFCoreOption>(configuration.GetSection(section));

            return services;
        }

        public static IServiceCollection AddIdentityService<TKeyUser>(this IServiceCollection services)
        {
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthenticateUser<TKeyUser>, AuthenticateUser<TKeyUser>>();
            services.AddScoped<IIdentityService<TKeyUser>, IdentityService<TKeyUser>>();

            return services;
        }

        public static IApplicationBuilder UseIdentityService<TKeyUser>(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<IdentityServiceMiddleware<TKeyUser>>();
        }

        public static void RegisterEntityConfigurations<TContext>(this ModelBuilder builder)
            where TContext : DbContext
        {
            var assembly = typeof(TContext).GetTypeInfo().Assembly;

            var entityConfigurationTypes = assembly.GetTypes().Where(x => IsEntityTypeConfiguration(x));

            var entityMethod = builder.GetMethodEntity();

            foreach (var entityConfigurationType in entityConfigurationTypes)
            {
                var genericTypeArgument = entityConfigurationType.GetInterfaces().Single().GenericTypeArguments.Single();

                var genericEntityMethod = entityMethod.MakeGenericMethod(genericTypeArgument);

                var entityTypeBuilder = genericEntityMethod.Invoke(builder, null);

                var instance = Activator.CreateInstance(entityConfigurationType);

                instance.GetType().GetMethod(nameof(IEntityTypeConfiguration<object>.Configure)).Invoke(instance, new[] { entityTypeBuilder });
            }
        }

        private static MethodInfo GetMethodEntity(this ModelBuilder builder)
        {
            return builder.GetType().GetMethods().Single(x => x.IsGenericMethod && x.Name == nameof(ModelBuilder.Entity) && x.ReturnType.Name == "EntityTypeBuilder`1");
        }

        private static bool IsEntityTypeConfiguration(Type type)
        {
            return type.GetInterfaces().Any(x => x.GetTypeInfo().IsGenericType && x.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
        }

    }
}
