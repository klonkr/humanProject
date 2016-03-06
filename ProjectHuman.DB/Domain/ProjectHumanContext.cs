using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectHuman.DB.Domain
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProjectHumanContext : DbContext
    {
        // Your context has been configured to use a 'ProjectHumanContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProjectHuman.DB.Domain.ProjectHumanContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProjectHumanContext' 
        // connection string in the application configuration file.
        public ProjectHumanContext()
            : base("name=ProjectHumanContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mammal>()
                .Property(m => m.Id);

            modelBuilder.Entity<Human>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Human");
            });


            modelBuilder.Entity<Pet>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("Pets");
            });

            modelBuilder.Entity<Human>()
                .HasMany(x => x.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("HumanId");
                    m.MapRightKey("FriendsWith");
                    m.ToTable("HumanFriends");
                });

            modelBuilder.Entity<Human>()
                .HasMany(x => x.Children)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("HumanId");
                    m.MapRightKey("Child");
                    m.ToTable("HumanChildren");
                });

        }

        //public virtual DbSet<Mammal> Mammals { get; set; }
        public virtual DbSet<Human> Humans { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<PetType> PetTypes { get; set; }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}