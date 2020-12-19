using ShareWatch.BusinessLogic.Common;
using ShareWatch.Const;
using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareWatch.Common.DataStore
{
    /// <summary>
    /// The REFM Store is Singleton and collects the REFM Codes and REFM Description from the database at the start of the application.
    /// </summary>
    public partial class RefmStore : IRefmStore
    {
        public DateTime LoadedTime { get; private set; } = DateTime.Now;
        private static RefmStore m_instance = null;
        private static OutRecordsListData<RefmRecordData> m_refmRecordDataList = null;
        private static Dictionary<string, List<RefmLookupData>> m_storeDictionary = new Dictionary<string, List<RefmLookupData>>();
        private static readonly object m_synRootObj = new object();
        /// <summary>
        /// Initializes a new instance of the <see cref="RefmStore" /> class.
        /// </summary>
        private RefmStore()
        {
            LoadStore();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static RefmStore Instance
        {
            get
            {
                // only create a new instance if one doesn't already exist.
                if (m_instance == null)
                {
                    // use this lock to ensure that only one thread is access this block of code at once.
                    lock (m_storeDictionary)
                    {
                        // only create a new instance if one doesn't already exist.
                        if (m_instance == null)
                        {
                            m_instance = new RefmStore();
                        }
                    }
                }
                // return instance where it was just created or already existed.
                return m_instance;
            }
        }

        /// <summary>
        /// Reset this instance.
        /// </summary>
        public static void Reset()
        {
            m_instance = null;
            _ = RefmStore.Instance;
        }

        /// <summary>
        /// Gets the Code and Description from REFM for the given tableID and tableSubID.
        /// </summary>
        /// <param name="tableID">The tableID in which the subset of tableSubID should be selected.</param>
        /// <param name="tableSubID">The tableSubID from which all the codes and description needs to be selected.</param>
        /// <returns>
        /// The List that contains all the Code and Description for the given tableID and tableSubID in the order
        /// </returns>
        public List<RefmLookupData> GetCodeAndDescriptionMap(string tableID, string tableSubID)
        {
            string keyCode = $"{tableID.Trim().ToUpper()}{tableSubID.Trim().ToUpper()}";

            // Checks if the key does not exists in the dictionary
            if (!m_storeDictionary.ContainsKey(keyCode))
            {
                return null;
            }
            return (m_storeDictionary[keyCode]);
        }

        /// <summary>
        /// Gets Reference code description
        /// </summary>
        /// <param name="tableID">The table ID.</param>
        /// <param name="tableSubID">The table sub ID.</param>
        /// <param name="valueCode">The value code.</param>
        /// <returns>
        /// description based on inputs
        /// </returns>
        public string GetRefmDescription(string tableID, string tableSubID, string valueCode)
        {
            List<RefmLookupData> codeMap = GetRefmLookups(tableID, tableSubID);

            // Check if the code Map is null
            if (codeMap == null)
            {
                return null;
            }
            valueCode = valueCode.Trim().ToUpper();
            RefmLookupData refmLookupData = GetRefmLookup(codeMap, valueCode);

            // Check if the refmLookupData is null
            if (refmLookupData == null)
            {
                return null;
            }
            return refmLookupData.Description;
        }

        /// <summary>
        /// Gets the refm description for active.
        /// </summary>
        /// <param name="tableID">The table identifier.</param>
        /// <param name="tableSubID">The table sub identifier.</param>
        /// <param name="valueCode">The value code.</param>
        /// <returns></returns>
        public string GetRefmDescriptionForActive(string tableID, string tableSubID, string valueCode)
        {
            List<RefmLookupData> codeMap = GetRefmLookups(tableID, tableSubID);

            // Check if the code Map is null
            if (codeMap == null)
            {
                return null;
            }
            valueCode = valueCode.Trim().ToUpper();
            RefmLookupData refmLookupData = GetRefmLookup(codeMap, valueCode, true);

            // Check if the refmLookupData is null
            if (refmLookupData == null)
            {
                return null;
            }
            return refmLookupData.Description;
        }

        /// <summary>
        /// Returns Reference code Data
        /// </summary>
        /// <returns>
        /// Returns the RefmRecordData object contains the TableID, TableSubID, ValueCode and related details
        /// </returns>
        public OutRecordsListData<RefmRecordData> GetStoreData()
        {

            return m_refmRecordDataList;
        }

        /// <summary>
        /// Determines whether [is Reference code code exists] [the specified table ID].
        /// </summary>
        /// <param name="screenID">The screen ID.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="code">The code.</param>
        /// <param name="dependentValue">The dependent value.</param>
        /// <returns>
        ///   <c>true</c> if [is Reference code code exists] [the specified table ID]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsRefmCodeExists(string screenID, string commonName, string code, string dependentValue = "")
        {
            RefmLookupStore refmLookupStore = RefmLookupStore.Instance;
            string description = string.Empty;

            string tableID = refmLookupStore.GetTableID(screenID, commonName, dependentValue);
            string tableSubID = refmLookupStore.GetTableSubID(screenID, commonName, dependentValue);

            // Checks if tableID and tableSubID are not empty
            if (!UtilityHandler.IsEmpty(tableID) && !UtilityHandler.IsEmpty(tableSubID))
            {
                description = GetRefmDescriptionForActive(tableID, tableSubID, code);
            }

            // Checks if the description exists
            if (UtilityHandler.IsEmpty(description))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets Reference code lookup data based on code map and code
        /// </summary>
        /// <param name="codeMap">The code map.</param>
        /// <param name="valueCode">The value code.</param>
        /// <param name="isOnlyActive">if set to <c>true</c> [is only active].</param>
        /// <returns>
        /// Returns RefmLookupData object contains Reference code lookup data
        /// </returns>
        private RefmLookupData GetRefmLookup(List<RefmLookupData> codeMap, string valueCode, bool isOnlyActive = false)
        {
            // Check if the CodeMap is null
            if (codeMap == null)
            {
                return null;
            }
            IList<RefmLookupData> resultTextList = null;

            //Is to get description only for active refm.
            if (isOnlyActive)
            {
                resultTextList = (from lookupData in codeMap
                                  where lookupData.Code == valueCode.Trim()
                                  select lookupData).ToList<RefmLookupData>();
            }
            else
            {
                resultTextList = (from lookupData in codeMap
                                  where lookupData.Code == valueCode.Trim()
                                  select lookupData).ToList<RefmLookupData>();
            }

            // Check if resultTextList has no values
            if (resultTextList.Count == Constants.NO_DATA_COUNT)
            {
                return null;
            }
            return (RefmLookupData)resultTextList[Constants.INITIAL_RECORD_INDEX];
        }

        /// <summary>
        /// Gets Reference code Lookups
        /// </summary>
        /// <param name="tableID">The table ID.</param>
        /// <param name="tableSubID">The table sub ID.</param>
        /// <returns>
        /// List of Reference code lookup data
        /// </returns>
        private List<RefmLookupData> GetRefmLookups(string tableID, string tableSubID)
        {
            string keyCode = tableID.ToUpper().Trim() + tableSubID.ToUpper().Trim();

            // Checks if the key exists in the dictionary
            if (!m_storeDictionary.ContainsKey(keyCode))
            {
                return null;
            }
            return ((List<RefmLookupData>)m_storeDictionary[keyCode]);
        }

        /// <summary>
        /// Loads the REFM from the Database into dictionary
        /// </summary>
        private void LoadStore()
        {
            BusinessBase businessBase = BusinessBase.GetInstance();
            businessBase.ServiceName = "RefmStore";
            businessBase.MethodName = "LoadStore";
            businessBase.PageLocation = "AppStart";
            DateTime startDateTime = DateTime.Now;
            string detailedLog = string.Empty;
            DynamicListBL dynamicListBL = new DynamicListBL(businessBase);
            OutRecordsListData<RefmRecordData> output = new OutRecordsListData<RefmRecordData>();
            lock (m_synRootObj)
            {
                try
                {
                    output = dynamicListBL.LoadRefm();
                    m_refmRecordDataList = output;
                    m_storeDictionary = new Dictionary<string, List<RefmLookupData>>();
                    List<RefmLookupData> refmLookupDataList = new List<RefmLookupData>();

                    // Parses each RefmLookupData object and alters the key value pair
                    m_refmRecordDataList.Data.ForEach(refmData =>
                    {
                        string keyCode = refmData.TableID + refmData.TableSubID;

                        // Checks if the key exists in the dictionary
                        if (m_storeDictionary.ContainsKey(keyCode))
                        {
                            refmLookupDataList = (List<RefmLookupData>)m_storeDictionary[keyCode];
                            refmLookupDataList.Add(new RefmLookupData(refmData.Code, refmData.Description));
                        }
                        else
                        {
                            refmLookupDataList = new List<RefmLookupData>
                            {
                            new RefmLookupData(refmData.Code, refmData.Description)
                            };
                            m_storeDictionary.Add(keyCode, refmLookupDataList);
                        }
                    });
                    this.LoadedTime = DateTime.Now;
                }
                catch (Exception)
                {
                    //  LoginUtil.UpdateStatus(exception, null, output, detailedLog);
                }
                finally
                {
                    DateTime endDateTime = DateTime.Now;
                    // LoginUtil.UpdateStatus(output, businessBase);
                    // LoginUtil.LogActivityDetails(businessBase, null, output, startDateTime, detailedLog);
                }
            }
        }
    }
}