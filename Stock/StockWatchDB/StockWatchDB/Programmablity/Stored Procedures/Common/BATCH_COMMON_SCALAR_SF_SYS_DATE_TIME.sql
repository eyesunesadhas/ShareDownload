/*
-----------------------------------------------------------------------------------------
Function Name : BATCH_COMMON_SCALAR$SF_SYS_DATE_TIME 
Description   : The purpose of this batch function is to get system date and time.
-----------------------------------------------------------------------------------------
*/

CREATE FUNCTION BATCH_COMMON_SCALAR$SF_SYS_DATE_TIME(
 )
  RETURNS DATETIME2
AS
 BEGIN
  RETURN SYSDATETIME();
 END

Go