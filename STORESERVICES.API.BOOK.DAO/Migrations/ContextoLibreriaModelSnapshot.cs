﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using STORESERVICES.API.BOOK.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.BOOK.DAO.Migrations
{
    [DbContext(typeof(ContextoLibreria))]
    partial class ContextoLibreriaModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TiendaServicios.Api.Libro.Modelo.LibreriaMaterial", b =>
            {
                b.Property<Guid?>("LibreriaMaterialId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid?>("AutorLibro")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime?>("FechaPublicacion")
                    .HasColumnType("datetime2");

                b.Property<string>("Titulo")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("LibreriaMaterialId");

                b.ToTable("LibreriaMaterial");
            });
#pragma warning restore 612, 618
        }
    }
}
