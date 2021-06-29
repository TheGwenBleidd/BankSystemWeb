using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BankApplication
{
    public partial class banksystemdbContext : DbContext
    {
        public banksystemdbContext()
        {
        }

        public banksystemdbContext(DbContextOptions<banksystemdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Bankclient> Bankclients { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseMySql("server=localhost;user=root;password=521473698Kz;database=banksystemdb", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.25-mysql"));
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("accounts");

                entity.HasIndex(e => e.BankClientIdKey, "IX_Accounts_BankClientIdKey");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccountNumber)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.BankClientIdKeyNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.BankClientIdKey)
                    .HasConstraintName("FK_Accounts_BankClients_BankClientIdKey");
            });

            modelBuilder.Entity<Bankclient>(entity =>
            {
                entity.ToTable("bankclients");

                entity.HasIndex(e => e.UniqueIdentityNumber, "AK_BankClients_UniqueIdentityNumber")
                    .IsUnique();

                entity.HasIndex(e => e.CityIdKey, "IX_BankClients_CityIdKey");

                entity.HasIndex(e => e.CountryIdKey, "IX_BankClients_CompanyIdKey");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.ClientBirthday).HasMaxLength(6);

                entity.Property(e => e.ClientFullName)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.UniqueIdentityNumber)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.HasOne(d => d.CityIdKeyNavigation)
                    .WithMany(p => p.Bankclients)
                    .HasForeignKey(d => d.CityIdKey)
                    .HasConstraintName("FK_BankClients_Cities_CityIdKey");

                entity.HasOne(d => d.CountryIdKeyNavigation)
                    .WithMany(p => p.Bankclients)
                    .HasForeignKey(d => d.CountryIdKey)
                    .HasConstraintName("FK_BankClients_Countries_CountryIdKey");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("cities");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("transactions");

                entity.HasIndex(e => e.ClientReceiverAccountIdKey, "IX_Transactions_ClientReceiverAccountIdKey");

                entity.HasIndex(e => e.ClientReceiverIdKey, "IX_Transactions_ClientReceiverIdKey");

                entity.HasIndex(e => e.ClientSenderAccountIdKey, "IX_Transactions_ClientSenderAccountIdKey");

                entity.HasIndex(e => e.ClientSenderIdKey, "IX_Transactions_ClientSenderIdKey");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TransactionType).IsRequired();

                entity.HasOne(d => d.ClientReceiverAccountIdKeyNavigation)
                    .WithMany(p => p.TransactionClientReceiverAccountIdKeyNavigations)
                    .HasForeignKey(d => d.ClientReceiverAccountIdKey)
                    .HasConstraintName("FK_Transactions_Accounts_ClientReceiverAccountIdKey");

                entity.HasOne(d => d.ClientReceiverIdKeyNavigation)
                    .WithMany(p => p.TransactionClientReceiverIdKeyNavigations)
                    .HasForeignKey(d => d.ClientReceiverIdKey)
                    .HasConstraintName("FK_Transactions_BankClients_ClientReceiverIdKey");

                entity.HasOne(d => d.ClientSenderAccountIdKeyNavigation)
                    .WithMany(p => p.TransactionClientSenderAccountIdKeyNavigations)
                    .HasForeignKey(d => d.ClientSenderAccountIdKey)
                    .HasConstraintName("FK_Transactions_Accounts_ClientSenderAccountIdKey");

                entity.HasOne(d => d.ClientSenderIdKeyNavigation)
                    .WithMany(p => p.TransactionClientSenderIdKeyNavigations)
                    .HasForeignKey(d => d.ClientSenderIdKey)
                    .HasConstraintName("FK_Transactions_BankClients_ClientSenderIdKey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
