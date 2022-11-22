﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using STORESERVICES.API.SHOPPINGCART.DAO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STORESERVICES.API.SHOPPINGCART.DAO.Migrations
{
    [DbContext(typeof(CarritoContexto))]
    [Migration("20200707051547_MigrationMySqlInicial")]
    partial class MigrationMySqlInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesion", b =>
            {
                b.Property<int>("CarritoSesionId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<DateTime?>("FechaCreacion")
                    .HasColumnType("datetime");

                b.HasKey("CarritoSesionId");

                b.ToTable("CarritoSesion");
            });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesionDetalle", b =>
            {
                b.Property<int>("CarritoSesionDetalleId")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int");

                b.Property<int>("CarritoSesionId")
                    .HasColumnType("int");

                b.Property<DateTime?>("FechaCreacion")
                    .HasColumnType("datetime");

                b.Property<string>("ProductoSeleccionado")
                    .HasColumnType("text");

                b.HasKey("CarritoSesionDetalleId");

                b.HasIndex("CarritoSesionId");

                b.ToTable("CarritoSesionDetalle");
            });

            modelBuilder.Entity("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesionDetalle", b =>
            {
                b.HasOne("TiendaServicios.Api.CarritoCompra.Modelo.CarritoSesion", "CarritoSesion")
                    .WithMany("ListaDetalle")
                    .HasForeignKey("CarritoSesionId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
