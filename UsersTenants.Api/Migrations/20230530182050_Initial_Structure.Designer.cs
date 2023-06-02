﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UsersTenants.Api.Data;

#nullable disable

namespace UsersTenants.Api.Migrations
{
    [DbContext(typeof(UsersTenantsContext))]
    [Migration("20230530182050_Initial_Structure")]
    partial class Initial_Structure
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UsersTenants.Api.Models.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("IdCreator")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdCreator");

                    b.ToTable("Roles", (string)null);
                });

            modelBuilder.Entity("UsersTenants.Api.Models.Tenant", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("IdCreator")
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdCreator");

                    b.ToTable("Tenants", (string)null);
                });

            modelBuilder.Entity("UsersTenants.Api.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("LegalTermsAccepted")
                        .HasColumnType("boolean");

                    b.Property<string>("NickName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("UsersTenants.Api.Models.UserTenantRole", b =>
                {
                    b.Property<string>("IdUser")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<string>("IdTenant")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<string>("IdRole")
                        .HasMaxLength(36)
                        .HasColumnType("character varying(36)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("IdUser", "IdTenant", "IdRole");

                    b.HasIndex("IdRole");

                    b.HasIndex("IdTenant");

                    b.ToTable("UserTenantRoles", (string)null);
                });

            modelBuilder.Entity("UsersTenants.Api.Models.Role", b =>
                {
                    b.HasOne("UsersTenants.Api.Models.User", "Creator")
                        .WithMany("CreatedRoles")
                        .HasForeignKey("IdCreator")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Role_Creator");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("UsersTenants.Api.Models.Tenant", b =>
                {
                    b.HasOne("UsersTenants.Api.Models.User", "Creator")
                        .WithMany("CreatedTenants")
                        .HasForeignKey("IdCreator")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("FK_Tenant_Creator");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("UsersTenants.Api.Models.UserTenantRole", b =>
                {
                    b.HasOne("UsersTenants.Api.Models.Role", "Role")
                        .WithMany("UserTenantRoles")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserTenantRole_Role");

                    b.HasOne("UsersTenants.Api.Models.Tenant", "Tenant")
                        .WithMany("UserTenantRoles")
                        .HasForeignKey("IdTenant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserTenantRole_Tenant");

                    b.HasOne("UsersTenants.Api.Models.User", "User")
                        .WithMany("UserTenantRoles")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserTenantRole_User");

                    b.Navigation("Role");

                    b.Navigation("Tenant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UsersTenants.Api.Models.Role", b =>
                {
                    b.Navigation("UserTenantRoles");
                });

            modelBuilder.Entity("UsersTenants.Api.Models.Tenant", b =>
                {
                    b.Navigation("UserTenantRoles");
                });

            modelBuilder.Entity("UsersTenants.Api.Models.User", b =>
                {
                    b.Navigation("CreatedRoles");

                    b.Navigation("CreatedTenants");

                    b.Navigation("UserTenantRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
