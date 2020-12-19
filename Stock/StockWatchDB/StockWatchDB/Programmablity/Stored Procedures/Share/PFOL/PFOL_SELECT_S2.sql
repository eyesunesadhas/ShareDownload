﻿/*=============================================================================================
 Procedure : PFOL_SELECT_S2
 Purpose   : Select Data from PFOL_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE PFOL_SELECT_S2 (@As_Trade_CODE     VARCHAR (15)= NULL,
                                @Ai_Account_ID     INT= NULL)
AS
BEGIN
   SET @Ai_Account_ID = NULLIF (@Ai_Account_ID, 0);

   SELECT A.* ,
          A.TotalCurrent_AMNT - A.TotalInvest_AMNT TotalBenefit_AMNT
   FROM (SELECT SM.Trade_CODE,
                SM.Trade_NAME,
                SM.Week52Low_AMNT,
                SM.Week52High_AMNT,
                SM.DividendPerShare_AMNT,
                SM.DividendYield_NUMB,
                SM.PERatio_NUMB,
                SM.Dividend_DATE,
                SM.BuyReco_INDC,
                SM.BuyRecoBy_NAME,
                SM.BuyReco_DATE,
                SM.SoldAt_AMNT,
                SM.SoldOn_DATE,
                A.Account_ID,
                B.Bank_NAME,
                B.BankAccount_ID,
                B.AccountType_CODE,
                B.HideAccount_INDC ,
                R.DescriptionValue_TEXT AccountType_TEXT,
                B.Owner_NAME,
                0 Trans_ID,
                A.Shares_CNT,
                A.CostBasis_AMNT,
                A.Shares_CNT * A.CostBasis_AMNT TotalInvest_AMNT,
                SV.Current_AMNT,
                A.Shares_CNT * SV.Current_AMNT TotalCurrent_AMNT ,
                SV.Current_AMNT - A.CostBasis_AMNT Benefit_AMNT ,
                'HOLD' TransAction_CODE ,
                NULL TransAction_DATE ,
                ST.BuyAt_AMNT ,
                ST.SellAt_AMNT
         FROM Portfolio_T1 A
              JOIN AccountMaster_T1 B ON A.Account_ID = B.Account_ID
              JOIN ShareMaster_T1 SM ON A.Trade_CODE = SM.Trade_CODE
              LEFT OUTER JOIN ShareMarketValue_T1 SV ON A.Trade_CODE = SV.Trade_CODE
              LEFT OUTER JOIN ShareTradeValue_T1 ST  ON A.Trade_CODE = ST.Trade_CODE
              LEFT OUTER JOIN RefMaintenance_T1 R
                 ON     R.Table_ID = 'BANKACC'
                    AND R.TableSub_ID = 'TYPE'
                    AND R.Value_CODE = AccountType_CODE
         WHERE     A.Shares_CNT > 0
               AND B.HideAccount_INDC != 'Y'
               AND A.Trade_CODE = IsNull (@As_Trade_CODE, A.Trade_CODE)
               AND A.Account_ID = IsNull (@Ai_Account_ID, A.Account_ID)) A
   ORDER BY A.Trade_CODE, A.Account_ID;
END