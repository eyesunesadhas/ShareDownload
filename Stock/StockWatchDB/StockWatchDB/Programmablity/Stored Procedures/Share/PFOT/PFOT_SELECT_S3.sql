CREATE PROCEDURE PFOL_SELECT_S3(@Ai_Account_ID      INT ,
                                @As_Trade_CODE      VARCHAR (15) = NULL
                                )
AS
   BEGIN
   SELECT       A.TransAction_DATE ,
                A.TransAction_CODE ,
                A.Trans_ID ,
                SM.Trade_CODE ,
                SM.Trade_NAME ,
                A.Account_ID ,
                A.Shares_CNT,
                A.CostBasis_AMNT,
                A.Shares_CNT * A.CostBasis_AMNT TotalInvest_AMNT,
                SV.Current_AMNT,
                A.Shares_CNT * SV.Current_AMNT TotalCurrent_AMNT ,
                SV.Current_AMNT - A.CostBasis_AMNT Benefit_AMNT ,
                SM.Week52Low_AMNT,
                SM.Week52High_AMNT,
                B.Bank_NAME,
                B.BankAccount_ID,
                B.AccountType_CODE,
                SM.BuyReco_INDC,
                SM.BuyRecoBy_NAME,
                SM.BuyReco_DATE
         FROM PortfolioTrans_T1 A
              JOIN AccountMaster_T1 B ON A.Account_ID = B.Account_ID
              JOIN ShareMaster_T1 SM ON A.Trade_CODE = SM.Trade_CODE
              LEFT OUTER JOIN ShareMarketValue_T1 SV ON A.Trade_CODE = SV.Trade_CODE
              LEFT OUTER JOIN RefMaintenance_T1 R
                 ON     R.Table_ID = 'BANKACC'
                    AND R.TableSub_ID = 'TYPE'
                    AND R.Value_CODE = AccountType_CODE
         WHERE     A.Account_ID = @Ai_Account_ID 
               AND A.Trade_CODE = IsNull (@As_Trade_CODE, A.Trade_CODE)
         ORDER BY A.TransAction_DATE DESC;
   END