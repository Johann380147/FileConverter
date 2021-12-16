using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BrightIdeasSoftware;
using System.Runtime.InteropServices;

namespace FileConverter
{
    public partial class MainForm : Form
    {
        ToolTip tooltip = new ToolTip();
        ContextMenuStrip contextmenu = new ContextMenuStrip();
        TextMatchFilter filter;
        HighlightTextRenderer renderer = new HighlightTextRenderer();
        List<string> filterList = new List<string>();

        List<Account> lstAccounts = new List<Account>();
        string currentCategory = String.Empty;
        bool isLocal = false;
        public string Path { get; set; }
        
        public MainForm(string path, bool isLocal)
        {
            InitializeComponent();
            InitializeStyles();

            this.isLocal = isLocal;
            SwapDrives.Text = this.isLocal ? "External" : "Local";
            Path = path;
            filter = new TextMatchFilter(this.lstFileAccounts);
            
            elementHost1.Child.KeyUp += SearchTextBox_KeyUp;
            
            RefreshList();
        }

        private void lstFileAccounts_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect == DragDropEffects.Copy ||
               e.Effect == DragDropEffects.Move)
            {
                lstAccounts.Clear();
                var items = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (items.Length == 0) return;

                foreach (var item in items)
                {
                    Path = item;
                    using (var reader = new StreamReader(item))
                    {
                        string line;
                        
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (IsEscapeCharacter(line)) continue;

                            if (line.StartsWith(">"))
                            {
                                AddAccountOfCategory(line, reader); //returns when line is empty or null
                                continue;
                            }

                            AddExtraAccountsOfCategory(line, reader);
                        }
                    }
                }
            }
            lstFileAccounts.Items.Clear();
            lstFileAccounts.SetObjects(lstAccounts);
        }

        private void lstFileAccounts_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Move;
        }

        private void AddAccountOfCategory(string category, StreamReader reader)
        {
            int index = 1;
            string line;
            Account account = new Account();
            account.Category = currentCategory = category.Remove(0, 1);
            
            lstAccounts.Add(account);

            while ((line = reader.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(line) || IsEscapeCharacter(line)) return;

                if (line.StartsWith(">"))
                {
                    AddAccountOfCategory(line, reader);
                    return;
                }

                if (index == 1)
                    account.Username = line;
                else if (index == 2)
                    account.Password = line;
                else
                    account.Extras += " " + line;
                index++;
            }
        }

        private void AddExtraAccountsOfCategory(string line, StreamReader reader)
        {
            Account account;
            int index = 1;

            if (line.StartsWith(">"))
            {
                AddAccountOfCategory(line, reader);
                return;
            }
            else if (!string.IsNullOrWhiteSpace(line))
            {
                index = 2;
                account = new Account();
                lstAccounts.Add(account);
                account.Category = currentCategory;
                account.Username = line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line) || IsEscapeCharacter(line)) return;

                    if (index == 2)
                        account.Password = line;
                    else
                        account.Extras += " " + line;
                    index++;
                }
            }
        }

        private bool IsEscapeCharacter(string line)
        {
            bool flag = true;
            if (line.StartsWith("-"))
                return true;
            for (var i = 0; i < line.Length; i++)
            {
                if (line.Substring(i, 1) != "_")
                {
                    flag = false;
                }
            }
            return flag;
        }
        
        private void lstFileAccounts_MouseUp(object sender, MouseEventArgs e)
        {
            if (lstFileAccounts.SelectedItem == null) return;

            CopyToClipboard(DetermineColumnAtPoint(PointToScreen(e.Location)), e.Location);
            
        }

        private void CopyToClipboard(int i, Point point)
        {
            if (i == -1) return;
            string text;
            text = lstFileAccounts.SelectedItem.GetSubItem(i).Text;
            if (text != null && !string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    Clipboard.SetText(text);
                }
                catch (ExternalException)
                {
                    tooltip.Show("Did not copy text", this.lstFileAccounts, point.X, point.Y - 20, 1000);
                }
            }
        }

        private int DetermineColumnAtPoint(Point point)
        {
            int baseLocation = this.Location.X;
            if (point.X >= baseLocation &&
                point.X < baseLocation + Category.Width)
                return 0;
            else if (point.X >= baseLocation &&
                point.X < baseLocation + Category.Width * 2)
                return 1;
            else if (point.X >= baseLocation &&
                point.X < baseLocation + Category.Width * 3)
                return 2;
            else if (point.X >= baseLocation &&
                point.X < baseLocation + Category.Width * 4)
                return 3;
            return -1;
        }

        private void SearchTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var control = (RoundedTextBox)elementHost1.Child;
            var searchText = control.txtSearch.Text;
            if (filterList.Count > 0)
                filterList[0] = searchText;
            else
                filterList.Add(searchText);

            filter.ContainsStrings = filterList;
            this.lstFileAccounts.ModelFilter = filter;
            renderer.Filter = filter;
            lstFileAccounts.DefaultRenderer = renderer;


            lblFilter.Text = string.IsNullOrWhiteSpace(searchText) ? searchText : searchText + "  X";

            if (!string.IsNullOrWhiteSpace(searchText))
            {
                btnClearSearch.Visible = true;
            }

            if (e.Key == System.Windows.Input.Key.Back ||
                e.Key == System.Windows.Input.Key.Return ||
                e.Key == System.Windows.Input.Key.Delete)
            {
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    btnClearSearch.Visible = false;
                }
            }
        }

        private void InitializeStyles()
        {
            TextOverlay textOverlay = this.lstFileAccounts.EmptyListMsgOverlay as TextOverlay;
            textOverlay.TextColor = Color.Firebrick;
            textOverlay.BackColor = Color.AntiqueWhite;
            textOverlay.BorderColor = Color.DarkRed;
            textOverlay.BorderWidth = 4.0f;
            textOverlay.Font = new Font("Chiller", 36);
            textOverlay.Rotation = -5;

            HeaderFormatStyle h = new HeaderFormatStyle();
            h.Normal.BackColor = Color.FromArgb(200, 0, 0, 0);
            h.Normal.ForeColor = Color.FromArgb(255, 200, 200, 200);
            h.Hot.BackColor = Color.FromArgb(160, 0, 0, 0);
            h.Hot.ForeColor = Color.FromArgb(255, 255, 255, 255);
            h.Pressed.BackColor = Color.FromArgb(200, 0, 0, 0);
            h.Pressed.ForeColor = Color.FromArgb(255, 200, 200, 200);
            lstFileAccounts.HeaderFormatStyle = h;

            lstFileAccounts.AlternateRowBackColor = ColorTranslator.FromHtml("#F5F5C9");

            renderer.FillBrush = new SolidBrush(Color.FromArgb(50, 0, 0, 255));
            renderer.FramePen = Pens.Blue;
        }
        
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            var control = (RoundedTextBox)elementHost1.Child;
            control.txtSearch.Clear();
            btnClearSearch.Visible = false;
            if (filterList.Count > 0)
                filterList[0] = "";
            else
                filterList.Add("");

            filter.ContainsStrings = filterList;
            this.lstFileAccounts.ModelFilter = filter;
            renderer.Filter = filter;
            lstFileAccounts.DefaultRenderer = renderer;
            lblFilter.Text = String.Empty;
        }

        bool cycleDialog = true;
        private void AddAccount_Click(object sender, EventArgs e)
        {
            var result = DialogResult.Yes;
            while (result == DialogResult.Yes)
            {
                if (cycleDialog)
                {
                    var dialog = new AddAccountDialog(this);
                    result = dialog.ShowDialog();
                }
                else
                {
                    var dialog = new RawEditDialog(this);
                    result = dialog.ShowDialog();
                }
                if (result == DialogResult.OK)
                    RefreshList();
                else if (result == DialogResult.Yes)
                    cycleDialog = !cycleDialog;
                else if (result == DialogResult.Cancel)
                    cycleDialog = true;
            }
        }

        private void RefreshList()
        {
            if (!File.Exists(Path))
            {
                lstFileAccounts.EmptyListMsg = "Drag a file here";
                AddAccount.Enabled = false;
                lstFileAccounts.Items.Clear();
                return;
            }
            else
            {
                var msg = string.IsNullOrWhiteSpace(lblFilter.Text) ? "" : lblFilter.Text.Remove(lblFilter.Text.Length - 3, 3);
                lstFileAccounts.EmptyListMsg = $"\"{msg}\" was not found";
                AddAccount.Enabled = true;
            }

            lstAccounts.Clear();

            using (var reader = new StreamReader(Path))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    if (IsEscapeCharacter(line)) continue;

                    if (line.StartsWith(">"))
                    {
                        AddAccountOfCategory(line, reader); //returns when line is empty or null
                        continue;
                    }

                    AddExtraAccountsOfCategory(line, reader);
                }
            }
            
            lstFileAccounts.Items.Clear();
            lstFileAccounts.SetObjects(lstAccounts);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var control = (RoundedTextBox)elementHost1.Child;
            control.txtSearch.Focus();
        }

        private void lblFilter_TextChanged(object sender, EventArgs e)
        {
            var msg = string.IsNullOrWhiteSpace(lblFilter.Text) ? "" : lblFilter.Text.Remove(lblFilter.Text.Length - 3, 3);
            if (File.Exists(Path))
                lstFileAccounts.EmptyListMsg = $"\"{msg}\" was not found";
            else
                lstFileAccounts.EmptyListMsg = "Drag a file here";

            if (string.IsNullOrWhiteSpace(lblFilter.Text))
                lblFilter.BorderStyle = BorderStyle.None;
            else
                lblFilter.BorderStyle = BorderStyle.FixedSingle;
        }

        private void RefreshAccount_Click(object sender, EventArgs e)
        {
            RefreshList();
        }
        
        private void SwapDrives_Click(object sender, EventArgs e)
        {
            if (isLocal)
            {
                SwapDrives.Text = "Local";
                Path = Utility.GetExternalPath();
                RefreshList();
            }
            else
            {
                SwapDrives.Text = "External";
                Path = Utility.GetLocalPath();
                RefreshList();
            }
            isLocal = !isLocal;
        }
       
    }
}
