/*=============================================================================================
 Procedure : ACLG_INSERT_S1
 Purpose   : Insert Data on ACLG_Y1
 CreatedBy :
 CreatedOn : 07/17/2020
 */
CREATE PROCEDURE ACLG_INSERT_S1 (@As_Unique_ID                VARCHAR (35),
                                 @As_PageLocation             VARCHAR (100),
                                 @As_Service_NAME             VARCHAR (35),
                                 @As_Method_NAME              VARCHAR (100),
                                 @As_Application_ID           VARCHAR (16),
                                 @As_ServerIP_TEXT            VARCHAR (35),
                                 @As_ClientIp_TEXT            VARCHAR (15),
                                 @As_Agent_TEXT               VARCHAR (400),
                                 @An_HttpStatus               NUMERIC (3, 0),
                                 @Ad_StartTime_DTTM           DATETIME2,
                                 @Ad_EndTime_DTTM             DATETIME2,
                                 @As_Input_JSON               VARCHAR (8000),
                                 @As_Status_JSON              VARCHAR (8000),
                                 @As_SignedOnWorker_ID        VARCHAR (36))
AS
   BEGIN
      /* Insert data on table ACLG_Y1 */
      INSERT INTO ACLG_Y1 (Unique_ID,
                           AccessByUser_ID,
                           PageLocation,
                           [Service_NAME],
                           Method_NAME,
                           Application_ID,
                           ServerIP_TEXT,
                           ClientIp_TEXT,
                           Agent_TEXT,
                           HttpStatus,
                           StartTime_DTTM,
                           EndTime_DTTM,
                           Input_JSON,
                           Status_JSON)
      VALUES (@As_Unique_ID,
              @As_SignedOnWorker_ID,
              @As_PageLocation,
              @As_Service_NAME,
              @As_Method_NAME,
              @As_Application_ID,
              @As_ServerIP_TEXT,
              @As_ClientIp_TEXT,
              @As_Agent_TEXT,
              @An_HttpStatus,
              @Ad_StartTime_DTTM,
              @Ad_EndTime_DTTM,
              @As_Input_JSON,
              @As_Status_JSON);
   END