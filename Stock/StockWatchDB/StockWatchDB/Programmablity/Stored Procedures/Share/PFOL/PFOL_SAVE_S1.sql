/*=============================================================================================
 Procedure : PFOL_SAVE_S1
 Purpose   : Insert Data on PFOL_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE PFOL_SAVE_S1 (
   @As_Trade_CODE                        VARCHAR (15),
   @Ai_Account_ID                        INT,
   @An_Shares_CNT                        NUMERIC (11, 4),
   @An_CostBasis_AMNT                    MONEY,
   @An_TransactionEventSeq_NUMB          NUMERIC (19, 0),
   @An_NewTransactionEventSeq_NUMB       NUMERIC (19, 0),
   @As_SignedOnWorker_ID                 VARCHAR (36)
  )
AS
   BEGIN
      DECLARE @Ld_SystemDatetime   DATETIME2 = SYSDATETIME ();

      /* Check the existance of recored with Primary Key */
      IF (EXISTS
             (SELECT TOP 1 1
                FROM Portfolio_T1 A
               WHERE    A.Trade_CODE = @As_Trade_CODE
                     AND A.Account_ID = @Ai_Account_ID))
         BEGIN
            UPDATE Portfolio_T1
               SET Shares_CNT = @An_Shares_CNT,
                   CostBasis_AMNT = @An_CostBasis_AMNT,
                   TransactionEventSeq_NUMB = @An_NewTransactionEventSeq_NUMB,
                   Update_DTTM = @Ld_SystemDatetime,
                   WorkerUpdate_ID = @As_SignedOnWorker_ID
             WHERE     Trade_CODE = @As_Trade_CODE
                   AND Account_ID = @Ai_Account_ID;

            RETURN;
         END
      
      /* Insert data on table PFOL_Y1 */
      INSERT INTO Portfolio_T1 (Trade_CODE,
                           Account_ID,
                           Shares_CNT,
                           CostBasis_AMNT,
                           TransactionEventSeq_NUMB,
                           Update_DTTM,
                           WorkerUpdate_ID)
      VALUES (@As_Trade_CODE,
              @Ai_Account_ID,
              @An_Shares_CNT,
              @An_CostBasis_AMNT,
              @An_NewTransactionEventSeq_NUMB,
              @Ld_SystemDatetime,
              @As_SignedOnWorker_ID);

   END