CREATE PROCEDURE BPFOT_DELETE_S1(@As_BankAccount_ID  VARCHAR(8000))
AS
 BEGIN
   DECLARE @BankAccount_P1 TABLE (
       BankAccount_ID VARCHAR(20)  NULL
   );

   INSERT INTO  @BankAccount_P1(BankAccount_ID)
    SELECT A.Word BankAccount_ID 
       FROM SplitCommaSeperated(@As_BankAccount_ID) A;

   DELETE FROM BankPortfolioTrans_T1 
      WHERE BankAccount_ID  IN (
                SELECT A.BankAccount_ID
                  FROM @BankAccount_P1 A
                  );
 END