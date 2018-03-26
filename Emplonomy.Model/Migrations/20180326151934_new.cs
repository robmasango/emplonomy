using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Emplonomy.Model.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "AddressType",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressTypeDesc = table.Column<string>(maxLength: 100, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Error",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2018, 3, 26, 17, 19, 34, 231, DateTimeKind.Local)),
                    Message = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Error", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<int>(maxLength: 100, nullable: false),
                    Town = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PasswordQsBank",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PasswordQuestion = table.Column<string>(maxLength: 100, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordQsBank", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Provisioned",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmailAddress = table.Column<string>(maxLength: 100, nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provisioned", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Val = table.Column<decimal>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SendSmsStatus",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StatusDesc = table.Column<string>(maxLength: 100, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendSmsStatus", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ShortMessage",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    isDeleted = table.Column<bool>(nullable: true),
                    smsText = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortMessage", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyFrequency",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    NumQuestions = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyFrequency", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SurveyQuestion",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Driver = table.Column<string>(nullable: true),
                    Question = table.Column<string>(nullable: true),
                    QuestionOrder = table.Column<int>(nullable: false),
                    QuestionType = table.Column<string>(nullable: true),
                    SubDriver = table.Column<string>(nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyQuestion", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organisation",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Industry = table.Column<string>(nullable: true),
                    LocationID = table.Column<int>(nullable: false),
                    OrganisationName = table.Column<string>(maxLength: 100, nullable: true),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organisation", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Organisation_Location_LocationID",
                        column: x => x.LocationID,
                        principalSchema: "dbo",
                        principalTable: "Location",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(maxLength: 100, nullable: true),
                    OrganisationID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Department_Organisation_OrganisationID",
                        column: x => x.OrganisationID,
                        principalSchema: "dbo",
                        principalTable: "Organisation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Survey",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FrequencyID = table.Column<int>(nullable: false),
                    OrganisationID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Survey_SurveyFrequency_FrequencyID",
                        column: x => x.FrequencyID,
                        principalSchema: "dbo",
                        principalTable: "SurveyFrequency",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Survey_Organisation_OrganisationID",
                        column: x => x.OrganisationID,
                        principalSchema: "dbo",
                        principalTable: "Organisation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmplonomyUser",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AgreeTC = table.Column<bool>(nullable: true),
                    AvatarURL = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Birthdate = table.Column<DateTime>(nullable: true),
                    ConfirmedReg = table.Column<bool>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2018, 3, 26, 17, 19, 34, 236, DateTimeKind.Local)),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmailAddressAlt = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    FailedPasswordAttempts = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    HireDate = table.Column<DateTime>(nullable: true),
                    IDNumber = table.Column<string>(type: "nvarchar(13)", nullable: true),
                    IsLocked = table.Column<bool>(nullable: false),
                    IsLoggedin = table.Column<bool>(nullable: false),
                    LastLoginDate = table.Column<DateTime>(nullable: true, defaultValue: new DateTime(2018, 3, 26, 17, 19, 34, 236, DateTimeKind.Local)),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PasswordAnswer = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PasswordQsBankID = table.Column<int>(nullable: true),
                    PasswordQuestionID = table.Column<int>(type: "int", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhoneCell = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhoneHome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    PhoneWork = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ResignationDate = table.Column<DateTime>(nullable: true),
                    Salary = table.Column<decimal>(type: "Money", nullable: false, defaultValue: 0m),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    isDeleted = table.Column<bool>(nullable: true),
                    isManager = table.Column<bool>(nullable: false),
                    isOrgManager = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmplonomyUser", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmplonomyUser_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmplonomyUser_PasswordQsBank_PasswordQsBankID",
                        column: x => x.PasswordQsBankID,
                        principalSchema: "dbo",
                        principalTable: "PasswordQsBank",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SendShortMessage",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SurveyID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true),
                    smsID = table.Column<int>(nullable: false),
                    smsStatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendShortMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SendShortMessage_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalSchema: "dbo",
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SendShortMessage_ShortMessage_smsID",
                        column: x => x.smsID,
                        principalSchema: "dbo",
                        principalTable: "ShortMessage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SendShortMessage_SendSmsStatus_smsStatusID",
                        column: x => x.smsStatusID,
                        principalSchema: "dbo",
                        principalTable: "SendSmsStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentManager",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartmentID = table.Column<int>(nullable: false),
                    ManagerID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentManager", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DepartmentManager_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalSchema: "dbo",
                        principalTable: "Department",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DepartmentManager_EmplonomyUser_ManagerID",
                        column: x => x.ManagerID,
                        principalSchema: "dbo",
                        principalTable: "EmplonomyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganisationManager",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ManagerID = table.Column<int>(nullable: false),
                    OrganisationID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganisationManager", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OrganisationManager_EmplonomyUser_ManagerID",
                        column: x => x.ManagerID,
                        principalSchema: "dbo",
                        principalTable: "EmplonomyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganisationManager_Organisation_OrganisationID",
                        column: x => x.OrganisationID,
                        principalSchema: "dbo",
                        principalTable: "Organisation",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SurveyResponse",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    SurveyID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyResponse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SurveyResponse_SurveyQuestion_QuestionID",
                        column: x => x.QuestionID,
                        principalSchema: "dbo",
                        principalTable: "SurveyQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyResponse_Survey_SurveyID",
                        column: x => x.SurveyID,
                        principalSchema: "dbo",
                        principalTable: "Survey",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyResponse_EmplonomyUser_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "EmplonomyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserAddress",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressTypeID = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    PrefferedAddress = table.Column<bool>(nullable: true),
                    Province = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    UserID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAddress", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserAddress_AddressType_AddressTypeID",
                        column: x => x.AddressTypeID,
                        principalSchema: "dbo",
                        principalTable: "AddressType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserAddress_EmplonomyUser_UserID",
                        column: x => x.UserID,
                        principalSchema: "dbo",
                        principalTable: "EmplonomyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmplonomyUserID = table.Column<int>(nullable: true),
                    RoleID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: false),
                    isDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UserRole_EmplonomyUser_EmplonomyUserID",
                        column: x => x.EmplonomyUserID,
                        principalSchema: "dbo",
                        principalTable: "EmplonomyUser",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleID",
                        column: x => x.RoleID,
                        principalSchema: "dbo",
                        principalTable: "Role",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_OrganisationID",
                schema: "dbo",
                table: "Department",
                column: "OrganisationID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentManager_DepartmentID",
                schema: "dbo",
                table: "DepartmentManager",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentManager_ManagerID",
                schema: "dbo",
                table: "DepartmentManager",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_EmplonomyUser_DepartmentID",
                schema: "dbo",
                table: "EmplonomyUser",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_EmplonomyUser_PasswordQsBankID",
                schema: "dbo",
                table: "EmplonomyUser",
                column: "PasswordQsBankID");

            migrationBuilder.CreateIndex(
                name: "IX_Organisation_LocationID",
                schema: "dbo",
                table: "Organisation",
                column: "LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationManager_ManagerID",
                schema: "dbo",
                table: "OrganisationManager",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_OrganisationManager_OrganisationID",
                schema: "dbo",
                table: "OrganisationManager",
                column: "OrganisationID");

            migrationBuilder.CreateIndex(
                name: "IX_SendShortMessage_SurveyID",
                schema: "dbo",
                table: "SendShortMessage",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_SendShortMessage_smsID",
                schema: "dbo",
                table: "SendShortMessage",
                column: "smsID");

            migrationBuilder.CreateIndex(
                name: "IX_SendShortMessage_smsStatusID",
                schema: "dbo",
                table: "SendShortMessage",
                column: "smsStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_FrequencyID",
                schema: "dbo",
                table: "Survey",
                column: "FrequencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_OrganisationID",
                schema: "dbo",
                table: "Survey",
                column: "OrganisationID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponse_QuestionID",
                schema: "dbo",
                table: "SurveyResponse",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponse_SurveyID",
                schema: "dbo",
                table: "SurveyResponse",
                column: "SurveyID");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyResponse_UserID",
                schema: "dbo",
                table: "SurveyResponse",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_AddressTypeID",
                schema: "dbo",
                table: "UserAddress",
                column: "AddressTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_UserAddress_UserID",
                schema: "dbo",
                table: "UserAddress",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_EmplonomyUserID",
                schema: "dbo",
                table: "UserRole",
                column: "EmplonomyUserID");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleID",
                schema: "dbo",
                table: "UserRole",
                column: "RoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentManager",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Error",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OrganisationManager",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Provisioned",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SendShortMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SurveyResponse",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserAddress",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRole",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ShortMessage",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SendSmsStatus",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SurveyQuestion",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Survey",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "AddressType",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EmplonomyUser",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SurveyFrequency",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Department",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PasswordQsBank",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Organisation",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Location",
                schema: "dbo");
        }
    }
}
