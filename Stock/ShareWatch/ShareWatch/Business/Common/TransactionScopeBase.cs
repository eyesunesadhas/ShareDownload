using System.Transactions;

namespace ShareWatch.BusinessLogic.Common
{
    /// <summary>
    ///  Wrapper for TransactionScope
    /// </summary>
    public class TransactionScopeBase
    {
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns></returns>
        public static TransactionScope GetInstance()
        {
            TransactionScopeOption ScopeOptions = new TransactionScopeOption();
            TransactionOptions Options = new TransactionOptions()
            {
                IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted
            };
            return new TransactionScope(ScopeOptions, Options);
        }
    }
}