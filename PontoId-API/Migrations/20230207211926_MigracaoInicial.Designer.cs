﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PontoId_API.Context;

#nullable disable

namespace PontoIdAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230207211926_MigracaoInicial")]
    partial class MigracaoInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PontoId_API.Models.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlunoId"));

                    b.Property<string>("EnderecoAluno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FotoAluno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdadeAluno")
                        .HasColumnType("int");

                    b.Property<bool>("Maioridade")
                        .HasColumnType("bit");

                    b.Property<string>("NomeAluno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResponsavelAluno")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelefoneAluno")
                        .HasColumnType("int");

                    b.Property<int>("TurmaId")
                        .HasColumnType("int");

                    b.HasKey("AlunoId");

                    b.HasIndex("TurmaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("PontoId_API.Models.Escola", b =>
                {
                    b.Property<int>("EscolaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EscolaId"));

                    b.Property<string>("BairroEscola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CepEscola")
                        .HasColumnType("int");

                    b.Property<string>("CidadeEscola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComplementoEscola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EstadoEscola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LogoEscola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomeEscola")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelefoneEscola")
                        .HasColumnType("int");

                    b.HasKey("EscolaId");

                    b.ToTable("Escola");
                });

            modelBuilder.Entity("PontoId_API.Models.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TurmaId"));

                    b.Property<int>("EscolaId")
                        .HasColumnType("int");

                    b.Property<string>("PeriodoAula")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantidadeAlunos")
                        .HasColumnType("int");

                    b.Property<int>("TurmaNumero")
                        .HasColumnType("int");

                    b.HasKey("TurmaId");

                    b.HasIndex("EscolaId");

                    b.ToTable("Turma");
                });

            modelBuilder.Entity("PontoId_API.Models.Aluno", b =>
                {
                    b.HasOne("PontoId_API.Models.Turma", "Turma")
                        .WithMany("Alunos")
                        .HasForeignKey("TurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Turma");
                });

            modelBuilder.Entity("PontoId_API.Models.Turma", b =>
                {
                    b.HasOne("PontoId_API.Models.Escola", "Escola")
                        .WithMany("Turmas")
                        .HasForeignKey("EscolaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escola");
                });

            modelBuilder.Entity("PontoId_API.Models.Escola", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("PontoId_API.Models.Turma", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
