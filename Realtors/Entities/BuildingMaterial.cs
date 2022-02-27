﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realtors.Entities
{
    [Table("BuildingMaterials")]
    public class BuildingMaterial
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
