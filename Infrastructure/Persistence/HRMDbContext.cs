using Application.Repositories;
using Application.Services.Common;
using Domain.Common;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class HRMDbContext : AuditableContext, IHRMDbContext
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDateTimeService _dateTimeService;

        public HRMDbContext(DbContextOptions<HRMDbContext> options, ICurrentUserService currentUserService
            , IDateTimeService dateTimeService)
        : base(options)
        {
            _currentUserService = currentUserService;
            _dateTimeService = dateTimeService;
        }
        #region Setup

        public virtual DbSet<CompanyType> CompanyType { get; set; }
        public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<OfficeLevel> OfficeLevel { get; set; }
        public virtual DbSet<Office> Office { get; set; }
        public virtual DbSet<OfficeDivision> OfficeDivision { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Section> Section { get; set; }
        public virtual DbSet<Designation> Designation { set; get; }
        public virtual DbSet<Thana> Thana { set; get; }

        #endregion Setup


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);

        }
        #region Save Changes and Audit 
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            int result = 0;

            foreach (var entry in ChangeTracker.Entries<AuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = _dateTimeService.Now;
                        entry.Entity.CreatedBy = _currentUserService.UserId;
                        entry.Entity.IsDeleted = false;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedOn = _dateTimeService.Now;
                        entry.Entity.LastModifiedBy = _currentUserService.UserId;
                        break;
                }
            }

            if (_currentUserService.UserId != null)
            {
                result = await base.SaveChangesAsync(cancellationToken);
            }
            else
            {
                return await base.SaveChangesAsync(_currentUserService.UserId, cancellationToken);
            }

            return result;
        }

        #endregion Save Changes and Audit 
    }
}
