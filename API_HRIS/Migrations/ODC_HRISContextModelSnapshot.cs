﻿// <auto-generated />
using System;
using API_HRIS.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_HRIS.Migrations
{
    [DbContext(typeof(ODC_HRISContext))]
    partial class ODC_HRISContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API_HRIS.Models.GetAllUserDetailsResult", b =>
                {
                    b.Property<int?>("ActiveStatusId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("AgreementStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Cno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Created_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Deleted")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Restored")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Date_Updated")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Delete_Flag")
                        .HasColumnType("bit");

                    b.Property<string>("Deleted_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("JWToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayrollType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rate")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Rate");

                    b.Property<string>("RememberToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Restored_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SalaryType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Suffix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Updated_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.ToView(null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblAddressInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Barangay")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("CountryOfBirth")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("date");

                    b.Property<string>("Municipality")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Province")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Region")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_AddressInfo", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblApiTokenModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ApiToken")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Role")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_ApiTokenModel", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblAudittrail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Actions")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Module")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("Status")
                        .HasColumnType("int")
                        .HasColumnName("status");

                    b.Property<string>("UserId")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.HasKey("Id");

                    b.ToTable("tbl_audittrail", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblDeparmentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("date");

                    b.Property<string>("DepartmentName")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_DeparmentModel", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblModulesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Class")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Img")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<string>("Link")
                        .HasColumnType("VARCHAR(MAX)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("VARCHAR(MAX)");

                    b.HasKey("Id");

                    b.ToTable("TblModulesModel");
                });

            modelBuilder.Entity("API_HRIS.Models.TblPayrollType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PayrollType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tbl_PayrollType", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblPositionModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Name")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("PositionId")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(35)
                        .IsUnicode(false)
                        .HasColumnType("varchar(35)")
                        .HasColumnName("PositionID")
                        .HasComputedColumnSql("((('POS'+'-')+'0')+CONVERT([varchar],[Id],(0)))", false);

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_PositionModel", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblSalaryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<decimal?>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SalaryType")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_SalaryType", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblStatusModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tbl_StatusModel", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblTaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("date");

                    b.Property<int?>("HoursofWork")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("TaskDescription")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Task Description");

                    b.Property<string>("Title")
                        .HasMaxLength(550)
                        .IsUnicode(false)
                        .HasColumnType("varchar(550)");

                    b.Property<int?>("UpdatedBy")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_TaskModel", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblTimeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RenderedHours")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("TaskId")
                        .HasColumnType("int");

                    b.Property<string>("TimeIn")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TimeOut")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("tbl_TimeLogs", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblUsersModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("Active")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool?>("AgreementStatus")
                        .HasColumnType("bit");

                    b.Property<string>("Cno")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Created_By");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("date")
                        .HasColumnName("Date_Created");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("date")
                        .HasColumnName("Date_Deleted");

                    b.Property<DateTime?>("DateRestored")
                        .HasColumnType("date")
                        .HasColumnName("Date_Restored");

                    b.Property<DateTime?>("DateStarted")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("date")
                        .HasColumnName("Date_Updated");

                    b.Property<bool>("DeleteFlag")
                        .HasColumnType("bit")
                        .HasColumnName("Delete_Flag");

                    b.Property<string>("DeletedBy")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Deleted_By");

                    b.Property<int?>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("EmployeeId")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("EmployeeID")
                        .HasComputedColumnSql("(('ODC-'+CONVERT([varchar],[id]))+format(getdate(),'yyyyMMdd'))", false);

                    b.Property<string>("FilePath")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Fname")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Fullname")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Gender")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Jwtoken")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("JWToken");

                    b.Property<string>("Lname")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Mname")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Password")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<int?>("PayrollType")
                        .HasColumnType("int");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.Property<string>("RememberToken")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("RestoredBy")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Restored_By");

                    b.Property<int?>("SalaryType")
                        .HasColumnType("int");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Suffix")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UpdatedBy")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("Updated_By");

                    b.Property<int?>("UserType")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id")
                        .HasName("PK_UsersModel");

                    b.ToTable("tbl_UsersModel", (string)null);
                });

            modelBuilder.Entity("API_HRIS.Models.TblUserType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(550)
                        .IsUnicode(false)
                        .HasColumnType("varchar(550)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateDeleted")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateRestored")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("DeletedBy")
                        .HasMaxLength(550)
                        .IsUnicode(false)
                        .HasColumnType("varchar(550)");

                    b.Property<string>("RestoredBy")
                        .HasMaxLength(550)
                        .IsUnicode(false)
                        .HasColumnType("varchar(550)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasMaxLength(550)
                        .IsUnicode(false)
                        .HasColumnType("varchar(550)");

                    b.Property<string>("UserType")
                        .HasMaxLength(550)
                        .IsUnicode(false)
                        .HasColumnType("varchar(550)");

                    b.HasKey("Id");

                    b.ToTable("tbl_UserType", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
