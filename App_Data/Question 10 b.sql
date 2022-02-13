USE [EquipmentTrackingContext];


INSERT INTO [dbo].[EquipmentClassification]([Name]) VALUES('Hand Tools');
INSERT INTO [dbo].[EquipmentClassification]([Name]) VALUES('Fasteners');
INSERT INTO [dbo].[EquipmentClassification]([Name]) VALUES('Gardening Tools');
INSERT INTO [dbo].[EquipmentClassification]([Name]) VALUES('Tools by Job');
INSERT INTO [dbo].[EquipmentClassification]([Name]) VALUES('Electrical-Tools');



INSERT INTO [dbo].[Equipment]([Code],[Name],[Description],[Qty],[EquipmentClassificationID]) 
	VALUES(1,'DRL101','Bosch Power Drill','1200W Power drill with reverse.',6,1);

INSERT INTO [dbo].[Equipment]([Code],[Name],[Description],[Qty],[EquipmentClassificationID]) 
	VALUES(2,'HMT101','Hammer','10 pounds',34,2);

INSERT INTO [dbo].[Equipment]([Code],[Name],[Description],[Qty],[EquipmentClassificationID]) 
	VALUES(3,'NAS101','Nails','4 0.5mm x 10cm nail',1000,3);

INSERT INTO [dbo].[Equipment]([Code],[Name],[Description],[Qty],[EquipmentClassificationID]) 
	VALUES(4,'SHO101','Shovels','Digging shovel.',41,4);

INSERT INTO [dbo].[Equipment]([Code],[Name],[Description],[Qty],[EquipmentClassificationID]) 
	VALUES(7,'VB20150033','4000W Arc welder','Welding machine, nothing special',1,6);


	-- Equipment movement Log
INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(21,'EMP009','2022/02/13 15:44:57',10,1,1);

INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(22,'EMP011','2022/02/13 15:45:17',18,2,1);

INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(23,'EMP012','2022/02/13 15:56:36',5,1,1);

INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(23,'EMP013','2022/02/13 15:56:36',5,1,1);

INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(25,'EMP014','2022/02/13 17:48:34',6,1,3);

INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(26,'EMP015','2022/02/13 17:53:18',40,2,3);

INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(27,'VB20150033','2022/02/13 18:23:41',2,1,7);

INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(27,'VB20150033','2022/02/13 18:23:41',2,1,7);


INSERT INTO [dbo].[EquipmentMovementLog]([EquipmentMovementLogID],[EmployeeNo],[LogDate],[Qty],[Direction],
                          [EquipmentID])  VALUES(28,'VB20150033','2022/02/13 18:24:05',3,2,7);


