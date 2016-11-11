namespace TaacTapTerminalApp.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderDetails> OrderDetailsSet { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<RestaurantInfo> RestaurantInfoes { get; set; }
        public virtual DbSet<RestaurantTable> RestaurantTables { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(true); 

            modelBuilder.Entity<OrderDetails>()
                .HasKey(e => new { e.OrderDetailsId });


            modelBuilder.Entity<Bill>()
                .Property(e => e.SubTotal)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bill>()
                .Property(e => e.TaxRate)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bill>()
                .Property(e => e.TipP)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Bill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bill>()
                .HasRequired(e => e.Order)
                .WithRequiredDependent();

            modelBuilder.Entity<Order>()
                .HasRequired(e => e.Bill)
                .WithRequiredPrincipal();

            modelBuilder.Entity<OrderDetails>()
                .HasRequired(e => e.Order)
                .WithRequiredPrincipal();

            modelBuilder.Entity<Menu>()
                .Property(e => e.MenuName)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.MenuItems)
                .WithRequired(e => e.Menu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuItem>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<MenuItem>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<MenuItem>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

      

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.Date);

            modelBuilder.Entity<Reservation>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurantInfo>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurantInfo>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurantInfo>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurantInfo>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<RestaurantInfo>()
                .HasMany(e => e.Menus)
                .WithRequired(e => e.RestaurantInfo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RestaurantTable>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.RestaurantTable)
                .HasForeignKey(e => e.TableId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RestaurantTable>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.RestaurantTable)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.AccountType)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
