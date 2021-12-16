using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace FileConverter
{
    public partial class TreeForm : Form
    {
        const string DELETED_STRING = "============================";
        Color DELETED_COLOR = Color.FromArgb(210, 50, 50);

        SearchDialog searchDialog;
        ContextMenuStrip menu;
        List<string> expandedNodeIds = new List<string>();
        List<TreeNode> searchNodes = new List<TreeNode>();
        TreeNode selectedNode;

        string path = "";
        bool showHidden = false;
        bool showPopup = false;
        int indexOfSearchResults = 0;
        int indexStartingPoint = 0;

        public TreeForm()
        {
            InitializeComponent();

            string pathWithEnv = @"%USERPROFILE%\Desktop\Wordpads\Legend.txt";
            path = Environment.ExpandEnvironmentVariables(pathWithEnv);

            InitializeSearchDialog();
            InitializeMenuItems();
            ReadFile();
        }
        private void InitializeSearchDialog()
        {
            searchDialog = new SearchDialog();
            searchDialog.SearchTextChanged += (sender, e) =>
            {
                searchNodes.Clear();
                SearchTree(treeView1.Nodes, searchDialog.SearchText, searchDialog.MatchCase);
                if (searchNodes == null || searchNodes.Count <= 0)
                {
                    MessageBox.Show("No results found for \"" + searchDialog.SearchText + "\".");
                    return;
                }


                if (indexOfSearchResults >= searchNodes.Count)
                    indexOfSearchResults = 0;
                else if (indexOfSearchResults < 0)
                    indexOfSearchResults = searchNodes.Count - 1;
                if (searchDialog.isNewSearch)
                {
                    indexStartingPoint = indexOfSearchResults;
                    showPopup = false;
                }

                switch (searchDialog.searchType)
                {
                    case SearchDialog.SearchType.Normal:
                    case SearchDialog.SearchType.Next:
                        if (searchNodes.Count <= 0) return;

                        searchNodes[indexOfSearchResults].Expand();
                        treeView1.SelectedNode = searchNodes[indexOfSearchResults];

                        if (indexOfSearchResults == indexStartingPoint)
                        {
                            if (showPopup)
                                MessageBox.Show("Reached starting point of the search.");
                            else
                                showPopup = true;
                        }
                        indexOfSearchResults++;
                        break;
                    case SearchDialog.SearchType.Previous:
                        if (searchNodes.Count <= 0) return;

                        searchNodes[indexOfSearchResults].Expand();
                        treeView1.SelectedNode = searchNodes[indexOfSearchResults];

                        if (indexOfSearchResults == indexStartingPoint)
                        {
                            if (showPopup)
                                MessageBox.Show("Reached starting point of the search.");
                            else
                                showPopup = true;
                        }
                        indexOfSearchResults--;
                        break;
                    default:
                        break;
                }
            };
        }
        private void InitializeMenuItems()
        {
            menu = new ContextMenuStrip();
            menu.Items.Add("Find..").Click += (sender, e) => ShowSearchDialog();
            menu.Items.Add("Show Deleted").Click += (sender, e) =>
            {
                if (showHidden)
                {
                    showHidden = false;
                    GetToolStripOfName("Hide Deleted").Text = "Show Deleted";
                }
                else
                {
                    showHidden = true;
                    GetToolStripOfName("Show Deleted").Text = "Hide Deleted";
                }
                ReadFile();
            };
            menu.Items.Add("-");
            menu.Items.Add("Refresh").Click += (sender, e) => ReadFile();
            menu.Items.Add("Expand all").Click += (sender, e) => treeView1.ExpandAll();
            menu.Items.Add("Collapse all").Click += (sender, e) => treeView1.CollapseAll();
            menu.Items.Add("-");
            menu.Items.Add("Delete").Click += (sender, e) =>
            {
                if (treeView1.SelectedNode == null) return;
                var text = "";
                using (var reader = new StreamReader(path))
                {
                    var line = "";
                    var index = -1;
                    var isTriggered = false;

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (isTriggered)
                        {
                            if (GetIndentationLevel(line) - index <= 0)
                            {
                                index = -1;
                                isTriggered = false;
                            }
                            else
                            {
                                line += DELETED_STRING;
                            }
                        }

                        if (line.TrimStart(new char[] { ' ' }) == treeView1.SelectedNode.Text)
                        {
                            line += DELETED_STRING;
                            isTriggered = true;
                            index = GetIndentationLevel(line);
                        }
                        text += Environment.NewLine + line;
                    }
                    text = text.Trim();
                }

                using (var writer = new StreamWriter(path))
                {
                    writer.Write(text);
                }

                ReadFile();
            };

            treeView1.ContextMenuStrip = menu;
        }

        private int GetIndentationLevel(string line)
        {
            int index = -1;
            var characters = line.ToCharArray();

            for (var x = 0; x < characters.Length; x++)
            {
                if (characters[x] != ' ')
                    break;
                else
                    index = x;
            }
            return index;
        }

        private void ReadFile()
        {
            var ParentNode = new TreeNode();
            
            using (var reader = new StreamReader(path))
            {
                var line = "";
                var index = -1;

                while ((line = reader.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    if (line.EndsWith(DELETED_STRING))
                    {
                        if (!showHidden)
                            continue;
                    }
                    
                    index = GetIndentationLevel(line);
                    
                    if (index == -1)
                    {
                        var i = line.IndexOf(DELETED_STRING);
                        if (i == -1)
                            ParentNode.Nodes.Add(line);
                        else
                            ParentNode.Nodes.Add(line.Remove(i)).ForeColor = DELETED_COLOR;
                    }
                    else
                    {
                        var node = ParentNode;
                        for (int x = 0; x < index + 1; x++)
                        {
                            node = GetChildNodes(node);
                        }
                        var i = line.IndexOf(DELETED_STRING);
                        if (i == -1)
                            node.Nodes.Add(line.Remove(0, index + 1));
                        else
                            node.Nodes.Add(line.Remove(i).Remove(0, index + 1)).ForeColor = DELETED_COLOR;
                    }
                }
                
            }

            expandedNodeIds.Clear();
            CollectExpandedNodes(treeView1.Nodes);
            selectedNode = treeView1.SelectedNode;

            treeView1.Nodes.Clear();
            foreach (TreeNode node in ParentNode.Nodes)
            {
                treeView1.Nodes.Add(node);
            }
            
            ExpandCollectedNodes(treeView1.Nodes);
            ScrollToSelectedNode(treeView1.Nodes);
        }

        private TreeNode GetChildNodes(TreeNode node)
        {
            if (node == null || node.Nodes.Count <= 0) return null;
            return node.Nodes[node.Nodes.Count - 1];
        }
        
        private void CollectExpandedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                if (node.IsExpanded) expandedNodeIds.Add(node.FullPath);
                if (node.Nodes.Count > 0) CollectExpandedNodes(node.Nodes);
            }
        }

        private void ExpandCollectedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                foreach (var item in expandedNodeIds)
                {
                    if (node.FullPath == item)
                    {
                        node.Expand();
                    }
                }
                if (node.Nodes.Count > 0) ExpandCollectedNodes(node.Nodes);
            }
        }
        
        private void ScrollToSelectedNode(TreeNodeCollection nodes)
        {
            if (selectedNode == null) return;

            foreach (TreeNode item in nodes)
            {
                if (item.Text == selectedNode.Text)
                {
                    item.EnsureVisible();
                    treeView1.SelectedNode = item;
                    break;
                }
                if (item.Nodes.Count > 0) ScrollToSelectedNode(item.Nodes);
            }
             
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                treeView1.SelectedNode = treeView1.GetNodeAt(e.Location);
            }
        }
        
        private void TreeForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.F))
            {
                ShowSearchDialog();
                e.Handled = e.SuppressKeyPress = true;
            }
            else if (e.KeyData == Keys.Escape)
            {
                searchDialog.Hide();
                e.Handled = e.SuppressKeyPress = true;
            }
            else if (e.KeyData == Keys.Enter ||
                e.KeyData == Keys.Return)
            {
                if (treeView1.SelectedNode.IsExpanded)
                    treeView1.SelectedNode.Collapse();
                else
                    treeView1.SelectedNode.Expand();
                e.Handled = e.SuppressKeyPress = true;
            }
            else if (e.KeyData == Keys.Delete)
            {
                if (MessageBox.Show("Delete " + treeView1.SelectedNode.Text + "?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    GetToolStripOfName("Delete").PerformClick();
            }
            
        }
        
        private void SearchTree(TreeNodeCollection nodes, string filter, bool matchCase)
        {
            foreach (TreeNode node in nodes)
            {
                if (matchCase)
                {
                    if (node.Text.Contains(filter))
                        searchNodes.Add(node);
                }
                else
                {
                    if (node.Text.ToLower().Contains(filter.ToLower()))
                        searchNodes.Add(node);
                }
                if (node.Nodes.Count > 0) SearchTree(node.Nodes, filter, matchCase);
            }
        }

        private void ShowSearchDialog()
        {
            if (!searchDialog.ContainsFocus)
            {
                searchDialog.Show();
                searchDialog.Focus();
            }
        }

        private ToolStripItem GetToolStripOfName(string name)
        {
            foreach (ToolStripItem item in menu.Items)
                if (item.Text == name)
                {
                    return item;
                }
            return null;
        }
    }
}