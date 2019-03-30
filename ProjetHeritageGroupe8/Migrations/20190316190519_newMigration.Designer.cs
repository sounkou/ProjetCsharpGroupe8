﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetHeritageGroupe8.Data;

namespace ProjetHeritageGroupe8.Migrations
{
    [DbContext(typeof(HeritageDbContext))]
    [Migration("20190316190519_newMigration")]
    partial class newMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Biens", b =>
                {
                    b.Property<int>("BiensID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("description");

                    b.HasKey("BiensID");

                    b.ToTable("Biens");
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Ecole", b =>
                {
                    b.Property<int>("EcoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RegleID");

                    b.Property<string>("description");

                    b.Property<string>("nom");

                    b.HasKey("EcoleID");

                    b.HasIndex("RegleID");

                    b.ToTable("Ecole");
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Heritage", b =>
                {
                    b.Property<int>("HeritageID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BiensID");

                    b.Property<DateTime>("DateDeces");

                    b.Property<DateTime>("DateHeritage");

                    b.Property<int>("EcoleID");

                    b.Property<string>("description");

                    b.Property<float>("montant");

                    b.HasKey("HeritageID");

                    b.HasIndex("BiensID");

                    b.HasIndex("EcoleID");

                    b.ToTable("Heritage");
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Heritier", b =>
                {
                    b.Property<int>("HeritierID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("code");

                    b.Property<string>("description");

                    b.Property<string>("illustration");

                    b.HasKey("HeritierID");

                    b.ToTable("Heritier");
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Regle", b =>
                {
                    b.Property<int>("RegleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SourceID");

                    b.Property<string>("commentaire");

                    b.Property<string>("description");

                    b.HasKey("RegleID");

                    b.HasIndex("SourceID");

                    b.ToTable("Regle");
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Source", b =>
                {
                    b.Property<int>("SourceID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("commentaire");

                    b.Property<string>("designation");

                    b.HasKey("SourceID");

                    b.ToTable("Source");
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Utilisateur", b =>
                {
                    b.Property<int>("UtilisateurID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("email");

                    b.Property<string>("nom");

                    b.Property<string>("passWord");

                    b.Property<string>("prenom");

                    b.Property<int>("typeUtilisateur");

                    b.HasKey("UtilisateurID");

                    b.ToTable("Utilisateur");
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Ecole", b =>
                {
                    b.HasOne("ProjetHeritageGroupe8.Models.Regle", "Regles")
                        .WithMany("ecoles")
                        .HasForeignKey("RegleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Heritage", b =>
                {
                    b.HasOne("ProjetHeritageGroupe8.Models.Biens", "Biens")
                        .WithMany("heritages")
                        .HasForeignKey("BiensID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetHeritageGroupe8.Models.Ecole", "Ecole")
                        .WithMany("heritages")
                        .HasForeignKey("EcoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetHeritageGroupe8.Models.Regle", b =>
                {
                    b.HasOne("ProjetHeritageGroupe8.Models.Source")
                        .WithMany("regles")
                        .HasForeignKey("SourceID");
                });
#pragma warning restore 612, 618
        }
    }
}
