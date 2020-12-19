CREATE PROCEDURE SHRV_SELECT_PERF_S3
AS
 BEGIN
   /*
      1. Find Day different 
	  2. Stock Range 
   */
    DECLARE @Ld_End_DATE DATE = SysDateTime();
	DECLARE @Ld_Start_DATE DATE = DateAdd(WEEK,-2,@Ld_End_DATE);
	SELECT A.*, (High_AMNT - Low_AMNT) * 100 /Low_AMNT Change_RATE
	 FROM (
  			SELECT A.Trade_CODE,
			   A.Trade_NAME ,
			   A.Week52Low_AMNT,
			   A.Week52High_AMNT ,
			   B.Start_DATE,
			   B.End_Date,
			   B.Low_AMNT,
			   B.High_AMNT 
			   FROM  ShareMaster_T1 A  
			 JOIN ( SELECT   B.Trade_CODE ,
							 Min(B.Trade_DATE ) [Start_DATE],
							 Max(B.Trade_DATE) End_DATE,
							 Min(B.Low_AMNT) Low_AMNT,
							 Max(B.High_AMNT) High_AMNT
					 FROM ShareMarketValueHist_T1 B 
					  WHERE B.Trade_DATE BETWEEN @Ld_Start_DATE AND @Ld_End_DATE
					  GROUP BY B.Trade_CODE ) B
					ON A.Trade_CODE = B.Trade_CODE ) A 
          WHERE (High_AMNT - Low_AMNT) * 100 /Low_AMNT > 15
          Order by Change_RATE DESC;
   
 END
