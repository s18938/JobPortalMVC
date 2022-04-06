using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JobPortalMVC.Models
{
    public partial class salesjobportalContext : DbContext
    {
        public salesjobportalContext()
        {
        }

        public salesjobportalContext(DbContextOptions<salesjobportalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Clientdatabase> Clientdatabases { get; set; }
        public virtual DbSet<Clienttype> Clienttypes { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<Experience> Experiences { get; set; }
        public virtual DbSet<Industry> Industries { get; set; }
        public virtual DbSet<Jobapliacationstate> Jobapliacationstates { get; set; }
        public virtual DbSet<Joboffer> Joboffers { get; set; }
        public virtual DbSet<Joboffercandidate> Joboffercandidates { get; set; }
        public virtual DbSet<Jobtype> Jobtypes { get; set; }
        public virtual DbSet<Jobtypejoboffer> Jobtypejoboffers { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Salescyclelength> Salescyclelengths { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("Server=localhost; port=3306;Database=salesjobportal; user=root; password=");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>(entity =>
            {
                entity.ToTable("candidate");

                entity.HasIndex(e => e.CityCityId, "candidate_city");

                entity.Property(e => e.CandidateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("candidateID");

                entity.Property(e => e.CityCityId)
                    .HasColumnType("int(11)")
                    .HasColumnName("city_cityId")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("lastName");

                entity.Property(e => e.TelNum)
                    .HasColumnType("int(11)")
                    .HasColumnName("telNum")
                    .HasDefaultValueSql("'NULL'");

                entity.HasOne(d => d.CityCity)
                    .WithMany(p => p.Candidates)
                    .HasForeignKey(d => d.CityCityId)
                    .HasConstraintName("candidate_city");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.CityId)
                    .HasColumnType("int(11)")
                    .HasColumnName("cityId");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("cityName");
            });

            modelBuilder.Entity<Clientdatabase>(entity =>
            {
                entity.ToTable("clientdatabase");

                entity.Property(e => e.ClientDatabaseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("clientDatabaseID");

                entity.Property(e => e.ClientDatabaseName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("clientDatabaseName");
            });

            modelBuilder.Entity<Clienttype>(entity =>
            {
                entity.ToTable("clienttype");

                entity.Property(e => e.ClientTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("clientTypeID");

                entity.Property(e => e.ClientTypeName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("clientTypeName");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("document");

                entity.HasIndex(e => e.CandidateCandidateId, "document_candidate");

                entity.Property(e => e.DocumentId)
                    .HasColumnType("int(11)")
                    .HasColumnName("documentID");

                entity.Property(e => e.CandidateCandidateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("candidate_candidateID");

                entity.Property(e => e.File)
                    .IsRequired()
                    .HasColumnType("blob")
                    .HasColumnName("file");

                entity.HasOne(d => d.CandidateCandidate)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CandidateCandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("document_candidate");
            });

            modelBuilder.Entity<Employer>(entity =>
            {
                entity.ToTable("employer");

                entity.Property(e => e.EmployerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employerID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("email");

                entity.Property(e => e.EmployeesNumber)
                    .HasColumnType("int(11)")
                    .HasColumnName("employeesNumber")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasColumnType("blob")
                    .HasColumnName("logo");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("name");

                entity.Property(e => e.Page)
                    .HasMaxLength(60)
                    .HasColumnName("page")
                    .HasDefaultValueSql("'NULL'");
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("experience");

                entity.HasIndex(e => e.CandidateCandidateId, "experience_candidate");

                entity.HasIndex(e => e.ClientDatabaseClientDatabaseId, "experience_clientDatabase");

                entity.HasIndex(e => e.ClientTypeClientTypeId, "experience_clientType");

                entity.HasIndex(e => e.IndustryIndustryId, "experience_industry");

                entity.HasIndex(e => e.PositionPositionId, "experience_position");

                entity.HasIndex(e => e.SalesCycleLengthSalesCycleLengthId, "experience_salesCycleLength");

                entity.Property(e => e.ExperienceId)
                    .HasColumnType("int(11)")
                    .HasColumnName("experienceID");

                entity.Property(e => e.CandidateCandidateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("candidate_candidateID");

                entity.Property(e => e.ClientDatabaseClientDatabaseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("clientDatabase_clientDatabaseID");

                entity.Property(e => e.ClientTypeClientTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("clientType_clientTypeID");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("companyName");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.IndustryIndustryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("industry_industryID");

                entity.Property(e => e.PositionPositionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("position_positionID");

                entity.Property(e => e.SalesCycleLengthSalesCycleLengthId)
                    .HasColumnType("int(11)")
                    .HasColumnName("salesCycleLength_salesCycleLengthID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.HasOne(d => d.CandidateCandidate)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.CandidateCandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("experience_candidate");

                entity.HasOne(d => d.ClientDatabaseClientDatabase)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.ClientDatabaseClientDatabaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("experience_clientDatabase");

                entity.HasOne(d => d.ClientTypeClientType)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.ClientTypeClientTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("experience_clientType");

                entity.HasOne(d => d.IndustryIndustry)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.IndustryIndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("experience_industry");

                entity.HasOne(d => d.PositionPosition)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.PositionPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("experience_position");

                entity.HasOne(d => d.SalesCycleLengthSalesCycleLength)
                    .WithMany(p => p.Experiences)
                    .HasForeignKey(d => d.SalesCycleLengthSalesCycleLengthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("experience_salesCycleLength");
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("industry");

                entity.Property(e => e.IndustryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("industryID");

                entity.Property(e => e.IndustryName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("industryName");
            });

            modelBuilder.Entity<Jobapliacationstate>(entity =>
            {
                entity.ToTable("jobapliacationstate");

                entity.Property(e => e.JobApliacationStateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("JobApliacationStateID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Joboffer>(entity =>
            {
                entity.ToTable("joboffer");

                entity.HasIndex(e => e.CityCityId, "jobOffer_city");

                entity.HasIndex(e => e.ClientDatabaseClientDatabaseId, "jobOffer_clientDatabase");

                entity.HasIndex(e => e.ClientTypeClientTypeId, "jobOffer_clientType");

                entity.HasIndex(e => e.EmployerEmployerId, "jobOffer_employer");

                entity.HasIndex(e => e.IndustryIndustryId, "jobOffer_industry");

                entity.HasIndex(e => e.PositionPositionId, "jobOffer_position");

                entity.HasIndex(e => e.SalesCycleLengthSalesCycleLengthId, "jobOffer_salesCycleLength");

                entity.Property(e => e.JobOfferId)
                    .HasColumnType("int(11)")
                    .HasColumnName("jobOfferID");

                entity.Property(e => e.CityCityId)
                    .HasColumnType("int(11)")
                    .HasColumnName("city_cityId");

                entity.Property(e => e.ClientDatabaseClientDatabaseId)
                    .HasColumnType("int(11)")
                    .HasColumnName("clientDatabase_clientDatabaseID");

                entity.Property(e => e.ClientTypeClientTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("clientType_clientTypeID");

                entity.Property(e => e.CommissonMax)
                    .HasColumnType("int(11)")
                    .HasColumnName("commissonMax")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CommissonMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("commissonMin")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.CompanyCar)
                    .HasColumnType("bit(1)")
                    .HasColumnName("companyCar");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasMaxLength(300)
                    .HasColumnName("content");

                entity.Property(e => e.EmployerEmployerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("employer_employerID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("endDate");

                entity.Property(e => e.IndustryIndustryId)
                    .HasColumnType("int(11)")
                    .HasColumnName("industry_industryID");

                entity.Property(e => e.PositionPositionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("position_positionID");

                entity.Property(e => e.SalaryMax)
                    .HasColumnType("int(11)")
                    .HasColumnName("salaryMax")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SalaryMin)
                    .HasColumnType("int(11)")
                    .HasColumnName("salaryMin")
                    .HasDefaultValueSql("'NULL'");

                entity.Property(e => e.SalesCycleLengthSalesCycleLengthId)
                    .HasColumnType("int(11)")
                    .HasColumnName("salesCycleLength_salesCycleLengthID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("startDate");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("title");

                entity.HasOne(d => d.CityCity)
                    .WithMany(p => p.Joboffers)
                    .HasForeignKey(d => d.CityCityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOffer_city");

                entity.HasOne(d => d.ClientDatabaseClientDatabase)
                    .WithMany(p => p.Joboffers)
                    .HasForeignKey(d => d.ClientDatabaseClientDatabaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOffer_clientDatabase");

                entity.HasOne(d => d.ClientTypeClientType)
                    .WithMany(p => p.Joboffers)
                    .HasForeignKey(d => d.ClientTypeClientTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOffer_clientType");

                entity.HasOne(d => d.EmployerEmployer)
                    .WithMany(p => p.Joboffers)
                    .HasForeignKey(d => d.EmployerEmployerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOffer_employer");

                entity.HasOne(d => d.IndustryIndustry)
                    .WithMany(p => p.Joboffers)
                    .HasForeignKey(d => d.IndustryIndustryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOffer_industry");

                entity.HasOne(d => d.PositionPosition)
                    .WithMany(p => p.Joboffers)
                    .HasForeignKey(d => d.PositionPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOffer_position");

                entity.HasOne(d => d.SalesCycleLengthSalesCycleLength)
                    .WithMany(p => p.Joboffers)
                    .HasForeignKey(d => d.SalesCycleLengthSalesCycleLengthId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOffer_salesCycleLength");
            });

            modelBuilder.Entity<Joboffercandidate>(entity =>
            {
                entity.ToTable("joboffercandidate");

                entity.HasIndex(e => e.JobApliacationStateJobApliacationStateId, "jobOfferCandidate_JobApliacationState");

                entity.HasIndex(e => e.CandidateCandidateId, "jobOfferCandidate_candidate");

                entity.HasIndex(e => e.JobOfferJobOfferId, "jobOfferCandidate_jobOffer");

                entity.Property(e => e.JobOfferCandidateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("jobOfferCandidateID");

                entity.Property(e => e.AddDate)
                    .HasColumnType("date")
                    .HasColumnName("addDate");

                entity.Property(e => e.CandidateCandidateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("candidate_candidateID");

                entity.Property(e => e.JobApliacationStateJobApliacationStateId)
                    .HasColumnType("int(11)")
                    .HasColumnName("JobApliacationState_JobApliacationStateID");

                entity.Property(e => e.JobOfferJobOfferId)
                    .HasColumnType("int(11)")
                    .HasColumnName("jobOffer_jobOfferID");

                entity.HasOne(d => d.CandidateCandidate)
                    .WithMany(p => p.Joboffercandidates)
                    .HasForeignKey(d => d.CandidateCandidateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOfferCandidate_candidate");

                entity.HasOne(d => d.JobApliacationStateJobApliacationState)
                    .WithMany(p => p.Joboffercandidates)
                    .HasForeignKey(d => d.JobApliacationStateJobApliacationStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOfferCandidate_JobApliacationState");

                entity.HasOne(d => d.JobOfferJobOffer)
                    .WithMany(p => p.Joboffercandidates)
                    .HasForeignKey(d => d.JobOfferJobOfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobOfferCandidate_jobOffer");
            });

            modelBuilder.Entity<Jobtype>(entity =>
            {
                entity.ToTable("jobtype");

                entity.Property(e => e.JobTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("jobTypeID");

                entity.Property(e => e.JobTypeName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("jobTypeName");
            });

            modelBuilder.Entity<Jobtypejoboffer>(entity =>
            {
                entity.ToTable("jobtypejoboffer");

                entity.HasIndex(e => e.JobOfferJobOfferId, "jobTypeJobOffer_jobOffer");

                entity.HasIndex(e => e.JobTypeJobTypeId, "jobTypeJobOffer_jobType");

                entity.Property(e => e.JobTypeJobOfferId)
                    .HasColumnType("int(11)")
                    .HasColumnName("jobTypeJobOfferID");

                entity.Property(e => e.JobOfferJobOfferId)
                    .HasColumnType("int(11)")
                    .HasColumnName("jobOffer_jobOfferID");

                entity.Property(e => e.JobTypeJobTypeId)
                    .HasColumnType("int(11)")
                    .HasColumnName("jobType_jobTypeID");

                entity.HasOne(d => d.JobOfferJobOffer)
                    .WithMany(p => p.Jobtypejoboffers)
                    .HasForeignKey(d => d.JobOfferJobOfferId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobTypeJobOffer_jobOffer");

                entity.HasOne(d => d.JobTypeJobType)
                    .WithMany(p => p.Jobtypejoboffers)
                    .HasForeignKey(d => d.JobTypeJobTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("jobTypeJobOffer_jobType");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("position");

                entity.Property(e => e.PositionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("positionID");

                entity.Property(e => e.PositionName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("positionName");
            });

            modelBuilder.Entity<Salescyclelength>(entity =>
            {
                entity.ToTable("salescyclelength");

                entity.Property(e => e.SalesCycleLengthId)
                    .HasColumnType("int(11)")
                    .HasColumnName("salesCycleLengthID");

                entity.Property(e => e.SalesCycleLengthName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .HasColumnName("salesCycleLengthName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
