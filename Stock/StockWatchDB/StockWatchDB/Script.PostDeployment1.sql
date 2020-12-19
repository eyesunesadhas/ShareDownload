/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- Master Tables DATA
PRINT 'Seed Data Load' ;
EXEC SEED_DATA_RefMaintenance_T1;
EXEC SEED_DATA_RefErrorMessage_T1;
EXEC SEED_DATA_ShareMaster_T1;
