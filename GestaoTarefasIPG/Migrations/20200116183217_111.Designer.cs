﻿// <auto-generated />
using GestaoTarefasIPG.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoTarefasIPG.Migrations
{
    [DbContext(typeof(IPGDbContext))]
    [Migration("20200116183217_111")]
    partial class _111
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GestaoTarefasIPG.Models.Departamento", b =>
                {
                    b.Property<int>("DepartamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeDepartamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(120)")
                        .HasMaxLength(120);

                    b.HasKey("DepartamentoId");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("GestaoTarefasIPG.Models.Escola", b =>
                {
                    b.Property<int>("EscolaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeEscola")
                        .IsRequired()
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(9)")
                        .HasMaxLength(9);

                    b.HasKey("EscolaId");

                    b.ToTable("Escola");
                });
#pragma warning restore 612, 618
        }
    }
}
