using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;

namespace ShareWatch.Common.DataStore
{
    public interface IMessageStore
    {
        DateTime LoadedTime { get; }
        OutRecordsListData<MessageData> Messages { get; }
        Dictionary<string, string> MessageDictionary { get; }
        string GetMessage(string code);
        OutRecordsListData<MessageData> GetStoreData();
    }
}
