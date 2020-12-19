CREATE PROCEDURE EMSG_SELECT_S1
AS
/*
-----------------------------------------------------------------------------------------
Procedure Name : EMSG_SELECT_S1
Description    : Retrieves All Error Code and Description From Error Message Table.
-----------------------------------------------------------------------------------------
*/ 
 BEGIN
 --BEGIN of EMSG_SELECT_S1 
  SELECT E.Error_CODE,
         E.DescriptionError_TEXT
    FROM RefErrorMessage_T1 E
   ORDER BY E.Error_CODE;
 END  
 --End of EMSG_SELECT_S1                                  
GO 
 