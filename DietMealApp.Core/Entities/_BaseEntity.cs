using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public abstract class _BaseEntity
    {
        public _BaseEntity() { }

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public DateTime CreationDate { get; set; } = DateTime.UtcNow;

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime ModifyDate { get; set; } = DateTime.UtcNow;

		public DateTime? DeleteDate { get; set; }

		public bool IsDeleted { get; set; } = false;
		public bool CanBeEdited { get; set; } = true;
	}

    
}
