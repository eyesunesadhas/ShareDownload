namespace ShareWatch.Common.DataStore
{
    public interface IRefmLookupStore
    {
        string GetTableID(string screenID, string columnName, string dependentValueText);
        string GetTableSubID(string screenID, string columnName, string dependentValueText);
        string GetReferenceType(string screenID, string columnName, string dependentValueText);
    }
}
