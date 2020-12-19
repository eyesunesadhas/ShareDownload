using System;
using System.Collections;
using System.Windows.Forms;

namespace ShareWatch
{


    public partial class MDIChildBase : Form
    {
        public MDIChildBase()
        {
            InitializeComponent();
        }


        protected Hashtable WorkersPool = null;
        protected string ScreenFunction = "";

        protected DateTime StartTime;
        protected DateTime EndTime;

        public TimeSpan TimeTaken
        {
            get
            {
                if (EndTime < StartTime) return DateTime.Now - StartTime;
                return EndTime - StartTime;
            }

        }

        protected MDIShareWatch Mdi
        {
            get
            {
                return (MDIShareWatch)this.MdiParent;
            }
        }

        protected virtual void MDIChildBase_Load(object sender, EventArgs e)
        {
            try
            {
                AttachMdiEvents();
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

        protected virtual void MDIChildBase_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                DeAttachMdiEvents();
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
        public void StartClockTimer()
        {
            this.ClockTimer.Enabled = true;
            this.StartTime = DateTime.Now;
        }

        public void StopClockTimer()
        {
            this.ClockTimer.Enabled = false;
            this.EndTime = DateTime.Now;
        }

        protected void ShowMessage(string Msg)
        {
            if (Mdi != null)
            {
                Mdi.ShowMessage(Msg);
            }
        }

        protected void ShowClock(string Msg)
        {
            if (Mdi != null)
            {
                Mdi.ShowClock(Msg);
            }
        }

        protected void ShowAnimate(bool isVisible)
        {
            if (Mdi != null)
            {
                Mdi.ShowProcessBar = isVisible;
            }
        }


        protected void AttachMdiEvents()
        {
            if (this.MdiParent == null) return;
            MDIShareWatch mdi = (MDIShareWatch)this.MdiParent;
            mdi.ToolNewClick += OnNewClick;
            mdi.ToolOpenClick += OnOpenClick;
            mdi.ToolSaveClick += OnSaveClick;
            mdi.ToolDeleteClick += OnDeleteClick;
            mdi.ToolRefreshClick += OnRefreshClick;
            mdi.ToolExcelExportClick += OnExcelExportClick;
            mdi.ToolGoolgeSheetExportClick += OnGoolgeSheetExportClick;
            mdi.ToolWordExportClick += OnWordExportClick;
            mdi.ContextMenuClick += OnMdiContextMenuClick;
        }



        protected void DeAttachMdiEvents()
        {
            if (this.MdiParent == null) return;
            MDIShareWatch mdi = (MDIShareWatch)this.MdiParent;
            mdi.ToolNewClick -= OnNewClick;
            mdi.ToolOpenClick -= OnOpenClick;
            mdi.ToolSaveClick -= OnSaveClick;
            mdi.ToolDeleteClick -= OnDeleteClick;
            mdi.ToolRefreshClick -= OnRefreshClick;
            mdi.ToolExcelExportClick -= OnExcelExportClick;
            mdi.ToolGoolgeSheetExportClick -= OnGoolgeSheetExportClick;
            mdi.ToolWordExportClick -= OnWordExportClick;
            mdi.ContextMenuClick -= OnMdiContextMenuClick;
        }

        protected virtual void OnMdiContextMenuClick(string key)
        {

        }


        protected virtual void OnNewClick(object sender, EventArgs e)
        {

        }

        protected virtual void OnOpenClick(object sender, EventArgs e)
        {

        }

        protected virtual void OnSaveClick(object sender, EventArgs e)
        {

        }

        protected virtual void OnDeleteClick(object sender, EventArgs e)
        {

        }

        protected virtual void OnRefreshClick(object sender, EventArgs e)
        {

        }

        protected virtual void OnExcelExportClick(object sender, EventArgs e)
        {

        }

        protected virtual void OnGoolgeSheetExportClick(object sender, EventArgs e)
        {

        }
        
        protected virtual void OnWordExportClick(object sender, EventArgs e)
        {

        }

        protected virtual void OnParentActivtiyTreeNodeClick(TreeNode node)
        {

        }

        protected virtual void OnGenerateDocClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
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



        protected virtual void OnCloseIssueClick(object sender, EventArgs e)
        {

        }

        protected virtual void LoadLeftTree()
        {

        }


    }
}
