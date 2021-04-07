using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Abstract
{
    public abstract class _User : IdentityUser<Guid>
    {
        public _User()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override Guid Id { get => base.Id; set => base.Id = value; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime RegisterDate { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastEditDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }

    }
}
