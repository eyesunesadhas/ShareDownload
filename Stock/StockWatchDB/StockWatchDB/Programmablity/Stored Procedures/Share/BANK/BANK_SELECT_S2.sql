/*=============================================================================================
 Procedure : BANK_SELECT_S2
 Purpose   : Select Data from BANK_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE BANK_SELECT_S2
AS
   BEGIN
      SELECT A.Account_ID,
             A.Bank_NAME,
             A.BankAccount_ID,
             A.AccountType_CODE,
             R.DescriptionValue_TEXT AccountType_TEXT ,
             A.Owner_NAME,
             A.HideAccount_INDC,
             A.TransactionEventSeq_NUMB,
             A.WorkerUpdate_ID
        FROM AccountMaster_T1 A
         LEFT OUTER JOIN RefMaintenance_T1 R
           ON R.Table_ID ='BANKACC'
            AND R.TableSub_ID ='TYPE' 
            AND A.AccountType_CODE = R.Value_CODE 
         ORDER BY  A.Owner_NAME , AccountType_TEXT, A.Bank_NAME;
   END
