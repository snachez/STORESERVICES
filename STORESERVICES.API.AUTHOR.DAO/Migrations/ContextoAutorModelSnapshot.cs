﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using STORESERVICES.API.AUTHOR.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.AUTHOR.DAO.Migrations
{
    [DbContext(typeof(ContextoAutor))]
    partial class ContextoAutorModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("TiendaServicios.Api.Autor.Modelo.AutorLibro", b =>
            {
                b.Property<int>("AutorLibroId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                b.Property<string>("Apellido")
                    .HasColumnType("text");

                b.Property<string>("AutorLibroGuid")
                    .HasColumnType("text");

                b.Property<DateTime?>("FechaNacimiento")
                    .HasColumnType("timestamp without time zone");

                b.Property<string>("Nombre")
                    .HasColumnType("text");

                b.HasKey("AutorLibroId");

                b.ToTable("AutorLibro");
            });

            modelBuilder.Entity("TiendaServicios.Api.Autor.Modelo.GradoAcademico", b =>
            {
                b.Property<int>("GradoAcademicoId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("integer")
                    .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                b.Property<int>("AutorLibroId")
                    .HasColumnType("integer");

                b.Property<string>("CentroAcademico")
                    .HasColumnType("text");

                b.Property<DateTime?>("FechaGrado")
                    .HasColumnType("timestamp without time zone");

                b.Property<string>("GradoAcademicoGuid")
                    .HasColumnType("text");

                b.Property<string>("Nombre")
                    .HasColumnType("text");

                b.HasKey("GradoAcademicoId");

                b.HasIndex("AutorLibroId");

                b.ToTable("GradoAcademico");
            });

            modelBuilder.Entity("TiendaServicios.Api.Autor.Modelo.GradoAcademico", b =>
            {
                b.HasOne("TiendaServicios.Api.Autor.Modelo.AutorLibro", "AutorLibro")
                    .WithMany("ListaGradoAcademico")
                    .HasForeignKey("AutorLibroId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
