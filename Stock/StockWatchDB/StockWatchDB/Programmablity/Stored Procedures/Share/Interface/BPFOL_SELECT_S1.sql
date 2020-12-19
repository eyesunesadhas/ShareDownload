CREATE PROCEDURE BPFOL_SELECT_S1
AS
 BEGIN
    SELECT  A.BankAccount_ID,
            A.Trade_CODE, 
            A.Trade_NAME,
            A.Shares_CNT,
            A.CostBasis_AMNT,
            A.Value_AMNT,
            A.Export_DATE 
    FROM BankPortfolioData_T1  A 
    WHERE 1 = 2;
 END
 

