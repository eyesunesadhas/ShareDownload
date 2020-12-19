CREATE PROCEDURE BPFOT_UPDATE_ACCOUNT_S1
AS
BEGIN
    UPDATE A
      SET A.Account_ID = B.Account_ID
    FROM BankPortfolioTrans_T1 A 
      JOIN AccountMaster_T1 B 
        ON A.BankAccount_ID = B.BankAccount_ID;

   UPDATE A 
       SET A.Trade_ID =  dbo.GetTradeID(B.Trade_CODE, B.TransAction_CODE ,B.TransAction_DATE, B.TransSeq_NUMB) 
    FROM BankPortfolioTrans_T1 A  
       JOIN (
            SELECT A.BankAccount_ID,
                   A.Trade_CODE ,
	               A.TransAction_CODE,
                   A.TransAction_DATE, 
	               A.Shares_CNT,
	               A.CostBasis_AMNT,
	               A.Value_AMNT ,
	               A.Seq_NUMB ,
               ROW_NUMBER() OVER (
                  PARTITION BY A.BankAccount_ID, A.TransAction_DATE,A.Trade_CODE
                  ORDER BY Seq_NUMB 
               ) TransSeq_NUMB
            FROM BankPortfolioTrans_T1 A ) B
        ON   A.BankAccount_ID = B.BankAccount_ID
         AND A.Seq_NUMB = B.Seq_NUMB
         AND A.Trade_CODE = B.Trade_CODE
         AND A.TransAction_DATE = B.TransAction_DATE;
END
