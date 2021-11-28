using DietMealApp.Core.Abstract;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DietMealApp.Core.DTO
{
    public sealed class DietDTO : _BaseDTO
    {
        public DietDTO() : base() { }
        public static DietDTO DietEntityToDTO(Diet entity)
        {
            if (entity != null)
            {
                var dto = new DietDTO()
                {
                    Id = entity.Id,
                    Days = entity.DietDays,
                    Description = entity.Description,
                    DietName = entity.DietName,
                    UserId = entity.UserId,
                };
                return dto;
            }
            return null;
        }
        [Required(ErrorMessage = "Pole nazwa diety jest wymagane")]
        [MinLength(3, ErrorMessage = "Nazwa diety musi składać się z minimum 3 znaków")]
        [MaxLength(50, ErrorMessage = "Nazwa diety nie może być dłuższa niż 50 znaków")]
        public string DietName { get; set; }
        [MaxLength(500, ErrorMessage = "Opis diety nie może być dłuższy niż 500 znaków")]
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<DietDay> Days { get; set; }
    }
}
