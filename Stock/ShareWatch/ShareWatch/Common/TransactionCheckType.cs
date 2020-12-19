namespace ShareWatch.Common
{
    public enum TransactionCheckType
    {
        ConcurrencyFailed,
        ConcurrencyFailedOnDelete,
        DeleteFailed,
        DuplicateRecord,
        InsertFailed,
        NoMatchingRecords,
        UpdateFailed
    }
}