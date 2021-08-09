using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class Diet : _BaseEntity
    {
        public string DietName { get; set; }
        public string Description { get; set; }
        public List<DietDay> DietDays { get; set; }

    }
}
