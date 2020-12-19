/*=============================================================================================
 Procedure : SHRM_SELECT_S2
 Purpose   : Select Data from SHRM_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROCEDURE SHRM_SELECT_S2 (
            @As_Trade_CODE  VARCHAR (15) ,
            @Ac_HaveShare_INDC  CHAR(1) = NULL
            )
AS
   BEGIN
      SELECT  A.Trade_CODE, 
              A.Trade_NAME,
              A.TransactionEventSeq_NUMB
        FROM ShareMaster_T1 A
       WHERE A.Trade_CODE = IsNull (@As_Trade_CODE, A.Trade_CODE);
   END