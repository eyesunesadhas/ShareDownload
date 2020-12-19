/*=============================================================================================
 Procedure : BANK_SELECT_S1
 Purpose   : Select Data from BANK_Y1
 CreatedBy : 
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE BANK_SELECT_S1(
	  	 @Ai_Account_ID  int
		,@As_Bank_NAME  varchar(255) OUTPUT 
		,@As_BankAccount_ID  varchar(20) OUTPUT 
		,@As_AccountType_CODE  varchar(10) OUTPUT 
		,@As_Owner_NAME  varchar(255) OUTPUT 
		,@Ac_HideAccount_INDC CHAR(1) OUTPUT
		,@An_TransactionEventSeq_NUMB  numeric(19,0) OUTPUT 
)
AS 
BEGIN
	SELECT @As_Bank_NAME = A.Bank_NAME
		,@As_BankAccount_ID = A.BankAccount_ID
		,@As_AccountType_CODE = A.AccountType_CODE
		,@As_Owner_NAME = A.Owner_NAME 
		,@Ac_HideAccount_INDC = A.HideAccount_INDC
		,@An_TransactionEventSeq_NUMB = A.TransactionEventSeq_NUMB
	 FROM AccountMaster_T1 A
		WHERE  A.Account_ID = @Ai_Account_ID ;
END 


