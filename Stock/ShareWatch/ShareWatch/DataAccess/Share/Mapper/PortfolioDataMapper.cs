using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataModel.Share.Pfol;
using System.Data;
using System.Data.Common;

namespace ShareWatch.DataAccess.Share.Mapper
{
    // Mapper class code
    public class PortfolioDataMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            DAUtility daUtility = (DAUtility)parameterValues[0];
            PortfolioData input = (PortfolioData)parameterValues[1];

            daUtility.AddInput(command, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
            daUtility.AddInput(command, DAParameterConstants.AI_ACCOUNT_ID, DbType.Int32, 10, input.AccountID);
        }
    }
}
