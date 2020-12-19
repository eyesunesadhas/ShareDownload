/*=============================================================================================
 Procedure : AULG_INSERT_S1
 Purpose   : Insert Data on AULG_Y1
 CreatedBy :
 CreatedOn : 07/17/2020
 */
CREATE PROCEDURE AULG_INSERT_S1 (@As_Unique_ID        VARCHAR (35),
                                 @As_User_ID          VARCHAR (36),
                                 @As_Ticket_ID        VARCHAR(1000),
                                 @As_AuthType_CODE    CHAR (10),
                                 @As_ClientIp_TEXT    VARCHAR (15),
                                 @Ai_Attempt_CNT      TINYINT,
                                 @As_Error_CODE       CHAR (18),
                                 @As_Error_TEXT       VARCHAR (300))
AS
   BEGIN
      /* Insert data on table AULG_Y1 */
      INSERT INTO AULG_Y1 (Unique_ID,
                           [User_ID],
                           Ticket_ID,
                           AuthType_CODE,
                           ClientIp_TEXT,
                           Attempt_CNT ,
                           Error_CODE,
                           Error_TEXT)
      VALUES (@As_Unique_ID,
              @As_User_ID,
              @As_Ticket_ID,
              @As_AuthType_CODE,
              @As_ClientIp_TEXT,
              @Ai_Attempt_CNT,
              @As_Error_CODE,
              @As_Error_TEXT);
   END