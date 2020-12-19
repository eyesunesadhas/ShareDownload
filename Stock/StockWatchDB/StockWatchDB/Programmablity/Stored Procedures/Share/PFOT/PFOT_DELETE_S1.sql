/*=============================================================================================
 Procedure : PFOT_DELETE_S1
 Purpose   : Delete Data on PFOT_Y1
 CreatedBy :
 CreatedOn : 09/19/2020
 */
CREATE PROC PFOT_DELETE_S1 (@As_Trade_CODE                  VARCHAR (15),
                            @Ai_Account_ID                  INT,
                            @An_TransactionEventSeq_NUMB    NUMERIC (19, 0),
                            @As_SignedOnWorker_ID           VARCHAR (36))
AS
   BEGIN
      DELETE FROM PFOT_Y1
       WHERE     Trade_CODE = @As_Trade_CODE
             AND Account_ID = @Ai_Account_ID;
   END