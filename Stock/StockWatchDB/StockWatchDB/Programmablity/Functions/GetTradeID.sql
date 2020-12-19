CREATE FUNCTION GetTradeID
(
	  @As_Trade_CODE         VARCHAR(10)
	, @As_TransAction_CODE   VARCHAR(5)
	, @Ad_TransAction_DATE   DATE
	, @Ai_TransSeq_NUMB      INT
)
RETURNS VARCHAR(50)
AS
 BEGIN
   DECLARE @Ls_Trade_ID VARCHAR(50);
   SET @Ls_Trade_ID = TRIM(@As_Trade_CODE)
                   + '-' + @As_TransAction_CODE +
                   + '-' +  FORMAT(@Ad_TransAction_DATE, 'yyyyMMdd', 'en-US' ) 
                   + '-' + FORMAT(@Ai_TransSeq_NUMB, '00'); 
  RETURN @Ls_Trade_ID;
 END