using Models.Core;
using Models.Entity;

namespace Data
{
    public class User : BaseEntity
    {
        public string UserEmail { get; set; }
        public DateTime Timestamp { get; set; }
    }
}