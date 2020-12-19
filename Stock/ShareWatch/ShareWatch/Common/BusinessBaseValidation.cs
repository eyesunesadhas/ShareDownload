using ShareWatch.BusinessLogic.Common.Validation;
using ShareWatch.Const;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShareWatch.Common
{
    /// <summary>
    /// Acts as a base class for all the BL classes, used to validate inputs provided
    /// </summary>
    public partial class BusinessBase
    {

        public bool IsValid(DataModelBase dataModelBase, ValidationStatus validationStatus)
        {
            return validationStatus.IsValid;
        }

        public bool IsKeyValid(DataModelBase dataModelBase, ValidationStatus validationStatus)
        {
            return validationStatus.IsValid;
        }



        public bool IsValidInputList<T>(
             List<T> input,
             StatusOut output,
             Func<T, ValidationStatus, bool> action)
            where T : DataModelBase
        {
            bool isValid = true;
            int recordIndex = Constants.INT_ZERO;

            input.ForEach(record =>
            {
                ValidationStatus validationStatus = new ValidationStatus();

                // Validate each record, by calling the corresponding validation logic
                if (!action((T)record, validationStatus))
                {
                    validationStatus.StatusList.ForEach(status =>
                    {
                        // if status code is not empty and status is not success then set row number
                        if (!UtilityHandler.IsEmpty(status.Code) && status.Code != Constants.STATUS_SUCCESS)
                        {
                            status.Row = recordIndex + Constants.INT_ONE;
                            output.StatusList.Add(status);
                            isValid = false;
                        }
                    });
                }
                recordIndex++;
            });
            return isValid;
        }



        public bool IsValidInput<T>(T input,
            StatusOut output,
            Func<T, ValidationStatus, bool> action,
            bool isMultipleError = false) where T : DataModelBase
        {
            bool isValid = true;

            ValidationStatus validationStatus = null;

            // Determines whether to use ValidationStaus or ValidationStatusMultipleError object
            if (!isMultipleError)
            {
                validationStatus = new ValidationStatus();
            }
            else
            {
                validationStatus = new ValidationStatusMultipleError();
            }

            // Validate record, by calling the corresponding validation logic
            if (!action((T)input, validationStatus))
            {
                output.StatusList = validationStatus.StatusList;
                isValid = false;
            }
            return isValid;
        }

        public bool IsValidKeyInput<T>(T input,
            StatusOut output,
            Func<T, ValidationStatus, bool> action)
            where T : DataModelBase
        {
            bool isValid = true;
            ValidationStatus validationStatus = new ValidationStatus();



            // Validate record, by calling the corresponding validation logic
            if (!action((T)input, validationStatus))
            {
                output.StatusList = validationStatus.StatusList;
                isValid = false;
            }
            return isValid;
        }


        public static StatusOut ValidateDuplicateRecords<T>(
             List<T> input,
             string relatedField = "")
           where T : DataModelBase
        {
            StatusOut output = new StatusOut();

            List<DuplicateRecordData<T>> duplicateRecordList =
                                       (from record in input
                                        group record by record into recordGroup
                                        where recordGroup.Count() > 1
                                        select new DuplicateRecordData<T>
                                        {
                                            DuplicateRecord = recordGroup,
                                            Count = recordGroup.Count()
                                        }).ToList();

            // iterate duplicate records & set error for duplicates
            duplicateRecordList.ForEach(duplicateRecordGroup =>
            {
                int previousIndex = Constants.INT_MINUS_ONE;

                // iterate duplicate records & set error for duplicates
                for (int i = Constants.INT_ZERO; i < duplicateRecordGroup.Count; i++)
                {
                    previousIndex = input.IndexOf(duplicateRecordGroup.DuplicateRecord.ElementAt(i), (previousIndex + Constants.INT_ONE));
                    UtilityHandler.UpdateStatus(output, TransactionCheckType.DuplicateRecord, relatedField);
                    output.StatusList[output.StatusList.Count - Constants.INT_ONE].Row = previousIndex + Constants.INT_ONE;
                }
            });
            return output;
        }
    }
}