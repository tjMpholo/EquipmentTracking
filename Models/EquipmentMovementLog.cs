using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EquipmentTracking.Models
{
    public enum DIRECTION
    {
        IN = 1,
        OUT = 2
    }
    public class EquipmentMovementLog
    {
        public int EquipmentMovementLogID { get; set; }

        [Required(ErrorMessage = "Please provide the employee ID.")]
        [MaxLength(15),
         DisplayName("Employee Number")]
        public string EmployeeNo { get; set; }

        [DisplayName("Log Date")]
        [Editable(false)]
        public DateTime LogDate { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Please select the quantity.")]
        [DisplayName("Movement quanitity")]
        public int Qty { get; set; }

        [Required(ErrorMessage = "Please select the movement direction.")]
        [DisplayName("Movement direction")]
        public DIRECTION? Direction { get; set; }

        [Required(ErrorMessage = "Please select the equipment.")]
        [DisplayName("Equipment Name")]
        public int EquipmentID { get; set; }
        public virtual Equipment Equipment { get; set; }


    }
}