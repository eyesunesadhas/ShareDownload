CREATE PROCEDURE BATCH_COMMON$SP_GET_ERROR_DESCRIPTION
   @As_Procedure_NAME                 VARCHAR (200),
   @As_ErrorMessage_TEXT              VARCHAR (MAX),
   @As_Sql_TEXT                       VARCHAR (200),
   @As_Sqldata_TEXT                   VARCHAR (2000),
   @An_Error_NUMB                     NUMERIC (11),
   @An_ErrorLine_NUMB                 NUMERIC (11) = 0,
   @As_DescriptionError_TEXT          VARCHAR (MAX) OUTPUT
/*
-----------------------------------------------------------------------------------------
Procedure Name : BATCH_COMMON$SP_GET_ERROR_DESCRIPTION
Description    : The procedure will Concatenate the error description which is passed in
                 input parameters and returns the Error description.
-----------------------------------------------------------------------------------------
*/
AS
   BEGIN
      SET  NOCOUNT ON;

      --BEGIN OF BATCH_COMMON$SP_GET_ERROR_DESCRIPTION

      BEGIN TRY
         SET @As_Procedure_NAME = ISNULL (@As_Procedure_NAME, '');
         SET @As_ErrorMessage_TEXT = ISNULL (@As_ErrorMessage_TEXT, '');
         SET @As_Sql_TEXT = ISNULL (@As_Sql_TEXT, '');
         SET @As_Sqldata_TEXT = ISNULL (@As_Sqldata_TEXT, '');
         SET @As_DescriptionError_TEXT = '';

         IF @An_Error_NUMB = 50001
            BEGIN
               SET @As_DescriptionError_TEXT =
                        'Error IN '
                      + @As_Procedure_NAME
                      + ' PROCEDURE'
                      + '. Error DESC - '
                      + @As_ErrorMessage_TEXT
                      + '. Error EXECUTE Location - '
                      + @As_Sql_TEXT
                      + '. Error List KEY - '
                      + @As_Sqldata_TEXT;
            END
         ELSE
            BEGIN
               SET @As_DescriptionError_TEXT =
                        'Error IN '  + @As_Procedure_NAME   + ' PROCEDURE'    
                      + '. Error DESC - '     + SUBSTRING (@As_ErrorMessage_TEXT, 1, 200)
                      + '. Error Line No - '  + ISNULL (CAST (@An_ErrorLine_NUMB AS VARCHAR), '')
                      + '. Error Number - '    + ISNULL (CAST (@An_Error_NUMB AS VARCHAR), '')
                      + '. Error EXECUTE Location - '   + @As_Sql_TEXT
                      + '. Error List KEY - ' + @As_Sqldata_TEXT;
            END
      END TRY
      BEGIN CATCH
         SET @As_DescriptionError_TEXT =  @As_ErrorMessage_TEXT
                                          + '-'  + SUBSTRING (ERROR_MESSAGE (), 1, 200);
      END CATCH
   END                          --END OF BATCH_COMMON$SP_GET_ERROR_DESCRIPTION