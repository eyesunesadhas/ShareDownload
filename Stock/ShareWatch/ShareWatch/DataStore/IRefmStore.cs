using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;

namespace ShareWatch.Common.DataStore
{
    public interface IRefmStore
    {
        DateTime LoadedTime { get; }
        List<RefmLookupData> GetCodeAndDescriptionMap(string tableID, string tableSubID);
        string GetRefmDescription(string tableID, string tableSubID, string valueCode);
        string GetRefmDescriptionForActive(string tableID, string tableSubID, string valueCode);
        OutRecordsListData<RefmRecordData> GetStoreData();
        bool IsRefmCodeExists(string screenID, string commonName, string code, string dependentValue = "");
    }
}
