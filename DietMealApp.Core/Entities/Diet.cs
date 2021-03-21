using DietMealApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class Diet : _BaseEntity
    {
        public string DietName { get; set; }
        public string Description { get; set; }
        public IEnumerable<DietDay> Days { get; set; }
    }
}
