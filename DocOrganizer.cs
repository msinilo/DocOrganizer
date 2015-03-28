using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.Win32;

namespace DocOrganizer
{
    public partial class DocOrganizer : Form
    {
        const string kTreeFileName = "tree.xml";
        const string kConfigFileName = "config.xml";

        public DocOrganizer()
        {
            InitializeComponent();

            LoadConfig(kConfigFileName);

            if (!LoadTree(kTreeFileName))
                InitTree();

            Dictionary<string, string> fileIconMap = ExtractFileIcons(m_config.Extensions);
            AddIconsToImageList(fileIconMap);
            BuildTreeView();
        }

        void BuildTreeView()
        {
            BuildTreeView("");
        }
        void InitTree()
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    TreeElement te = new TreeElement(drive.RootDirectory.Name, drive.RootDirectory.Name,
                        TreeElement.EType.DIRECTORY);
                    m_tree.Add(te);
                }
            }
        }

        public TreeElement RescanSubtree(string path, string fullPath, TreeElement originalElement)
        {
            TreeElement te = new TreeElement(path, fullPath, TreeElement.EType.DIRECTORY);
            try
            {
                foreach (string ext in m_config.Extensions)
                {
                    string[] files = Directory.GetFiles(fullPath, ext);
                    foreach (string f in files)
                    {
                        FileInfo fi = new FileInfo(f);
                        TreeElement fileChild = new TreeElement(fi.Name, fi.FullName, TreeElement.EType.DOCUMENT);
                        te.AddChild(fileChild);
                    }
                }
                DirectoryInfo di = new DirectoryInfo(fullPath);
                DirectoryInfo[] subDirs = di.GetDirectories("*");
                foreach (DirectoryInfo subDir in subDirs)
                {
                    TreeElement originalChild = (originalElement == null ? null : originalElement.FindChildByName(subDir.Name));
                    TreeElement child = RescanSubtree(subDir.Name, subDir.FullName, originalChild);
                    if (child.HasAnyDocuments())
                        te.AddChild(child);
                }
            }
            catch { }

            if (originalElement != null)
            {
                foreach (TreeElement child in te.Children)
                {
                    TreeElement originalChild = originalElement.FindChildByName(child.Name);
                    if (originalChild != null)
                        child.Tags = originalChild.Tags;
                }
            }
            return te;
        }
        // @@ TODO: Clean this... Lots of code duplication between RescanDir & RescanSubtree.
        public void RescanDirectory(TreeElement element)
        {
            //element.ClearAllChildren();
            try
            {
                DirectoryInfo di = new DirectoryInfo(element.FullPath);
                DirectoryInfo[] subDirs = di.GetDirectories("*");
                List<TreeElement> children = new List<TreeElement>();

                foreach (string ext in m_config.Extensions)
                {
                    string[] files = Directory.GetFiles(element.FullPath, ext);
                    foreach (string f in files)
                    {
                        FileInfo fi = new FileInfo(f);
                        TreeElement fileChild = new TreeElement(fi.Name, fi.FullName, TreeElement.EType.DOCUMENT);
                        children.Add(fileChild);
                    }
                }

                foreach (DirectoryInfo subDir in subDirs)
                {
                    TreeElement originalChild = element.FindChildByName(subDir.Name);
                    TreeElement child = RescanSubtree(subDir.Name, subDir.FullName, originalChild);
                    if (child.HasAnyDocuments())
                    {
                        children.Add(child);
                    }
                }
                foreach (TreeElement child in children)
                {
                    TreeElement originalChild = element.FindChildByName(child.Name);
                    if (originalChild != null)
                        child.Tags = originalChild.Tags;
                }
                element.Children = children;
            }
            catch { }
        }

        private void rescanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode rootNode = treeMain.SelectedNode;
            rootNode.Nodes.Clear();

            TreeElement element = rootNode.Tag as TreeElement;
            RescanDirectory(element);
            BuildTreeView();
        }

        bool LoadTree(string fileName)
        {
            XmlSerializer s = new XmlSerializer(m_tree.GetType());
            bool success = true;
            try
            {
                TextReader r = new StreamReader(fileName);
                m_tree = (List<TreeElement>)s.Deserialize(r);
                r.Close();
            }
            catch (System.IO.FileNotFoundException)
            {
                success = false;
            }
            return success;
        }
        void SaveTree(string fileName)
        {
            XmlSerializer s = new XmlSerializer(m_tree.GetType());
            TextWriter w = new StreamWriter(fileName, false);
            s.Serialize(w, m_tree);
            w.Close();
        }

        [Serializable]
        public class TreeElement
        {
            public enum EType
            {
                DIRECTORY,
                DOCUMENT
            };

            public TreeElement() { }
            public TreeElement(string name, string fullPath, EType type)
            {
                m_tags.Add(name);
                m_fullPath = fullPath;
                m_type = type;
            }
            public void AddChild(TreeElement e)
            {
                m_children.Add(e);
            }
            public void ClearAllChildren()
            {
                m_children.Clear();
            }

            public EType ElementType
            {
                get { return m_type; }
                set { m_type = value; }
            }
            public string Name
            {
                get { return m_tags[0]; }
            }
            public string FullPath
            {
                get { return m_fullPath; }
                set { m_fullPath = value; }
            }
            public bool IsDocument
            {
                get { return m_type == EType.DOCUMENT; }
            }
            public List<TreeElement> Children
            {
                get { return m_children; }
                set { m_children = value; }
            }
            public List<string> Tags
            {
                get { return m_tags; }
                set { m_tags = value; }
            }
            public string BuildTagList()
            {
                string tagList = "";
                for (int i = 0; i < m_tags.Count; ++i)
                {
                    tagList += m_tags[i];
                    if (i != m_tags.Count - 1)
                        tagList += ", ";
                }
                return tagList;
            }
            public bool HasTag(string tag)
            {
                return m_tags.IndexOf(tag) >= 0;
            }
            public bool MatchTag(string tag)
            {
                if (string.IsNullOrEmpty(tag))
                    return true;
                foreach (string myTag in m_tags)
                {
                    if (myTag.IndexOf(tag) >= 0)
                        return true;
                }
                return false;
            }
            public void TagSubtree(string tag)
            {
                foreach (TreeElement child in m_children)
                {
                    if (child.IsDocument && !child.HasTag(tag))
                    {
                        child.m_tags.Add(tag);
                    }
                    else if (!child.IsDocument)
                        child.TagSubtree(tag);
                }
                if (IsDocument)
                    m_tags.Add(tag);
            }
            public bool SubtreeMatchesTag(string tag)
            {
                if (MatchTag(tag) && IsDocument)
                    return true;
                foreach (TreeElement child in m_children)
                {
                    if (child.SubtreeMatchesTag(tag))
                        return true;
                }
                return string.IsNullOrEmpty(tag);
            }
            public bool HasAnyDocuments()
            {
                if (IsDocument)
                    return true;
                foreach (TreeElement child in m_children)
                {
                    if (child.IsDocument || child.HasAnyDocuments())
                        return true;
                }
                return false;
            }
            public TreeElement FindChildByName(string name)
            {
                foreach (TreeElement child in m_children)
                {
                    if (child.Name == name)
                        return child;
                }
                return null;
            }

            EType m_type = EType.DIRECTORY;
            List<string> m_tags = new List<string>();
            List<TreeElement> m_children = new List<TreeElement>();
            string m_fullPath = "";
        };

        Dictionary<string, string> ExtractFileIcons(List<string> extensions)
        {
            Dictionary<string, string> fileIconMap = new Dictionary<string, string>();
            try
            {
                RegistryKey rkRoot = Registry.ClassesRoot;
                foreach (string keyName in rkRoot.GetSubKeyNames())
                {
                    if (string.IsNullOrEmpty(keyName) || keyName.IndexOf(".") != 0)
                        continue;

                    string fullKeyName = "*" + keyName;
                    if (extensions.IndexOf(fullKeyName) < 0)
                        continue;

                    RegistryKey rkFileType = rkRoot.OpenSubKey(keyName);
                    if (rkFileType == null)
                        continue;
                    object defaultValue = rkFileType.GetValue("");
                    if (defaultValue == null)
                        continue;
                    string defaultIcon = defaultValue.ToString() + "\\DefaultIcon";
                    RegistryKey rkIcon = rkRoot.OpenSubKey(defaultIcon);
                    if (rkIcon != null)
                    {
                        object value = rkIcon.GetValue("");
                        if (value != null)
                        {
                            string iconPath = value.ToString().Replace("\"", "");
                            fileIconMap.Add(fullKeyName, iconPath);
                        }
                        rkIcon.Close();
                    }
                    rkFileType.Close();
                }
                rkRoot.Close();
            }
            catch (Exception exc)
            { 
                throw exc;
            }
            return fileIconMap;
        }
        void AddIconsToImageList(Dictionary<string, string> fileIconMap)
        {
            try
            {
                foreach (KeyValuePair<string, string> entry in fileIconMap)
                {
                    string iconPath = entry.Value;
                    string fileName = "";
                    int commaIndex = iconPath.IndexOf(",");
                    string iconIndexString = "";
                    if (commaIndex > 0)
                    {
                        fileName = iconPath.Substring(0, commaIndex);
                        iconIndexString = iconPath.Substring(commaIndex + 1);
                    }
                    else
                        fileName = iconPath;

                    int iconIndex = 0;
                    if (!string.IsNullOrEmpty(iconIndexString))
                    {
                        iconIndex = int.Parse(iconIndexString);
                        if (iconIndex < 0)
                            iconIndex = 0;
                    }
                    IntPtr hIcon = RegisteredFileType.ExtractIcon(Handle.ToInt32(), fileName, iconIndex);
                    if (hIcon != IntPtr.Zero)
                    {
                        Icon icon = Icon.FromHandle(hIcon);
                        iconsList.Images.Add(icon.ToBitmap());
                        m_iconIndexForExtension.Add(entry.Key, iconsList.Images.Count - 1);
                    }
                }
            }
            catch { }
        }

        void UpdateFileDetails(TreeElement e)
        {
            lName.Text = "Name: " + e.Name;
            FileInfo fi = new FileInfo(e.FullPath);
            lSize.Text = "Size: " + ((float)fi.Length / 1024.0f).ToString() + "k";
            lLastModified.Text = "Last Modified: " + fi.LastWriteTime.ToString();
            lTags.Text = "Tags: " + e.BuildTagList();
        }
        void ClearFileDetails()
        {
            lName.Text = "Name: ";
            lSize.Text = "Size: ";
            lLastModified.Text = "Last Modified: ";
            lTags.Text = "Tags: ";
        }

        List<TreeElement> m_tree = new List<TreeElement>();
        Dictionary<string, int> m_iconIndexForExtension = new Dictionary<string, int>();

        public class Config
        {
            public List<string> Extensions
            {
                get { return m_extensions; }
                set { m_extensions = value; }
            }
            public List<string> ExcludedDirs
            {
                get { return m_excludedDirs; }
            }

            public void InitExtensions()
            {
                m_extensions.Add("*.pdf");
                m_extensions.Add("*.ppt");
            }
            public bool IsDirExcluded(string dir)
            {
                return m_excludedDirs.IndexOf(dir) >= 0;
            }
            public void AddExcludedDir(string dir)
            {
                m_excludedDirs.Add(dir);
            }

            List<string> m_extensions = new List<string>();
            List<string> m_excludedDirs = new List<string>();
        };
        Config m_config = new Config();

        private void tagSubtreeWithDirNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeElement te = treeMain.SelectedNode.Tag as TreeElement;
            if (te != null)
            {
                te.TagSubtree(te.Name);
            }
        }

        void BuildTreeView(string tagString)
        {
            string[] tags = tagString.Split(',');
            for (int i = 0; i < tags.Length; ++i)
                tags[i] = tags[i].Trim();

            treeMain.Nodes.Clear();
            foreach (TreeElement e in m_tree)
            {
                BuildTreeView(treeMain.Nodes, e, tags);
            }
        }
        void BuildTreeView(TreeNodeCollection nodes, TreeElement e, string[] tags)
        {
            if (IsDirExcluded(e.FullPath))
                return;

            bool hasAnyTag = false;
            foreach (string tag in tags)
            {
                if (e.SubtreeMatchesTag(tag))
                {
                    hasAnyTag = true;
                    break;
                }
            }
            if (!hasAnyTag)
                return;

            nodes.Add(e.Name);
            nodes[nodes.Count - 1].Tag = e;
            if (e.ElementType == TreeElement.EType.DOCUMENT)
            {
                int imageIndex = GetIconIndex(e.Name);
                nodes[nodes.Count - 1].ImageIndex = imageIndex;
                nodes[nodes.Count - 1].SelectedImageIndex = imageIndex;
            }

            foreach (TreeElement child in e.Children)
                BuildTreeView(nodes[nodes.Count - 1].Nodes, child, tags);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            m_filterDirty = true;
            timer1.Start();
        }

        private void treeMain_Leave(object sender, EventArgs e)
        {
            ClearFileDetails();
        }

        private void tagSubtreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TagDialog dlg = new TagDialog();
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                TreeElement te = treeMain.SelectedNode.Tag as TreeElement;
                if (te != null)
                {
                    te.TagSubtree(dlg.TagText);
                }
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsDialog dlg = new OptionsDialog(m_config.Extensions);
            dlg.ShowDialog(this);
            m_config.Extensions = dlg.GetExtensions();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void SaveConfig(string fileName)
        {
            XmlSerializer s = new XmlSerializer(m_config.GetType());
            TextWriter w = new StreamWriter(fileName, false);
            s.Serialize(w, m_config);
            w.Close();
        }
        bool LoadConfig(string fileName)
        {
            XmlSerializer s = new XmlSerializer(m_config.GetType());
            bool success = true;
            try
            {
                TextReader r = new StreamReader(fileName);
                m_config = (Config)s.Deserialize(r);
                r.Close();
            }
            catch
            {
                success = false;
            }
            if (m_config.Extensions.Count == 0)
                m_config.InitExtensions();
            return success;
        }
            
        bool IsDirExcluded(string dir)
        {
            return m_config.IsDirExcluded(dir);
        }
      
        private void excludeSubtreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeElement te = treeMain.SelectedNode.Tag as TreeElement;
            string dir = te.FullPath;
            if (!IsDirExcluded(dir))
            {
                m_config.AddExcludedDir(dir);
            }
        }
        int GetIconIndex(string name)
        {
            int index = 0;
            string ext = "*" + Path.GetExtension(name);
            m_iconIndexForExtension.TryGetValue(ext, out index);
            return index; 
        }

        private void bExpandAll_Click(object sender, EventArgs e)
        {
            if (treeMain.SelectedNode != null)
                treeMain.SelectedNode.ExpandAll();
            else
                treeMain.ExpandAll();
        }

        private void treeMain_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                TreeElement te = e.Node.Tag as TreeElement;
                string fileName = te.FullPath;
                System.Diagnostics.Process.Start(fileName);
            }
        }

        private void DocOrganizer_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTree(kTreeFileName);
            SaveConfig(kConfigFileName);
        }

        private void treeMain_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            TreeElement te = treeMain.SelectedNode.Tag as TreeElement;
            if (te != null && te.IsDocument)
                UpdateFileDetails(te);
            else
                ClearFileDetails();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (m_filterDirty)
            {
                treeMain.Nodes.Clear();
                BuildTreeView(textFilter.Text);
                treeMain.ExpandAll();
                timer1.Stop();
                m_filterDirty = false;
            }
        }

        bool m_filterDirty = false;
    }
}
