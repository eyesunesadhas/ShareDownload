using ShareWatch.BusinessLogic.Common;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Transactions;

namespace ShareWatch.Business.Share
{
    public partial class PortfolioBL : BusinessBase
    {
        public PortfolioBL(BusinessBase businessBase)
               : base(businessBase)
        {

        }

        public OutData<int> SavePortfolio(PortfolioData input)
        {
            OutData<int> output = new OutData<int>();

            if (!IsValidInput<PortfolioData>(input, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {

                UtilityBL utilityBL = new UtilityBL(businessBase);
                input.NewTransactionEventSeqNumb = utilityBL.Generatevent("SavePortfolio");
                PortfolioDA portfolioDA = new PortfolioDA(businessBase);
                output.Data = portfolioDA.SavePortfolio(input);
                scope.Complete();
            }
            return output;
        }

        public OutRecordsListData<PortfolioData> GetPortfolioData(PortfolioData input)
        {
            PortfolioDA portfolioDA = new PortfolioDA(businessBase);
            return portfolioDA.GetPortfolioData(input);
        }

        public StatusOut SavePortfolioCostBasis(PortfolioData input)
        {
            StatusOut output = new StatusOut();

            if (!IsValidInput<PortfolioData>(input, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {

                UtilityBL utilityBL = new UtilityBL(businessBase);
                input.NewTransactionEventSeqNumb = utilityBL.Generatevent("SaveCostBasis");
                PortfolioDA portfolioDA = new PortfolioDA(businessBase);
                int rowsAfftected = portfolioDA.SavePortfolioCostBasis(input);
                scope.Complete();
            }
            return output;
        }
    }
}
