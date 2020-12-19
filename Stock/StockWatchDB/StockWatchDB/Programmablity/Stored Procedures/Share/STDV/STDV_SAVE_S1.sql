/*=============================================================================================
 Procedure : STDV_SAVE_S1
 Purpose   : Insert Data on ShareTradeValue_T1
 CreatedBy : 
 CreatedOn : 11/12/2020
 */
CREATE PROCEDURE STDV_SAVE_S1(
	  	@As_Trade_CODE  varchar(15)
		,@An_BuyAt_AMNT  money
		,@An_SellAt_AMNT  money
		,@As_SignedOnWorker_ID   varchar(36)
)
AS 
BEGIN
	DECLARE @Ld_SystemDatetime DATETIME2 = SYSDATETIME();
 /* Check the existance of recored with Primary Key */
 IF (EXISTS(SELECT top 1 1 FROM ShareTradeValue_T1 A 
		 WHERE    A.Trade_CODE = @As_Trade_CODE
		)
	)
	BEGIN
	UPDATE ShareTradeValue_T1
		SET  BuyAt_AMNT = @An_BuyAt_AMNT
		, SellAt_AMNT = @An_SellAt_AMNT
		, Update_DTTM = @Ld_SystemDatetime
		, WorkerUpdate_ID = @As_SignedOnWorker_ID 
		WHERE  Trade_CODE = @As_Trade_CODE ;
    RETURN; 
END 
/* Insert data on table ShareTradeValue_T1 */
INSERT INTO ShareTradeValue_T1 (
		Trade_CODE
		,BuyAt_AMNT
		,SellAt_AMNT
		,Update_DTTM
		,WorkerUpdate_ID
)
 VALUES (
		@As_Trade_CODE
		,@An_BuyAt_AMNT
		,@An_SellAt_AMNT
		,@Ld_SystemDatetime
		,@As_SignedOnWorker_ID 
);
END 