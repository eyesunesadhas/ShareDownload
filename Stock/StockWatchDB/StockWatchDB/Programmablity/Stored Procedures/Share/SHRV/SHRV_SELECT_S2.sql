/*=============================================================================================
 Procedure : SHRV_SELECT_S2
 Purpose   : Select Data from SHRV_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE SHRV_SELECT_S2 (
            @As_Trade_CODE      VARCHAR(15) = NULL ,
            @Ac_HaveShare_INDC  CHAR(1) = NULL 
          )
AS
   BEGIN
      DECLARE @TradePriority_P1 TABLE(  
                  Trade_CODE VARCHAR (15) NOT NULL,
                  HaveShare_INDC CHAR(1)  NULL DEFAULT 'N' ,
                  [Priority]  INT NOT NULL);  
      INSERT INTO  @TradePriority_P1( Trade_CODE,[Priority])
        SELECT SM.Trade_CODE , 
                Case WHEN SM.BuyReco_INDC ='Y'  THEN 2
                     ELSE 99
                     END [Priority]
           FROM  ShareMaster_T1 SM;
       
      UPDATE A 
        SET A.HaveShare_INDC = 'Y' ,
            A.[Priority] = 1
        FROM @TradePriority_P1 A
            JOIN (SELECT  DISTINCT P.Trade_CODE
                        FROM Portfolio_T1 P  
                        WHERE P.Shares_CNT > 0) B ON B.Trade_CODE = A.Trade_CODE;

      DECLARE @Lc_BuyReco_INDC    CHAR(1) = 'Y';
      SELECT SM.Trade_CODE,
             SM.Trade_NAME,
             SM.Region_NAME,
             SM.Country_CODE,
             SM.Type_CODE,
             SM.Exchange_CODE,
             SM.Sector_NAME,
             SM.Currency_CODE,
             SM.Industry_NAME,
             A.Current_AMNT,
             P.HaveShare_INDC,
             SM.BuyReco_INDC,
             SM.BuyRecoBy_NAME,
             SM.BuyReco_DATE,
             P.[Priority],
             SM.Week52High_AMNT,
             SM.Week52Low_AMNT,
             SM.Day50MovAvg_AMNT,
             SM.Day200MovAvg_AMNT,
             SM.Dividend_DATE,
             SM.DividendPerShare_AMNT,
             SM.DividendYield_NUMB,
             SM.ExDividend_DATE,
             SM.LatestQuarter_DATE,
             SM.FTEmployees_CNT,
             SM.MarketGap_NUMB,
             SM.PERatio_NUMB,
             SM.BookValue_NUMB,
             SM.Eps_NUMB,
             TV.BuyAt_AMNT,
             TV.SellAt_AMNT,
             SM.SoldAt_AMNT,
             SM.SoldOn_DATE,
             A.Trade_DATE ,          
             A.Open_AMNT,
             A.Low_AMNT,
             A.High_AMNT ,
             A.Volume_CNT,
             A.AvgVol_CNT,
             A.TransactionEventSeq_NUMB,
             SM.Update_DTTM
        FROM    ShareMaster_T1 SM 
            JOIN @TradePriority_P1 P  ON SM.Trade_CODE =P.Trade_CODE
            LEFT OUTER JOIN  ShareMarketValue_T1 A  ON A.Trade_CODE = SM.Trade_CODE
            LEFT OUTER JOIN ShareTradeValue_T1 TV ON SM.Trade_CODE = TV.Trade_CODE
       WHERE SM.Trade_CODE = IsNull (@As_Trade_CODE, SM.Trade_CODE)
            AND  P.HaveShare_INDC = IsNull(@Ac_HaveShare_INDC , P.HaveShare_INDC)
       ORDER BY IsNull(SM.BuyReco_DATE,'1/1/0001') Desc, P.[Priority], SM.Trade_CODE;
      
   END