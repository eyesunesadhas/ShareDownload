using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModel.Common;
using System;
using System.Data;
using System.Data.Common;

namespace ShareWatch.DataAccess.Common
{
    /// <summary>
    /// Data Access Utility
    /// </summary>
    public class DAUtility
    {


        /// <summary>
        /// The variable for TransactionType
        /// </summary>
        protected TransactionType transactionType;

        /// <summary>
        /// The m_data base
        /// </summary>
        protected CustomSqlDatabase dataBase;

        /// <summary>
        /// The m_application base
        /// </summary>
        public BusinessBase businessBase = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="DAUtility" /> class.
        /// </summary>
        /// <param name="applicationBase">The application base.</param>
        /// <param name="transactionType">Type of the transaction.</param>
        public DAUtility(BusinessBase businessBase, TransactionType transactionType)
        {
            this.businessBase = businessBase;
            this.transactionType = transactionType;
            dataBase = null;
        }

        /// <summary>
        /// Gets the data base.
        /// </summary>
        /// <value>
        /// The data base.
        /// </value>
        public CustomSqlDatabase DataBase
        {
            get
            {
                if (dataBase == null)
                {
                    string connectionString = ApplicationSettings.Default.DBConnectionString;
                    dataBase = new CustomSqlDatabase(connectionString, businessBase);
                }
                return dataBase;
            }
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="dataRecordRetrieve">The data record retrieve.</param>
        /// <returns></returns>
        public static string GetString(DataRecordRetrieve dataRecordRetrieve)
        {
            string outData = string.Empty;
            IDataRecord record = dataRecordRetrieve.DataRecord;
            string columnName = dataRecordRetrieve.ColumnName;
            outData = record.IsDBNull(record.GetOrdinal(columnName)) ? string.Empty : record.GetString(record.GetOrdinal(columnName));
            return UtilityHandler.RemoveSpacesFromChar(outData);
        }

        public static decimal GetAmount(DataRecordRetrieve dataRecordRetrieve)
        {
            decimal outData = Constants.NULL_DECIMAL;
            IDataRecord record = dataRecordRetrieve.DataRecord;
            string columnName = dataRecordRetrieve.ColumnName;
            outData = record.IsDBNull(record.GetOrdinal(columnName)) ? Constants.NULL_DECIMAL : record.GetDecimal(record.GetOrdinal(columnName));
            return outData;
        }

        /// <summary>
        /// Sets the no matching records.
        /// </summary>
        /// <param name="output">The output.</param>
        public static void SetNoMatchingRecords(StatusOut output)
        {
            UtilityHandler.UpdateStatus(output, TransactionCheckType.NoMatchingRecords);
        }

        /// <summary>
        /// Adds the input.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="length">The length.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="value">The value.</param>
        public void AddInput(DbCommand command, string parameterName, DbType dbType, int length, int scale, object value)
        {
            // Set credential information
            if (dbType == DbType.String
                 && parameterName == DAParameterConstants.AS_SIGNED_ON_WORKER_ID)
            {
                value = businessBase.SignedOnWorkerID;
            }

            // substitutes null value for Not null columns
            value = SubstituteForNull(dbType, value);

            DataBase.AddParameter(command,
                       parameterName,
                       dbType,
                       length + scale,
                       ParameterDirection.Input,
                       true,
                       (byte)length,
                       (byte)scale,
                       null,
                       DataRowVersion.Current,
                       value);
        }

        /// <summary>
        /// Adds the input.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        public void AddInput(DbCommand command, string parameterName)
        {
            AddInput(command, parameterName, DbType.String, 30, 0, string.Empty);
        }

        /// <summary>
        /// Adds the input.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="length">The length.</param>
        /// <param name="value">The value.</param>
        public void AddInput(DbCommand command, string parameterName, DbType dbType, int length, object value)
        {
            AddInput(command, parameterName, dbType, length, 0, value);
        }

        /// <summary>
        /// Adds the input output.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="precision">The precision.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="value">The value.</param>
        public void AddInputOutput(DbCommand command, string parameterName, DbType dbType, int precision, int scale, object value)
        {
            // Set credential information
            if (dbType == DbType.String && parameterName == DAParameterConstants.AS_SIGNED_ON_WORKER_ID)
            {
                value = businessBase.SignedOnWorkerID;
            }

            // substitutes null value for Not null columns
            value = SubstituteForNull(dbType, value);

            DataBase.AddParameter(command, parameterName, dbType, precision + scale, ParameterDirection.InputOutput, true, (byte)precision, (byte)scale, null, DataRowVersion.Current, value);
        }

        /// <summary>
        /// Adds the output.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="length">The length.</param>
        /// <param name="scale">The scale.</param>
        public void AddOutput(DbCommand command, string parameterName, DbType dbType, int length, int scale)
        {
            CheckDBType(dbType);
            DataBase.AddParameter(command, parameterName, dbType, length + scale, ParameterDirection.Output, true, (byte)length, (byte)scale, null, DataRowVersion.Current, DBNull.Value);
        }

        /// <summary>
        /// Adds the output.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="length">The length.</param>
        public void AddOutput(DbCommand command, string parameterName, DbType dbType, int length)
        {
            AddOutput(command, parameterName, dbType, length, 0);
        }

        /// <summary>
        /// Adds the return.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="length">The length.</param>
        public void AddReturn(DbCommand command, string parameterName, DbType dbType, int length)
        {
            AddReturn(command, parameterName, dbType, length, 0);
        }

        /// <summary>
        /// Adds the return.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="length">The length.</param>
        /// <param name="scale">The scale.</param>
        public void AddReturn(DbCommand command, string parameterName, DbType dbType, int length, int scale)
        {
            DataBase.AddParameter(command, parameterName, dbType, ParameterDirection.ReturnValue, null, DataRowVersion.Current, null);
        }

        /// <summary>
        /// Checks the type of the DB.
        /// </summary>
        /// <param name="dbType">Type of the db.</param>
        /// <exception cref="System.Exception">Only DbType.DateTime2 allowed</exception>
        private void CheckDBType(DbType dbType)
        {
            switch (dbType)
            {
                case DbType.Date:
                case DbType.DateTime:
                    {
                        throw new Exception("Only DbType.DateTime2 allowed");
                    }
            }
        }

        /// <summary>
        /// Substitutes for null.
        /// </summary>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        /// Returns the converted value
        /// </returns>
        /// <exception cref="System.Exception">DbType.Decimal allowed only for UInt64. Use appropriate DbType for this field</exception>
        private object SubstituteForNull(DbType dbType, object value)
        {
            CheckDBType(dbType);

            switch (dbType)
            {
                case DbType.String:
                    {
                        // check if value is empty or null
                        if (value == null || UtilityHandler.IsEmpty(value.ToString()))
                        {
                            // check if TransactionType is inquiry
                            if (transactionType == TransactionType.Inquiry)
                            {
                                return DBNull.Value;
                            }
                            else
                            {
                                return Constants.SYMBOL_SPACE;
                            }
                        }
                        return value;
                    }
                case DbType.DateTime2:
                    {
                        DateTime dateTimeValue = Convert.ToDateTime(value);

                        // check if dateTimeValue is empty
                        if (UtilityHandler.IsEmpty(dateTimeValue))
                        {
                            value = DBNull.Value;
                        }
                        return value;
                    }
                case DbType.Int16:
                    {
                        Int16 int16Value = Convert.ToInt16(value);

                        // check if int16Value is empty
                        if (UtilityHandler.IsEmpty(int16Value))
                        {
                            // check if TransactionType is inquiry
                            if (transactionType == TransactionType.Inquiry)
                            {
                                return DBNull.Value;
                            }
                            else
                            {
                                value = UtilityHandler.SubstituteNull(int16Value);
                            }
                        }
                        return value;
                    }
                case DbType.Int32:
                    {
                        Int32 int32Value = Convert.ToInt32(value);

                        // check if int32Value is empty
                        if (UtilityHandler.IsEmpty(int32Value))
                        {
                            // check if TransactionType is inquiry
                            if (transactionType == TransactionType.Inquiry)
                            {
                                return DBNull.Value;
                            }
                            else
                            {
                                value = UtilityHandler.SubstituteNull(int32Value);
                            }
                        }
                        return value;
                    }
                case DbType.Int64:
                    {
                        Int64 int64Value = Convert.ToInt64(value);

                        // check if int64Value is empty
                        if (UtilityHandler.IsEmpty(int64Value))
                        {
                            // check if TransactionType is inquiry
                            if (transactionType == TransactionType.Inquiry)
                            {
                                return DBNull.Value;
                            }
                            else
                            {
                                value = UtilityHandler.SubstituteNull(int64Value);
                            }
                        }
                        return value;
                    }
                case DbType.UInt64:
                    {
                        ulong ulongValue = Convert.ToUInt64(value);

                        // check if ulongValue is empty
                        if (UtilityHandler.IsEmpty(ulongValue))
                        {
                            // check if TransactionType is inquiry
                            if (transactionType == TransactionType.Inquiry)
                            {
                                return DBNull.Value;
                            }
                            else
                            {
                                value = UtilityHandler.SubstituteNull(ulongValue);
                            }
                        }
                        return value;
                    }
                case DbType.Decimal:
                case DbType.Currency:
                    {
                        if (value is UInt64)
                        {
                            ulong ulongValue = Convert.ToUInt64(value);

                            // check if ulongValue is empty
                            if (UtilityHandler.IsEmpty(ulongValue))
                            {
                                // check if TransactionType is inquiry
                                if (transactionType == TransactionType.Inquiry)
                                {
                                    return DBNull.Value;
                                }
                            }
                        }
                        else
                        {
                            /*
                            if (!(value is Decimal))
                            {
                                throw new Exception("DbType.Decimal allowed only for UInt64 or Decimal. Use appropriate DbType for this field");
                            }
                            */
                            Decimal decimalValue = Convert.ToDecimal(value);

                            // check if decimalValue is empty
                            if (UtilityHandler.IsEmpty(decimalValue))
                            {
                                // check if TransactionType is inquiry
                                if (transactionType == TransactionType.Inquiry)
                                {
                                    return DBNull.Value;
                                }
                                else
                                {
                                    value = UtilityHandler.SubstituteNull(decimalValue);
                                }
                            }
                        }
                        return value;
                    }
                case DbType.Double:
                    {
                        double doubleValue = Convert.ToDouble(value);

                        // check if doubleValue is empty
                        if (UtilityHandler.IsEmpty(doubleValue))
                        {
                            // check if TransactionType is inquiry
                            if (transactionType == TransactionType.Inquiry)
                            {
                                return DBNull.Value;
                            }
                            else
                            {
                                value = UtilityHandler.SubstituteNull(doubleValue);
                            }
                        }
                        return value;
                    }
            }
            return value;
        }
    }
}