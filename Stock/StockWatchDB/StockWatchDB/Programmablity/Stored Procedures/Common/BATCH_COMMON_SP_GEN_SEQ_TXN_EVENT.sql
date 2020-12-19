/*
-----------------------------------------------------------------------------------------
Procedure Name : BATCH_COMMON$SP_GEN_SEQ_TXN_EVENT
Description    : Generates global sequence number.
-----------------------------------------------------------------------------------------
*/
CREATE PROCEDURE BATCH_COMMON$SP_GEN_SEQ_TXN_EVENT (
   @As_SignedOnWorker_ID                 VARCHAR (36),
   @Ac_Process_ID                        VARCHAR (50),
   @Ad_EffectiveEvent_DATE               DATE,
   @An_EventFunctionalSeq_NUMB           SMALLINT,
   @An_TransactionEventSeq_NUMB          NUMERIC (19) OUTPUT,
   @Ac_Msg_CODE                          CHAR (1) OUTPUT,
   @As_DescriptionError_TEXT             VARCHAR (4000) OUTPUT)
AS
   BEGIN
      SET  NOCOUNT ON;
      --BEGIN OF BATCH_COMMON$SP_GEN_SEQ_TXN_EVENT

      DECLARE
         @Lc_StatusSuccess_CODE CHAR (1) = 'S',
         @Lc_StatusFailed_CODE CHAR (1) = 'F',
         @Ls_Procedure_NAME VARCHAR (100)  = 'BATCH_COMMON$SP_GEN_SEQ_TXN_EVENT';
      DECLARE
         @Ln_Error_NUMB NUMERIC,
         @Ln_Rowcount_QNTY NUMERIC,
         @Ln_Zero_NUMB NUMERIC (1) = 0,
         @Ln_ErrorLine_NUMB NUMERIC (11),
         @Ls_Sql_TEXT VARCHAR (200) = '',
         @Ls_Sqldata_TEXT VARCHAR (2000) = '',
         @Ls_ErrorMessage_TEXT VARCHAR (4000) = '';

      BEGIN TRY
         SET @Ac_Msg_CODE = '';
         SET @As_DescriptionError_TEXT = '';
         SET @An_TransactionEventSeq_NUMB = 0;
         SET @Ls_Sql_TEXT = 'INSERT GLEC_Y1';
         SET @Ls_Sqldata_TEXT =
                  'EffectiveEvent_DATE = '         + ISNULL (CAST (@Ad_EffectiveEvent_DATE AS VARCHAR), '')
                + ', Worker_ID = '                 + ISNULL (@As_SignedOnWorker_ID, '')
                + ', EventFunctionalSeq_NUMB = '   + ISNULL (CAST (@An_EventFunctionalSeq_NUMB AS VARCHAR), '');

         INSERT GLEC_Y1 (EffectiveEvent_DATE,
                         WorkerUpdate_ID,
                         Process_ID,
                         EventFunctionalSeq_NUMB)
         VALUES (@Ad_EffectiveEvent_DATE,                
                 IsNull (@As_SignedOnWorker_ID, ''),    
                 @Ac_Process_ID,
                 @An_EventFunctionalSeq_NUMB);      

         SET @Ln_Rowcount_QNTY = @@ROWCOUNT;

         IF @Ln_Rowcount_QNTY = @Ln_Zero_NUMB
            BEGIN
               SET @Ls_ErrorMessage_TEXT = 'INSERT GLEC_Y1 FAILED';

               RAISERROR (50001, 16, 1);
            END

         SET @An_TransactionEventSeq_NUMB = @@IDENTITY;
         SET @Ac_Msg_CODE = @Lc_StatusSuccess_CODE;
      END TRY
      BEGIN CATCH
         SET @Ac_Msg_CODE = @Lc_StatusFailed_CODE;
         SET @Ln_Error_NUMB = ERROR_NUMBER ();
         SET @Ln_ErrorLine_NUMB = ERROR_LINE ();

         IF @Ln_Error_NUMB <> 50001
            BEGIN
               SET @Ls_ErrorMessage_TEXT =
                      SUBSTRING (ERROR_MESSAGE (), 1, 200);
            END

         EXECUTE BATCH_COMMON$SP_GET_ERROR_DESCRIPTION @As_Procedure_NAME = @Ls_Procedure_NAME,
                                                        @As_ErrorMessage_TEXT = @Ls_ErrorMessage_TEXT,
                                                        @As_Sql_TEXT = @Ls_Sql_TEXT,
                                                        @As_Sqldata_TEXT = @Ls_Sqldata_TEXT,
                                                        @An_Error_NUMB = @Ln_Error_NUMB,
                                                        @An_ErrorLine_NUMB = @Ln_ErrorLine_NUMB,
                                                        @As_DescriptionError_TEXT = @As_DescriptionError_TEXT OUTPUT ;
      END CATCH
   END      
   --END OF BATCH_COMMON$SP_GEN_SEQ_TXN_EVENT
GO