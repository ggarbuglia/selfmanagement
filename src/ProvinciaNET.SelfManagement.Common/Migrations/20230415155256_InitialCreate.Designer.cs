﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProvinciaNET.SelfManagement.Common.Context;

#nullable disable

namespace ProvinciaNET.SelfManagement.Common.Migrations
{
    [DbContext(typeof(SelfManagementContext))]
    [Migration("20230415155256_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.AdUserAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("GivenName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("MembershipId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("SamAccountName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("UserPrincipalName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("MembershipId");

                    b.ToTable("AdUserAccounts");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.AdUserAccountProvision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("AdUserAccountId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Error")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("HasError")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("AdUserAccountId");

                    b.ToTable("AdUserAccountProvisions");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgCostCenter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("OrgCostCenters");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgDirection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("OrgDirections");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AdGroupAccountName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AdGroupDisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("OrgLocations");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgMailDatabaseGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("OrgMailDatabaseGroups");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgMembership", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("AdGroupAccountName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AdGroupDisplayName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.Property<int>("StructureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StructureId");

                    b.ToTable("OrgMemberships");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgSection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CostCenterId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("DirectionId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CostCenterId");

                    b.HasIndex("DirectionId");

                    b.ToTable("OrgSections");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgStructure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("MailDatabaseGroupId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrgUnit")
                        .IsRequired()
                        .HasMaxLength(800)
                        .HasColumnType("varchar(800)");

                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MailDatabaseGroupId");

                    b.HasIndex("SectionId");

                    b.ToTable("OrgStructures");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.AdUserAccount", b =>
                {
                    b.HasOne("ProvinciaNET.SelfManagement.Common.Entities.OrgLocation", "Location")
                        .WithMany("AdUserAccounts")
                        .HasForeignKey("LocationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProvinciaNET.SelfManagement.Common.Entities.OrgMembership", "Membership")
                        .WithMany("AdUserAccounts")
                        .HasForeignKey("MembershipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Location");

                    b.Navigation("Membership");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.AdUserAccountProvision", b =>
                {
                    b.HasOne("ProvinciaNET.SelfManagement.Common.Entities.AdUserAccount", "AdUserAccount")
                        .WithMany("AdUserAccountProvisions")
                        .HasForeignKey("AdUserAccountId");

                    b.Navigation("AdUserAccount");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgMembership", b =>
                {
                    b.HasOne("ProvinciaNET.SelfManagement.Common.Entities.OrgStructure", "Structure")
                        .WithMany("Memberships")
                        .HasForeignKey("StructureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Structure");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgSection", b =>
                {
                    b.HasOne("ProvinciaNET.SelfManagement.Common.Entities.OrgCostCenter", "CostCenter")
                        .WithMany("Sections")
                        .HasForeignKey("CostCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProvinciaNET.SelfManagement.Common.Entities.OrgDirection", "Direction")
                        .WithMany("Sections")
                        .HasForeignKey("DirectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CostCenter");

                    b.Navigation("Direction");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgStructure", b =>
                {
                    b.HasOne("ProvinciaNET.SelfManagement.Common.Entities.OrgMailDatabaseGroup", "MailDatabaseGroup")
                        .WithMany("Structures")
                        .HasForeignKey("MailDatabaseGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProvinciaNET.SelfManagement.Common.Entities.OrgSection", "Section")
                        .WithMany("Structures")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MailDatabaseGroup");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.AdUserAccount", b =>
                {
                    b.Navigation("AdUserAccountProvisions");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgCostCenter", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgDirection", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgLocation", b =>
                {
                    b.Navigation("AdUserAccounts");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgMailDatabaseGroup", b =>
                {
                    b.Navigation("Structures");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgMembership", b =>
                {
                    b.Navigation("AdUserAccounts");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgSection", b =>
                {
                    b.Navigation("Structures");
                });

            modelBuilder.Entity("ProvinciaNET.SelfManagement.Common.Entities.OrgStructure", b =>
                {
                    b.Navigation("Memberships");
                });
#pragma warning restore 612, 618
        }
    }
}
