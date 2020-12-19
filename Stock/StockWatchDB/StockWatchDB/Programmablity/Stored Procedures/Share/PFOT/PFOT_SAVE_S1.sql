/*=============================================================================================
 Procedure : PFOT_SAVE_S1
 Purpose   : Insert Data on PortfolioTrans_T1
 CreatedBy :
 CreatedOn : 10/09/2020
 */
CREATE PROCEDURE PFOT_SAVE_S1 (
   @Ai_Trans_ID                          INT  NULL,
   @As_Trade_CODE                        VARCHAR (15),
   @Ai_Account_ID                        INT,
   @An_Shares_CNT                        NUMERIC (11, 4),
   @As_TransAction_CODE                  VARCHAR (10),
   @Ad_TransAction_DATE                  DATE,
   @Ad_Settlement_DATE                   DATE,
   @An_CostBasis_AMNT                    MONEY,
   @An_TransactionEventSeq_NUMB          NUMERIC (19, 0),
   @An_NewTransactionEventSeq_NUMB       NUMERIC (19, 0),
   @As_SignedOnWorker_ID                 VARCHAR (36),
   @Ai_OutTrans_ID                       INT  OUTPUT
   )
AS
   BEGIN
       IF(IsNull(@Ai_Trans_ID,0) != 0)
       BEGIN
          RETURN;
       END
       DECLARE @Ld_SystemDatetime   DATETIME2 = SYSDATETIME();
       /* SELL Transaction must have - count */
       IF(@As_TransAction_CODE = 'SELL' AND @An_Shares_CNT > 0)
       BEGIN
          SET  @An_Shares_CNT = - @An_Shares_CNT;
       END 
     
       DECLARE @Ln_Shares_CNT NUMERIC(11,2) = 0,
               @Ln_CostBasis_AMNT MONEY = 0 ,
               @Li_Portfolio_ID   INT = 0 ,
               @Li_Portfolio_ID_OUT INT = 0;
     
      SELECT @Ln_Shares_CNT = A.Shares_CNT ,
             @Ln_CostBasis_AMNT = A.CostBasis_AMNT
           FROM Portfolio_T1 A
        WHERE A.Account_ID = @Ai_Account_ID 
          AND A.Trade_CODE = @As_Trade_CODE;
     /* Balance shares */
     SET @Ln_Shares_CNT = @Ln_Shares_CNT + @An_Shares_CNT;

     IF(@As_TransAction_CODE = 'BUY')
     BEGIN
         SET @Ln_CostBasis_AMNT  = ((@Ln_Shares_CNT * @Ln_CostBasis_AMNT )
                                    +  (@An_Shares_CNT * @An_CostBasis_AMNT ) ) / (@Ln_Shares_CNT + @An_Shares_CNT)
         
     END 
     IF(@As_TransAction_CODE = 'SELL')
     BEGIN
        UPDATE ShareMaster_T1 
          SET SoldAt_AMNT = @An_CostBasis_AMNT ,
              SoldOn_DATE = @Ad_TransAction_DATE
          WHERE Trade_CODE = @As_Trade_CODE;
     END

     exec PFOL_SAVE_S1   @As_Trade_CODE   =  @As_Trade_CODE  ,    
                         @Ai_Account_ID   =  @Ai_Account_ID  ,
                         @An_Shares_CNT   =  @Ln_Shares_CNT  ,
                         @An_CostBasis_AMNT  =  @Ln_CostBasis_AMNT ,
                         @An_TransactionEventSeq_NUMB     = @An_TransactionEventSeq_NUMB ,
                         @An_NewTransactionEventSeq_NUMB  = @An_NewTransactionEventSeq_NUMB,
                         @As_SignedOnWorker_ID  = @As_SignedOnWorker_ID;
      /* Insert data on table PortfolioTrans_T1 */
       DECLARE @Li_Seq_NUMB INT  = 0;
       SELECT @Li_Seq_NUMB = Count(1)
          FROM PFOT_Y1 A 
          WHERE A.Account_ID = @Ai_Account_ID
           AND  A.Trade_CODE = @As_Trade_CODE
           AND  A.TransAction_DATE = @Ad_TransAction_DATE;
      SET @Li_Seq_NUMB = IsNull(@Li_Seq_NUMB,0) + 1 ;

      DECLARE @Ls_Trade_ID VARCHAR(45) = dbo.GetTradeID( @As_Trade_CODE , @As_TransAction_CODE,@Ad_TransAction_DATE,@Li_Seq_NUMB);
      INSERT INTO PFOT_Y1 (
                        Trade_CODE,
                        Account_ID,
                        Shares_CNT,
                        TransAction_CODE,
                        TransAction_DATE,
                        Settlement_DATE,
                        CostBasis_AMNT,
                        Trade_ID,
                        TransactionEventSeq_NUMB,
                        Update_DTTM,
                        WorkerUpdate_ID)
      VALUES (
              @As_Trade_CODE,
              @Ai_Account_ID,
              @An_Shares_CNT,
              @As_TransAction_CODE,
              @Ad_TransAction_DATE,
              @Ad_Settlement_DATE,
              @An_CostBasis_AMNT,
              @Ls_Trade_ID,
              @An_NewTransactionEventSeq_NUMB,
              @Ld_SystemDatetime,
              @As_SignedOnWorker_ID);
       SET @Ai_OutTrans_ID = @@IDENTITY;    
         
   END