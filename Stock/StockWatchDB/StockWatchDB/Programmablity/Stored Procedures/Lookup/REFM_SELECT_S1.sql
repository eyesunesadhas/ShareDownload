CREATE PROCEDURE REFM_SELECT_S1 
AS
   BEGIN
      SELECT R.Table_ID,
             R.TableSub_ID,
             R.Value_CODE,
             R.DescriptionValue_TEXT,
             R.DispOrder_NUMB
        FROM RefMaintenance_T1 R 
      ORDER BY R.Table_ID,
               R.TableSub_ID,
               R.DispOrder_NUMB,
               R.DescriptionValue_TEXT;
   END
GO

