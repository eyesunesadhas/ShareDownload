using ShareWatch.Business.Share;
using ShareWatch.Const;
using ShareWatch.DataModel.Share.Bank;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShareWatch.Common.Utility
{
    public class UIUtility
    {
        public static void SetAutoComplete(TextBox tradeCode)
        {
            ShareKeyData input = new ShareKeyData();
            ShareMasterBL shareMasterBL = new ShareMasterBL(ShareMasterBL.GetInstance());
            OutRecordsListData<ShareMasterData> output = shareMasterBL.GetSharesDetail(input);
            tradeCode.Tag = output.Data;
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            foreach (ShareMasterData data in output.Data)
            {
                acsc.Add(data.TradeCode);
            }
            tradeCode.AutoCompleteCustomSource = acsc;
            tradeCode.AutoCompleteMode = AutoCompleteMode.Suggest;
            tradeCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        public static void FillAccountsListCombo(ComboBox AccountID)
        {
            BankBL bankBL = new BankBL(BusinessBase.GetInstance());
            OutRecordsListData<AccountMasterData> output = bankBL.GetBanksList();
            AccountID.DataSource = output.Data;
            AccountID.ValueMember = DMFieldConstants.ACCOUNT_ID;
            AccountID.DisplayMember = DMFieldConstants.ACCOUNT_NAME;
        }

        public static void FillAccountsCombo(ComboBox AccountID)
        {
            BankBL bankBL = new BankBL(BusinessBase.GetInstance());
            OutRecordsListData<AccountMasterData> output = bankBL.GetBanks();
            AccountID.DataSource = output.Data;
            AccountID.ValueMember = DMFieldConstants.ACCOUNT_ID;
            AccountID.DisplayMember = DMFieldConstants.ACCOUNT_NAME;
        }

        public static string GetTradeName(TextBox tradeCode)
        {
            string trade = tradeCode.Text.Trim().ToUpper();
            if (UtilityHandler.IsEmpty(trade))
            {
                return string.Empty;
            }
            List<ShareMasterData> shares = (List<ShareMasterData>)tradeCode.Tag;
            if (shares == null)
            {
                return string.Empty;
            }
            foreach (ShareMasterData data in shares)
            {
                if (data.TradeCode.Equals(trade))
                {
                    return data.TradeName;
                }
            }
            return string.Empty;
        }

        public static decimal GetAmountValue(decimal input)
        {
            return (input == Constants.NULL_DECIMAL) ? 0 : input;
        }

        public static decimal GetAmountValue(TextBox input)
        {
            if (UtilityHandler.IsEmpty(input.Text))
            {
                return 0;
            }
            _ = decimal.TryParse(input.Text.Trim(), out decimal output);
            return output;
        }

        public static DateTime GetDateValue(DateTime input)
        {
            return (input == Constants.NULL_DATE) ? DateTime.MinValue : input;
        }

    
    }
}
