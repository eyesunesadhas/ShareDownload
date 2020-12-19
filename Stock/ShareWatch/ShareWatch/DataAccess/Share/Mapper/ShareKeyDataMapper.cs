using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataModel.Share.Shrm;
using System.Data;
using System.Data.Common;

namespace ShareWatch.DataAccess.Share.Shrm.Mapper
{
    // Mapper class code
    public class ShareKeyDataMapper : IParameterMapper
    {
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            DAUtility daUtility = (DAUtility)parameterValues[0];
            ShareKeyData input = (ShareKeyData)parameterValues[1];
            daUtility.AddInput(command, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, 0, input.TradeCode);
            daUtility.AddInput(command, DAParameterConstants.AC_HAVE_SHARE_INDC, DbType.String, 15, 0, input.HaveShareIndc);

        }
    }
}
