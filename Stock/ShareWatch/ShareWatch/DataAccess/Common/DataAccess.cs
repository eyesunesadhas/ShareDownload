using ShareWatch.BusinessLogic.Logging;
using ShareWatch.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.DataAccess.Common
{
    public class SqlDataAccess : DataAccessBase
    {
        private readonly AuditLogger auditLog = null;
        public SqlDataAccess(BusinessBase businessBase)
           : base(businessBase)
        {
            this.auditLog = new AuditLogger(businessBase);
        }


        public int ExecuteSql(string sql)
        {
            auditLog.StartDBCall();
            auditLog.SetStatement(GetSpName(sql), sql);
            string errorMsg = string.Empty;
            using SqlConnection Cn = new SqlConnection(ApplicationSettings.Default.DBConnectionString);
            try
            {
                Cn.Open();
                using SqlCommand cmd = new SqlCommand
                {
                    CommandText = sql,
                    Connection = Cn,
                    CommandType = CommandType.Text
                };
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                errorMsg = $"{ex.Message} - {ex.StackTrace}";
                throw;
            }
            finally
            {
                if (Cn.State == ConnectionState.Open)
                {
                    Cn.Close();
                }
                auditLog.EndDBCall(errorMsg);
            }

        }

        private static string GetSpName(string sql)
        {
            string[] parts = sql.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in parts)
            {
                if (s.ToUpper() == "EXEC"
                  || s.ToUpper() == "EXECUTE")
                {
                    continue;
                }
                return s;
            }
            return sql;
        }

        public DataSet GetDataSet(string sql, int rows2Fill = 0)
        {
            auditLog.StartDBCall();
            auditLog.SetStatement(GetSpName(sql), sql);
            string errorMsg = string.Empty;

            using SqlConnection Cn = new SqlConnection(ApplicationSettings.Default.DBConnectionString);
            try
            {
                Cn.Open();
                using SqlCommand cmd = new SqlCommand
                {
                    CommandText = sql,
                    Connection = Cn,
                    CommandType = CommandType.Text
                };
                using SqlDataAdapter Da = new SqlDataAdapter(cmd);
                using DataSet Ds = new DataSet("RECORDS");
                if (rows2Fill == 0)
                {
                    Da.Fill(Ds);
                }
                else
                {
                    Da.Fill(Ds, 0, rows2Fill, "RECORD");
                }
                return Ds;
            }
            catch (Exception ex)
            {
                errorMsg = $"{ex.Message} - {ex.StackTrace}";
                throw;
            }
            finally
            {
                if (Cn.State == ConnectionState.Open)
                {
                    Cn.Close();
                }
                auditLog.EndDBCall(errorMsg);
            }
        }

        internal bool SaveData(string sql)
        {
            throw new NotImplementedException();
        }

        public string GetString(string sql)
        {
            auditLog.StartDBCall();
            auditLog.SetStatement(GetSpName(sql), sql);
            string errorMsg = string.Empty;
            using SqlConnection Cn = new SqlConnection(ApplicationSettings.Default.DBConnectionString);
            try
            {
                Cn.Open();
                using SqlCommand cmd = new SqlCommand
                {
                    CommandText = sql,
                    Connection = Cn,
                    CommandType = CommandType.StoredProcedure
                };

                using SqlDataAdapter Da = new SqlDataAdapter(cmd);
                using DataSet Ds = new DataSet("RECORDS");
                Da.Fill(Ds);
                if (Ds == null || Ds.Tables.Count == 0 || Ds.Tables[0].Rows.Count == 0)
                {
                    throw new ApplicationException("No Data found");
                }
                DataRow row = Ds.Tables[0].Rows[0];
                string value = row.IsNull(0) ? "" : row[0].ToString().Trim();
                Ds.Dispose();
                return value;
            }
            catch (Exception ex)
            {
                errorMsg = $"{ex.Message} - {ex.StackTrace}";
                throw;
            }
            finally
            {
                if (Cn.State == ConnectionState.Open)
                {
                    Cn.Close();
                }
                auditLog.EndDBCall(errorMsg);
            }

        }
    }
}
