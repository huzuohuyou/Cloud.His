using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using Capinfo.EntityFrameworkCore.Seed.Host;
using Capinfo.EntityFrameworkCore.Seed.Tenants;
using Capinfo.EntityFrameworkCore.Seed.Patients;

namespace Capinfo.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<CapinfoDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(CapinfoDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context).Create();
            new DefaultPatientsCreator(context).Create();
            // Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
