using Microsoft.EntityFrameworkCore;
using OnlineShop.DB.Models;

namespace OnlineShop.DB.Context
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> Items { get; set; }
        public DbSet<FavoriteProduct> FavoriteProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            //Database.EnsureCreated(); //создаем базу данных при первом обращении

            Database.Migrate(); //миграция


            // если изменилась модель то надо в Package Manager Console добавить миграцию например командой --Add-Migration Initialization -context DatabaseContext--
            // где Initialization - имя миграции, DatabaseContext - имя контекста в рамках которой выполняется миграция. Сейчас контекст пока 1.
            //Add-Migration AddIdentityContext -context IdentityContext -OutputDir Migrations/Identity
            //--dotnet ef database update--context ConfigurationDbContext

            //dotnet ef migrations add InitConfigration -c Fully.Qualified.Namespaces.ConfigurationDbContext -o Migrations/Identity
            //dotnet ef migrations add InitialIdentityServerConfigurationDbMigration -c IdentityServer4.EntityFramework.DbContexts.ConfigurationDbContext -o /Migrations/Identity
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product
                {
                    Id = new Guid("7b8c9d0e-1f2a-3b4c-5d6e-7f8a9b0c1d2e"),
                    Name = "АКС-74",
                    Cost = 23500,
                    Description = "Автомат страйкбольный E&L АКС-74 ELS-74 MN Gen2",
                    ImageUrl = "/images/ak74.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-7172-aaf0-b596e6081587"),
                    Name = "CM.518",
                    Cost = 10000,
                    Description = "Страйкбольная штурмовая винтовка Cyma CM.518",
                    ImageUrl = "/images/cyma518.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-72ec-9252-758d4d5f3615"),
                    Name = "G36-C",
                    Cost = 9000,
                    Description = "Автомат страйкбольный G36-C Specna Arms SA-G12 EBB Tan",
                    ImageUrl = "/images/G36-C.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-7f5d-a449-36a22b72b3e8"),
                    Name = "Colt 1911",
                    Cost = 2500,
                    Description = "Пистолет страйкбольный Colt 1911 STTI Green Gas",
                    ImageUrl = "/images/1911.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-75ca-988a-60f3a98a9718"),
                    Name = "MP7",
                    Cost = 5000,
                    Description = "Пистолет-пулемет страйкбольный MP7 R4 WELL Plastic Body",
                    ImageUrl = "/images/mp7.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-7e5d-904c-e60e6f1a815d"),
                    Name = "РПК-74М",
                    Cost = 22000,
                    Description = "Пулемет страйкбольный РПК-74М CYMA CM.052А",
                    ImageUrl = "/images/rpk-74m.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-704e-9e8b-3a5f4c1d2e7a"),
                    Name = "Mauser C96",
                    Cost = 4000,
                    Description = "Пистолет страйкбольный WELL Mauser C96 CO2",
                    ImageUrl = "/images/c96.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-7a5f-8d3e-4c2b1a9d8e6f"),
                    Name = "M56DL",
                    Cost = 4500,
                    Description = "Дробовик EE M56DL Black",
                    ImageUrl = "/images/M56DL.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-7b6c-9e2d-3a4f5b6c7d8e"),
                    Name = "ГП-1",
                    Cost = 12000,
                    Description = "Подствольный гранатомет Pyrosoft ГП-1 ЗНИЧ",
                    ImageUrl = "/images/GP1.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-7c7d-8e3f-4b5a6d7e8f9a"),
                    Name = "Fenix AER-03",
                    Cost = 1200,
                    Description = "Выносная тактическая кнопка Fenix AER-03 v2.0",
                    ImageUrl = "/images/aer.jpg"
                },
                new Product
                {
                    Id = new Guid("0198650b-ffda-7d8e-9f4a-5c6b7e8f9a1b"),
                    Name = "Г52Д",
                    Cost = 4500,
                    Description = "Гильза Г52Д для гранатомёта страйкбольного Pyrosof",
                    ImageUrl = "/images/G52D.jpg"
                }
            });
        }
    }
}

