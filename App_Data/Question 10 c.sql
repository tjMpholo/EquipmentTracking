USE [EquipmentTrackingContext];


PRINT 'GetAllAboutEquipmentTracking'
GO

CREATE VIEW [GetAllAboutEquipmentTracking]
AS
SELECT (eqc.Name + '-' + eq.Name) as Equipment_View, eq.Qty as Qty__View,
		CAST(
             CASE
                  WHEN eqml.Direction = '1'
                     THEN 'IN'
                  ELSE 'OUT'
             END AS varchar) as Direction_V,
			 eqml.LogDate as LogDate_View,
			 eqml.EmployeeNo as Employee_View,
			 eqml.Qty as Eml_Qty_View
			 FROM [dbo].[Equipment] eq
				LEFT JOIN [dbo].[EquipmentClassification] eqc 
					ON eq.EquipmentClassificationID = eqc.ID
				LEFT JOIN [dbo].[EquipmentMovementLog] eqml
					ON eq.EquipmentID = eqml.EquipmentID;
