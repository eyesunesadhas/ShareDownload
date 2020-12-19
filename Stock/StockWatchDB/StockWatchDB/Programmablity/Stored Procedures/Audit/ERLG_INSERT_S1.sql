/*=============================================================================================
 Procedure : ERLG_INSERT_S1
 Purpose   : Insert Data on ERLG_Y1
 CreatedBy :
 CreatedOn : 07/17/2020
 */
CREATE PROCEDURE ERLG_INSERT_S1 (
   @As_Unique_ID                   CHAR (35),
   @As_Type_TEXT                   CHAR (10),
   @As_Application_ID              VARCHAR (16),
   @As_ServerIP_TEXT               VARCHAR (35),
   @As_ClientIp_TEXT               VARCHAR (15),
   @As_Agent_TEXT                  VARCHAR (400),
   @As_Input_JSON                  VARCHAR (8000),
   @As_Status_JSON                 VARCHAR (8000),
   @As_ScriptError_TEXT            VARCHAR (8000),
   @As_StackTrace_TEXT             VARCHAR (8000),
   @As_BaseException_TEXT          VARCHAR (4000),
   @As_InnerException_TEXT         VARCHAR (4000),
   @As_InnerExceptionStack_TEXT    VARCHAR (8000),
   @As_SignedOnWorker_ID           VARCHAR (36)
   )
AS
   BEGIN
      
      /* Insert data on table ERLG_Y1 */
      INSERT INTO ERLG_Y1 (Unique_ID,
                           AccessByUser_ID,
                           Type_TEXT,
                           Application_ID,
                           ServerIP_TEXT,
                           ClientIp_TEXT,
                           Agent_TEXT,
                           Input_JSON,
                           Status_JSON,
                           ScriptError_TEXT,
                           StackTrace_TEXT,
                           BaseException_TEXT,
                           InnerException_TEXT,
                           InnerExceptionStack_TEXT)
      VALUES (@As_Unique_ID,
              @As_SignedOnWorker_ID,
              @As_Type_TEXT,
              @As_Application_ID,
              @As_ServerIP_TEXT,
              @As_ClientIp_TEXT,
              @As_Agent_TEXT,
              @As_Input_JSON,
              @As_Status_JSON,
              @As_ScriptError_TEXT,
              @As_StackTrace_TEXT,
              @As_BaseException_TEXT,
              @As_InnerException_TEXT,
              @As_InnerExceptionStack_TEXT);
   END