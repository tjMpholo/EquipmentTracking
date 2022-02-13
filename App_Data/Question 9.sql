USE [EquipmentTrackingContext];


SELECT (eqc.Name + '-' + eq.Name) as Equipment, eq.Qty,
		CAST(
             CASE
                  WHEN eqml.Direction = '1'
                     THEN 'IN'
                  ELSE 'OUT'
             END AS varchar) as Direction,
			 eqml.LogDate,
			 eqml.EmployeeNo,
			 eqml.Qty
			 FROM [dbo].[Equipment] eq
				LEFT JOIN [dbo].[EquipmentClassification] eqc 
					ON eq.EquipmentClassificationID = eqc.ID
				LEFT JOIN [dbo].[EquipmentMovementLog] eqml
					ON eq.EquipmentID = eqml.EquipmentID;