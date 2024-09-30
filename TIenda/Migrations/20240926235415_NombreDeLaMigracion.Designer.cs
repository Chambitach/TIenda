﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TIenda.Models;

#nullable disable

namespace TIenda.Migrations
{
    [DbContext(typeof(TiendaContext))]
    [Migration("20240926235415_NombreDeLaMigracion")]
    partial class NombreDeLaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TIenda.Models.DetallePedido", b =>
                {
                    b.Property<int>("IdDetalle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalle"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("INT");

                    b.Property<int>("IdPedido")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioUnitario")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("IdDetalle");

                    b.ToTable("DetallesPedido");
                });

            modelBuilder.Entity("TIenda.Models.Pedido", b =>
                {
                    b.Property<int>("IdPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPedido"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("DATETIME");

                    b.Property<decimal>("Total")
                        .HasColumnType("DECIMAL(18,2)");

                    b.HasKey("IdPedido");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("TIenda.Models.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("DECIMAL(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("INT");

                    b.HasKey("IdProducto");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("TIenda.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(255)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
