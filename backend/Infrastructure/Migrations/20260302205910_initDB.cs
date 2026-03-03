using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client_Condition",
                columns: table => new
                {
                    Client_Condition_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Catalog = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Item_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Item_Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Item_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client_Condition", x => x.Client_Condition_Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Comment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Comment_Id);
                });

            migrationBuilder.CreateTable(
                name: "Container_Type",
                columns: table => new
                {
                    ContainerType_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Descr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container_Type", x => x.ContainerType_Id);
                });

            migrationBuilder.CreateTable(
                name: "Credit_Status",
                columns: table => new
                {
                    CreditStatus_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit_Status", x => x.CreditStatus_id);
                });

            migrationBuilder.CreateTable(
                name: "Credit_Type",
                columns: table => new
                {
                    Credit_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Activve = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit_Type", x => x.Credit_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Document",
                columns: table => new
                {
                    Cust_Doc_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Document", x => x.Cust_Doc_Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Category",
                columns: table => new
                {
                    Emp_Cat_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Cat_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Category", x => x.Emp_Cat_Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_Document",
                columns: table => new
                {
                    Eqpm_Doc_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_Document", x => x.Eqpm_Doc_Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_Status",
                columns: table => new
                {
                    EquipStatus_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_Status", x => x.EquipStatus_id);
                });

            migrationBuilder.CreateTable(
                name: "Event_Classification",
                columns: table => new
                {
                    Event_Classification_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clasiff_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Clasiff_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event_Classification", x => x.Event_Classification_Id);
                });

            migrationBuilder.CreateTable(
                name: "IMO",
                columns: table => new
                {
                    IMO_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMO", x => x.IMO_Id);
                });

            migrationBuilder.CreateTable(
                name: "Items_Catalog",
                columns: table => new
                {
                    Items_Catalog_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item_Catalog = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Item_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Item_Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Item_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_Catalog", x => x.Items_Catalog_Id);
                });

            migrationBuilder.CreateTable(
                name: "Logistics_Provider",
                columns: table => new
                {
                    Logistics_Provider_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url_Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logistics_Provider", x => x.Logistics_Provider_Id);
                });

            migrationBuilder.CreateTable(
                name: "Packaging_Type",
                columns: table => new
                {
                    Packaging_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Packaging_Clasiffication = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Packaging_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Packaging_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packaging_Type", x => x.Packaging_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Payment_Terms",
                columns: table => new
                {
                    paymentTerm_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment_Terms", x => x.paymentTerm_id);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Rol_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Rol_Id);
                });

            migrationBuilder.CreateTable(
                name: "Service_Event_Type",
                columns: table => new
                {
                    ServiceEventTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Event_Type", x => x.ServiceEventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Shipping_Line",
                columns: table => new
                {
                    Shipping_Line_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Short_Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipping_Line", x => x.Shipping_Line_Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Status_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status_Classification = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Status_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Sequence = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Status_Id);
                });

            migrationBuilder.CreateTable(
                name: "Status_Service",
                columns: table => new
                {
                    StatusServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sequence = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status_Service", x => x.StatusServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Trip_Type",
                columns: table => new
                {
                    Trip_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip_Type", x => x.Trip_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "Credit",
                columns: table => new
                {
                    Credit_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Credit_Type_Id = table.Column<int>(type: "int", nullable: false),
                    CreditStatus_id = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit", x => x.Credit_Id);
                    table.ForeignKey(
                        name: "FK_Credit_Credit_Status_CreditStatus_id",
                        column: x => x.CreditStatus_id,
                        principalTable: "Credit_Status",
                        principalColumn: "CreditStatus_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Credit_Credit_Type_Credit_Type_Id",
                        column: x => x.Credit_Type_Id,
                        principalTable: "Credit_Type",
                        principalColumn: "Credit_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Emp_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Cat_Id = table.Column<int>(type: "int", nullable: false),
                    Employee_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Names = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Middle_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Entry_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Guild = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Termination_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Birth_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Marital_Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Photo_Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    RFC = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CURP = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: true),
                    NSS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    INE = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Drive_License = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Drive_License_DateExp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Certificated_ForeignDriver = table.Column<bool>(type: "bit", nullable: true),
                    BloodType = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Education_level = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Emp_Id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_Category_Emp_Cat_Id",
                        column: x => x.Emp_Cat_Id,
                        principalTable: "Employee_Category",
                        principalColumn: "Emp_Cat_Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipment_Type",
                columns: table => new
                {
                    EquipType_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fuel_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    LogisticsProviderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_Type", x => x.EquipType_id);
                    table.ForeignKey(
                        name: "FK_Equipment_Type_Logistics_Provider_LogisticsProviderId",
                        column: x => x.LogisticsProviderId,
                        principalTable: "Logistics_Provider",
                        principalColumn: "Logistics_Provider_Id");
                });

            migrationBuilder.CreateTable(
                name: "ProvideLogistic_Comments",
                columns: table => new
                {
                    ProvideLog_Comment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment_Id = table.Column<int>(type: "int", nullable: false),
                    ProvLog_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvideLogistic_Comments", x => x.ProvideLog_Comment_Id);
                    table.ForeignKey(
                        name: "FK_ProvideLogistic_Comments_Comment_Comment_Id",
                        column: x => x.Comment_Id,
                        principalTable: "Comment",
                        principalColumn: "Comment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProvideLogistic_Comments_Logistics_Provider_ProvLog_Id",
                        column: x => x.ProvLog_Id,
                        principalTable: "Logistics_Provider",
                        principalColumn: "Logistics_Provider_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Terminal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logistics_Provider_Id = table.Column<int>(type: "int", nullable: false),
                    Terminal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Name_Terminal = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url_Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Terminal_Id);
                    table.ForeignKey(
                        name: "FK_Terminal_Logistics_Provider_Logistics_Provider_Id",
                        column: x => x.Logistics_Provider_Id,
                        principalTable: "Logistics_Provider",
                        principalColumn: "Logistics_Provider_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service_Event",
                columns: table => new
                {
                    ServiceEventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceEventTypeId = table.Column<int>(type: "int", nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_Event", x => x.ServiceEventId);
                    table.ForeignKey(
                        name: "FK_Service_Event_Service_Event_Type_ServiceEventTypeId",
                        column: x => x.ServiceEventTypeId,
                        principalTable: "Service_Event_Type",
                        principalColumn: "ServiceEventTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Container",
                columns: table => new
                {
                    Container_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContainerType_Id = table.Column<int>(type: "int", nullable: false),
                    Container_Red_Id = table.Column<int>(type: "int", nullable: true),
                    Shipping_Line_Id = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Weight_Kg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Container_Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Red_Entry_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Red_Liberation_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Container_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cntr_Document_Recuest = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Archieve_Request = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cntr_Document_Rfc = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Rfc_Company = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Company_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container", x => x.Container_Id);
                    table.ForeignKey(
                        name: "FK_Container_Container_Container_Red_Id",
                        column: x => x.Container_Red_Id,
                        principalTable: "Container",
                        principalColumn: "Container_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Container_Container_Type_ContainerType_Id",
                        column: x => x.ContainerType_Id,
                        principalTable: "Container_Type",
                        principalColumn: "ContainerType_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Container_Shipping_Line_Shipping_Line_Id",
                        column: x => x.Shipping_Line_Id,
                        principalTable: "Shipping_Line",
                        principalColumn: "Shipping_Line_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Customer_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Trip_Type_Id = table.Column<int>(type: "int", nullable: false),
                    paymentTerm_id = table.Column<int>(type: "int", nullable: false),
                    Actual_Executive_id = table.Column<int>(type: "int", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Names = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Middle_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Full_Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Company_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Rfc_Company = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Cust_Position = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Url_WebPage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url_Invoicing = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Modify_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Contract_Actual = table.Column<bool>(type: "bit", nullable: true),
                    Certificated_Customer = table.Column<bool>(type: "bit", nullable: true),
                    Base_Contract = table.Column<bool>(type: "bit", nullable: true),
                    Contract_Personalized = table.Column<bool>(type: "bit", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Customer_Id);
                    table.ForeignKey(
                        name: "FK_Customer_Employee_Actual_Executive_id",
                        column: x => x.Actual_Executive_id,
                        principalTable: "Employee",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Payment_Terms_paymentTerm_id",
                        column: x => x.paymentTerm_id,
                        principalTable: "Payment_Terms",
                        principalColumn: "paymentTerm_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Trip_Type_Trip_Type_Id",
                        column: x => x.Trip_Type_Id,
                        principalTable: "Trip_Type",
                        principalColumn: "Trip_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee_Disabled",
                columns: table => new
                {
                    Emp_Disabled_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_Disabled", x => x.Emp_Disabled_Id);
                    table.ForeignKey(
                        name: "FK_Employee_Disabled_Employee_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "Employee",
                        principalColumn: "Emp_Id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Token_id = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Id);
                    table.ForeignKey(
                        name: "FK_User_Employee_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "Employee",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Appointment_Terminal",
                columns: table => new
                {
                    Appo_Terminal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terminal_Id = table.Column<int>(type: "int", nullable: false),
                    Appo_Category = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Appo_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Appo_Block = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Appo_Date_Ini = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Appo_Date_Fin = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Appo_Date_IniEta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment_Terminal", x => x.Appo_Terminal_Id);
                    table.ForeignKey(
                        name: "FK_Appointment_Terminal_Terminal_Terminal_Id",
                        column: x => x.Terminal_Id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Equipment_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipType_id = table.Column<int>(type: "int", nullable: false),
                    terminal_id = table.Column<int>(type: "int", nullable: false),
                    Trip_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Equipment_Status = table.Column<int>(type: "int", nullable: false),
                    Economic_Number = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Plates = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Plates_Estate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Diesel_capacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    towing_capacity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AvailablePartners = table.Column<bool>(type: "bit", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Labeled_Unit = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Equipment_id);
                    table.ForeignKey(
                        name: "FK_Equipment_Equipment_Status_Equipment_Status",
                        column: x => x.Equipment_Status,
                        principalTable: "Equipment_Status",
                        principalColumn: "EquipStatus_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Equipment_Type_EquipType_id",
                        column: x => x.EquipType_id,
                        principalTable: "Equipment_Type",
                        principalColumn: "EquipType_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Terminal_terminal_id",
                        column: x => x.terminal_id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_Trip_Type_Trip_Type_Id",
                        column: x => x.Trip_Type_Id,
                        principalTable: "Trip_Type",
                        principalColumn: "Trip_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Forbidden_Employee",
                columns: table => new
                {
                    Forb_Employee_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    Terminal_Id = table.Column<int>(type: "int", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forbidden_Employee", x => x.Forb_Employee_Id);
                    table.ForeignKey(
                        name: "FK_Forbidden_Employee_Employee_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "Employee",
                        principalColumn: "Emp_Id");
                    table.ForeignKey(
                        name: "FK_Forbidden_Employee_Terminal_Terminal_Id",
                        column: x => x.Terminal_Id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Layout_Name",
                columns: table => new
                {
                    Layout_Name_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terminal_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Full_Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Url_Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Layout_Name", x => x.Layout_Name_Id);
                    table.ForeignKey(
                        name: "FK_Layout_Name_Terminal_Terminal_Id",
                        column: x => x.Terminal_Id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Road_Routes",
                columns: table => new
                {
                    Road_Routes_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terminal_Origen_Id = table.Column<int>(type: "int", nullable: false),
                    Terminal_Destino_Id = table.Column<int>(type: "int", nullable: false),
                    Route_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Route_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Total_Kms = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Estimated_Time = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Road_Routes", x => x.Road_Routes_Id);
                    table.ForeignKey(
                        name: "FK_Road_Routes_Terminal_Terminal_Destino_Id",
                        column: x => x.Terminal_Destino_Id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Road_Routes_Terminal_Terminal_Origen_Id",
                        column: x => x.Terminal_Origen_Id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Container_Seals",
                columns: table => new
                {
                    Container_Seal_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Container_Id = table.Column<int>(type: "int", nullable: false),
                    Seal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sealed_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Container_Seals", x => x.Container_Seal_Id);
                    table.ForeignKey(
                        name: "FK_Container_Seals_Container_Container_Id",
                        column: x => x.Container_Id,
                        principalTable: "Container",
                        principalColumn: "Container_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Contract_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Status_Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Status_Contract_Id = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Contract_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Contract_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cancellation_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Credit_Days = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Contract_Id);
                    table.ForeignKey(
                        name: "FK_Contract_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contract_Status_Status_Contract_Id",
                        column: x => x.Status_Contract_Id,
                        principalTable: "Status",
                        principalColumn: "Status_Id");
                    table.ForeignKey(
                        name: "FK_Contract_Status_Status_Customer_Id",
                        column: x => x.Status_Customer_Id,
                        principalTable: "Status",
                        principalColumn: "Status_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Credit_Customer",
                columns: table => new
                {
                    CreditCusto_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_id = table.Column<int>(type: "int", nullable: false),
                    Credit_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credit_Customer", x => x.CreditCusto_id);
                    table.ForeignKey(
                        name: "FK_Credit_Customer_Credit_Credit_id",
                        column: x => x.Credit_id,
                        principalTable: "Credit",
                        principalColumn: "Credit_Id");
                    table.ForeignKey(
                        name: "FK_Credit_Customer_Customer_Customer_id",
                        column: x => x.Customer_id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer_Comment",
                columns: table => new
                {
                    Cust_Com_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Comment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Comment", x => x.Cust_Com_id);
                    table.ForeignKey(
                        name: "FK_Customer_Comment_Comment_Comment_Id",
                        column: x => x.Comment_Id,
                        principalTable: "Comment",
                        principalColumn: "Comment_Id");
                    table.ForeignKey(
                        name: "FK_Customer_Comment_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id");
                });

            migrationBuilder.CreateTable(
                name: "Customer_File",
                columns: table => new
                {
                    Eqpm_File_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cust_Doc_Id = table.Column<int>(type: "int", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Url_Document_Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Apply = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Exp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url_Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_File", x => x.Eqpm_File_Id);
                    table.ForeignKey(
                        name: "FK_Customer_File_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_File_Customer_Document_Cust_Doc_Id",
                        column: x => x.Cust_Doc_Id,
                        principalTable: "Customer_Document",
                        principalColumn: "Cust_Doc_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer_Type",
                columns: table => new
                {
                    Customer_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Cust_Parent_FF = table.Column<int>(type: "int", nullable: false),
                    Invoicing_CF = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Invoicing_FF = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Cust_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cust_Type_Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_Type", x => x.Customer_Type_Id);
                    table.ForeignKey(
                        name: "FK_Customer_Type_Customer_Cust_Parent_FF",
                        column: x => x.Cust_Parent_FF,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Customer_Type_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Industry_Type",
                columns: table => new
                {
                    Industry_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Industry_Type = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Desc = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Industry_Type", x => x.Industry_Type_Id);
                    table.ForeignKey(
                        name: "FK_Industry_Type_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personal_Addresses",
                columns: table => new
                {
                    Personal_Addresses_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    Terminal_Id = table.Column<int>(type: "int", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Logistics_Provider_Id = table.Column<int>(type: "int", nullable: false),
                    Street_Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Internal_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Exterior_Number = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    State = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Zip_Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Maps_Url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Full_Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Reference_1 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Reference_2 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Reference_3 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Reference_4 = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Maps_Lat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Maps_Long = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_Addresses", x => x.Personal_Addresses_Id);
                    table.ForeignKey(
                        name: "FK_Personal_Addresses_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personal_Addresses_Employee_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "Employee",
                        principalColumn: "Emp_Id");
                    table.ForeignKey(
                        name: "FK_Personal_Addresses_Logistics_Provider_Logistics_Provider_Id",
                        column: x => x.Logistics_Provider_Id,
                        principalTable: "Logistics_Provider",
                        principalColumn: "Logistics_Provider_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personal_Addresses_Terminal_Terminal_Id",
                        column: x => x.Terminal_Id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Personal_Contact",
                columns: table => new
                {
                    Personal_Contact_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    Terminal_Id = table.Column<int>(type: "int", nullable: false),
                    Customer_Id = table.Column<int>(type: "int", nullable: false),
                    Logistics_Provider_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Certificated = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal_Contact", x => x.Personal_Contact_Id);
                    table.ForeignKey(
                        name: "FK_Personal_Contact_Customer_Customer_Id",
                        column: x => x.Customer_Id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personal_Contact_Employee_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "Employee",
                        principalColumn: "Emp_Id");
                    table.ForeignKey(
                        name: "FK_Personal_Contact_Logistics_Provider_Logistics_Provider_Id",
                        column: x => x.Logistics_Provider_Id,
                        principalTable: "Logistics_Provider",
                        principalColumn: "Logistics_Provider_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Personal_Contact_Terminal_Terminal_Id",
                        column: x => x.Terminal_Id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DateEvents_Type",
                columns: table => new
                {
                    DateEvents_Type_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Event_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Event_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status_Id = table.Column<int>(type: "int", nullable: false),
                    User_Report_Id = table.Column<int>(type: "int", nullable: false),
                    Url_Event = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Archieve_Event = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Type_Receipt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Payment_Method = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Budget_Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Amount_Established = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Amout = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currency = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    User_Create = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Date_Create = table.Column<DateTime>(type: "datetime2", nullable: true),
                    User_Modificate = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Date_Modificate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateEvents_Type", x => x.DateEvents_Type_Id);
                    table.ForeignKey(
                        name: "FK_DateEvents_Type_Status_Status_Id",
                        column: x => x.Status_Id,
                        principalTable: "Status",
                        principalColumn: "Status_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DateEvents_Type_User_User_Report_Id",
                        column: x => x.User_Report_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User_Rol",
                columns: table => new
                {
                    User_Rol_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_Id = table.Column<int>(type: "int", nullable: false),
                    Rol_Id = table.Column<int>(type: "int", nullable: false),
                    Assign_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Rol", x => x.User_Rol_Id);
                    table.ForeignKey(
                        name: "FK_User_Rol_Rol_Rol_Id",
                        column: x => x.Rol_Id,
                        principalTable: "Rol",
                        principalColumn: "Rol_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Rol_User_User_Id",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_File",
                columns: table => new
                {
                    Eqpm_File_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Eqpm_Doc_Id = table.Column<int>(type: "int", nullable: false),
                    Equipment_id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Url_Document_Path = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Date_Apply = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Installation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Date_Exp = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Url_Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_File", x => x.Eqpm_File_Id);
                    table.ForeignKey(
                        name: "FK_Equipment_File_Equipment_Document_Eqpm_Doc_Id",
                        column: x => x.Eqpm_Doc_Id,
                        principalTable: "Equipment_Document",
                        principalColumn: "Eqpm_Doc_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_File_Equipment_Equipment_id",
                        column: x => x.Equipment_id,
                        principalTable: "Equipment",
                        principalColumn: "Equipment_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Equipment_Repair_log",
                columns: table => new
                {
                    Equip_RepairLog_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment_Id = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descr = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment_Repair_log", x => x.Equip_RepairLog_Id);
                    table.ForeignKey(
                        name: "FK_Equipment_Repair_log_Equipment_Equipment_Id",
                        column: x => x.Equipment_Id,
                        principalTable: "Equipment",
                        principalColumn: "Equipment_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Service_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipament_Id = table.Column<int>(type: "int", nullable: false),
                    Container_Id = table.Column<int>(type: "int", nullable: false),
                    Trip_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Customer_id = table.Column<int>(type: "int", nullable: false),
                    StatusServiceId = table.Column<int>(type: "int", nullable: false),
                    Creation_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    User_Creation = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Autorization_CCO_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Autorization_CFO_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Operated_Traffic = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Service_SingleFull = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Service_Id);
                    table.ForeignKey(
                        name: "FK_Services_Container_Container_Id",
                        column: x => x.Container_Id,
                        principalTable: "Container",
                        principalColumn: "Container_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Customer_Customer_id",
                        column: x => x.Customer_id,
                        principalTable: "Customer",
                        principalColumn: "Customer_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Equipment_Equipament_Id",
                        column: x => x.Equipament_Id,
                        principalTable: "Equipment",
                        principalColumn: "Equipment_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Status_Service_StatusServiceId",
                        column: x => x.StatusServiceId,
                        principalTable: "Status_Service",
                        principalColumn: "StatusServiceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_Trip_Type_Trip_Type_Id",
                        column: x => x.Trip_Type_Id,
                        principalTable: "Trip_Type",
                        principalColumn: "Trip_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items_Contract",
                columns: table => new
                {
                    Items_Contract_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contract_Id = table.Column<int>(type: "int", nullable: false),
                    Items_Catalog_Id = table.Column<int>(type: "int", nullable: false),
                    Client_Condition_Id = table.Column<int>(type: "int", nullable: false),
                    Status_Id = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Amount_Percent = table.Column<decimal>(type: "decimal(18,4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_Contract", x => x.Items_Contract_Id);
                    table.ForeignKey(
                        name: "FK_Items_Contract_Client_Condition_Client_Condition_Id",
                        column: x => x.Client_Condition_Id,
                        principalTable: "Client_Condition",
                        principalColumn: "Client_Condition_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Contract_Contract_Contract_Id",
                        column: x => x.Contract_Id,
                        principalTable: "Contract",
                        principalColumn: "Contract_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Contract_Items_Catalog_Items_Catalog_Id",
                        column: x => x.Items_Catalog_Id,
                        principalTable: "Items_Catalog",
                        principalColumn: "Items_Catalog_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Items_Contract_Status_Status_Id",
                        column: x => x.Status_Id,
                        principalTable: "Status",
                        principalColumn: "Status_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assigned_Equipment",
                columns: table => new
                {
                    Assigned_Equipment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Equipment_Id = table.Column<int>(type: "int", nullable: false),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    Assign_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unassign_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Pernocta_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigned_Equipment", x => x.Assigned_Equipment_Id);
                    table.ForeignKey(
                        name: "FK_Assigned_Equipment_Equipment_Equipment_Id",
                        column: x => x.Equipment_Id,
                        principalTable: "Equipment",
                        principalColumn: "Equipment_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assigned_Equipment_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assigned_Operator",
                columns: table => new
                {
                    Assigned_Operator_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emp_Id = table.Column<int>(type: "int", nullable: false),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    Assign_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unassign_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Pernocta_Date = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assigned_Operator", x => x.Assigned_Operator_Id);
                    table.ForeignKey(
                        name: "FK_Assigned_Operator_Employee_Emp_Id",
                        column: x => x.Emp_Id,
                        principalTable: "Employee",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Assigned_Operator_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Full_Empty",
                columns: table => new
                {
                    Full_Empty_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    Container_Id = table.Column<int>(type: "int", nullable: false),
                    Full_Empty = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Full_Empty_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Full_Empty", x => x.Full_Empty_Id);
                    table.ForeignKey(
                        name: "FK_Full_Empty_Container_Container_Id",
                        column: x => x.Container_Id,
                        principalTable: "Container",
                        principalColumn: "Container_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Full_Empty_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loose_Commodity",
                columns: table => new
                {
                    Loose_Commodity_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Packaging_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    Commodity = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    Unload_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loose_Commodity", x => x.Loose_Commodity_Id);
                    table.ForeignKey(
                        name: "FK_Loose_Commodity_Packaging_Type_Packaging_Type_Id",
                        column: x => x.Packaging_Type_Id,
                        principalTable: "Packaging_Type",
                        principalColumn: "Packaging_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Loose_Commodity_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Routes_Services",
                columns: table => new
                {
                    Routes_Services_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Road_Routes_Id = table.Column<int>(type: "int", nullable: false),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    Route_Ini_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Route_End_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes_Services", x => x.Routes_Services_Id);
                    table.ForeignKey(
                        name: "FK_Routes_Services_Road_Routes_Road_Routes_Id",
                        column: x => x.Road_Routes_Id,
                        principalTable: "Road_Routes",
                        principalColumn: "Road_Routes_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Routes_Services_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service_ServiceEvent",
                columns: table => new
                {
                    Service_ServiceEvent_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceEventId = table.Column<int>(type: "int", nullable: false),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_ServiceEvent", x => x.Service_ServiceEvent_Id);
                    table.ForeignKey(
                        name: "FK_Service_ServiceEvent_Service_Event_ServiceEventId",
                        column: x => x.ServiceEventId,
                        principalTable: "Service_Event",
                        principalColumn: "ServiceEventId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_ServiceEvent_Services_ServiceId1",
                        column: x => x.ServiceId1,
                        principalTable: "Services",
                        principalColumn: "Service_Id");
                    table.ForeignKey(
                        name: "FK_Service_ServiceEvent_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Services_Comment",
                columns: table => new
                {
                    Serv_Com_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    Coment_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services_Comment", x => x.Serv_Com_Id);
                    table.ForeignKey(
                        name: "FK_Services_Comment_Comment_Coment_Id",
                        column: x => x.Coment_Id,
                        principalTable: "Comment",
                        principalColumn: "Comment_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Services_Comment_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services_DateEvents",
                columns: table => new
                {
                    Services_DateEvents = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    DateEvents_Type_Id = table.Column<int>(type: "int", nullable: false),
                    Event_Classification_Id = table.Column<int>(type: "int", nullable: false),
                    Event_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event_Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services_DateEvents", x => x.Services_DateEvents);
                    table.ForeignKey(
                        name: "FK_Services_DateEvents_DateEvents_Type_DateEvents_Type_Id",
                        column: x => x.DateEvents_Type_Id,
                        principalTable: "DateEvents_Type",
                        principalColumn: "DateEvents_Type_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_DateEvents_Event_Classification_Event_Classification_Id",
                        column: x => x.Event_Classification_Id,
                        principalTable: "Event_Classification",
                        principalColumn: "Event_Classification_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Services_DateEvents_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operator_Equipment",
                columns: table => new
                {
                    Operator_Equipment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Assigned_Operator_Id = table.Column<int>(type: "int", nullable: false),
                    Assigned_Equipment_Id = table.Column<int>(type: "int", nullable: false),
                    Assign_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Unassign_Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operator_Equipment", x => x.Operator_Equipment_Id);
                    table.ForeignKey(
                        name: "FK_Operator_Equipment_Assigned_Equipment_Assigned_Equipment_Id",
                        column: x => x.Assigned_Equipment_Id,
                        principalTable: "Assigned_Equipment",
                        principalColumn: "Assigned_Equipment_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operator_Equipment_Assigned_Operator_Assigned_Operator_Id",
                        column: x => x.Assigned_Operator_Id,
                        principalTable: "Assigned_Operator",
                        principalColumn: "Assigned_Operator_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Scheduleded_Appointment",
                columns: table => new
                {
                    Sche_Appointment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Appo_Terminal_Id = table.Column<int>(type: "int", nullable: false),
                    Services_DateEvents = table.Column<int>(type: "int", nullable: false),
                    Full_Empty_Id = table.Column<int>(type: "int", nullable: false),
                    Container_Id = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scheduleded_Appointment", x => x.Sche_Appointment_Id);
                    table.ForeignKey(
                        name: "FK_Scheduleded_Appointment_Appointment_Terminal_Appo_Terminal_Id",
                        column: x => x.Appo_Terminal_Id,
                        principalTable: "Appointment_Terminal",
                        principalColumn: "Appo_Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scheduleded_Appointment_Container_Container_Id",
                        column: x => x.Container_Id,
                        principalTable: "Container",
                        principalColumn: "Container_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scheduleded_Appointment_Full_Empty_Full_Empty_Id",
                        column: x => x.Full_Empty_Id,
                        principalTable: "Full_Empty",
                        principalColumn: "Full_Empty_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scheduleded_Appointment_Services_DateEvents_Services_DateEvents",
                        column: x => x.Services_DateEvents,
                        principalTable: "Services_DateEvents",
                        principalColumn: "Services_DateEvents",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Terminal_Ticket",
                columns: table => new
                {
                    Terminal_Ticket_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service_Id = table.Column<int>(type: "int", nullable: false),
                    Container1_Id = table.Column<int>(type: "int", nullable: false),
                    Container2_Id = table.Column<int>(type: "int", nullable: false),
                    Terminal_Id = table.Column<int>(type: "int", nullable: false),
                    Operator_Equipment_Id = table.Column<int>(type: "int", nullable: false),
                    Url_Ticket = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Archieve_Ticket = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Terminal_TicketDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Terminal_TicketExpDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal_Ticket", x => x.Terminal_Ticket_Id);
                    table.ForeignKey(
                        name: "FK_Terminal_Ticket_Container_Container1_Id",
                        column: x => x.Container1_Id,
                        principalTable: "Container",
                        principalColumn: "Container_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Terminal_Ticket_Container_Container2_Id",
                        column: x => x.Container2_Id,
                        principalTable: "Container",
                        principalColumn: "Container_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Terminal_Ticket_Operator_Equipment_Operator_Equipment_Id",
                        column: x => x.Operator_Equipment_Id,
                        principalTable: "Operator_Equipment",
                        principalColumn: "Operator_Equipment_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Terminal_Ticket_Services_Service_Id",
                        column: x => x.Service_Id,
                        principalTable: "Services",
                        principalColumn: "Service_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terminal_Ticket_Terminal_Terminal_Id",
                        column: x => x.Terminal_Id,
                        principalTable: "Terminal",
                        principalColumn: "Terminal_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Container_Type",
                columns: new[] { "ContainerType_Id", "Active", "Descr", "Name" },
                values: new object[,]
                {
                    { 1, true, "Contenedor de 20 pies", "20'" },
                    { 2, true, "Contenedor de 40 pies", "40'" },
                    { 3, true, "Contenedor de 45 pies", "45'" },
                    { 4, true, "Contenedor Open Top", "OT" },
                    { 5, true, "Contenedor Refrigerado", "RF" },
                    { 6, true, "Contenedor Tanque", "TK" }
                });

            migrationBuilder.InsertData(
                table: "Employee_Category",
                columns: new[] { "Emp_Cat_Id", "Cat_Description", "Category", "Comments" },
                values: new object[,]
                {
                    { 1, "Personal administrativo del sistema", "Administración", "Categoría designada para el personal administrativo del sistema" },
                    { 2, "Personal operador de equipo", "Operador", "Categoría designada para el operador del equipo tracto" }
                });

            migrationBuilder.InsertData(
                table: "Equipment_Status",
                columns: new[] { "EquipStatus_id", "Active", "Descr", "Name" },
                values: new object[,]
                {
                    { 1, true, "Equipo disponible para asignar a servicio", "Disponible" },
                    { 2, true, "Equipo actualmente asignado a un servicio", "En Ruta" },
                    { 3, true, "Equipo en mantenimiento, no disponible para asignar a servicio", "Mantenimiento" },
                    { 4, true, "Equipo en reparacion, no disponible para asignar a servicio", "Reparacion" },
                    { 5, true, "Equipo retenido por las autoridades, no disponible para asignar a servicio", "Red" },
                    { 6, true, "Equipo fuera de servicio por daño o retiro, no disponible para asignar a servicio", "Fuera de Servicio" }
                });

            migrationBuilder.InsertData(
                table: "Equipment_Type",
                columns: new[] { "EquipType_id", "Active", "Comments", "Descr", "Fuel_Type", "LogisticsProviderId", "Name" },
                values: new object[,]
                {
                    { 1, true, null, "Equipo tipo tracto", null, null, "Tracto" },
                    { 2, true, null, "Equipo tipo caja seca", null, null, "Caja seca" },
                    { 3, true, null, "Equipo tipo plataforma", null, null, "Plataforma" },
                    { 4, true, null, "Equipo tipo lowboy", null, null, "Lowboy" },
                    { 5, true, null, "Equipo tipo refrigerado", null, null, "Refrigerado" },
                    { 6, true, null, "Equipo tipo tanque", null, null, "Tanque" },
                    { 7, true, null, "Chasis portacontenedor", null, null, "Chasis" },
                    { 8, true, null, "Remolque auxiliar dolly", null, null, "Dolly" }
                });

            migrationBuilder.InsertData(
                table: "IMO",
                columns: new[] { "IMO_Id", "Active", "Desc", "Name" },
                values: new object[,]
                {
                    { 1, true, "Explosivos", "Clase 1" },
                    { 2, true, "Gases (inflamables, no inflamables, tóxicos)", "Clase 2" },
                    { 3, true, "Líquidos inflamables (pinturas, gasolina)", "Clase 3" },
                    { 4, true, "Sólidos inflamables", "Clase 4" },
                    { 5, true, "Comburentes y peróxidos orgánicos", "Clase 5" },
                    { 6, true, "Tóxicos e infecciosos", "Clase 6" },
                    { 7, true, "Material radioactivo", "Clase 7" },
                    { 8, true, "Corrosivos", "Clase 8" },
                    { 9, true, "Mercancías peligrosas diversas (pilas de litio, etc.)", "Clase 9" }
                });

            migrationBuilder.InsertData(
                table: "Logistics_Provider",
                columns: new[] { "Logistics_Provider_Id", "Active", "Comments", "Full_Name", "Name", "Url_Image" },
                values: new object[] { 1, true, null, "ASLA LOGISTICS", "ASLA", null });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "Rol_Id", "Active", "Comments", "Descr", "Name" },
                values: new object[] { 1, true, "Rol destinado para el Administrador del sistema", "Acceso total al sistema", "Administrador" });

            migrationBuilder.InsertData(
                table: "Shipping_Line",
                columns: new[] { "Shipping_Line_Id", "Active", "Comments", "Description", "Name", "Short_Name" },
                values: new object[,]
                {
                    { 1, true, null, "A.P. Moller-Maersk", "Maersk", "MAEU" },
                    { 2, true, null, "Mediterranean Shipping Company", "MSC", "MSCU" },
                    { 3, true, null, "CMA CGM S.A.", "CMA CGM", "CMDU" },
                    { 4, true, null, "Hapag-Lloyd AG", "Hapag-Lloyd", "HLCU" },
                    { 5, true, null, "COSCO Shipping Lines", "COSCO", "COSU" },
                    { 6, true, null, "Evergreen Marine Corporation", "Evergreen", "EGLV" },
                    { 7, true, null, "Ocean Network Express", "ONE", "ONEY" },
                    { 8, true, null, "Yang Ming Marine Transport Corp.", "Yang Ming", "YMLU" },
                    { 9, true, null, "ZIM Integrated Shipping Services", "ZIM", "ZIMU" },
                    { 10, true, null, "Hyundai Merchant Marine", "HMM", "HDMU" }
                });

            migrationBuilder.InsertData(
                table: "Status_Service",
                columns: new[] { "StatusServiceId", "Classification", "Descr", "Name", "Sequence" },
                values: new object[,]
                {
                    { 1, "LocalLleno", "Registro en ASLA", "Registro ASLA", 1 },
                    { 2, "LocalLleno", "En espera de acceso", "Espera Acceso", 2 },
                    { 3, "LocalLleno", "Pase a terminal", "Pase Terminal", 3 },
                    { 4, "LocalLleno", "Ingreso a terminal", "Ingreso Terminal", 4 },
                    { 5, "LocalLleno", "Proceso de carga del contenedor", "Proceso Carga", 5 },
                    { 6, "LocalLleno", "Salida por ruta fiscal", "Salida Ruta Fiscal", 6 },
                    { 7, "LocalLleno", "En fila para modulación", "En Fila para Modular", 7 },
                    { 8, "LocalLleno", "Ingreso a aduana", "Ingreso Aduana", 8 },
                    { 9, "LocalLleno", "Revisión en aduana", "Revisión Aduana", 9 },
                    { 10, "LocalLleno", "Salida de puerto y resguardo a patio", "Salida de Puerto y Resguardo a Patio", 10 },
                    { 11, "LocalLleno", "Servicio local lleno finalizado", "Finalizado", 11 },
                    { 12, "LocalVacio", "Recolección de contenedor en patio", "Recolección en Patio", 1 },
                    { 13, "LocalVacio", "Registro en ASLA", "Registro ASLA", 2 },
                    { 14, "LocalVacio", "En espera de acceso", "Espera Acceso", 3 },
                    { 15, "LocalVacio", "Pase a terminal", "Pase a Terminal", 4 },
                    { 16, "LocalVacio", "Ingreso a terminal", "Ingreso a Terminal", 5 },
                    { 17, "LocalVacio", "Proceso de descarga del contenedor", "Proceso de Descarga", 6 },
                    { 18, "LocalVacio", "Salida a puerto", "Salida a Puerto", 7 },
                    { 19, "LocalVacio", "Servicio local vacío finalizado", "Finalizado", 8 },
                    { 20, "ForaneoLleno", "Proceso de documentación", "Documentación", 1 },
                    { 21, "ForaneoLleno", "Recolección de contenedor en patio", "Recolección en Patio", 2 },
                    { 22, "ForaneoLleno", "Inicio de ruta foránea", "Inicio de Ruta", 3 },
                    { 23, "ForaneoLleno", "Traslado a destino", "Traslado", 4 },
                    { 24, "ForaneoLleno", "Arribo a bodega de destino", "Arribo a Bodega", 5 },
                    { 25, "ForaneoLleno", "Proceso de descarga en bodega", "Proceso de Descarga", 6 },
                    { 26, "ForaneoLleno", "Retorno de la unidad", "Retorno Unidad", 7 },
                    { 27, "ForaneoLleno", "Resguardo del contenedor", "Resguardo de Contenedor", 8 },
                    { 28, "ForaneoLleno", "Servicio foráneo lleno finalizado", "Finalizado", 9 }
                });

            migrationBuilder.InsertData(
                table: "Trip_Type",
                columns: new[] { "Trip_Type_Id", "Active", "Desc", "Name" },
                values: new object[,]
                {
                    { 1, true, "Servicios locales", "Local" },
                    { 2, true, "Servicios foraneos", "Foraneos" }
                });

            migrationBuilder.InsertData(
                table: "Container",
                columns: new[] { "Container_Id", "Active", "Archieve_Request", "Cntr_Document_Recuest", "Cntr_Document_Rfc", "Company_Name", "Container_Number", "Container_Red_Id", "ContainerType_Id", "Container_Type", "Red_Entry_date", "Red_Liberation_date", "Rfc_Company", "Shipping_Line_Id", "Size", "Weight_Kg" },
                values: new object[,]
                {
                    { 1, true, null, null, null, null, "MAEU1234567", null, 1, "Dry", null, null, null, 1, "20", 2200m },
                    { 2, true, null, null, null, null, "MAEU7654321", null, 1, "Dry", null, null, null, 1, "40", 3800m },
                    { 3, true, null, null, null, null, "MSCU9876543", null, 2, "High Cube", null, null, null, 2, "40", 3900m },
                    { 4, true, null, null, null, null, "CMDU1122334", null, 3, "Reefer", null, null, null, 3, "20", 2500m },
                    { 5, true, null, null, null, null, "HLCU5566778", null, 1, "Dry", null, null, null, 4, "40", 3800m },
                    { 6, true, null, null, null, null, "COSU3344556", null, 2, "High Cube", null, null, null, 5, "40", 3900m },
                    { 7, true, null, null, null, null, "EGLV9988776", null, 4, "Open Top", null, null, null, 6, "20", 2400m },
                    { 8, true, null, null, null, null, "ONEY4455667", null, 1, "Dry", null, null, null, 7, "20", 2200m },
                    { 9, true, null, null, null, null, "YMLU6677889", null, 5, "Flat Rack", null, null, null, 8, "40", 4000m },
                    { 10, true, null, null, null, null, "ZIMU1133557", null, 1, "Dry", null, null, null, 9, "40", 3800m }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Emp_Id", "Active", "Birth_Date", "BloodType", "CURP", "Certificated_ForeignDriver", "Comments", "Company", "Drive_License", "Drive_License_DateExp", "Education_level", "Email", "Emp_Cat_Id", "Employee_Number", "Entry_Date", "Full_Name", "Gender", "Guild", "INE", "Last_Name", "Marital_Status", "Middle_Name", "NSS", "Names", "Photo_Url", "RFC", "Salary", "Termination_Date" },
                values: new object[,]
                {
                    { 1, true, null, null, null, null, null, null, null, null, null, "admin@sistema.com", 1, "EMP-001", new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin Sistema Principal", null, null, null, "Principal", null, "Sistema", null, "Admin", null, null, null, null },
                    { 2, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Erineo Carranza Gonzales", null, null, null, "Gonzales", null, "Carranza", null, "Erineo", null, null, null, null },
                    { 3, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2024, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jeremias Salamanca Espinoza", null, null, null, "Espinoza", null, "Salamanca", null, "Jeremias", null, null, null, null },
                    { 4, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 2, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver Miguel Arellano Bravo", null, null, null, "Bravo", null, "Arellano", null, "Oliver Miguel", null, null, null, null },
                    { 5, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Braian Ismael Castillo Gonzales", null, null, null, "Gonzales", null, "Castillo", null, "Braian Ismael", null, null, null, null },
                    { 6, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rafael Alejandro Torres Espino", null, null, null, "Espino", null, "Torres", null, "Rafael Alejandro", null, null, null, null },
                    { 7, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Miguel Angel Torres Lugo", null, null, null, "Lugo", null, "Torres", null, "Miguel Angel", null, null, null, null },
                    { 8, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Juan Carlos Medina Hernandez", null, null, null, "Hernandez", null, "Medina", null, "Juan Carlos", null, null, null, null },
                    { 9, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Abraham Moreno Sanchez", null, null, null, "Sanchez", null, "Moreno", null, "Abraham", null, null, null, null },
                    { 10, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jairo Miguel Garcia Hernandez", null, null, null, "Hernandez", null, "Garcia", null, "Jairo Miguel", null, null, null, null },
                    { 11, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "David Romero Arteaga", null, null, null, "Arteaga", null, "Romero", null, "David", null, null, null, null },
                    { 12, true, null, null, null, false, null, null, null, null, null, null, 2, null, new DateTime(2025, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Oliver Misael Rivera Fuentes", null, null, null, "Fuentes", null, "Rivera", null, "Oliver Misael", null, null, null, null },
                    { 13, true, null, null, null, false, null, null, null, null, null, null, 2, "035", new DateTime(2025, 11, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yair Alejandro Bautista Flores", null, null, null, "Flores", null, "Bautista", null, "Yair Alejandro", null, null, null, null },
                    { 14, true, null, null, null, false, null, null, null, null, null, null, 2, "034", new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lucio Antonio Salazar Baltazar", null, null, null, "Baltazar", null, "Salazar", null, "Lucio Antonio", null, null, null, null },
                    { 15, true, null, null, null, true, null, null, null, null, null, null, 2, null, new DateTime(2024, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gustavo Fernando Pazarin Mejia", null, null, null, "Mejia", null, "Pazarin", null, "Gustavo Fernando", null, null, null, null },
                    { 16, true, null, null, null, true, null, null, null, null, null, null, 2, null, new DateTime(2025, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rafael Regueyra Gomez", null, null, null, "Gomez", null, "Regueyra", null, "Rafael", null, null, null, null },
                    { 17, true, null, null, null, true, null, null, null, null, null, null, 2, null, new DateTime(2025, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kevin Axel Coria Torres", null, null, null, "Torres", null, "Coria", null, "Kevin Axel", null, null, null, null },
                    { 18, true, null, null, null, true, null, null, null, null, null, null, 2, null, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis Antonio Perez Serrano", null, null, null, "Serrano", null, "Perez", null, "Luis Antonio", null, null, null, null },
                    { 19, true, null, null, null, true, null, null, null, null, null, null, 2, null, new DateTime(2026, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Antonio Gutierrez Aguilar", null, null, null, "Aguilar", null, "Gutierrez", null, "Antonio", null, null, null, null },
                    { 20, true, null, null, null, true, null, null, null, null, null, null, 2, null, null, "Ramon Alberto Zamarripa Rodriguez", null, null, null, "Rodriguez", null, "Zamarripa", null, "Ramon Alberto", null, null, null, null },
                    { 21, true, null, null, null, true, null, null, null, null, null, null, 2, null, new DateTime(2025, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Luis Antonio Perez Cardenas", null, null, null, "Cardenas", null, "Perez", null, "Luis Antonio", null, null, null, null },
                    { 22, true, null, null, null, true, null, null, null, null, null, null, 2, null, new DateTime(2024, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Josafat Villa Villaseñor", null, null, null, "Villaseñor", null, "Villa", null, "Josafat", null, null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Terminal",
                columns: new[] { "Terminal_Id", "Active", "Comments", "Logistics_Provider_Id", "Name_Terminal", "Terminal", "Url_Image" },
                values: new object[,]
                {
                    { 1, true, null, 1, "SETRASA", "SET", null },
                    { 2, true, null, 1, "BELUGA", "BEL", null },
                    { 3, true, null, 1, "AT PACIFIC", "ATP", null },
                    { 4, true, null, 1, "RESGUARDO INTELIGENTE (RI)", "RI", null },
                    { 5, true, null, 1, "MANPORT", "MAN", null },
                    { 6, true, null, 1, "LA PALMA CONTAINER", "LPC", null },
                    { 7, true, null, 1, "VAS CONTAINER", "VAS", null },
                    { 8, true, null, 1, "DAMCO", "DAM", null },
                    { 9, true, null, 1, "CIMA", "CIM", null },
                    { 10, true, null, 1, "MAOSA", "MAO", null },
                    { 11, true, null, 1, "VALMARQ", "VAL", null },
                    { 12, true, null, 1, "CALA", "CAL", null },
                    { 13, true, null, 1, "HUTCHISON PORTS", "HUT", null },
                    { 14, true, null, 1, "APM TERMINALS", "APM", null },
                    { 15, true, null, 1, "NKS", "NKS", null },
                    { 16, true, null, 1, "UTTSA", "UTT", null }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Equipment_id", "Active", "AvailablePartners", "Color", "Diesel_capacity", "Economic_Number", "EquipType_id", "Equipment_Status", "Labeled_Unit", "Plates", "Plates_Estate", "terminal_id", "towing_capacity", "Trip_Type_Id" },
                values: new object[,]
                {
                    { 1, true, false, "", null, "VM01", 7, 1, false, "6MM-828-D", null, 11, null, 1 },
                    { 2, true, false, "", null, "VM04", 7, 1, false, "1MN-288-D", null, 11, null, 1 },
                    { 3, true, false, "", null, "VM06", 7, 1, false, "7MM-529-D", null, 11, null, 1 },
                    { 4, true, false, "", null, "VM07", 7, 1, false, "969-WR-2", null, 11, null, 1 },
                    { 5, true, false, "", null, "VM08", 7, 1, false, "97-UM-6Y", null, 11, null, 1 },
                    { 6, true, false, "", null, "VM09", 7, 1, false, "6MM-818-D", null, 11, null, 1 },
                    { 7, true, false, "", null, "VM10", 7, 1, false, "6MM-827-D", null, 11, null, 1 },
                    { 8, true, false, "", null, "VM13", 7, 1, false, "38-UN-4Y", null, 11, null, 1 },
                    { 9, true, false, "", null, "VM14", 7, 1, false, "37-UA-4V", null, 11, null, 1 },
                    { 10, true, false, "", null, "VM15", 7, 1, false, "7MM973-D", null, 11, null, 1 },
                    { 11, true, false, "", null, "VM16", 7, 1, false, "8MM-321-D", null, 11, null, 1 },
                    { 12, true, false, "", null, "VM21", 7, 1, false, "7MM-477-D", null, 11, null, 1 },
                    { 13, true, false, "", null, "VM22", 7, 1, false, "7MM-473-D", null, 11, null, 1 },
                    { 14, true, false, "", null, "VM23", 7, 1, false, "7MM-468-D", null, 11, null, 1 },
                    { 15, true, false, "", null, "VM26 PLANA", 7, 1, false, "09-UP-5X", null, 11, null, 1 },
                    { 16, true, false, "", null, "VM29", 7, 1, false, "7MM-960-D", null, 11, null, 1 },
                    { 17, true, false, "", null, "VM30", 7, 1, false, "7MM-961-D", null, 11, null, 1 },
                    { 18, true, false, "", null, "VM31", 7, 1, false, "6ML-081-D", null, 11, null, 1 },
                    { 19, true, false, "", null, "VM33", 7, 1, false, "MM-969-D", null, 11, null, 1 },
                    { 20, true, false, "", null, "VM34", 7, 1, false, "7MM-970-D", null, 11, null, 1 },
                    { 21, true, false, "", null, "VM35", 7, 1, false, "MM-962-D", null, 11, null, 1 },
                    { 22, true, false, "", null, "VM39", 7, 1, false, "8MM-325-D", null, 11, null, 1 },
                    { 23, true, false, "", null, "VM41", 7, 1, false, "28-AP-6V", null, 11, null, 1 },
                    { 24, true, false, "", null, "VM44", 7, 1, false, "9MM-710-D", null, 11, null, 1 },
                    { 25, true, false, "", null, "VM45", 7, 1, false, "9MM-711-D", null, 11, null, 1 },
                    { 26, true, false, "", null, "VM46", 7, 1, false, "81-AP-6V", null, 11, null, 1 },
                    { 27, true, false, "", null, "CH01JM", 7, 1, false, "2GK003A", null, 11, null, 1 },
                    { 28, true, false, "", null, "CH57", 7, 1, false, "38-UN-4Y", null, 11, null, 1 },
                    { 29, true, false, "", null, "CH54", 7, 1, false, "37-UA-4V", null, 11, null, 1 },
                    { 30, true, false, "", null, "CH55", 7, 1, false, "NH-4360-C", null, 11, null, 1 },
                    { 31, true, false, "", null, "CHAZUL NUEVO58", 7, 1, false, "NH-4710-C", null, 11, null, 1 },
                    { 32, true, false, "", null, "CHNUEVO59", 7, 1, false, "SIN PLACAS", null, 11, null, 1 },
                    { 33, true, false, "", null, "VM11", 7, 1, false, "74-UU-7P", null, 11, null, 2 },
                    { 34, true, false, "", null, "VM12", 7, 1, false, "75-UU-7P", null, 11, null, 2 },
                    { 35, true, false, "", null, "VM18", 7, 1, false, "59-UP-3Z", null, 11, null, 2 },
                    { 36, true, false, "", null, "VM19", 7, 1, false, "30-UP-3Z", null, 11, null, 2 },
                    { 37, true, false, "", null, "VM20", 7, 1, false, "29-UP-3Z", null, 11, null, 2 },
                    { 38, true, false, "", null, "VM24", 7, 1, false, "697-YH-7", null, 11, null, 2 },
                    { 39, true, false, "", null, "VM36", 7, 1, false, "79UX5C", null, 11, null, 2 },
                    { 40, true, false, "", null, "VM37", 7, 1, false, "78UXSC", null, 11, null, 2 },
                    { 41, true, false, "", null, "VM38", 7, 1, false, "80-UX-5C", null, 11, null, 2 },
                    { 42, true, false, "", null, "VM40", 7, 1, false, "77UX5C", null, 11, null, 2 },
                    { 43, true, false, "", null, "VM42", 7, 1, false, "ARENDADO", null, 11, null, 2 },
                    { 44, true, false, "", null, "VM43", 7, 1, false, "023-YJ-3", null, 11, null, 2 },
                    { 45, true, false, "", null, "VM48", 7, 1, false, "94UY8F", null, 11, null, 2 },
                    { 46, true, false, "", null, "VM49", 7, 1, false, "93UY8T", null, 11, null, 2 },
                    { 47, true, false, "", null, "VM50", 7, 1, false, "46-UZ-2M", null, 11, null, 2 },
                    { 48, true, false, "", null, "VM51", 7, 1, false, "47-UZ-2M", null, 11, null, 2 },
                    { 49, true, false, "", null, "VM52", 7, 1, false, "31VA1M", null, 11, null, 2 },
                    { 50, true, false, "", null, "VM53", 7, 1, false, "28VA1M", null, 11, null, 2 },
                    { 51, true, false, "", null, "VM56", 7, 1, false, "26VA1M", null, 11, null, 2 },
                    { 52, true, false, "", null, "VM47", 7, 1, false, "65UU6D", null, 11, null, 2 },
                    { 53, true, false, "", null, "VM54", 7, 1, false, "37-UA-4V", null, 11, null, 2 },
                    { 54, true, false, "", null, "VM55", 7, 1, false, "NH-4360-C", null, 11, null, 2 },
                    { 55, true, false, "", null, "VM57", 7, 1, false, "38-UN-4Y", null, 11, null, 2 },
                    { 56, true, false, "", null, "VM58", 7, 1, false, "NH-4710-C", null, 11, null, 2 },
                    { 57, true, false, "", null, "VM59", 7, 1, false, "NH-4360-C", null, 11, null, 2 },
                    { 58, true, false, "", null, "VMD02", 8, 1, false, "", null, 11, null, 1 },
                    { 59, true, false, "", null, "VMD03", 8, 1, false, "", null, 11, null, 1 },
                    { 60, true, false, "", null, "VMD04", 8, 1, false, "", null, 11, null, 1 },
                    { 61, true, false, "", null, "VMD04", 8, 1, false, "", null, 11, null, 1 },
                    { 62, true, false, "", null, "VMD05", 8, 1, false, "", null, 11, null, 1 },
                    { 63, true, false, "", null, "DL S/N JM PONER EL ECO VMD06", 8, 1, false, "", null, 11, null, 1 },
                    { 64, true, false, "", null, "VMD07", 8, 1, false, "", null, 11, null, 1 },
                    { 65, true, false, "", null, "VMD08", 8, 1, false, "", null, 11, null, 1 },
                    { 66, true, false, "", null, "VM09", 8, 1, false, "", null, 11, null, 1 },
                    { 67, true, false, "", null, "VMD10", 8, 1, false, "", null, 11, null, 1 },
                    { 68, true, false, "", null, "VMD13", 8, 1, false, "", null, 11, null, 1 },
                    { 69, true, false, "", null, "VMD14", 8, 1, false, "", null, 11, null, 1 },
                    { 70, true, false, "", null, "VMD15", 8, 1, false, "", null, 11, null, 1 },
                    { 71, true, false, "", null, "VMD16", 8, 1, false, "", null, 11, null, 1 },
                    { 72, true, false, "", null, "VMD17", 8, 1, false, "", null, 11, null, 1 },
                    { 73, true, false, "", null, "DL02", 8, 1, false, "", null, 11, null, 2 },
                    { 74, true, false, "", null, "DL03", 8, 1, false, "", null, 11, null, 2 },
                    { 75, true, false, "", null, "DL11", 8, 1, false, "", null, 11, null, 2 },
                    { 76, true, false, "", null, "DL12", 8, 1, false, "", null, 11, null, 2 },
                    { 77, true, false, "", null, "DL15", 8, 1, false, "", null, 11, null, 2 },
                    { 78, true, false, "", null, "DL16", 8, 1, false, "", null, 11, null, 2 },
                    { 79, true, false, "", null, "DL D-03 (DL18)", 8, 1, false, "", null, 11, null, 2 },
                    { 80, true, null, "#FFFFFF", null, "001VM", 1, 1, null, "NC0379C", null, 11, null, 1 },
                    { 81, true, null, "#0000FF", null, "004VM", 1, 1, null, "NS6913C", null, 11, null, 1 },
                    { 82, true, null, "#0000FF", null, "006VM", 1, 1, null, "NN9650B", null, 11, null, 1 },
                    { 83, true, null, "#FFFFFF", null, "007VM", 1, 1, null, "NB2438D", null, 11, null, 1 },
                    { 84, true, null, "#FFFFFF", null, "009VM", 1, 1, null, "NS6908C", null, 11, null, 1 },
                    { 85, true, null, "#800080", null, "010VM", 1, 1, null, "68BJ8L", null, 11, null, 1 },
                    { 86, true, null, "#FF0000", null, "011VM", 1, 1, null, "NS6980C", null, 11, null, 1 },
                    { 87, true, null, "#FFFFFF", null, "012VM", 1, 1, null, "NH3940C", null, 11, null, 1 },
                    { 88, true, null, "#FFFFFF", null, "013VM", 1, 1, null, "NS7083C", null, 11, null, 1 },
                    { 89, true, null, "#808080", null, "014VM", 1, 1, null, "NH4608C", null, 11, null, 1 },
                    { 90, true, null, "#000000", null, "033VM", 1, 1, null, "NT9927B", null, 11, null, 1 },
                    { 91, true, null, "#808080", null, "035VM", 1, 1, null, "NH9069B", null, 11, null, 1 },
                    { 92, true, null, "#FF0000", null, "034VM", 1, 1, null, "NH9069B", null, 11, null, 1 },
                    { 93, true, false, "#FFFFFF", null, "101VM", 1, 1, false, "66-BG-9F", null, 11, null, 2 },
                    { 94, true, false, "#FF0000", null, "02VM", 1, 1, false, "67-BJ-8L", null, 11, null, 2 },
                    { 95, true, false, "#FFFFFF", null, "103VMF", 1, 1, false, "30-AX-8E", null, 11, null, 2 },
                    { 96, true, false, "#FFFFFF", null, "104VMF", 1, 1, false, "91AY4M", null, 11, null, 2 },
                    { 97, true, false, "#FFFFFF", null, "105VM", 1, 1, false, "79-BG-4X", null, 11, null, 2 },
                    { 98, true, false, "#FFFFFF", null, "106VM", 1, 1, false, "87-BG-7A", null, 11, null, 2 },
                    { 99, true, false, "#FFFFFF", null, "107VM", 1, 1, false, "86-BG-7A", null, 11, null, 2 },
                    { 100, true, false, "#FF0000", null, "108VM", 1, 1, false, "82BL2C", null, 11, null, 2 },
                    { 101, true, false, "#FFFFFF", null, "109VM", 1, 1, false, "98BL2C", null, 11, null, 2 },
                    { 102, true, false, "#FF0000", null, "110VM", 1, 1, false, "66-BJ-8L", null, 11, null, 2 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "User_Id", "Active", "Comments", "Emp_Id", "Password", "Token_id", "Username" },
                values: new object[] { 1, true, null, 1, "$2b$12$FiMusG28CiTnNFIQOBnxgutrY.y6ovbZINPT0IBDUw5fKvEshEg5m", null, "Administrador" });

            migrationBuilder.InsertData(
                table: "User_Rol",
                columns: new[] { "User_Rol_Id", "Active", "Assign_Date", "Rol_Id", "User_Id" },
                values: new object[] { 1, true, new DateTime(2026, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_Terminal_Terminal_Id",
                table: "Appointment_Terminal",
                column: "Terminal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Assigned_Equipment_Equipment_Id",
                table: "Assigned_Equipment",
                column: "Equipment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Assigned_Equipment_Service_Id",
                table: "Assigned_Equipment",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Assigned_Operator_Emp_Id",
                table: "Assigned_Operator",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Assigned_Operator_Service_Id",
                table: "Assigned_Operator",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Container_Container_Red_Id",
                table: "Container",
                column: "Container_Red_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Container_ContainerType_Id",
                table: "Container",
                column: "ContainerType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Container_Shipping_Line_Id",
                table: "Container",
                column: "Shipping_Line_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Container_Seals_Container_Id",
                table: "Container_Seals",
                column: "Container_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Customer_Id",
                table: "Contract",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Status_Contract_Id",
                table: "Contract",
                column: "Status_Contract_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Status_Customer_Id",
                table: "Contract",
                column: "Status_Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_Credit_Type_Id",
                table: "Credit",
                column: "Credit_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_CreditStatus_id",
                table: "Credit",
                column: "CreditStatus_id");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_Customer_Credit_id",
                table: "Credit_Customer",
                column: "Credit_id");

            migrationBuilder.CreateIndex(
                name: "IX_Credit_Customer_Customer_id",
                table: "Credit_Customer",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Actual_Executive_id",
                table: "Customer",
                column: "Actual_Executive_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_paymentTerm_id",
                table: "Customer",
                column: "paymentTerm_id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Trip_Type_Id",
                table: "Customer",
                column: "Trip_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Comment_Comment_Id",
                table: "Customer_Comment",
                column: "Comment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Comment_Customer_Id",
                table: "Customer_Comment",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_File_Cust_Doc_Id",
                table: "Customer_File",
                column: "Cust_Doc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_File_Customer_Id",
                table: "Customer_File",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Type_Cust_Parent_FF",
                table: "Customer_Type",
                column: "Cust_Parent_FF");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_Type_Customer_Id",
                table: "Customer_Type",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DateEvents_Type_Status_Id",
                table: "DateEvents_Type",
                column: "Status_Id");

            migrationBuilder.CreateIndex(
                name: "IX_DateEvents_Type_User_Report_Id",
                table: "DateEvents_Type",
                column: "User_Report_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Emp_Cat_Id",
                table: "Employee",
                column: "Emp_Cat_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Category_Category",
                table: "Employee_Category",
                column: "Category",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Disabled_Emp_Id",
                table: "Employee_Disabled",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Equipment_Status",
                table: "Equipment",
                column: "Equipment_Status");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipType_id",
                table: "Equipment",
                column: "EquipType_id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_terminal_id",
                table: "Equipment",
                column: "terminal_id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Trip_Type_Id",
                table: "Equipment",
                column: "Trip_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_File_Eqpm_Doc_Id",
                table: "Equipment_File",
                column: "Eqpm_Doc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_File_Equipment_id",
                table: "Equipment_File",
                column: "Equipment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Repair_log_Equipment_Id",
                table: "Equipment_Repair_log",
                column: "Equipment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Type_LogisticsProviderId",
                table: "Equipment_Type",
                column: "LogisticsProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Forbidden_Employee_Emp_Id",
                table: "Forbidden_Employee",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Forbidden_Employee_Terminal_Id",
                table: "Forbidden_Employee",
                column: "Terminal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Full_Empty_Container_Id",
                table: "Full_Empty",
                column: "Container_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Full_Empty_Service_Id",
                table: "Full_Empty",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Industry_Type_Customer_Id",
                table: "Industry_Type",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Contract_Client_Condition_Id",
                table: "Items_Contract",
                column: "Client_Condition_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Contract_Contract_Id",
                table: "Items_Contract",
                column: "Contract_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Contract_Items_Catalog_Id",
                table: "Items_Contract",
                column: "Items_Catalog_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Contract_Status_Id",
                table: "Items_Contract",
                column: "Status_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Layout_Name_Terminal_Id",
                table: "Layout_Name",
                column: "Terminal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loose_Commodity_Packaging_Type_Id",
                table: "Loose_Commodity",
                column: "Packaging_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Loose_Commodity_Service_Id",
                table: "Loose_Commodity",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Operator_Equipment_Assigned_Equipment_Id",
                table: "Operator_Equipment",
                column: "Assigned_Equipment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Operator_Equipment_Assigned_Operator_Id",
                table: "Operator_Equipment",
                column: "Assigned_Operator_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Addresses_Customer_Id",
                table: "Personal_Addresses",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Addresses_Emp_Id",
                table: "Personal_Addresses",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Addresses_Logistics_Provider_Id",
                table: "Personal_Addresses",
                column: "Logistics_Provider_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Addresses_Terminal_Id",
                table: "Personal_Addresses",
                column: "Terminal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Contact_Customer_Id",
                table: "Personal_Contact",
                column: "Customer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Contact_Emp_Id",
                table: "Personal_Contact",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Contact_Logistics_Provider_Id",
                table: "Personal_Contact",
                column: "Logistics_Provider_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_Contact_Terminal_Id",
                table: "Personal_Contact",
                column: "Terminal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProvideLogistic_Comments_Comment_Id",
                table: "ProvideLogistic_Comments",
                column: "Comment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProvideLogistic_Comments_ProvLog_Id",
                table: "ProvideLogistic_Comments",
                column: "ProvLog_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Road_Routes_Terminal_Destino_Id",
                table: "Road_Routes",
                column: "Terminal_Destino_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Road_Routes_Terminal_Origen_Id",
                table: "Road_Routes",
                column: "Terminal_Origen_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Services_Road_Routes_Id",
                table: "Routes_Services",
                column: "Road_Routes_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_Services_Service_Id",
                table: "Routes_Services",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduleded_Appointment_Appo_Terminal_Id",
                table: "Scheduleded_Appointment",
                column: "Appo_Terminal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduleded_Appointment_Container_Id",
                table: "Scheduleded_Appointment",
                column: "Container_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduleded_Appointment_Full_Empty_Id",
                table: "Scheduleded_Appointment",
                column: "Full_Empty_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Scheduleded_Appointment_Services_DateEvents",
                table: "Scheduleded_Appointment",
                column: "Services_DateEvents");

            migrationBuilder.CreateIndex(
                name: "IX_Service_Event_ServiceEventTypeId",
                table: "Service_Event",
                column: "ServiceEventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceEvent_Service_Id",
                table: "Service_ServiceEvent",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceEvent_ServiceEventId",
                table: "Service_ServiceEvent",
                column: "ServiceEventId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_ServiceEvent_ServiceId1",
                table: "Service_ServiceEvent",
                column: "ServiceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Container_Id",
                table: "Services",
                column: "Container_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Customer_id",
                table: "Services",
                column: "Customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Equipament_Id",
                table: "Services",
                column: "Equipament_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_StatusServiceId",
                table: "Services",
                column: "StatusServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Trip_Type_Id",
                table: "Services",
                column: "Trip_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Comment_Coment_Id",
                table: "Services_Comment",
                column: "Coment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_Comment_Service_Id",
                table: "Services_Comment",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DateEvents_DateEvents_Type_Id",
                table: "Services_DateEvents",
                column: "DateEvents_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DateEvents_Event_Classification_Id",
                table: "Services_DateEvents",
                column: "Event_Classification_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Services_DateEvents_Service_Id",
                table: "Services_DateEvents",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Logistics_Provider_Id",
                table: "Terminal",
                column: "Logistics_Provider_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Ticket_Container1_Id",
                table: "Terminal_Ticket",
                column: "Container1_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Ticket_Container2_Id",
                table: "Terminal_Ticket",
                column: "Container2_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Ticket_Operator_Equipment_Id",
                table: "Terminal_Ticket",
                column: "Operator_Equipment_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Ticket_Service_Id",
                table: "Terminal_Ticket",
                column: "Service_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Ticket_Terminal_Id",
                table: "Terminal_Ticket",
                column: "Terminal_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Emp_Id",
                table: "User",
                column: "Emp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_Rol_Rol_Id",
                table: "User_Rol",
                column: "Rol_Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Rol_User_Id",
                table: "User_Rol",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Container_Seals");

            migrationBuilder.DropTable(
                name: "Credit_Customer");

            migrationBuilder.DropTable(
                name: "Customer_Comment");

            migrationBuilder.DropTable(
                name: "Customer_File");

            migrationBuilder.DropTable(
                name: "Customer_Type");

            migrationBuilder.DropTable(
                name: "Employee_Disabled");

            migrationBuilder.DropTable(
                name: "Equipment_File");

            migrationBuilder.DropTable(
                name: "Equipment_Repair_log");

            migrationBuilder.DropTable(
                name: "Forbidden_Employee");

            migrationBuilder.DropTable(
                name: "IMO");

            migrationBuilder.DropTable(
                name: "Industry_Type");

            migrationBuilder.DropTable(
                name: "Items_Contract");

            migrationBuilder.DropTable(
                name: "Layout_Name");

            migrationBuilder.DropTable(
                name: "Loose_Commodity");

            migrationBuilder.DropTable(
                name: "Personal_Addresses");

            migrationBuilder.DropTable(
                name: "Personal_Contact");

            migrationBuilder.DropTable(
                name: "ProvideLogistic_Comments");

            migrationBuilder.DropTable(
                name: "Routes_Services");

            migrationBuilder.DropTable(
                name: "Scheduleded_Appointment");

            migrationBuilder.DropTable(
                name: "Service_ServiceEvent");

            migrationBuilder.DropTable(
                name: "Services_Comment");

            migrationBuilder.DropTable(
                name: "Terminal_Ticket");

            migrationBuilder.DropTable(
                name: "User_Rol");

            migrationBuilder.DropTable(
                name: "Credit");

            migrationBuilder.DropTable(
                name: "Customer_Document");

            migrationBuilder.DropTable(
                name: "Equipment_Document");

            migrationBuilder.DropTable(
                name: "Client_Condition");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropTable(
                name: "Items_Catalog");

            migrationBuilder.DropTable(
                name: "Packaging_Type");

            migrationBuilder.DropTable(
                name: "Road_Routes");

            migrationBuilder.DropTable(
                name: "Appointment_Terminal");

            migrationBuilder.DropTable(
                name: "Full_Empty");

            migrationBuilder.DropTable(
                name: "Services_DateEvents");

            migrationBuilder.DropTable(
                name: "Service_Event");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Operator_Equipment");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "Credit_Status");

            migrationBuilder.DropTable(
                name: "Credit_Type");

            migrationBuilder.DropTable(
                name: "DateEvents_Type");

            migrationBuilder.DropTable(
                name: "Event_Classification");

            migrationBuilder.DropTable(
                name: "Service_Event_Type");

            migrationBuilder.DropTable(
                name: "Assigned_Equipment");

            migrationBuilder.DropTable(
                name: "Assigned_Operator");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Container");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Status_Service");

            migrationBuilder.DropTable(
                name: "Container_Type");

            migrationBuilder.DropTable(
                name: "Shipping_Line");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Payment_Terms");

            migrationBuilder.DropTable(
                name: "Equipment_Status");

            migrationBuilder.DropTable(
                name: "Equipment_Type");

            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropTable(
                name: "Trip_Type");

            migrationBuilder.DropTable(
                name: "Employee_Category");

            migrationBuilder.DropTable(
                name: "Logistics_Provider");
        }
    }
}
