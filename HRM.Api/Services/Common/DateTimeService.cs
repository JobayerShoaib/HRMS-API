using Application.Services.Common;

namespace HRM.Api.Services.Common
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}
