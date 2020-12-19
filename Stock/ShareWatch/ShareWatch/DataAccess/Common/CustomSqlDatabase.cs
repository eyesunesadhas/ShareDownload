using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using ShareWatch.BusinessLogic.Logging;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace ShareWatch.DataAccess.Common
{
    /// <summary>
    /// CustomSqlDatabase inherited from SqlDatabase
    /// </summary>
    public class CustomSqlDatabase : SqlDatabase
    {
        private readonly BusinessBase businessBase = null;
        private readonly AuditLogger auditLog = null;
        private readonly List<string> paramBuilder = new List<string>();


        public CustomSqlDatabase(string connectionString, BusinessBase businessBase)
            : base(connectionString)
        {
            this.businessBase = businessBase;
            this.paramBuilder = new List<string>();
            this.auditLog = new AuditLogger(businessBase);
        }

        private void Add2ParameterList(string paramName,
                                      DbType dbType,
                                      object paramValue,
                                      ParameterDirection parameterDirection)
        {
            string name = paramName.Replace("@", string.Empty);
            string value = string.Empty;
            if (paramValue != null)
            {
                switch (dbType)
                {
                    case DbType.Int16:
                    case DbType.Int32:
                    case DbType.Int64:
                    case DbType.Decimal:
                    case DbType.Double:
                    case DbType.Currency:
                    case DbType.UInt16:
                    case DbType.UInt32:
                    case DbType.UInt64:
                        value = $"{paramValue} ";
                        break;
                    case DbType.Date:
                        if (paramValue is DateTime dt)
                        {
                            value = $"'{dt:MM/dd/yyyy}'";
                        }
                        else
                        {
                            value = $"'{paramValue}' ";
                        }
                        break;
                    default:
                        value = $"'{paramValue}' ";
                        break;
                }

            }
            if (paramValue == DBNull.Value)
            {
                value = "null";
            }
            string changedValue = value;
            switch (parameterDirection)
            {
                case ParameterDirection.Input:
                    paramBuilder.Add($"@{name} = {changedValue} ");
                    break;
                case ParameterDirection.InputOutput:
                case ParameterDirection.Output:
                    paramBuilder.Add($"@{name} = @{name} OUTPUT ");
                    break;
                case ParameterDirection.ReturnValue:
                    paramBuilder.Add($"@{name} ");
                    break;
                default:
                    break;
            }
        }


        public override void AddParameter(DbCommand command,
            string parameterName,
            DbType dbType,
            int size,
            ParameterDirection direction,
            bool nullable,
            byte precision,
            byte scale,
            string sourceColumn,
            DataRowVersion sourceVersion,
            object value)
        {
            Add2ParameterList(parameterName, dbType, value, direction);
            base.AddParameter(command, parameterName, dbType,
                           size, direction, nullable, precision,
                           scale, sourceColumn, sourceVersion, value);
        }


        private string GetProcedureStatement(string procedureName)
        {
            string s = string.Join(",", paramBuilder);
            string statement = $"{procedureName} {s}";
            return statement;
        }


        public override int ExecuteNonQuery(DbCommand command)
        {
            int i = 0;
            Exception ex = null;
            try
            {
                auditLog.StartDBCall();
                i = base.ExecuteNonQuery(command);
            }
            catch (Exception exception)
            {
                ex = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(command.CommandText, ex);
            }
            return i;
        }


        public IEnumerable<TResult> ExecuteSprocAccessor<TResult>(string procedureName, object input, object rowMapper) where TResult : new()
        {
            IEnumerable<TResult> result = null;
            Exception ex = null;
            string exceptionMessage = string.Empty;
            try
            {
                auditLog.StartDBCall();
                result = DatabaseExtensions.ExecuteSprocAccessor<TResult>(this, procedureName, input, rowMapper);
            }
            catch (Exception exception)
            {
                ex = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(procedureName, ex);
            }
            return result;
        }


        public IEnumerable<TResult> ExecuteSprocAccessor<TResult>(string procedureName, IRowMapper<TResult> rowMapper) where TResult : new()
        {
            IEnumerable<TResult> result = null;
            Exception ex = null;
            try
            {
                auditLog.StartDBCall();
                result = DatabaseExtensions.ExecuteSprocAccessor<TResult>(this, procedureName, rowMapper);
            }
            catch (Exception exception)
            {
                ex = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(procedureName, ex);
            }
            return result;
        }


        public IEnumerable<TResult> ExecuteSprocAccessor<TResult>(string procedureName, IParameterMapper parameterMapper, IRowMapper<TResult> rowMapper) where TResult : new()
        {
            IEnumerable<TResult> result = null;
            Exception ex = null;
            try
            {
                auditLog.StartDBCall();
                result = DatabaseExtensions.ExecuteSprocAccessor<TResult>(this, procedureName, parameterMapper, rowMapper);
            }
            catch (Exception exception)
            {
                ex = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(procedureName, ex);
            }
            return result;
        }


        public IEnumerable<TResult> ExecuteSprocAccessor<TResult>(string procedureName, IParameterMapper parameterMapper, IRowMapper<TResult> rowMapper, params object[] parameterValues) where TResult : new()
        {
            IEnumerable<TResult> result = null;
            Exception ex = null;

            try
            {
                auditLog.StartDBCall();
                result = DatabaseExtensions.ExecuteSprocAccessor<TResult>(this, procedureName, parameterMapper, rowMapper, parameterValues);
            }
            catch (Exception exception)
            {
                ex = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(procedureName, ex);
            }
            return result;
        }


        public int ExecuteNonQuery(DbCommand command, DataModelBase input)
        {
            int i = 0;
            Exception exceptionInst = null;
            try
            {
                auditLog.StartDBCall();
                i = base.ExecuteNonQuery(command);
            }
            catch (Exception exception)
            {
                exceptionInst = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(command.CommandText, exceptionInst);
                DbCallComplete(exceptionInst);
            }
            return i;
        }


        public void ExecuteSprocAccessor<TResult>(string procedureName, object input, object rowMapper, OutRecordsListData<TResult> output) where TResult : new()
        {
            Exception exceptionInst = null;
            try
            {
                auditLog.StartDBCall();
                IEnumerable<TResult> result = DatabaseExtensions.ExecuteSprocAccessor<TResult>(
                    this,
                    procedureName,
                    input,
                    rowMapper);
                output.Data = result.ToList();

                //If there is no data set no matching records
                if (output.Data.Count == Constants.NO_DATA_COUNT)
                {
                    DAUtility.SetNoMatchingRecords(output);
                }
            }
            catch (Exception exception)
            {
                exceptionInst = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(procedureName, exceptionInst);
                DbCallComplete(exceptionInst);
            }
        }


        public void ExecuteSprocAccessor<TResult>(string procedureName, IRowMapper<TResult> rowMapper, OutRecordsListData<TResult> output) where TResult : new()
        {
            Exception exceptionInst = null;
            try
            {
                auditLog.StartDBCall();
                IEnumerable<TResult> result = DatabaseExtensions.ExecuteSprocAccessor<TResult>(
                    this,
                    procedureName,
                    rowMapper);
                output.Data = result.ToList();
                //If there is no data set no matching records
                if (output.Data.Count == Constants.NO_DATA_COUNT)
                {
                    DAUtility.SetNoMatchingRecords(output);
                }
            }
            catch (Exception exception)
            {
                exceptionInst = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(procedureName, exceptionInst);
                DbCallComplete(exceptionInst);
            }
        }


        public void ExecuteSprocAccessor<TResult>(string procedureName, IParameterMapper parameterMapper, IRowMapper<TResult> rowMapper, OutRecordsListData<TResult> output) where TResult : new()
        {
            Exception exceptionInst = null;
            try
            {
                auditLog.StartDBCall();
                IEnumerable<TResult> result = DatabaseExtensions.ExecuteSprocAccessor<TResult>(
                    this,
                    procedureName,
                    parameterMapper,
                    rowMapper);
                output.Data = result.ToList();

                //If there is no data set no matching records
                if (output.Data.Count == Constants.NO_DATA_COUNT)
                {
                    DAUtility.SetNoMatchingRecords(output);
                }
            }
            catch (Exception exception)
            {
                exceptionInst = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(procedureName, exceptionInst);
                DbCallComplete(exceptionInst);
            }
        }

        public void ExecuteSprocAccessor<TResult>(string procedureName, IParameterMapper parameterMapper, IRowMapper<TResult> rowMapper, OutRecordsListData<TResult> output, params object[] parameterValues) where TResult : new()
        {
            Exception exceptionInst = null;
            try
            {
                auditLog.StartDBCall();
                IEnumerable<TResult> result = DatabaseExtensions.ExecuteSprocAccessor<TResult>(
                    this,
                    procedureName,
                    parameterMapper,
                    rowMapper,
                    parameterValues);
                output.Data = result.ToList();

                //If there is no data set no matching records
                if (output.Data.Count == Constants.NO_DATA_COUNT)
                {
                    DAUtility.SetNoMatchingRecords(output);
                }
            }
            catch (Exception exception)
            {
                exceptionInst = exception;
                throw;
            }
            finally
            {
                AddToProcessStep(procedureName, exceptionInst);
                DbCallComplete(exceptionInst);
            }
        }

        /// <summary>
        /// Databases the call complete.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public void DbCallComplete(Exception exception = null)
        {
            string errorMessage = (exception != null) ? exception.Message : string.Empty;
            auditLog.EndDBCall(errorMessage);
        }


        /// <summary>
        /// Adds to tracker.
        /// </summary>
        /// <param name="procedureName">Name of the procedure.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        private void AddToProcessStep(string procedureName, Exception ex)
        {
            string statement = GetProcedureStatement(procedureName);
            if (businessBase != null)
            {
                businessBase.AddToProcessStep(statement, ex, true, procedureName, statement);
            }
            auditLog.SetStatement(procedureName, statement);
        }

    }
}