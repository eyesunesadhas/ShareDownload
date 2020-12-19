CREATE PROCEDURE PFOT_UPDATE_TRADE_ID
AS
 BEGIN
   UPDATE A 
       SET A.Trade_ID =  dbo.GetTradeID(B.Trade_CODE, B.TransAction_CODE ,B.TransAction_DATE, B.TransSeq_NUMB) 
    FROM PortfolioTrans_T1 A  
       JOIN (
            SELECT A.Account_ID,
                   A.Trade_CODE ,
				   A.Trans_ID ,
	               A.TransAction_CODE,
                   A.TransAction_DATE, 
	               A.Shares_CNT,
	               A.CostBasis_AMNT,
               ROW_NUMBER() OVER (
                  PARTITION BY A.Account_ID, A.TransAction_DATE,A.Trade_CODE
                  ORDER BY Trans_ID 
               ) TransSeq_NUMB
            FROM PortfolioTrans_T1 A ) B
        ON   A.Account_ID = B.Account_ID
         AND A.Trans_ID = B.Trans_ID
         AND A.Trade_CODE = B.Trade_CODE
         AND A.TransAction_DATE = B.TransAction_DATE;
 END

