/*=============================================================================================
 Procedure : STDV_SELECT_S1
 Purpose   : Select Data from ShareTradeValue_T1
 CreatedBy : 
 CreatedOn : 11/12/2020
 */
CREATE PROCEDURE STDV_SELECT_S1(
		 @As_Trade_CODE  varchar(15)
		,@As_Trade_NAME  varchar(255) OUTPUT
		,@An_Current_AMNT  MONEY OUTPUT
		,@An_Week52High_AMNT money OUTPUT 
		,@An_Week8High_AMNT money OUTPUT 
		,@An_Week8Low_AMNT money OUTPUT 
		,@An_SoldAt_AMNT  money OUTPUT
		,@Ad_SoldOn_DATE DATE OUTPUT
		,@An_BuyAt_AMNT  money OUTPUT 
		,@An_SellAt_AMNT  money OUTPUT 
)
AS 
BEGIN
    DECLARE @Ld_Week8Start_DATE DATE = DateAdd(W,-8,SysDateTime());
 
	SELECT  @As_Trade_NAME = A.Trade_NAME  
	      , @An_Week52High_AMNT = A.Week52High_AMNT
	      , @An_Current_AMNT = SV.Current_AMNT
	      , @An_BuyAt_AMNT = TV.BuyAt_AMNT
		  , @An_SellAt_AMNT = TV.SellAt_AMNT
	 FROM ShareMaster_T1 A 
	    LEFT OUTER JOIN ShareMarketValue_T1 SV 
		   ON SV.Trade_CODE =  A.Trade_CODE
	    LEFT OUTER JOIN ShareTradeValue_T1 TV   
		   ON TV.Trade_CODE = A.Trade_CODE
		WHERE  A.Trade_CODE = @As_Trade_CODE ;

     SELECT @An_Week8High_AMNT = Max(A.High_AMNT) ,
	       @An_Week8Low_AMNT  = Min(A.Low_AMNT)
	 FROM ShareMarketValueHist_T1 A
	     WHERE A.Trade_CODE = @As_Trade_CODE
		  AND A.Trade_DATE >= @Ld_Week8Start_DATE;

	SELECT @Ad_SoldOn_DATE = A.TransAction_DATE,
	       @An_SoldAt_AMNT = A.CostBasis_AMNT
	FROM PortfolioTrans_T1 A 
	 WHERE  A.TransAction_CODE = 'SELL'
	   AND  A.Trade_CODE = @As_Trade_CODE;

END  