/*=============================================================================================
 Procedure : SPLG_INSERT_S1
 Purpose   : Insert Data on SPLG_Y1
 CreatedBy :
 CreatedOn : 07/17/2020
 */
CREATE PROCEDURE SPLG_INSERT_S1 (@As_Application_NAME        VARCHAR (50),
                                 @As_Unique_ID               VARCHAR (35),
                                 @As_Application_ID          VARCHAR (16),
                                 @As_StoredProcedure_NAME    VARCHAR (400),
                                 @Ad_StartTime_DTTM          DATETIME2,
                                 @Ad_EndTime_DTTM            DATETIME2,
                                 @As_Sql_TEXT                VARCHAR (MAX),
                                 @As_Error_TEXT              VARCHAR (8000),
                                 @As_SignedOnWorker_ID       VARCHAR (36))
AS
   BEGIN
      /* Insert data on table SPLG_Y1 */
      INSERT INTO SPLG_Y1 (Application_NAME,
                           Unique_ID,
                           AccessByUser_ID,
                           Application_ID,
                           StoredProcedure_NAME,
                           StartTime_DTTM,
                           EndTime_DTTM,
                           Sql_TEXT,
                           Error_TEXT)
      VALUES (@As_Application_NAME,
              @As_Unique_ID,
              @As_SignedOnWorker_ID,
              @As_Application_ID,
              @As_StoredProcedure_NAME,
              @Ad_StartTime_DTTM,
              @Ad_EndTime_DTTM,
              @As_Sql_TEXT,
              @As_Error_TEXT);
   END