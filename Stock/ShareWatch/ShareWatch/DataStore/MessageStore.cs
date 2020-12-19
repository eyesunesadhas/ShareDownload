using ShareWatch.BusinessLogic.Common;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;

namespace ShareWatch.Common.DataStore
{
    public class MessageStore : IMessageStore
    {
        private readonly BusinessBase businessBase = BusinessBase.GetInstance();
        private static readonly object m_synRootObj = new object();
        private static MessageStore m_instance = null;
        public OutRecordsListData<MessageData> Messages { get; private set; } = null;
        public Dictionary<string, string> MessageDictionary { get; private set; } = null;

        protected Exception m_exceptionData = null;
        public DateTime LoadedTime { get; private set; } = DateTime.Now;
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageStore" /> class.
        /// </summary>
        private MessageStore()
        {
            LoadStore();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static MessageStore Instance
        {
            get
            {
                // only create a new instance if one doesn't already exist.
                if (m_instance == null)
                {
                    // use this lock to ensure that only one thread is access this block of code at once.
                    lock (m_synRootObj)
                    {
                        // only create a new instance if one doesn't already exist.
                        if (m_instance == null)
                        {
                            m_instance = new MessageStore();
                        }
                    }
                }
                // return instance where it was just created or already existed.
                return m_instance;
            }
        }

        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="code">The Error code for which description is needed.</param>
        /// <returns>
        /// The Error Description for the given code. Returns Empty String if it does not exists
        /// </returns>
        public string GetMessage(string code)
        {
            code = code.Trim();
            //Re Load if the Message store is null
            if (MessageDictionary == null)
            {
                LoadStore();
            }
            //Checks whether the dictionary already contains Code
            if (MessageDictionary.ContainsKey(code))
            {
                return MessageDictionary[code];
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets all the Error Code and Description in the Dictionary and return the same
        /// </summary>
        /// <returns>
        /// All the Error Code and Description in the Dictionary
        /// </returns>
        public OutRecordsListData<MessageData> GetStoreData()
        {
            return this.Messages;
        }





        /// <summary>
        /// Loads the Error Codes and Error Messages from the database into Dictionary
        /// </summary>
        /// <param name="dynamicListBL">The dynamic list bl.</param>
        private void LoadStore()
        {
            string detailedLog = string.Empty;
            BusinessBase businessBase = BusinessBase.GetInstance();
            DynamicListBL dynamicListBL = new DynamicListBL(businessBase);
            OutRecordsListData<MessageData> output = new OutRecordsListData<MessageData>();
            DateTime startDateTime = DateTime.Now;
            lock (m_synRootObj)
            {
                try
                {

                    businessBase.ServiceName = "MessageStore";
                    businessBase.MethodName = "LoadStore";
                    businessBase.PageLocation = "AppStart";
                    output = dynamicListBL.GetMessages();
                    this.MessageDictionary = new Dictionary<string, string>();
                    // Checks whether the status contains any failure or validation errors
                    if (UtilityHandler.IsValidStatus(output))
                    {
                        this.Messages = output;
                        output.Data.ForEach(record =>
                        {
                            this.MessageDictionary.Add(record.ErrorCode.Trim().ToUpper(), record.Description.Trim());
                        });
                    }
                    output.StatusList.Add(new Status() { Code = "S" });
                    this.LoadedTime = DateTime.Now;
                }
                catch (Exception)
                {
                    // LoginUtil.UpdateStatus(exception, null, output, detailedLog);
                }
                finally
                {
                    //LoginUtil.UpdateStatus(output, businessBase);
                    //LoginUtil.LogActivityDetails(businessBase, null, output, startDateTime,  detailedLog);
                }
            }
        }
    }
}