﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace DevOps.Util.DotNet.Triage.Migrations
{
    public partial class IncludeGitHubIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "GitHubRepository",
                table: "ModelTrackingIssues",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GitHubOrganization",
                table: "ModelTrackingIssues",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModelGitHubIssueId",
                table: "ModelTrackingIssues",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GitHubRepository",
                table: "ModelBuilds",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GitHubOrganization",
                table: "ModelBuilds",
                type: "nvarchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ModelGitHubIssue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Organization = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Repository = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Number = table.Column<int>(nullable: false),
                    ModelBuildId = table.Column<int>(nullable: false),
                    ModelBuildId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelGitHubIssue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModelGitHubIssue_ModelBuilds_ModelBuildId1",
                        column: x => x.ModelBuildId1,
                        principalTable: "ModelBuilds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ModelTrackingIssues_ModelGitHubIssueId",
                table: "ModelTrackingIssues",
                column: "ModelGitHubIssueId");

            migrationBuilder.CreateIndex(
                name: "IX_ModelGitHubIssue_ModelBuildId1",
                table: "ModelGitHubIssue",
                column: "ModelBuildId1");

            migrationBuilder.CreateIndex(
                name: "IX_ModelGitHubIssue_Organization_Repository_Number_ModelBuildId",
                table: "ModelGitHubIssue",
                columns: new[] { "Organization", "Repository", "Number", "ModelBuildId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ModelTrackingIssues_ModelGitHubIssue_ModelGitHubIssueId",
                table: "ModelTrackingIssues",
                column: "ModelGitHubIssueId",
                principalTable: "ModelGitHubIssue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModelTrackingIssues_ModelGitHubIssue_ModelGitHubIssueId",
                table: "ModelTrackingIssues");

            migrationBuilder.DropTable(
                name: "ModelGitHubIssue");

            migrationBuilder.DropIndex(
                name: "IX_ModelTrackingIssues_ModelGitHubIssueId",
                table: "ModelTrackingIssues");

            migrationBuilder.DropColumn(
                name: "ModelGitHubIssueId",
                table: "ModelTrackingIssues");

            migrationBuilder.AlterColumn<string>(
                name: "GitHubRepository",
                table: "ModelTrackingIssues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GitHubOrganization",
                table: "ModelTrackingIssues",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GitHubRepository",
                table: "ModelBuilds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GitHubOrganization",
                table: "ModelBuilds",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldNullable: true);
        }
    }
}
