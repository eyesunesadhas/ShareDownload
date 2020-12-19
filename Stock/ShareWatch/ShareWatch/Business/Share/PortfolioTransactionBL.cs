using ShareWatch.Common;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModel.Share.Pfot;
using ShareWatch.DataModels.CoreDataModel;

namespace ShareWatch.Business.Share
{
    public class PortfolioTransactionBL : BusinessBase
    {
        public PortfolioTransactionBL(BusinessBase businessBase)
               : base(businessBase)
        {

        }

        public OutRecordsListData<PortfolioData> GetPortfolioSummary()
        {
            PortfolioTransactionDA portfolioTransactionDA = new PortfolioTransactionDA(businessBase);
            return portfolioTransactionDA.GetPortfolioSummary();
        }


        public OutRecordsListData<PortfolioData> GetPortfolio(PortfolioData input)
        {
            PortfolioTransactionDA portfolioTransactionDA = new PortfolioTransactionDA(businessBase);
            return portfolioTransactionDA.GetPortfolio(input);
        }

        public OutRecordsListData<PortfolioTransactionData> GetPortfolioTransaction(PortfolioData input)
        {
            PortfolioTransactionDA portfolioTransactionDA = new PortfolioTransactionDA(businessBase);
            return portfolioTransactionDA.GetPortfolioTransaction(input);

        }

    }
}
