using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Service.DTOs
{
    public abstract class _BaseDTO
    {
        public _BaseDTO() { }
        public Guid Id { get; set; }
    }
}
