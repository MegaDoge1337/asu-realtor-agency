﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Realtors.Entities
{
    [Table("RealEstate")]
    public class RealEstate
    {
        [Key]
        public int Id { get; set; }
        public District District { get; set; }
        [ForeignKey("District")]
        public int DistrictId { get; set; }
        public string Address { get; set; }
        public int Floor { get; set; }
        public int RoomsCount { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public BuildingMaterial BuildingMaterial { get; set; }
        [ForeignKey("BuildingMaterial")]
        public int BuildingMaterialId { get; set; }
        public int Square { get; set; }
        public DateTime Date { get; set; }
    }
}
