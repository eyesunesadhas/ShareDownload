using System;

namespace ShareWatch
{
    public class AppScreens
    {

        public const string BANK = "BANK";
        public const string STOCK = "STOCK";
        public const string PORT_FOLIO = "PORTFOLIO";
        public const string TRANSACTION = "TRANSACTION";
        public const string TREND = "TREND";
        public const string HOME = "TREND";
        


        public static MDIChildBase GetScreenForm(string ScreenName)
        {
            return ScreenName switch
            {
                BANK => new AccountScreen(),
                STOCK => new StockScreen(),
                PORT_FOLIO => new PortFolioScreen(),
                TREND => new TrendScreen(),
                TRANSACTION => new PortFolioTransaction(),
                _ => throw new ApplicationException("Not an valid Screen"),
            };
        }

    }
}
