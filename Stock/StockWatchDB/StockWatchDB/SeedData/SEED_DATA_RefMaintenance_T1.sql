CREATE PROCEDURE SEED_DATA_RefMaintenance_T1
 AS
  BEGIN
  
   TRUNCATE TABLE RefMaintenance_T1;
   INSERT INTO RefMaintenance_T1 ( Table_ID, TableSub_ID, SystemTable_INDC, DescriptionTable_TEXT, DispOrder_NUMB, Value_CODE, DescriptionValue_TEXT, BeginValidity_DATE, Update_DTTM, WorkerUpdate_ID, TransactionEventSeq_NUMB )
   VALUES 
   ( 'BANKACC', 'TYPE', 'Y', 'Bank Account Type', '1', 'CHEK', 'Checking', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'TYPE', 'Y', 'Bank Account Type', '2', 'BROK', 'Saving', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'TYPE', 'Y', 'Bank Account Type', '3', 'SAVE', 'Saving', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'TYPE', 'Y', 'Bank Account Type', '4', 'ROBN', 'Saving ', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'TYPE', 'Y', 'Bank Account Type', '11', '401K', 'Retirement', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'TYPE', 'Y', 'Bank Account Type', '12', 'TIRA', 'Retirement', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'TYPE', 'Y', 'Bank Account Type', '13', 'RIRA', 'Retirement', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'TYPE', 'Y', 'Bank Account Type', '14', 'SIRA', 'Retirement', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'NAME', 'Y', 'Bank Name', '1', 'MERR', 'Merrill Lynch', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'BANKACC', 'NAME', 'Y', 'Bank Name', '2', 'FEDE', 'Fidelity Investments', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'YSNO', 'YSNO', 'Y', 'Yes  No Lookup', '1', 'N', 'No', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'YSNO', 'YSNO', 'Y', 'Yes  No Lookup', '2', 'Y', 'Yes', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'TRADE', 'ACTION', 'Y', 'Trade Action', '1', 'BUY', 'Buy', '09/19/2020', '09/19/2020', 'ADMIN', 1 ),
   ( 'TRADE', 'ACTION', 'Y', 'Trade Action', '2', 'SELL', 'Sell', '09/19/2020', '09/19/2020', 'ADMIN', 1 );
END
