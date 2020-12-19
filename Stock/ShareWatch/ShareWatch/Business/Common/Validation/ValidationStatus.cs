using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModel.Common;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ShareWatch.BusinessLogic.Common.Validation
{
    /// <summary>
    /// All common validations done in the Business Logic files are defined here.
    /// </summary>
    public partial class ValidationStatus
    {
        /// <summary>
        /// Hash table object to store the error fields
        /// </summary>
        private Hashtable m_fieldList = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidationStatus" /> class.
        /// </summary>
        public ValidationStatus()
        {
            StatusList = new List<Status>();
            m_fieldList = new Hashtable();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid
        {
            get
            {
                // Return true if StatusList is null or zero
                if (StatusList == null || StatusList.Count == Constants.INT_ZERO)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Gets or sets the status list.
        /// </summary>
        /// <value>
        /// The status list.
        /// </value>
        public List<Status> StatusList
        {
            get;
            set;
        }

        /// <summary>
        /// Add the validation failure to the field. If any error is set to the field
        /// already, the new error will not be set.
        /// </summary>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public virtual void AddValidationFailure(string errorCode, string commonName)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Check field not present already
                if (!m_fieldList.ContainsKey(commonName))
                {
                    Status status = new Status(errorCode, commonName);
                    StatusList.Add(status);
                    m_fieldList.Add(commonName, commonName);
                }
            }
        }

        /// <summary>
        /// Determines whether [has error on any fields] [the specified common names].
        /// </summary>
        /// <param name="commonNames">The common names.</param>
        /// <returns>
        ///   <c>true</c> if [has error on any fields] [the specified common names]; otherwise, <c>false</c>.
        /// </returns>
        public bool HasErrorOnAnyFields(params string[] commonNames)
        {
            foreach (string name in commonNames)
            {
                // Return true if errorSetOnField
                if (IsErrorSetOnField(name))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether [is error set on field] [the specified common name].
        /// </summary>
        /// <param name="commonName">Name of the common.</param>
        /// <returns>
        ///   <c>true</c> if [is error set on field] [the specified common name]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsErrorSetOnField(string commonName)
        {
            // Return false if commonName is empty
            if (UtilityHandler.IsEmpty(commonName))
            {
                return false;
            }
            return m_fieldList.ContainsKey(commonName);
        }

        #region Required Field Validations

        /// <summary>
        /// Checks if the given input is Empty.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldIfEmpty(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is empty
                if (BaseValidators.IsEmpty(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Checks if the given input is Empty.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The e code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldIfEmpty(int fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is empty
                if (BaseValidators.IsEmpty(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Checks if the given input is Empty.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldIfEmpty(double fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is empty
                if (BaseValidators.IsEmpty(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Checks if the given input is Empty.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldIfEmpty(decimal fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is empty
                if (BaseValidators.IsEmpty(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Checks if the given input is Empty.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldIfEmpty(ulong fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is empty
                if (BaseValidators.IsEmpty(Convert.ToDouble(fieldValue)))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Checks if the given input is Empty.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldIfEmpty(long fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is empty
                if (BaseValidators.IsEmpty(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field if empty.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldIfEmpty(DateTime fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is empty
                if (BaseValidators.IsEmpty(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion Required Field Validations

        #region Minimum Length Validation

        /// <summary>
        /// Validates the length of the field is min.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="minLength">Length of the min.</param>
        public void ValidateFieldIsMinLength(string fieldValue, string errorCode, string commonName, int minLength)
        {
            // Check for error not set already on the same field.
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is MinLength
                if (BaseValidators.IsMinLength(fieldValue, minLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the length of the field is min.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="minLength">Length of the min.</param>
        public void ValidateFieldIsMinLength(long fieldValue, string errorCode, string commonName, int minLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is MinLength
                if (BaseValidators.IsMinLength(fieldValue, minLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the length of the field is min.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="minLength">Length of the min.</param>
        public void ValidateFieldIsMinLength(double fieldValue, string errorCode, string commonName, int minLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is MinLength
                if (BaseValidators.IsMinLength(fieldValue, minLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion Minimum Length Validation

        #region Maximum Length Validations

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(double fieldValue, int scale, string errorCode, string commonName, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength, scale))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(decimal fieldValue, int scale, string errorCode, string commonName, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength, scale))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(int fieldValue, int scale, string errorCode, string commonName, int maxLength)
        {
            ValidateFieldOversize(fieldValue, errorCode, commonName, maxLength);
        }

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(ulong fieldValue, int scale, string errorCode, string commonName, int maxLength)
        {
            ValidateFieldOversize(fieldValue, errorCode, commonName, maxLength);
        }

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="scale">The scale.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(long fieldValue, int scale, string errorCode, string commonName, int maxLength)
        {
            ValidateFieldOversize(fieldValue, errorCode, commonName, maxLength);
        }

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(string fieldValue, string errorCode, string commonName, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(int fieldValue, string errorCode, string commonName, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(long fieldValue, string errorCode, string commonName, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field oversize.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="maxLength">Length of the min.</param>
        public void ValidateFieldOversize(ulong fieldValue, string errorCode, string commonName, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion Maximum Length Validations

        #region Maximum and Minum Length Valdiations

        /// <summary>
        /// Validates the size of the field.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="minLength">Length of the min.</param>
        /// <param name="maxLength">Length of the max.</param>
        public void ValidateFieldSize(int fieldValue, string errorCode, string commonName, int minLength, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
                else if (BaseValidators.IsMinLength(fieldValue, minLength))
                {
                    // Set error if fieldValue is minLengh
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the size of the field.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="minLength">Length of the min.</param>
        /// <param name="maxLength">Length of the max.</param>
        public void ValidateFieldSize(long fieldValue, string errorCode, string commonName, int minLength, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
                else if (BaseValidators.IsMinLength(fieldValue, minLength))
                {
                    // Set error if fieldValue is minLengh
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the size of the field.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="minLength">Length of the min.</param>
        /// <param name="maxLength">Length of the max.</param>
        public void ValidateFieldSize(string fieldValue, string errorCode, string commonName, int minLength, int maxLength)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is OverSize
                if (BaseValidators.IsOverSize(fieldValue, maxLength))
                {
                    AddValidationFailure(errorCode, commonName);
                }
                else if (BaseValidators.IsMinLength(fieldValue, minLength))
                {
                    // Set error if fieldValue is minLengh
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion Maximum and Minum Length Valdiations

        #region Date Validations

        /// <summary>
        /// Validates the field date equals today.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldDateEqualsToday(DateTime fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid date
                if (!BaseValidators.IsValidDate(fieldValue))
                {
                    AddValidationFailure(ErrorConstants.E0043, commonName);
                }
                else if (BaseValidators.IsToday(fieldValue))
                {
                    // Set error if fieldValue is not a current date.
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field date greater than equals today.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldDateGreaterThanEqualsToday(DateTime fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid date
                if (!BaseValidators.IsValidDate(fieldValue))
                {
                    AddValidationFailure(ErrorConstants.E0043, commonName);
                }
                else if (BaseValidators.IsFutureCurrentDate(fieldValue))
                {
                    // Set error if fieldValue is a Future date.
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field date greater than today.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldDateGreaterThanToday(DateTime fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid date
                if (!BaseValidators.IsValidDate(fieldValue))
                {
                    AddValidationFailure(ErrorConstants.E0043, commonName);
                }
                else if (BaseValidators.IsFutureDate(fieldValue))
                {
                    // Set error if fieldValue is a Future date.
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field date less than today.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldDateLessThanToday(DateTime fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid date
                if (!BaseValidators.IsValidDate(fieldValue))
                {
                    AddValidationFailure(ErrorConstants.E0043, commonName);
                }
                else if (BaseValidators.IsPastDate(fieldValue))
                {
                    // Set error if fieldValue is a  Past date.
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid date.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidDate(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid date
                if (!BaseValidators.IsValidDate(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid date.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidDate(DateTime fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid date
                if (!BaseValidators.IsValidDate(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid date time.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidDateTime(DateTime fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid dateTime
                if (!BaseValidators.IsValidDateTime(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion Date Validations

        #region Amount Valdiations

        /// <summary>
        /// Validates the field valid amount.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAmount(double fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Amount
                if (!BaseValidators.IsValidAmount(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid amount not neg.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAmountNotNeg(double fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumeric(fieldValue))
                {
                    AddValidationFailure(ErrorConstants.E0043, commonName);
                }
                else if (BaseValidators.IsAmountNegative(fieldValue))
                {
                    // Set error if fieldValue is Negative amount
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid amount.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAmount(decimal fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                //Set error if fieldValue is Invalid Amount
                if (!BaseValidators.IsValidAmount(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid amount not neg.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAmountNotNeg(decimal fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                //Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumeric(fieldValue))
                {
                    AddValidationFailure(ErrorConstants.E0043, commonName);
                }
                else if (BaseValidators.IsAmountNegative(fieldValue))
                {
                    // Set error if fieldValue is Negative amount
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion Amount Valdiations

        #region Numeric Value Validations

        /// <summary>
        /// Validates the field valid numeric.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidNumeric(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumeric(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid numeric.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidNumeric(int fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumeric(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid numeric.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidNumeric(long fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumeric(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid numeric.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errCode">The err code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidNumeric(double fieldValue, string errCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumeric(fieldValue))
                {
                    AddValidationFailure(errCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid numeric.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errCode">The err code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidNumeric(decimal fieldValue, string errCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumeric(fieldValue))
                {
                    AddValidationFailure(errCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid numeric.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errCode">The err code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidNumeric(ulong fieldValue, string errCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumeric(Convert.ToDouble(fieldValue)))
                {
                    AddValidationFailure(errCode, commonName);
                }
            }
        }

        #endregion Numeric Value Validations

        #region String Value Allowed characters Validations

        /// <summary>
        /// Checks if the given input is valid AlphaNumeric. This includes "_" and
        /// White space character also.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The e code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldAlphaNumeric(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Alpha Numeric
                if (!BaseValidators.IsValidAlphaNumeric(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field numeric hyphen.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldNumericHypen(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsValidNumericHypen(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field non zero alpha numeric.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldNonZeroAlphaNumeric(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Numeric
                if (!BaseValidators.IsNonZeroAlphaNumeric(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid alpha.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAlpha(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Alpha
                if (!BaseValidators.IsValidAlpha(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid alpha hyphen.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAlphaHypen(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid AlphaHypen
                if (!BaseValidators.IsValidAlphaHypen(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid alpha numeric.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAlphaNumeric(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Alpha numeric
                if (!BaseValidators.IsValidAlphaNumeric(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid alpha numeric hyphen.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The e code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAlphaNumericHypen(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Alpha numeric
                if (!BaseValidators.IsValidAlphaNumericHypen(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid alpha space.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAlphaSpace(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Alpha Space
                if (!BaseValidators.IsValidAlphaSpace(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion String Value Allowed characters Validations

        #region Other Special Field Validations

        /// <summary>
        /// Validates the current or past year.
        /// </summary>
        /// <param name="fieldvalue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateCurrentOrPastYear(string fieldvalue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid year
                if (BaseValidators.IsFutureYear(fieldvalue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field case id.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The e code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldCaseIdno(int fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid caseIdno
                if (!BaseValidators.IsValidCaseIdno(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field check number.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldCheckNumber(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Check number
                if (!BaseValidators.IsValidCheckNumber(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field description.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldDescription(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid description
                if (!BaseValidators.IsValidDescription(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field docket identifier.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldDocketID(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid description
                if (!BaseValidators.IsValidDocketID(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field E mail.The formats allowed are [A-Za-z0-9._]+@[A-Za-z0-9_]+\\.[a-zA-Z]{2,3}
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldEMail(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Email
                if (!BaseValidators.IsValidEMail(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// Validates the field E mail.The formats allowed are ^(?=(.*\\d))(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\\d]).{8,}$
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldStrongPassword(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Email
                if (!BaseValidators.IsStrongPassword(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field IVA case id.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The e code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldIvaCaseIdno(long fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid IvaCaseIdno
                if (!BaseValidators.IsValidIvaCaseIdno(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field member id.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The e code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldMemberIdno(long fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid MemberIdno
                if (!BaseValidators.IsValidMemberIdno(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the name of the field.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldName(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid name
                if (!BaseValidators.IsValidName(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field OTHP id.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The e code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldOthpIdno(int fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid othpIdno
                if (!BaseValidators.IsValidOthpIdno(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the name of the field OTHP.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldOthpName(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid othpName
                if (!BaseValidators.IsValidOthpName(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field payor id.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The e code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldPayorIdno(long fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid payorIdno
                if (!BaseValidators.IsValidPayorIdno(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field phone number.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldPhoneNumber(ulong fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid phone number
                if (!BaseValidators.IsValidPhoneNumber(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field receipt number.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldReceiptNumber(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid receipt number
                if (!BaseValidators.IsValidReceiptNumber(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field SSN.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldSSN(int fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid SSN
                if (!BaseValidators.IsValidSsn(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the state of the field US.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldUSState(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid US State
                if (!BaseValidators.IsValidUSState(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid address.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidAddress(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Address
                if (!BaseValidators.IsValidAddress(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid city.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidCity(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid City
                if (!BaseValidators.IsValidCity(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid id FIPS.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidFipsCode(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Fips
                if (!BaseValidators.IsValidFips(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field valid month support.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldValidMonthSupport(int fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Month support
                if (!BaseValidators.IsValidMonthSupport(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field worker ID.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldWorkerID(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid WorkerID
                if (!BaseValidators.IsValidWorkerID(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field year.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        public void ValidateFieldYear(string fieldValue, string errorCode, string commonName)
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid year
                if (!BaseValidators.IsValidYear(fieldValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        /// <summary>
        /// Validates the field zip.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="country">The country.</param>
        public void ValidateFieldZip(string fieldValue, string errorCode, string commonName, string country = "")
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid Zip
                if (!BaseValidators.IsValidZip(fieldValue, country))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion Other Special Field Validations

        #region Lookup Validations

        /// <summary>
        /// Validates the field look up.
        /// </summary>
        /// <param name="fieldValue">The field value.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="screenID">The screen ID.</param>
        /// <param name="dependentValue">The dependent value.</param>
        public void ValidateFieldLookUp(string fieldValue, string errorCode, string commonName, string screenID, string dependentValue = "")
        {
            // Check for error not set already on the same field
            if (!IsErrorSetOnField(commonName))
            {
                // Set error if fieldValue is Invalid LookUp
                if (!BaseValidators.IsValidLookUp(screenID, commonName, fieldValue, dependentValue))
                {
                    AddValidationFailure(errorCode, commonName);
                }
            }
        }

        #endregion Lookup Validations
    }
}