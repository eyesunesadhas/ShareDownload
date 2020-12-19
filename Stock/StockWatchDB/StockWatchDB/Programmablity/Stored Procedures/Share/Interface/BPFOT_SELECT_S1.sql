CREATE PROCEDURE BPFOT_SELECT_S1
AS
 BEGIN
 SELECT A.BankAccount_ID
      ,A.Trade_CODE
      ,A.Trade_NAME
      ,A.Trade_ID
      ,A.TransAction_CODE
      ,A.TransAction_DATE
      ,A.Settlement_DATE
      ,A.Shares_CNT
      ,A.CostBasis_AMNT
      ,A.Value_AMNT
      ,A.Export_DATE
      ,A.Seq_NUMB
  FROM BankPortfolioTrans_T1 A
  WHERE 1=2;
 END