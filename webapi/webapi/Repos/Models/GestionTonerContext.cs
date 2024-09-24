using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace webapi.Repos.Models;

public partial class GestionTonerContext : DbContext
{
    public GestionTonerContext()
    {
    }

    public GestionTonerContext(DbContextOptions<GestionTonerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BaseToner> BaseToners { get; set; }

    public virtual DbSet<EtatStock> EtatStocks { get; set; }

    public virtual DbSet<Mouvement> Mouvements { get; set; }

    public virtual DbSet<TblRefreshtoken> TblRefreshtokens { get; set; }

    public virtual DbSet<User> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseToner>(entity =>
        {
            entity.HasKey(e => e.IdTonner);

            entity.ToTable("Base_Toner", tb => tb.HasTrigger("TR_Base_Toner_INSERT"));

            entity.Property(e => e.IdTonner).HasColumnName("ID_Tonner");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EtatStock>(entity =>
        {
            entity.HasKey(e => e.IdEtat).HasName("PK_Etat_stock_1");

            entity.ToTable("Etat_stock", tb => tb.HasTrigger("TR_EtatStock_UPDATE"));

            entity.Property(e => e.IdEtat).HasColumnName("ID_Etat");
            entity.Property(e => e.ReferenceId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Reference_id");
            entity.Property(e => e.SommeEntree).HasColumnName("Somme_Entree");
            entity.Property(e => e.SommeSortie).HasColumnName("Somme_Sortie");
            entity.Property(e => e.StockFinal).HasColumnName("Stock_Final");
        });

        modelBuilder.Entity<Mouvement>(entity =>
        {
            entity.HasKey(e => e.IdMouvement);

            entity.ToTable("Mouvement", tb => tb.HasTrigger("RollBackDelete"));

            entity.Property(e => e.IdMouvement).HasColumnName("ID_Mouvement");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Entree).HasColumnName("entree");
            entity.Property(e => e.Reference)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("reference");
            entity.Property(e => e.Sortie).HasColumnName("sortie");
        });

        modelBuilder.Entity<TblRefreshtoken>(entity =>
        {
            entity.HasKey(e => e.Userid);

            entity.ToTable("tbl_refreshtoken");

            entity.Property(e => e.Userid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("userid");
            entity.Property(e => e.Refreshtoken)
                .IsUnicode(false)
                .HasColumnName("refreshtoken");
            entity.Property(e => e.Tokenid)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tokenid");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Departement)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ReferenceToner)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Reference_toner");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Utilisateur)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
