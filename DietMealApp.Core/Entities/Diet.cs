using DietMealApp.Core.DTO;
using DietMealApp.Core.Entities;
using DietMealApp.Core.Intersections;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DietMealApp.Core.Entities
{
    public class Diet : _BaseEntity
    {
        public static Diet DietDTOToEntity(DietDTO dto)
        {
            if (dto != null)
            {
                var entity = new Diet()
                {
                    Id = dto.Id,
                    DietDays = dto.Days.ToList(),
                    Description = dto.Description,
                    DietName = dto.DietName,
                    UserId = dto.UserId,
                };
                return entity;
            }
            return null;
        }
        public string DietName { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        public List<DietDay> DietDays { get; set; }

    }
}
