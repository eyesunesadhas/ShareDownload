using ShareWatch.BusinessLogic.Common.Validation;
using ShareWatch.Common;
using ShareWatch.DataModel.Share.Stdv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.Business.Share
{
    public partial class ShareTradeValueBL : BusinessBase
    {
        public bool IsValid(ShareTradeValueData input, ValidationStatus validationStatus)
        {
          
            return validationStatus.IsValid;
        }

    }
}
