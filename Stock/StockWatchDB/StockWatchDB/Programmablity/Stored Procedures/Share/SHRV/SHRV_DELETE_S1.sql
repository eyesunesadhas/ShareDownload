/*=============================================================================================
 Procedure : SHRV_DELETE_S1
 Purpose   : Delete Data on SHRV_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROC SHRV_DELETE_S1 (@As_Trade_CODE                  VARCHAR (15),
                            @An_TransactionEventSeq_NUMB    NUMERIC (19, 0),
                            @As_SignedOnWorker_ID           VARCHAR (36))
AS
   BEGIN
      DECLARE @Ld_SystemDatetime   DATETIME2 = SYSDATETIME ();
      DECLARE @Ld_High_DATE   DATE = '12/31/9999';

      DELETE FROM SHRV_Y1
       WHERE Trade_CODE = @As_Trade_CODE;
   END