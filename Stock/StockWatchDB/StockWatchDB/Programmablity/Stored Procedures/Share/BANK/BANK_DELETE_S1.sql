/*=============================================================================================
 Procedure : BANK_DELETE_S1
 Purpose   : Delete Data on BANK_Y1
 CreatedBy : 
 CreatedOn : 09/19/2020
 */
CREATE Proc BANK_DELETE_S1(
		 @Ai_Account_ID  int
		,@An_TransactionEventSeq_NUMB  numeric(19,0)
		,@As_SignedOnWorker_ID   varchar(36)
)
AS 
BEGIN
	DELETE  FROM BANK_Y1
		 WHERE Account_ID = @Ai_Account_ID ;
END 

