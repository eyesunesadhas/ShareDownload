/*=============================================================================================
 Procedure : SHRM_DELETE_S1
 Purpose   : Delete Data on SHRM_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROC SHRM_DELETE_S1 (@As_Trade_CODE                  VARCHAR (15),
                            @An_TransactionEventSeq_NUMB    NUMERIC (19, 0),
                            @As_SignedOnWorker_ID           VARCHAR (36))
AS
   BEGIN
      DELETE FROM SHRM_Y1
       WHERE Trade_CODE = @As_Trade_CODE;
   END