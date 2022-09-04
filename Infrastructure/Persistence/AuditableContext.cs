using Application.AppEnums;
using Application.IdentityEntities;
using Application.Services.Common;
using Domain.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public abstract class AuditableContext : IdentityDbContext<ApplicationUser, ApplicationRole, string,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>
    {
        public AuditableContext(DbContextOptions options) : base(options)
        {
        }
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;

        protected AuditableContext(DbContextOptions<AuditableContext> options, ICurrentUserService currentUserService, IDateTimeService dateTimeService) : base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }



        public DbSet<AuditTrails> AuditTrails { get; set; }
        public DbSet<AuditSecrets> AuditSecrets { get; set; }

        #region Save Changes and Audit 
        //public virtual async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        //{
        //    int result = 0;

        //    foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
        //    {
        //        switch (entry.State)
        //        {
        //            case EntityState.Added:
        //                entry.Entity.CreatedOn = _dateTimeService.Now;
        //                entry.Entity.CreatedBy = _currentUserService.UserId;
        //                entry.Entity.IsDeleted = false;
        //                break;

        //            case EntityState.Modified:
        //                entry.Entity.LastModifiedOn = _dateTimeService.Now;
        //                entry.Entity.LastModifiedBy = _currentUserService.UserId;
        //                break;
        //        }
        //    }

        //    if (_currentUserService.UserId != null)
        //    {
        //        result = await base.SaveChangesAsync(cancellationToken);
        //    }
        //    else
        //    {
        //        var auditEntries = OnBeforeSaveChanges(_currentUserService.UserId);
        //        result = await base.SaveChangesAsync(cancellationToken);
        //        await OnAfterSaveChanges(auditEntries, cancellationToken);
        //    }

        //    return result;
        //}
        public virtual async Task<int> SaveChangesAsync(string userId = null, CancellationToken cancellationToken = new())
        {
            var auditEntries = OnBeforeSaveChanges(userId);
            var result = await SaveChangesAsync(cancellationToken);
            await OnAfterSaveChanges(auditEntries, cancellationToken);
            return result;
        }
        private List<AuditEntry> OnBeforeSaveChanges(string userId)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditTrails || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;

                var auditEntry = new AuditEntry(entry)
                {
                    TableName = entry.Entity.GetType().Name,
                    UserId = userId
                };
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    if (property.IsTemporary)
                    {
                        auditEntry.TemporaryProperties.Add(property);
                        continue;
                    }

                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = (int)EnumAuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;

                        case EntityState.Deleted:
                            auditEntry.AuditType = (int)EnumAuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;

                        case EntityState.Modified:
                            if (property.IsModified && property.OriginalValue?.Equals(property.CurrentValue) == false)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = (int)EnumAuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries.Where(_ => !_.HasTemporaryProperties))
            {
                AuditTrails.Add(auditEntry.ToAudit());
            }
            return auditEntries.Where(_ => _.HasTemporaryProperties).ToList();
        }

        private Task OnAfterSaveChanges(List<AuditEntry> auditEntries, CancellationToken cancellationToken = new())
        {
            if (auditEntries == null || auditEntries.Count == 0)
                return Task.CompletedTask;

            foreach (var auditEntry in auditEntries)
            {
                foreach (var prop in auditEntry.TemporaryProperties)
                {
                    if (prop.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                    else
                    {
                        auditEntry.NewValues[prop.Metadata.Name] = prop.CurrentValue;
                    }
                }
                AuditTrails.Add(auditEntry.ToAudit());
            }
            return SaveChangesAsync(cancellationToken);
        }
        #endregion Save Changes and Audit 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(e => e.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired();

                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(e => e.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired();

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(e => e.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired();

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<ApplicationRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });

            //builder.Entity<ApplicationUser>(entity =>
            //{
            //    entity.ToTable(name: "ApplicationUser", "Identity");
            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();
            //});

            //builder.Entity<ApplicationRole>(entity =>
            //{
            //    entity.ToTable(name: "ApplicationRole", "Identity");
            //    entity.Property(e => e.Id).ValueGeneratedOnAdd();

            //});
            //builder.Entity<ApplicationUserRole>(entity =>
            //{
            //    entity.ToTable("ApplicationUserRole", "Identity");
            //});

            //builder.Entity<ApplicationUserClaim>(entity =>
            //{
            //    entity.ToTable("ApplicationUserClaim", "Identity");
            //});

            //builder.Entity<ApplicationUserLogin>(entity =>
            //{
            //    entity.ToTable("ApplicationUserLogin", "Identity");
            //});

            //builder.Entity<ApplicationRoleClaim>(entity =>
            //{
            //    entity.ToTable(name: "ApplicationRoleClaim", "Identity");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.RoleClaims)
            //        .HasForeignKey(d => d.RoleId)
            //        .OnDelete(DeleteBehavior.Cascade);
            //});

            //builder.Entity<ApplicationUserToken>(entity =>
            //{
            //    entity.ToTable("ApplicationUserToken", "Identity");
            //});
        }
    }
}
