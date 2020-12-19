CREATE FUNCTION SplitCommaSeperated (@List  VARCHAR (MAX))
   RETURNS @words TABLE (Word VARCHAR (255))
AS
   BEGIN
      DECLARE @Word VARCHAR (100), @t VARCHAR (MAX);
      DECLARE @Pos   INT;
      IF( IsNull(@List,'') = '' )
      BEGIN
           RETURN;
      END
      SET @t = @List;
      SET @Pos = CharIndex (',', @t);
 
      WHILE (@Pos > 0)
      BEGIN
         SET @Word = Left (@t, @Pos - 1);
         SET @t = SubString (@t, @Pos + 1, LEN (@List));
         SET @Pos = CharIndex (',', @t);

         INSERT INTO @words (Word)
         VALUES (@Word);
      END

      IF (@t != '')
         BEGIN
            INSERT INTO @words (Word)
            VALUES (@t);
         END

      RETURN;
   END
Go