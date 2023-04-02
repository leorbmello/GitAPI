namespace SchedApi.Models
{
    /// <summary>
    /// Schedule information to store.
    /// </summary>
    public class ScheduleItemInfo
    {
        public long Id { get; set; }
        public string? Value { get; set; }
        public string? Phone { get; set; }
        public byte Status { get; set; }
        public DateTime Date { get; set; }

        /// <summary>
        /// Check if the schedule time is still valid.
        /// </summary>
        public bool IsTimeOver => DateTime.Now > Date && !(IsCompleted || IsCanceled);

        /// <summary>
        /// Check if the current type is scheduled.
        /// </summary>
        public bool IsScheduled => (ScheduleStatusType)Status == ScheduleStatusType.Scheduled;

        /// <summary>
        /// Check if the schedule has been completed.
        /// </summary>
        public bool IsCompleted => (ScheduleStatusType)Status == ScheduleStatusType.Completed;

        /// <summary>
        /// Check if the schedule has been canceled.
        /// </summary>
        public bool IsCanceled => (ScheduleStatusType)Status == ScheduleStatusType.Canceled;
    }

    /// <summary>
    /// Defined types of the schedule status.
    /// </summary>
    public enum ScheduleStatusType : byte
    {
        Invalid,
        Scheduled,
        Canceled,
        Completed
    }
}
