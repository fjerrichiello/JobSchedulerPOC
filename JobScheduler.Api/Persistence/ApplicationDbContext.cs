using JobScheduler.Api.Persistence.Models.Quartz;
using Microsoft.EntityFrameworkCore;

namespace JobScheduler.Api.Persistence;

public class ApplicationDbContext : DbContext
{
    public virtual DbSet<AuthorEntity> Authors { get; set; } = null!;

    public virtual DbSet<BookEntity> Books { get; set; } = null!;

    public virtual DbSet<BookRequestEntity> BookRequests { get; set; } = null!;

    public ApplicationDbContext(
        DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<BookRequestEntity>()
            .Property(x => x.RequestType)
            .HasConversion<string>();

        modelBuilder.Entity<BookRequestEntity>()
            .Property(x => x.ApprovalStatus)
            .HasConversion<string>();


        modelBuilder.Entity<BookRequestEntity>()
            .HasIndex(b => new { b.AuthorId, b.Title, b.ApprovalStatus })
            .IsUnique()
            .HasFilter("""
                       "ApprovalStatus" = 'Pending'
                       """);

        modelBuilder.Entity<BookRequestEntity>()
            .HasIndex(b => new { b.AuthorId, b.NewTitle, b.ApprovalStatus })
            .IsUnique()
            .HasFilter("""
                       "ApprovalStatus" = 'Pending'
                       """);

        modelBuilder.Entity<BookEntity>()
            .HasIndex(b => new { b.AuthorId, b.Title })
            .IsUnique();

        // List<AuthorEntity> authors =
        // [
        //     new Author() { Id = 1, AuthorId = "Dr.Seuss" },
        //     new Author() { Id = 2, AuthorId = "Roald Dahl" },
        //     new Author() { Id = 3, AuthorId = "Beatrix Potter" },
        //     new Author() { Id = 4, AuthorId = "Maurice Sendak" },
        //     new Author() { Id = 5, AuthorId = "Eric Carle" },
        //     new Author() { Id = 6, AuthorId = "Shel Silverstein" },
        //     new Author() { Id = 7, AuthorId = "Judy Blume" }
        // ];


        // modelBuilder.Entity<AuthorEntity>()
        //     .HasData(authors);


        // Quartz
        modelBuilder.Entity<QuartzBlobTrigger>(entity =>
        {
            entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
            entity.HasOne(x => x.QuartzTrigger)
                .WithOne(x => x.QuartzBlobTrigger)
                .HasForeignKey<QuartzBlobTrigger>(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
        });

        modelBuilder.Entity<QuartzCalendar>()
            .HasKey(x => new { x.SchedName, x.CalendarName });

        modelBuilder.Entity<QuartzCronTrigger>(entity =>
        {
            entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
            entity.HasOne(x => x.QuartzTrigger)
                .WithOne(x => x.QuartzCronTrigger)
                .HasForeignKey<QuartzCronTrigger>(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
        });

        modelBuilder.Entity<QuartzFiredTrigger>(entity =>
        {
            entity.HasKey(x => new { x.SchedName, x.EntryId });
            entity.HasIndex(x => x.JobGroup, "idx_qrtz_ft_job_group");
            entity.HasIndex(x => x.JobName, "idx_qrtz_ft_job_name");
            entity.HasIndex(x => x.RequestsRecovery, "idx_qrtz_ft_job_req_recovery");
            entity.HasIndex(x => x.TriggerGroup, "idx_qrtz_ft_trig_group");
            entity.HasIndex(x => x.InstanceName, "idx_qrtz_ft_trig_inst_name");
            entity.HasIndex(x => x.TriggerName, "idx_qrtz_ft_trig_name");
            entity.HasIndex(x => new { x.SchedName, x.TriggerName, x.TriggerGroup }, "idx_qrtz_ft_trig_nm_gp");
        });

        modelBuilder.Entity<QuartzJobDetail>(entity =>
        {
            entity.HasKey(x => new { x.SchedName, x.JobName, x.JobGroup });
            entity.HasIndex(x => x.RequestsRecovery, "idx_qrtz_j_req_recovery");
        });

        modelBuilder.Entity<QuartzLock>()
            .HasKey(x => new { x.SchedName, x.LockName });

        modelBuilder.Entity<QuartzPausedTriggerGroup>()
            .HasKey(x => new { x.SchedName, x.TriggerGroup });

        modelBuilder.Entity<QuartzSchedulerState>()
            .HasKey(x => new { x.SchedName, x.InstanceName });

        modelBuilder.Entity<QuartzSimpleTrigger>(entity =>
        {
            entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
            entity.HasOne(x => x.QuartzTrigger)
                .WithOne(x => x.QuartzSimpleTrigger)
                .HasForeignKey<QuartzSimpleTrigger>(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
        });

        modelBuilder.Entity<QuartzSimpropTrigger>(entity =>
        {
            entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
            entity.HasOne(x => x.QuartzTrigger)
                .WithOne(x => x.QuartzSimpropTrigger)
                .HasForeignKey<QuartzSimpropTrigger>(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
        });

        modelBuilder.Entity<QuartzTrigger>(entity =>
        {
            entity.HasKey(x => new { x.SchedName, x.TriggerName, x.TriggerGroup });
            entity.HasIndex(x => x.NextFireTime, "idx_qrtz_t_next_fire_time");
            entity.HasIndex(x => new { x.NextFireTime, x.TriggerState }, "idx_qrtz_t_nft_st");
            entity.HasIndex(x => x.TriggerState, "idx_qrtz_t_state");
            entity.HasOne(x => x.QuartzJobDetail)
                .WithMany(x => x.QuartzTriggers)
                .HasForeignKey(x => new { x.SchedName, x.JobName, x.JobGroup })
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
    }
}