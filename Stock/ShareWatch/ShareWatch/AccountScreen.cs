
using ProDataGridViewColumns;
using ShareWatch.Business.Share;
using ShareWatch.Common;
using ShareWatch.Common.DataStore;
using ShareWatch.Common.Utility;
using ShareWatch.Const;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Bank;
using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Windows.Forms;

namespace ShareWatch
{
    public partial class AccountScreen : MDIChildBase
    {
        public AccountScreen()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int accountID = 0;
                if (!UtilityHandler.IsEmpty(AccountID.Text))
                {
                    int.TryParse(AccountID.Text, out accountID);
                }

                AccountMasterData input = new AccountMasterData()
                {
                    AccountID = accountID,
                    BankName = BankName.Text,
                    BankAccountID = BankAccountID.Text,
                    AccountTypeCode = AccountTypeCode.SelectedValue.ToString(),
                    OwnerName = OwnerName.Text,
                    HideAccountIndc = HideAccountIndc.Checked ? Constants.YES_INDC : Constants.NO_INDC
                };
                BankBL bankBL = new BankBL(BusinessBase.GetInstance());
                OutData<int> output = bankBL.SaveBankMaster(input);
                AccountID.Text = output.Data.ToString();
                ShowData();
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }

        private void AccountScreen_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                DesignGrid();
                LoadCombo();
                ShowData();
                ShowMessage("Done");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }


        private void DesignGrid()
        {
            Grid.ColumnHeadersVisible = true;
            Grid.RowHeadersVisible = false;
            Grid.BackgroundColor = this.BackColor;
            Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Grid.AutoGenerateColumns = false;
            Grid.ColumnHeadersHeight = 18;
            Grid.RowTemplate.Height = 18;
            Grid.RowTemplate.ReadOnly = true;
            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToDeleteRows = false;
            Grid.AllowUserToOrderColumns = false;
            Grid.AllowUserToResizeRows = false;
            Grid.AllowUserToResizeColumns = true;
            Grid.Columns.Clear();
            Grid.Columns.Add(ColumnSelector.LabelColumn("ID", "AccountID", 20, DataGridViewContentAlignment.MiddleRight, "", DataGridViewAutoSizeColumnMode.None, 20, 30));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Bank", "BankName", 300, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 300, 400));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Account#", "BankAccountID", 125, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 125, 150));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Type", "AccountTypeText", 150, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 130, 175));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Owner", "OwnerName", 130, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 150, 175));
            Grid.Columns.Add(ColumnSelector.CheckBoxColumn("Hide", "HideAccountIndc", 20,"Y","N", DataGridViewAutoSizeColumnMode.None, 20, 20));
            return;
        }


        private void ShowData()
        {
            BankBL bankBL = new BankBL(BusinessBase.GetInstance());
            OutRecordsListData<AccountMasterData> output = bankBL.GetBanks();
            Grid.DataSource = output.Data;
        }

        private void LoadCombo()
        {
            System.Collections.Generic.List<RefmLookupData> data = RefmStore.Instance.GetCodeAndDescriptionMap("BANKACC", "TYPE");
            AccountTypeCode.DataSource = data;
            AccountTypeCode.ValueMember = "Code";
            AccountTypeCode.DisplayMember = "Description";
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                ShowData();
                ShowMessage("Done");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }

        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if (e.RowIndex < 0)
                {
                    return;
                }
                DataGridView dataGrid = (DataGridView)sender;
                AccountMasterData rv = (AccountMasterData)Grid.CurrentRow.DataBoundItem;
                BankName.Text = rv.BankName;
                AccountID.Text = rv.AccountID.ToString();
                BankAccountID.Text = rv.BankAccountID;
                AccountTypeCode.SelectedValue = rv.AccountTypeCode;
                OwnerName.Text = rv.OwnerName;
                HideAccountIndc.Checked = UtilityHandler.GetBooleanValue(rv.HideAccountIndc);
                ShowMessage("Done");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                AccountID.Text = string.Empty;
                BankAccountID.Text = string.Empty;
                OwnerName.Text = string.Empty;
                ShowMessage("Done");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }
    }
}
