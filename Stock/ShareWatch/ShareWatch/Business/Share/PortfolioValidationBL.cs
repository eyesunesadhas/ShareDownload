using ShareWatch.BusinessLogic.Common.Validation;
using ShareWatch.Common;
using ShareWatch.DataModel.Share.Pfol;

namespace ShareWatch.Business.Share
{
    public partial class PortfolioBL : BusinessBase
    {
        /* Validation Code block */
        public bool IsValid(PortfolioData input, ValidationStatus validationStatus)
        {
            return validationStatus.IsValid;
        }

      
      
    }
}
