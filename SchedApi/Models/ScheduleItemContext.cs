using Microsoft.EntityFrameworkCore;

namespace SchedApi.Models
{
    public class ScheduleItemContext : DbContext
    {
        /// <summary>
        /// Context of items to store on database (currently using on memory)
        /// </summary>
        public DbSet<ScheduleItemInfo> ScheduleItems { get; set; }

        /// <summary>
        /// Initialize a new instance of the dbcontext for schedule itens and set the options.
        /// </summary>
        public ScheduleItemContext(DbContextOptions<ScheduleItemContext> options)
            : base(options)
        {
        }
    }
}