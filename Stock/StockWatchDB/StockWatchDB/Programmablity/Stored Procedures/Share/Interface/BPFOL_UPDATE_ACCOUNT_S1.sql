CREATE PROCEDURE BPFOL_UPDATE_ACCOUNT_S1
AS
BEGIN
    UPDATE A
      SET A.Account_ID = B.Account_ID
    FROM BankPortfolioData_T1 A 
      JOIN AccountMaster_T1 B 
        ON A.BankAccount_ID = B.BankAccount_ID;
END
