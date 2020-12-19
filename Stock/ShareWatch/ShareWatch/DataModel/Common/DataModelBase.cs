using ShareWatch.Const;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json.Serialization;

namespace ShareWatch.DataModel.Common
{
    public class DataModelBase
    {

        public ulong TransactionEventSeqNumb { get; set; } = 0;
        [JsonIgnore]
        public ulong NewTransactionEventSeqNumb { get; set; } = Constants.NULL_ULONG;
        //public string SignedOnWorkerID { get; set; } = string.Empty;

        public string WorkerUpdateID { get; set; } = string.Empty;
        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <typeparam name="T">The type of the input</typeparam>
        /// <returns>Returns the instance of this class</returns>
        public T Copy<T>() where T : DataModelBase
        {
            return (T)Copy();
        }

        /// <summary>
        /// Copies this instance.
        /// </summary>
        /// <returns>Returns the instance of this class</returns>
        private DataModelBase Copy()
        {
            DataModelBase actualClass = this;
            DataModelBase copyClass = (DataModelBase)Activator.CreateInstance(actualClass.GetType());

            // iterated for each properties in the class
            foreach (PropertyInfo property in actualClass.GetType().GetProperties())
            {
                PropertyInfo propertyCopyClass = copyClass.GetType().GetProperty(property.Name);

                //Checks whether the property as set method
                if (propertyCopyClass.CanWrite)
                {
                    var propertyValue = property.GetValue(actualClass, null);
                    Type propertyType = propertyCopyClass.PropertyType;

                    //if the property is list then make a copy of list
                    if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>))
                    {
                        Type listType = propertyType.GetGenericArguments()[0];

                        //Create a instance of the IList of the type
                        IList objectList = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(listType));

                        // process only when value exists
                        if (propertyValue != null)
                        {
                            //Cast the value to enumerable
                            IEnumerable copyFrom = (IEnumerable)propertyValue;

                            //Iterate each object in the input list, create a copy & add to new list
                            foreach (object item in copyFrom)
                            {
                                objectList.Add(((DataModelBase)item).Copy());
                            }
                        }

                        //Set the new list as the value for copy class
                        propertyValue = objectList;
                    }
                    propertyCopyClass.SetValue(copyClass, propertyValue, null);
                }
            }
            return copyClass;
        }
    }
}
