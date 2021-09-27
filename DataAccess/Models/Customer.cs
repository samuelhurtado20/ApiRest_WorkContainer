using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public int CustomerOrder { get; set; }
        public bool Migrated { get; set; }
        public DateTime CreatedAt { get; set; }
		public Guid CreatedBy { get; set; }
	}
}
