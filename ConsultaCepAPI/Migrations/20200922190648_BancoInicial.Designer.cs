﻿// <auto-generated />
using ConsultaCepAPI.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsultaCepAPI.Migrations
{
    [DbContext(typeof(ConsultaCepAPIContext))]
    [Migration("20200922190648_BancoInicial")]
    partial class BancoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("ConsultaCepAPI.Models.CEP", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Bairro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Cep")
                        .HasColumnType("TEXT");

                    b.Property<string>("Complemento")
                        .HasColumnType("TEXT");

                    b.Property<long>("Ddd")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gia")
                        .HasColumnType("TEXT");

                    b.Property<long>("Ibge")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Localidade")
                        .HasColumnType("TEXT");

                    b.Property<string>("Logradouro")
                        .HasColumnType("TEXT");

                    b.Property<long>("Siafi")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Uf")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Ceps");
                });
#pragma warning restore 612, 618
        }
    }
}