using Microsoft.Extensions.Logging.Abstractions;
using jobinjaClone.Enums;
namespace jobinjaClone.Entities
{
    public class Experience : BaseEntity
    {
        public string CompanyName { get; set; } = null!;
        public string RollName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool DescriptionIsOn { get; set; }

        public MonthEnum Startmonth { get; set; }

        public string StartYear { get; set; } = null!;

        public MonthEnum Endtmonth { get; set; }

        public string EndYear { get; set; } = null!;

        public int JobSeekerId { get; set; }

        public bool StillWorking { get; set; }

        public JobSeeker JobSeeker { get; set; } = null!;
    }
}
