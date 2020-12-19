CREATE TABLE RefScreen_T1 (
    Screen_ID                CHAR (4)       NOT NULL,
    Screen_NAME              VARCHAR (150)  NOT NULL,
    Description_TEXT         VARCHAR (4000) NOT NULL,
    Update_DTTM              DATETIME2 (7)  NOT NULL,
    WorkerUpdate_ID          CHAR (30)      NOT NULL,
    BeginValidity_DATE       DATE           NOT NULL,
    TransactionEventSeq_NUMB NUMERIC (19)   NOT NULL,
    CONSTRAINT SCRN_I1 PRIMARY KEY CLUSTERED (Screen_ID ASC)
);
