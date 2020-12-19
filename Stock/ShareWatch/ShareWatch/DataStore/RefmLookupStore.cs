using System.Collections.Generic;

namespace ShareWatch.Common.DataStore
{
    /// <summary>
    /// The RefmLookup Store is Singleton and the data from database are loaded at the start of the application
    /// </summary>
    public partial class RefmLookupStore : StoreBase
    {
        private static RefmLookupStore m_instance = null;
        private static Dictionary<string, string> m_storeDictionary = new Dictionary<string, string>();
        private static Dictionary<string, string> m_tableIDDictionary = new Dictionary<string, string>();
        private static Dictionary<string, string> m_tableIDSub = new Dictionary<string, string>();


        /// <summary>
        /// Initializes a new instance of the <see cref="RefmLookupStore" /> class.
        /// </summary>
        private RefmLookupStore()
        {
            LoadStore();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static RefmLookupStore Instance
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
                            m_instance = new RefmLookupStore();
                        }
                    }
                }
                // return instance where it was just created or already existed.
                return m_instance;
            }
        }

        /// <summary>
        /// Gets the Reference Type from RefmLookup for the given Class name and Column name.
        /// </summary>
        /// <param name="screenID">The Screen in which the Reference Type for the given column to be checked.</param>
        /// <param name="columnName">The Column for which the Reference Type is needed.</param>
        /// <param name="dependentValueText">The dependent value text.</param>
        /// <returns>
        /// The Reference Type for the given code. Returns null if it does not exists
        /// </returns>
        public string GetReferenceType(string screenID, string columnName, string dependentValueText)
        {
            string keyValue = GetKey(screenID, columnName, dependentValueText);

            //Checks whether the dictionary already contains Code
            if (m_storeDictionary.ContainsKey(keyValue))
            {
                return (m_storeDictionary[keyValue].ToString());
            }
            return null;
        }



        /// <summary>
        /// Gets the table ID from RefmLookup for the given Class name and Column name.
        /// </summary>
        /// <param name="screenID">The Class represents the Screen in which the table ID for the given column to be checked.</param>
        /// <param name="columnName">The Column for which the table ID is needed.</param>
        /// <param name="dependentValueText">The dependent value text.</param>
        /// <returns>
        /// The table ID for the given code. Returns null if it does not exists
        /// </returns>
        public string GetTableID(string screenID, string columnName, string dependentValueText)
        {
            string keyValue = GetKey(screenID, columnName, dependentValueText);

            //Checks whether the dictionary already contains Code
            if (m_tableIDDictionary.ContainsKey(keyValue))
            {
                return (m_tableIDDictionary[keyValue].ToString());
            }
            return null;
        }

        /// <summary>
        /// Gets the table sub ID from RefmLookup for the given Class name and Column name.
        /// </summary>
        /// <param name="screenID">The Class represents the Screen in which the TableSubID for the given column to be checked.</param>
        /// <param name="columnName">The Column for which the TableSubID is needed.</param>
        /// <param name="dependentValueText">The dependent value text.</param>
        /// <returns>
        /// The TableSubID for the given code. Returns null if it does not exists
        /// </returns>
        public string GetTableSubID(string screenID, string columnName, string dependentValueText)
        {
            string keyValue = GetKey(screenID, columnName, dependentValueText);

            //Checks whether the dictionary already contains Code
            if (m_tableIDSub.ContainsKey(keyValue))
            {
                return (m_tableIDSub[keyValue].ToString());
            }
            return null;
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <param name="screenID">The screen ID.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="dependentValueText">The dependent value text.</param>
        /// <returns></returns>
        private string GetKey(string screenID, string columnName, string dependentValueText)
        {
            return screenID + columnName + dependentValueText;
        }

        /// <summary>
        /// Loads the RefmLookup from the Database into Dictionary
        /// </summary>
        private void LoadStore()
        {

        }
    }
}