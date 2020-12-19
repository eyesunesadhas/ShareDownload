

using ShareWatch.DataModel.Common;

namespace ShareWatch.BusinessLogic.Common.Validation
{
    /// <summary>
    /// All common validations done in the Business Logic files are defined here.
    /// Inherited from ValidationStatus and override the method AddValidationFailure method to set multiple errors on a field
    /// </summary>
    public partial class ValidationStatusMultipleError : ValidationStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationStatusMultipleError" /> class.
        /// </summary>
        public ValidationStatusMultipleError()
            : base()
        {
        }

        /// <summary>
        /// Add the validation failure to the field.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public override void AddValidationFailure(string errorCode, string commonName)
        {
            // Check for error code set already on the same field.
            if (!StatusList.Exists(status => status.Code == errorCode && status.RelatedField == commonName))
            {
                Status status = new Status(errorCode, commonName);
                StatusList.Add(status);
            }
        }
    }
}