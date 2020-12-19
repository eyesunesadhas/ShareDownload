CREATE PROCEDURE SHRV_SELECT_REVIEW_S3
AS
   BEGIN
      SELECT SM.Trade_CODE,
             SM.Trade_NAME,
             SM.Exchange_CODE,
             SM.Week52Low_AMNT,
             SM.Week52High_AMNT,
             A.Current_AMNT,
             SM.LatestQuarter_DATE,
             SM.DividendPerShare_AMNT,
             SM.Dividend_DATE,
             SM.BuyReco_INDC,
             SM.BuyRecoBy_NAME,
             SM.BuyReco_DATE,
             (SELECT TOP 1 1
                FROM Portfolio_T1 PO
               WHERE SM.Trade_CODE = PO.Trade_CODE)
                HaveShare_INDC
        FROM    ShareMaster_T1 SM
             LEFT OUTER JOIN
                ShareMarketValue_T1 A
             ON A.Trade_CODE = SM.Trade_CODE
      ORDER BY SM.BuyReco_DATE DESC;
   END