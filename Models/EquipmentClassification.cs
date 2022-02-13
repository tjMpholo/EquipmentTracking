using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EquipmentTracking.Models
{
    public class EquipmentClassification
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "A classification name is required.")]
        [MaxLength(50),
         DisplayName("Classification Name")]
        public string Name { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}