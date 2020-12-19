
/*=============================================================================================
 Procedure : PFOL_SELECT_SUMM_S3
 Purpose   : Select Data from PFOL_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE PFOL_SELECT_SUMM_S3
AS
BEGIN
 SELECT A.Trade_CODE,
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
       0 Account_ID,
       '' Bank_NAME,
       '' BankAccount_ID,
       '' AccountType_CODE,
       '' AccountType_TEXT,
       '' Owner_NAME,
       0 Trans_ID,
       NULL TransAction_DATE,
       'HOLD' TransAction_CODE,
       A.Shares_CNT,
       A.TotalInvest_AMNT / A.Shares_CNT CostBasis_AMNT,
       A.TotalInvest_AMNT,
       A.Current_AMNT,
       A.TotalCurrent_AMNT,
       A.Current_AMNT - (A.TotalInvest_AMNT / A.Shares_CNT) Benefit_AMNT,
       A.TotalCurrent_AMNT - A.TotalInvest_AMNT TotalBenefit_AMNT ,
       ST.BuyAt_AMNT ,
       ST.SellAt_AMNT
  FROM    (SELECT A.Trade_CODE,
                  SUM (A.Shares_CNT) Shares_CNT,
                  SUM (A.Shares_CNT * A.CostBasis_AMNT) TotalInvest_AMNT,
                  MAX (SV.Current_AMNT) Current_AMNT,
                  SUM (A.Shares_CNT * SV.Current_AMNT) TotalCurrent_AMNT
             FROM    Portfolio_T1 A
                  LEFT OUTER JOIN
                     ShareMarketValue_T1 SV
                  ON A.Trade_CODE = SV.Trade_CODE
            WHERE A.Shares_CNT > 0
              AND A.Account_ID IN (  
                                  SELECT AM.Account_ID 
                                     FROM AccountMaster_T1 AM 
                                     WHERE AM.HideAccount_INDC = 'N')
           GROUP BY A.Trade_CODE) A
       JOIN
          ShareMaster_T1 SM
         ON A.Trade_CODE = SM.Trade_CODE
       LEFT OUTER JOIN ShareTradeValue_T1 ST
         ON A.Trade_CODE = ST.Trade_CODE
   ORDER BY A.Trade_CODE;
END