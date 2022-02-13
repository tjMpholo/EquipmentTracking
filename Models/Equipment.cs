using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EquipmentTracking.Models
{
    public class Equipment
    {
        public int EquipmentID { get; set; }

        [Required(ErrorMessage = "Please provide the equipment code.")]
        [MaxLength(15),
         DisplayName("Equipment Code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please provide the equipment name.")]
        [MaxLength(50),
         DisplayName("Equipment Name")]
        public string Name { get; set; }

        [MaxLength(50),DisplayName("Equipment Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please provide the equipment Quantity.")]
        [DisplayName("Equipment Quantity")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Please select a classification.")]
        [DisplayName("Equipment Classification")]
        public int EquipmentClassificationID { get; set; }

        //public int EquipmentMovementLogID { get; set; }

        public virtual EquipmentClassification EquipmentClassification { get; set; }
        //public virtual EquipmentMovementLog EquipmentMovementLog { get; set; }
        public virtual ICollection<EquipmentMovementLog> EquipmentMovementLogs { get; set; }
    }
}