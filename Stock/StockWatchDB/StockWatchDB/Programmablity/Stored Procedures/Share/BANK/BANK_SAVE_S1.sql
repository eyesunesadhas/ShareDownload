/*=============================================================================================
 Procedure : BANK_SAVE_S1
 Purpose   : Insert Data on BANK_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE BANK_SAVE_S1 (
   @Ai_Account_ID                        INT = NULL,
   @As_Bank_NAME                         VARCHAR (255),
   @As_BankAccount_ID                    VARCHAR (20),
   @As_AccountType_CODE                  VARCHAR (10),
   @As_Owner_NAME                        VARCHAR (255) ,
   @Ac_HideAccount_INDC                  CHAR(1) = 'N',
   @An_TransactionEventSeq_NUMB          NUMERIC (19, 0),
   @An_NewTransactionEventSeq_NUMB       NUMERIC (19, 0),
   @As_SignedOnWorker_ID                 VARCHAR (36),
   @Ai_Account_ID_Out                    INT OUTPUT)
AS
   BEGIN
      DECLARE @Ld_SystemDatetime   DATETIME2 = SYSDATETIME ();

      /* Check the existance of recored with Primary Key */
      IF (EXISTS
             (SELECT TOP 1 1
                FROM AccountMaster_T1 A
               WHERE A.Account_ID = @Ai_Account_ID))
         BEGIN
            SET @Ai_Account_ID_Out = @Ai_Account_ID;

            UPDATE AccountMaster_T1
               SET Bank_NAME = @As_Bank_NAME,
                   BankAccount_ID = @As_BankAccount_ID,
                   AccountType_CODE = @As_AccountType_CODE,
                   Owner_NAME = @As_Owner_NAME,
                   HideAccount_INDC = @Ac_HideAccount_INDC,
                   TransactionEventSeq_NUMB = @An_NewTransactionEventSeq_NUMB,
                   Update_DTTM = @Ld_SystemDatetime,
                   WorkerUpdate_ID = @As_SignedOnWorker_ID
             WHERE Account_ID = @Ai_Account_ID;

            RETURN;
         END

      /* Insert data on table BANK_Y1 */
      INSERT INTO AccountMaster_T1 (Bank_NAME,
                           BankAccount_ID,
                           AccountType_CODE,
                           Owner_NAME,
                           HideAccount_INDC,
                           TransactionEventSeq_NUMB,
                           Update_DTTM,
                           WorkerUpdate_ID)
      VALUES (@As_Bank_NAME,
              @As_BankAccount_ID,
              @As_AccountType_CODE,
              @As_Owner_NAME,
              @Ac_HideAccount_INDC ,
              @An_NewTransactionEventSeq_NUMB,
              @Ld_SystemDatetime,
              @As_SignedOnWorker_ID);

      SET @Ai_Account_ID_Out = @@IDENTITY;
   END