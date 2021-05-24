using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LisBank.Infrastructure.Data
{
    public partial class LisBankContext : DbContext
    {
        public LisBankContext()
        {
        }

        public LisBankContext(DbContextOptions<LisBankContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Authentication> Authentications { get; set; }
        public virtual DbSet<BranchOffice> BranchOffices { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<CreditAccount> CreditAccounts { get; set; }
        public virtual DbSet<DebitAccount> DebitAccounts { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<OriginBranchOffice> OriginBranchOffices { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=LisBank;User id=sa;Password=Password_0");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Clabe)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CLABE");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Client");
            });

            modelBuilder.Entity<Authentication>(entity =>
            {
                entity.ToTable("Authentication");

                entity.Property(e => e.Device)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastLogin).HasColumnType("date");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BranchOffice>(entity =>
            {
                entity.ToTable("BranchOffice");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.BranchOffice)
                    .HasForeignKey<BranchOffice>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BranchOffice_Origin");
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("Card");

                entity.Property(e => e.Cvv)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CVV");

                entity.Property(e => e.DueDate)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nip).HasColumnName("NIP");

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Cards)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Card_Account");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Client");

                entity.Property(e => e.A)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoClient)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProofIncome)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAuthenticationNavigation)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.IdAuthentication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Client_Authentication");
            });

            modelBuilder.Entity<CreditAccount>(entity =>
            {
                entity.ToTable("CreditAccount");

                entity.Property(e => e.ClosingDate).HasColumnType("date");

                entity.Property(e => e.PaymentdueDate).HasColumnType("date");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.CreditAccounts)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditAccount_Account");
            });

            modelBuilder.Entity<DebitAccount>(entity =>
            {
                entity.ToTable("DebitAccount");

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.DebitAccounts)
                    .HasForeignKey(d => d.IdAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebitAccount_Account");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.ToTable("Device");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Ip)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.OperatingSystem)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Device)
                    .HasForeignKey<Device>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_Origin");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NoPersonal)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImage)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAuthenticationNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdAuthentication)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Authentication");

                entity.HasOne(d => d.IdBranchOfficeNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdBranchOffice)
                    .HasConstraintName("FK_Employee_BranchOffice");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Role");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("Origin");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OriginBranchOffice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("OriginBranchOffice");

                entity.HasOne(d => d.IdOriginNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOrigin)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OriginBranchOffice_Origin");

                entity.HasOne(d => d.IdOriginBranchOfficeNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdOriginBranchOffice)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OriginBranchOffice_BranchOffice");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.Cycle).HasColumnType("date");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.HasOne(d => d.IdCreditAccountNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdCreditAccount)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payment_CreditAccount");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Table)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Permissions)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_Role");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Responsibility)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Schedule)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Role)
                    .HasForeignKey<Role>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Role_Employee");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.Concept)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.NoTransaction)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.IdAccount)
                    .HasConstraintName("FK_Transaction_Account");

                entity.HasOne(d => d.IdOriginNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.IdOrigin)
                    .HasConstraintName("FK_Transaction_Origin");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
