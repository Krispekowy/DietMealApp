using System;
using System.Collections.Generic;
using System.Text;

namespace DietMealApp.Core.Abstract
{
    public abstract class _BaseDTO
    {
        public _BaseDTO() { }
        public Guid Id { get; set; }
    }
}
