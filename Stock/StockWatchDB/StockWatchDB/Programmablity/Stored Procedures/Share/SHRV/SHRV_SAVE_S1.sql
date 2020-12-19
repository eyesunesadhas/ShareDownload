/*=============================================================================================
 Procedure : SHRV_SAVE_S1
 Purpose   : Insert Data on SHRV_Y1
 CreatedBy :
 CreatedOn : 09/25/2020
 */
CREATE PROCEDURE SHRV_SAVE_S1 (
   @As_Trade_CODE                     VARCHAR (15),
   @Ad_Trade_DATE                     DATE,
   @An_Open_AMNT                      MONEY,
   @An_Close_AMNT                     MONEY,
   @An_Low_AMNT                       MONEY,
   @An_High_AMNT                      MONEY,
   @An_Current_AMNT                   MONEY,
   @An_Volume_CNT                     BIGINT,
   @An_AvgVol_CNT                     BIGINT,
   @An_TransactionEventSeq_NUMB       NUMERIC (19, 0),
   @An_NewTransactionEventSeq_NUMB    NUMERIC (19, 0) = NULL,
   @As_SignedOnWorker_ID              VARCHAR (36))
AS
   BEGIN
      DECLARE @Ld_SystemDatetime   DATETIME2 = SYSDATETIME ();

      /* Check the existance of recored with Primary Key */
      IF (EXISTS
             (SELECT TOP 1 1
                FROM ShareMarketValue_T1 A
               WHERE A.Trade_CODE = @As_Trade_CODE))
         BEGIN
            UPDATE ShareMarketValue_T1
               SET Trade_DATE = @Ad_Trade_DATE,
                   Open_AMNT = @An_Open_AMNT,
                   Low_AMNT = @An_Low_AMNT,
                   High_AMNT = @An_High_AMNT,
                   Close_AMNT = @An_Close_AMNT,
                   Current_AMNT = @An_Current_AMNT,
                   Volume_CNT = @An_Volume_CNT,
                   AvgVol_CNT = @An_AvgVol_CNT,
                   TransactionEventSeq_NUMB = @An_NewTransactionEventSeq_NUMB,
                   Update_DTTM = @Ld_SystemDatetime,
                   WorkerUpdate_ID = @As_SignedOnWorker_ID
             WHERE Trade_CODE = @As_Trade_CODE;

            RETURN;
         END

      /* Insert data on table SHRV_Y1 */
      INSERT INTO ShareMarketValue_T1 (Trade_CODE,
                           Trade_DATE,
                           Open_AMNT,
                           Low_AMNT,
                           High_AMNT,
                           Close_AMNT,
                           Current_AMNT,
                           Volume_CNT,
                           AvgVol_CNT,
                           TransactionEventSeq_NUMB,
                           Update_DTTM,
                           WorkerUpdate_ID)
      VALUES (@As_Trade_CODE,
              @Ad_Trade_DATE,
              @An_Open_AMNT,
              @An_Low_AMNT,
              @An_High_AMNT,
              @An_Close_AMNT,
              @An_Current_AMNT,
              @An_Volume_CNT,
              @An_AvgVol_CNT,
              @An_NewTransactionEventSeq_NUMB,
              @Ld_SystemDatetime,
              @As_SignedOnWorker_ID);
   END