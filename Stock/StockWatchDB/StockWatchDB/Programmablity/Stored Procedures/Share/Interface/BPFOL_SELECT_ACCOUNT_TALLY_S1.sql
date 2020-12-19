/*=============================================================================================
 Procedure : PFOT_SELECT_S2
 Purpose   : Select Data from PFOT_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE BPFOL_SELECT_ACCOUNT_TALLY_S4 
AS
   BEGIN

   SELECT       IsNUll( B.BankAccount_ID, BD.BankAccount_ID) BankAccount_ID,
                B.Owner_NAME,
                IsNull(SM.Trade_CODE,BD.Trade_CODE) Trade_CODE  ,
                IsNull(SM.Trade_NAME,BD.Trade_NAME)  Trade_NAME,
                A.Shares_CNT,
                BD.Shares_CNT AccountShares_CNT,
                CASE WHEN IsNull(A.Shares_CNT,0) != IsNull(BD.Shares_CNT,0) THEN 'Y'
                    ELSE 'N'
                END ShareMismatch_INDC ,
                A.CostBasis_AMNT,
                A.Shares_CNT * A.CostBasis_AMNT TotalInvest_AMNT,
                BD.Export_DATE 
         FROM  BankPortfolioData_T1 BD 
              FULL OUTER JOIN  Portfolio_T1 A
                ON A.Account_ID = BD.Account_ID
                  AND A.Trade_CODE = BD.Trade_CODE
              LEFT OUTER  JOIN AccountMaster_T1 B 
                  ON A.Account_ID = B.Account_ID
               LEFT OUTER  JOIN ShareMaster_T1 SM
                  ON A.Trade_CODE = SM.Trade_CODE
         WHERE  IsNull(A.Shares_CNT,BD.Shares_CNT) != 0
               AND IsNull(A.Account_ID,BD.Account_ID) IN (SELECT C.Account_ID FROM BankPortfolioData_T1 C)
       
         ORDER BY  IsNull(A.Account_ID,BD.Account_ID), IsNull(SM.Trade_CODE,BD.Trade_CODE);
    
   END