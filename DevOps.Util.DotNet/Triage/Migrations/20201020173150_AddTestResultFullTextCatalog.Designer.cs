﻿// <auto-generated />
using System;
using DevOps.Util.DotNet.Triage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DevOps.Util.DotNet.Triage.Migrations
{
    [DbContext(typeof(TriageContext))]
    [Migration("20201020173150_AddTestResultFullTextCatalog")]
    partial class AddTestResultFullTextCatalog
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuild", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("AzureOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AzureProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BuildNumber")
                        .HasColumnType("int");

                    b.Property<string>("BuildResult")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("GitHubOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHubRepository")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHubTargetBranch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMergedPullRequest")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ModelBuildDefinitionId")
                        .HasColumnType("int");

                    b.Property<int?>("PullRequestNumber")
                        .HasColumnType("int");

                    b.Property<DateTime?>("QueueTime")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildDefinitionId");

                    b.ToTable("ModelBuilds");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuildAttempt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt")
                        .HasColumnType("int");

                    b.Property<int>("BuildResult")
                        .HasColumnType("int");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool>("IsTimelineMissing")
                        .HasColumnType("bit");

                    b.Property<string>("ModelBuildId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.HasIndex("Attempt", "ModelBuildId")
                        .IsUnique()
                        .HasFilter("[ModelBuildId] IS NOT NULL");

                    b.ToTable("ModelBuildAttempts");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuildDefinition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AzureOrganization")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AzureProject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("DefinitionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AzureOrganization", "AzureProject", "DefinitionId")
                        .IsUnique()
                        .HasFilter("[AzureOrganization] IS NOT NULL AND [AzureProject] IS NOT NULL");

                    b.ToTable("ModelBuildDefinitions");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelOsxDeprovisionRetry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("JobFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ModelBuildId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OsxJobFailedCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.ToTable("ModelOsxDeprovisionRetry");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTestResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixConsoleUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixCoreDumpUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixRunClientUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HelixTestResultsUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsHelixTestResult")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubResult")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSubResultContainer")
                        .HasColumnType("bit");

                    b.Property<string>("ModelBuildId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ModelTestRunId")
                        .HasColumnType("int");

                    b.Property<string>("Outcome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TestFullName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.HasIndex("ModelTestRunId");

                    b.ToTable("ModelTestResults");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTestRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("AzureOrganization")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("AzureProject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ModelBuildId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TestRunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildId");

                    b.HasIndex("AzureOrganization", "AzureProject", "TestRunId")
                        .IsUnique()
                        .HasFilter("[AzureOrganization] IS NOT NULL AND [AzureProject] IS NOT NULL");

                    b.ToTable("ModelTestRuns");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTimelineIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Attempt")
                        .HasColumnType("int");

                    b.Property<string>("IssueType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(12)")
                        .HasDefaultValue("Warning");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<string>("ModelBuildId")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RecordId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecordName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("ModelBuildId");

                    b.ToTable("ModelTimelineIssues");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GitHubIssueNumber")
                        .HasColumnType("int");

                    b.Property<string>("GitHubOrganization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHubRepository")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("IssueTitle")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ModelBuildDefinitionId")
                        .HasColumnType("int");

                    b.Property<string>("SearchRegexText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrackingKind")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildDefinitionId");

                    b.ToTable("ModelTrackingIssues");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssueMatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HelixLogUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelTestResultId")
                        .HasColumnType("int");

                    b.Property<int?>("ModelTimelineIssueId")
                        .HasColumnType("int");

                    b.Property<int>("ModelTrackingIssueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("ModelTestResultId");

                    b.HasIndex("ModelTimelineIssueId");

                    b.HasIndex("ModelTrackingIssueId");

                    b.ToTable("ModelTrackingIssueMatches");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssueResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsPresent")
                        .HasColumnType("bit");

                    b.Property<int>("ModelBuildAttemptId")
                        .HasColumnType("int");

                    b.Property<int>("ModelTrackingIssueId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModelBuildAttemptId");

                    b.HasIndex("ModelTrackingIssueId", "ModelBuildAttemptId")
                        .IsUnique();

                    b.ToTable("ModelTrackingIssueResults");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuild", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildDefinition", "ModelBuildDefinition")
                        .WithMany()
                        .HasForeignKey("ModelBuildDefinitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelBuildAttempt", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany("ModelBuildAttempts")
                        .HasForeignKey("ModelBuildId");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelOsxDeprovisionRetry", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany()
                        .HasForeignKey("ModelBuildId");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTestResult", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany("ModelTestResults")
                        .HasForeignKey("ModelBuildId");

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTestRun", "ModelTestRun")
                        .WithMany()
                        .HasForeignKey("ModelTestRunId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTestRun", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany()
                        .HasForeignKey("ModelBuildId");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTimelineIssue", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany("ModelTimelineIssues")
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuild", "ModelBuild")
                        .WithMany("ModelTimelineIssues")
                        .HasForeignKey("ModelBuildId");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssue", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildDefinition", "ModelBuildDefinition")
                        .WithMany()
                        .HasForeignKey("ModelBuildDefinitionId");
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssueMatch", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany("ModelTrackingIssueMatches")
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTestResult", "ModelTestResult")
                        .WithMany()
                        .HasForeignKey("ModelTestResultId");

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTimelineIssue", "ModelTimelineIssue")
                        .WithMany()
                        .HasForeignKey("ModelTimelineIssueId");

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTrackingIssue", "ModelTrackingIssue")
                        .WithMany("ModelTrackingIssueMatches")
                        .HasForeignKey("ModelTrackingIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DevOps.Util.DotNet.Triage.ModelTrackingIssueResult", b =>
                {
                    b.HasOne("DevOps.Util.DotNet.Triage.ModelBuildAttempt", "ModelBuildAttempt")
                        .WithMany("ModelTrackingIssueResults")
                        .HasForeignKey("ModelBuildAttemptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DevOps.Util.DotNet.Triage.ModelTrackingIssue", "ModelTrackingIssue")
                        .WithMany()
                        .HasForeignKey("ModelTrackingIssueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
