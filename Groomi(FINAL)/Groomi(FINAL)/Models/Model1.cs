namespace Groomi_FINAL_.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Enquiry> Enquiries { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<GroomingTool> GroomingTools { get; set; }
        public virtual DbSet<ShampooandConditioner> ShampooandConditioners { get; set; }
        public virtual DbSet<Toy> Toys { get; set; }
        public virtual DbSet<TreatsandBiscuit> TreatsandBiscuits { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .Property(e => e.NRIC)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Booking>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Enquiry>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Enquiry>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Enquiry>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Food>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Food>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<GroomingTool>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<GroomingTool>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<GroomingTool>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<GroomingTool>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<ShampooandConditioner>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ShampooandConditioner>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ShampooandConditioner>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ShampooandConditioner>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<Toy>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Toy>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Toy>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Toy>()
                .Property(e => e.Logo)
                .IsUnicode(false);

            modelBuilder.Entity<TreatsandBiscuit>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<TreatsandBiscuit>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<TreatsandBiscuit>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TreatsandBiscuit>()
                .Property(e => e.Logo)
                .IsUnicode(false);
        }
    }
}
