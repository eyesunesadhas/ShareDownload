/*=============================================================================================
 Procedure : SHRM_SAVE_S1
 Purpose   : Insert Data on SHRM_Y1
 CreatedBy :
 CreatedOn : 09/25/2020
 */
CREATE PROCEDURE SHRM_SAVE_S1 (
   @As_Trade_CODE                  VARCHAR (15),
   @As_Trade_NAME                  VARCHAR (255),
   @As_Region_NAME                 VARCHAR (50),
   @As_Country_CODE                VARCHAR (50),
   @As_Type_CODE                   VARCHAR (25),
   @As_Exchange_CODE               VARCHAR (25),
   @As_Sector_NAME                 VARCHAR (100),
   @As_Currency_CODE               VARCHAR (25),
   @As_Industry_NAME               VARCHAR (100),
   @Ai_FTEmployees_CNT             INT,
   @Ad_LatestQuarter_DATE          DATE,
   @An_MarketGap_NUMB              BIGINT,
   @An_PERatio_NUMB               NUMERIC (10, 5),
   @An_BookValue_NUMB              NUMERIC (10, 5),
   @An_DividendPerShare_AMNT       MONEY,
   @An_DividendYield_NUMB          NUMERIC (10, 5),
   @An_Eps_NUMB                    NUMERIC (10, 5),
   @An_Week52High_AMNT             MONEY,
   @An_Week52Low_AMNT              MONEY,
   @An_Day50MovAvg_AMNT            NUMERIC (12, 4),
   @An_Day200MovAvg_AMNT           NUMERIC (12, 4),
   @Ad_Dividend_DATE               DATE,
   @Ad_ExDividend_DATE             DATE,
   @Ac_BuyReco_INDC                CHAR(1) = 'N',
   @As_BuyRecoBy_NAME              VARCHAR(50) = '',
   @Ad_BuyReco_DATE                DATE,
   @An_TransactionEventSeq_NUMB    NUMERIC (19, 0),
   @An_NewTransactionEventSeq_NUMB NUMERIC (19, 0) NULL,
   @As_SignedOnWorker_ID           VARCHAR (36))
AS
   BEGIN
      DECLARE @Ld_SystemDatetime   DATETIME2 = SYSDATETIME ();
 
      /* Check the existance of recored with Primary Key */
      IF (EXISTS
             (SELECT TOP 1 1
                FROM ShareMaster_T1 A
               WHERE A.Trade_CODE = @As_Trade_CODE))
         BEGIN
            UPDATE ShareMaster_T1
               SET Trade_NAME = @As_Trade_NAME,
                   Region_NAME = @As_Region_NAME,
                   Country_CODE = @As_Country_CODE,
                   Type_CODE = @As_Type_CODE,
                   Exchange_CODE = @As_Exchange_CODE,
                   Sector_NAME = @As_Sector_NAME,
                   Currency_CODE = @As_Currency_CODE,
                   Industry_NAME = @As_Industry_NAME,
                   FTEmployees_CNT = @Ai_FTEmployees_CNT,
                   LatestQuarter_DATE = @Ad_LatestQuarter_DATE,
                   MarketGap_NUMB = @An_MarketGap_NUMB,
                   PERatio_NUMB = @An_PERatio_NUMB,
                   BookValue_NUMB = @An_BookValue_NUMB,
                   DividendPerShare_AMNT = @An_DividendPerShare_AMNT,
                   DividendYield_NUMB = @An_DividendYield_NUMB,
                   Eps_NUMB = @An_Eps_NUMB,
                   Week52High_AMNT = @An_Week52High_AMNT,
                   Week52Low_AMNT = @An_Week52Low_AMNT,
                   Day50MovAvg_AMNT = @An_Day50MovAvg_AMNT,
                   Day200MovAvg_AMNT = @An_Day200MovAvg_AMNT,
                   Dividend_DATE = @Ad_Dividend_DATE,
                   ExDividend_DATE = @Ad_ExDividend_DATE,
                   BuyReco_INDC    = @Ac_BuyReco_INDC, 
                   BuyRecoBy_NAME  = @As_BuyRecoBy_NAME,
                   BuyReco_DATE   = @Ad_BuyReco_DATE,
                   TransactionEventSeq_NUMB = @An_NewTransactionEventSeq_NUMB,
                   Update_DTTM = @Ld_SystemDatetime,
                   WorkerUpdate_ID = @As_SignedOnWorker_ID
             WHERE Trade_CODE = @As_Trade_CODE;

            RETURN;
         END

      /* Insert data on table SHRM_Y1 */
      INSERT INTO ShareMaster_T1 (Trade_CODE,
                           Trade_NAME,
                           Region_NAME,
                           Country_CODE,
                           Type_CODE,
                           Exchange_CODE,
                           Sector_NAME,
                           Currency_CODE,
                           Industry_NAME,
                           FTEmployees_CNT,
                           LatestQuarter_DATE,
                           MarketGap_NUMB,
                           PERatio_NUMB,
                           BookValue_NUMB,
                           DividendPerShare_AMNT,
                           DividendYield_NUMB,
                           Eps_NUMB,
                           Week52High_AMNT,
                           Week52Low_AMNT,
                           Day50MovAvg_AMNT,
                           Day200MovAvg_AMNT,
                           Dividend_DATE,
                           ExDividend_DATE,
                           BuyReco_INDC,
                           BuyRecoBy_NAME ,
                           BuyReco_DATE,
                           TransactionEventSeq_NUMB,
                           Update_DTTM,
                           WorkerUpdate_ID)
      VALUES (@As_Trade_CODE,
              @As_Trade_NAME,
              @As_Region_NAME,
              @As_Country_CODE,
              @As_Type_CODE,
              @As_Exchange_CODE,
              @As_Sector_NAME,
              @As_Currency_CODE,
              @As_Industry_NAME,
              @Ai_FTEmployees_CNT,
              @Ad_LatestQuarter_DATE,
              @An_MarketGap_NUMB,
              @An_PERatio_NUMB,
              @An_BookValue_NUMB,
              @An_DividendPerShare_AMNT,
              @An_DividendYield_NUMB,
              @An_Eps_NUMB,
              @An_Week52High_AMNT,
              @An_Week52Low_AMNT,
              @An_Day50MovAvg_AMNT,
              @An_Day200MovAvg_AMNT,
              @Ad_Dividend_DATE,
              @Ad_ExDividend_DATE,
              @Ac_BuyReco_INDC,
              @As_BuyRecoBy_NAME ,
              @Ad_BuyReco_DATE ,
              @An_NewTransactionEventSeq_NUMB,
              @Ld_SystemDatetime,
              @As_SignedOnWorker_ID);
   END