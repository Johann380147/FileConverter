using System;
using System.Drawing;
using System.Windows.Forms;

namespace FileConverter
{
    public partial class SearchDialog : Form
    {
        public delegate void TextChangedEventHandler(object sender, EventArgs e);
        public event TextChangedEventHandler SearchTextChanged;

        public enum SearchType { Normal, Next, Previous }
        private string searchText;
        private string oldSearchText;

        public bool isNewSearch { get; set; }
        public SearchType searchType { get; set; }
        public bool MatchCase { get; set; }
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                if (searchText != oldSearchText)
                {
                    isNewSearch = true;
                    oldSearchText = searchText;
                }
                else
                {
                    isNewSearch = false;
                }
                OnSearchTextChanged(EventArgs.Empty);
            }
        }

        public SearchDialog()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            TreeForm treeForm;

            foreach(var form in Application.OpenForms)
            {
                try
                {
                    treeForm = (TreeForm)form;
                    var location = treeForm.Location;
                    this.Location = new Point(treeForm.Location.X + treeForm.Width / 2, location.Y + 30);
                    break;
                }
                catch (InvalidCastException)
                {

                    continue;
                }
            }
            
        }

        protected virtual void OnSearchTextChanged(EventArgs e)
        {
            if (SearchTextChanged != null)
            {
                SearchTextChanged(this, e);
            }
        }
        
        private void SearchDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
                e.Handled = e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Enter ||
                e.KeyCode == Keys.Return)
            {
                SearchText = txtSearch.Text;
                e.Handled = e.SuppressKeyPress = true;
            }

            
        }

        private void SearchDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void chkMatchCase_CheckedChanged(object sender, EventArgs e)
        {
            MatchCase = chkMatchCase.CheckState == CheckState.Checked ? true : false;
        }

        private void btnSearchPrevious_Click(object sender, EventArgs e)
        {
            searchType = SearchType.Previous;
            SearchText = txtSearch.Text;
        }

        private void btnSearchNext_Click(object sender, EventArgs e)
        {
            searchType = SearchType.Next;
            SearchText = txtSearch.Text;
        }

        private void btnSearchNormal_Click(object sender, EventArgs e)
        {
            searchType = SearchType.Normal;
            SearchText = txtSearch.Text;
        }
    }
}
