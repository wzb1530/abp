﻿using Volo.Abp.EntityFrameworkCore;

namespace Microsoft.EntityFrameworkCore
{
    public static class AbpModelBuilderExtensions
    {
        private const string ModelDatabaseProviderAnnotationKey = "_Abp_DatabaseProvider";

        public static void SetDatabaseProvider(
            this ModelBuilder modelBuilder,
            EfCoreDatabaseProvider databaseProvider)
        {
            modelBuilder.Model.SetAnnotation(ModelDatabaseProviderAnnotationKey, databaseProvider);
        }

        public static void ClearDatabaseProvider(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.Model.RemoveAnnotation(ModelDatabaseProviderAnnotationKey);
        }

        public static EfCoreDatabaseProvider? GetDatabaseProvider(
            this ModelBuilder modelBuilder
        )
        {
            return (EfCoreDatabaseProvider?) modelBuilder.Model[ModelDatabaseProviderAnnotationKey];
        }
        
        public static void UseMySQL(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.MySql);
        }
        
        public static void UseOracle(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.Oracle);
        }
        
        public static void UseSqlServer(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.SqlServer);
        }
        
        public static void UsePostgreSql(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.PostgreSql);
        }
        
        public static void UseSqlite(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.Sqlite);
        }
        
        public static void UseInMemory(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.InMemory);
        }
        
        public static void UseCosmos(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.Cosmos);
        }
        
        public static void UseFirebird(
            this ModelBuilder modelBuilder)
        {
            modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.Firebird);
        }
    }
}