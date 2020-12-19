CREATE TABLE RefRoles_T1 (
    Role_ID                  CHAR (10)     NOT NULL,
    Role_NAME                VARCHAR (50)  NOT NULL,
    SupervisorRole_INDC      CHAR (1)      NOT NULL,
    TransactionEventSeq_NUMB NUMERIC (19)  NOT NULL,
    Update_DTTM              DATETIME2 (7) NOT NULL,
    WorkerUpdate_ID          CHAR (30)     NOT NULL,
    CONSTRAINT ROLE_I1 PRIMARY KEY CLUSTERED (Role_ID )
);
