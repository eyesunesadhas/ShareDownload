
using ShareWatch.Common;
using ShareWatch.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.DataAccess.Share
{
    public class BankPortfolioDA : DataAccessBase
    {
        public BankPortfolioDA(BusinessBase businessBase)
          : base(businessBase)
        {
        }

        public  DataSet GetEmptyData()
        {
            string spName = "BPFOL_SELECT_S1";
            SqlDataAccess da = new SqlDataAccess(businessBase);
            return da.GetDataSet(spName);
        }

        public static void SaveData(List<string> accounts, DataSet input)
        {

            string sql = "BPFOL_DELETE_S1 @As_BankAccount_ID ='<LIST>'";
            sql = sql.Replace("<LIST>", string.Join(',', accounts));
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
                cmd.ExecuteNonQuery();
                using SqlBulkCopy sbc = new SqlBulkCopy(Cn)
                {
                    DestinationTableName = "BankPortfolioData_T1",
                    BatchSize = 100
                };
                sbc.WriteToServer(input.Tables[0]);

                sql = "BPFOL_UPDATE_ACCOUNT_S1";
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (Cn.State == ConnectionState.Open)
                {
                    Cn.Close();
                }
            }

        }

        public static DataSet GetAccountTallyReport()
        {

            string spName = "BPFOL_SELECT_ACCOUNT_TALLY_S4";
            using SqlConnection Cn = new SqlConnection(ApplicationSettings.Default.DBConnectionString);
            try
            {
                Cn.Open();
                using SqlCommand cmd = new SqlCommand
                {
                    CommandText = spName,
                    Connection = Cn,
                    CommandType = CommandType.StoredProcedure
                };
                using SqlDataAdapter Da = new SqlDataAdapter(cmd);
                using DataSet Ds = new DataSet("AccountTally");
                Da.Fill(Ds);
                return Ds;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (Cn.State == ConnectionState.Open)
                {
                    Cn.Close();
                }
            }

        }
    }
}
