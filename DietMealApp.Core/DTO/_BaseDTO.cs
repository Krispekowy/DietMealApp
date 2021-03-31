using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.DTOs
{
    public abstract class _BaseDTO
    {
        public _BaseDTO() { }
        public Guid Id { get; set; }
    }
}
