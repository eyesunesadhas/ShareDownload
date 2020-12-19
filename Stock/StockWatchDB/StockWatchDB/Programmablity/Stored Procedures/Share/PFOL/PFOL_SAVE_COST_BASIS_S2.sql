CREATE PROCEDURE PFOL_SAVE_COST_BASIS_S2 (
   @As_Trade_CODE                  VARCHAR (15),
   @Ai_Account_ID                  INT,
   @An_CostBasis_AMNT              MONEY,
   @An_TransactionEventSeq_NUMB    NUMERIC (19, 0),
   @An_NewTransactionEventSeq_NUMB    NUMERIC (19, 0),
   @As_SignedOnWorker_ID           VARCHAR (36))
AS
   BEGIN
      DECLARE @Ld_SystemDatetime   DATETIME2 = SYSDATETIME ();
      UPDATE Portfolio_T1
         SET CostBasis_AMNT = @An_CostBasis_AMNT,
             TransactionEventSeq_NUMB = @An_NewTransactionEventSeq_NUMB,
             Update_DTTM = @Ld_SystemDatetime,
             WorkerUpdate_ID = @As_SignedOnWorker_ID
       WHERE Trade_CODE = @As_Trade_CODE
        AND Account_ID = @Ai_Account_ID;
   END