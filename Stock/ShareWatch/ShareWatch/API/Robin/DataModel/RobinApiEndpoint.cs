using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.API.Robin.DataModel
{
    public sealed class RobinApiEndpoint
    {
        public const string Accounts = "https://api.robinhood.com/accounts/";
        public const string ACHAavAuth = "https://api.robinhood.com/ach/iav/auth/";
        public const string AchRelationships = "https://api.robinhood.com/ach/relationships/";
        public const string AchTransfers = "https://api.robinhood.com/ach/transfers/";
        public const string Applications = "https://api.robinhood.com/applications/";
        public const string DocumentRequests = "https://api.robinhood.com/upload/document_requests/";
        public const string Dividends = "https://api.robinhood.com/dividends/";
        public const string DDocuments = "https://api.robinhood.com/documents/";
        public const string Employment = "https://api.robinhood.com/user/employment";
        public const string EnvestmentProfile = "https://api.robinhood.com/user/investment_profile/";
        public const string Instruments = "https://api.robinhood.com/instruments/";
        public const string Login = "https://api.robinhood.com/oauth2/token/";
        public const string MarginUpgrades = "https://api.robinhood.com/margin/upgrades/";
        public const string Markets = "https://api.robinhood.com/markets/";
        public const string NotificationSettings = "https://api.robinhood.com/settings/notifications/";
        public const string Notifications = "https://api.robinhood.com/notifications/";
        public const string Orders = "https://api.robinhood.com/orders/";
        public const string PasswordReset = "https://api.robinhood.com/password_reset/request/";
        public const string Portfolios = "https://api.robinhood.com/portfolios/";
        public const string Positions = "https://api.robinhood.com/positions/";
        public const string Quotes = "https://api.robinhood.com/quotes/";
        public const string User = "https://api.robinhood.com/user/";
        public const string Watchlists = "https://api.robinhood.com/watchlists/";
        public const string OptionsOrders = "https://api.robinhood.com/options/orders/";
        public const string OptionsPositions = "https://api.robinhood.com/options/positions/";
    }
}
