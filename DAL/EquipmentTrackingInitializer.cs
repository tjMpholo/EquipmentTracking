using EquipmentTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace EquipmentTracking.DAL
{
    public class EquipmentTrackingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<EquipmentTrackingContext>
    {
        protected override void Seed(EquipmentTrackingContext context)
        {
            var equipmentClassificationList = new List<EquipmentClassification>
            {
                new EquipmentClassification{ Name = "Power Tools"},
                new EquipmentClassification{ Name = "Hand Tools"},
                new EquipmentClassification{ Name = "Fasteners"},
                new EquipmentClassification{ Name = "Gardening Tools"},
                new EquipmentClassification{ Name = "Tools by Job"}
            };

            equipmentClassificationList.ForEach(eq => context.EquipmentClassifications.Add(eq));
            context.SaveChanges();

            var equipmentList = new List<Equipment>
            {
                new Equipment{Code = "DRL101", EquipmentClassificationID = 1, Name = "Bosch Power Drill", Description = "1200W Power drill with reverse.", Qty = 10},
                new Equipment{Code = "HMT101", EquipmentClassificationID = 2, Name = "Hammer"    ,        Description = "10 pounds.", Qty = 34},
                new Equipment{Code = "NAS101", EquipmentClassificationID = 3, Name = "Nails",             Description = "4 0.5mm x 10cm nail", Qty = 1000},
                new Equipment{Code = "SHO101", EquipmentClassificationID = 4, Name = "Shovels", Description = "Digging shovel.", Qty = 41},
                new Equipment{Code = "WOO101", EquipmentClassificationID = 5, Name = "Wood cutter", Description = "45cm Wood cutter.", Qty = 2}
                //new Equipment{Code = "NAG102", EquipmentClassificationID = 1, Name = "Nail gun", Description = "500w nail gun.", Qty = 4},
                //new Equipment{Code = "CLP102", EquipmentClassificationID = 2, Name = "Clamp", Description = "10cm diameter steel clamps.", Qty = 3},
                //new Equipment{Code = "LAW102", EquipmentClassificationID = 3, Name = "Lawn Edger", Description = "25cm lawn edger.", Qty = 1},
                //new Equipment{Code = "PLS103", EquipmentClassificationID = 4, Name = "Pliers", Description = "25cm pliers with rubber insulattion.", Qty = 74},
                //new Equipment{Code = "MLM105", EquipmentClassificationID = 5, Name = "Multi-meter", Description = "Fluke 1000 000V 200ohm resistance.", Qty = 12}*//*
            };

            equipmentList.ForEach(el => context.Equipments.Add(el));
            context.SaveChanges();

            var equipmentMovementLogs = new List<EquipmentMovementLog>
            {
                new EquipmentMovementLog{EquipmentID = 1, EmployeeNo = "EMP101", LogDate = DateTime.Now , Qty = 2, Direction = DIRECTION.OUT},
                new EquipmentMovementLog{EquipmentID = 2, EmployeeNo = "EMP101", LogDate = DateTime.Now , Qty = 2, Direction = DIRECTION.IN},
                new EquipmentMovementLog{EquipmentID = 3, EmployeeNo = "EMP102", LogDate = DateTime.Now , Qty = 2, Direction = DIRECTION.OUT},
                new EquipmentMovementLog{EquipmentID = 4, EmployeeNo = "EMP103", LogDate = DateTime.Now , Qty = 2, Direction = DIRECTION.IN},
                new EquipmentMovementLog{EquipmentID = 5, EmployeeNo = "EMP104", LogDate = DateTime.Now , Qty = 2, Direction = DIRECTION.OUT}
                //new EquipmentMovementLog{EquipmentID = 6, EmployeeNo = "EMP105", LogDate = DateTime.Now , Qty = 2, Direction = DIRECTION.IN.ToString()},
                //new EquipmentMovementLog{EquipmentID = 7, EmployeeNo = "EMP106", LogDate = DateTime.Now , Qty = 2, Direction = DIRECTION.IN.ToString()}
            };

            equipmentMovementLogs.ForEach(eqm => context.EquipmentMovementLogs.Add(eqm));
            context.SaveChanges();
        }
    }
}