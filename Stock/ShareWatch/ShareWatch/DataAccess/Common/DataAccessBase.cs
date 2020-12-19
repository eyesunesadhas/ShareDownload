using ShareWatch.Common;

namespace ShareWatch.DataAccess.Common
{
    public class DataAccessBase
    {
        /// <summary>
        /// The m_application base
        /// </summary>
        protected BusinessBase businessBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessBase"/> class.
        /// </summary>
        private DataAccessBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessBase"/> class.
        /// </summary>
        /// <param name="businessBase">The application base.</param>
        public DataAccessBase(BusinessBase businessBase)
        {
            this.businessBase = businessBase;
        }
    }
}