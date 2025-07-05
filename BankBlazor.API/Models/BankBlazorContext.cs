using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BankBlazor.API.Models;

public partial class BankBlazorContext : DbContext
{
    public BankBlazorContext()
    {
    }

    public BankBlazorContext(DbContextOptions<BankBlazorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Card> Cards { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Disposition> Dispositions { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<PermenentOrder> PermenentOrders { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.;Database=BankAppData;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK_account");
        });

        modelBuilder.Entity<Card>(entity =>
        {
            entity.HasOne(d => d.Disposition).WithMany(p => p.Cards)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cards_Dispositions");
        });

        modelBuilder.Entity<Disposition>(entity =>
        {
            entity.HasKey(e => e.DispositionId).HasName("PK_disposition");

            entity.HasOne(d => d.Account).WithMany(p => p.Dispositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dispositions_Accounts");

            entity.HasOne(d => d.Customer).WithMany(p => p.Dispositions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dispositions_Customers");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK_loan");

            entity.HasOne(d => d.Account).WithMany(p => p.Loans)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Loans_Accounts");
        });

        modelBuilder.Entity<PermenentOrder>(entity =>
        {
            entity.HasOne(d => d.Account).WithMany(p => p.PermenentOrders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PermenentOrder_Accounts");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK_trans2");

            entity.HasOne(d => d.AccountNavigation).WithMany(p => p.Transactions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Transactions_Accounts");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK_User_UserID");

            entity.Property(e => e.PasswordHash).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
