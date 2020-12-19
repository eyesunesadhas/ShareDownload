using ShareWatch.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.DataModel.Share.Pfol
{
    public class PortfolioSummaryData
    {

        public string OwnerName { get; set; } = string.Empty;

        public string AccountName { get; set; } = string.Empty;
        public string AccountTypeCode { get; set; } = string.Empty;
        public string AccountTypeText { get; set; } = string.Empty;

        public decimal TotalInvestAmnt { get; set; } = 0;

        public decimal TotalCurrentAmnt { get; set; } = 0;
        
        public decimal TotalBenefitAmnt
        {
            get
            {
                return TotalCurrentAmnt - TotalInvestAmnt;
            }
        }

        public decimal BenefitPercentage
        {
            get
            {
                if (TotalInvestAmnt == 0) { return 0; }
                return (TotalBenefitAmnt / TotalInvestAmnt) * 100;
            }
        }
    }
}
