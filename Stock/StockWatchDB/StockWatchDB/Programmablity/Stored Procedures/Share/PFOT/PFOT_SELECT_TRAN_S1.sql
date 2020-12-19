CREATE PROCEDURE PFOT_SELECT_TRAN_S1(@Ai_Account_ID      INT ,
                                    @As_Trade_CODE      VARCHAR (15) = NULL
                                  )
AS
   BEGIN
        SELECT      A.TransAction_DATE ,
                    SM.Trade_CODE ,
                    SM.Trade_NAME ,
                    A.TransAction_CODE ,
                    A.Shares_CNT,
                    A.CostBasis_AMNT,
                    A.Shares_CNT * A.CostBasis_AMNT TotalInvest_AMNT,
                    A.Account_ID ,
                    B.Bank_NAME,
                    B.BankAccount_ID,
                    B.AccountType_CODE ,
                    R.DescriptionValue_TEXT AccountType_TEXT,
                    B.Owner_NAME ,
                    ROW_NUMBER() OVER(PARTITION BY A.Account_ID ORDER BY A.TransAction_DATE , A.Trans_ID )  Row_NUMB,
                    SUM( CASE WHEN A.TransAction_CODE = 'BUY'
                                   THEN  A.Shares_CNT
                                   ELSE -A.Shares_CNT
                                   END ) 
                         OVER(PARTITION BY A.Account_ID,SM.Trade_CODE 
                         ORDER BY  A.TransAction_DATE , A.Trans_ID) SharesInHand_CNT,  
                     SUM( CASE WHEN A.TransAction_CODE = 'BUY'
                                   THEN   A.Shares_CNT * A.CostBasis_AMNT
                                   ELSE  - A.Shares_CNT * A.CostBasis_AMNT
                                   END ) 
                         OVER(PARTITION BY A.Account_ID,SM.Trade_CODE 
                         ORDER BY  A.TransAction_DATE , A.Trans_ID) RunningInvest_AMNT, 
                     SUM( CASE WHEN A.TransAction_CODE = 'BUY'
                                   THEN   A.Shares_CNT * A.CostBasis_AMNT
                                   ELSE   - A.Shares_CNT * A.CostBasis_AMNT
                                   END ) 
                         OVER(PARTITION BY A.Account_ID 
                         ORDER BY  A.TransAction_DATE , A.Trans_ID) Worth_AMNT,    
                    A.Trans_ID 
             FROM PortfolioTrans_T1 A
                  JOIN AccountMaster_T1 B ON A.Account_ID = B.Account_ID
                  JOIN ShareMaster_T1 SM ON A.Trade_CODE = SM.Trade_CODE
                  LEFT OUTER JOIN RefMaintenance_T1 R
                     ON     R.Table_ID = 'BANKACC'
                        AND R.TableSub_ID = 'TYPE'
                        AND R.Value_CODE = AccountType_CODE
             WHERE     A.Account_ID = @Ai_Account_ID 
                   AND A.Trade_CODE = IsNull (@As_Trade_CODE, A.Trade_CODE)
         ORDER BY A.TransAction_DATE DESC;
   END