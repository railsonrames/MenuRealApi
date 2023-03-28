using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRealApi.Models
{
    public class Restaurant
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public ushort PriceStar { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Dictionary<System.DayOfWeek, string> WorkHours { get; set; }
        public bool TakeAway { get; set; }
        public bool Buffet { get; set; }
        public Category Category { get; set; }
    }
}
