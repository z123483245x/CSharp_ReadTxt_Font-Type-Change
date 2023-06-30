using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharp_test2
{
    public partial class Form1 : Form
    {
        private Panel removePanel;
        private Label fontChoiceLabel;
        private Label fontAddLabel;
        private TextBox outputTextBox;
        private Label fontRemoveLabel;
        private ComboBox fontChoiceComboBox;
        private TextBox fontAddTextBox;
        private TextBox fontRemoveTextBox;
        private Button fontColorButton;
        private Button confirmButton;
        private Button importTxtButton;
        private NumericUpDown updown;
        private LinkLabel linkLabel;

        public Form1()
        {
            InitializeComponent();
            this.Text = "CSharp_test2";
            this.Size = new Size(600,500);
            this.StartPosition = FormStartPosition.CenterScreen;

            outputTextBox = new TextBox();
            outputTextBox.Text = "白色區域";
            outputTextBox.Font = new Font(TextBox.DefaultFont.FontFamily, 30);
            outputTextBox.Multiline = true;
            outputTextBox.ScrollBars = ScrollBars.Vertical;
            outputTextBox.Size = new Size(600,260);
            outputTextBox.Location = new Point(0,200);
            outputTextBox.BackColor = Color.White;
            outputTextBox.BorderStyle = BorderStyle.FixedSingle;
            outputTextBox.ReadOnly = true;
            outputTextBox.TextAlign = HorizontalAlignment.Left;
            
            this.Controls.Add(outputTextBox);

            importTxtButton = new Button();
            importTxtButton.Text = "匯入Txt文字檔";
            importTxtButton.Font = new Font(TextBox.DefaultFont.FontFamily, 13);
            importTxtButton.Size = new Size(140,60);
            importTxtButton.Location = new Point(60, 50);
            importTxtButton.Click += importTxtButton_Click;
            this.Controls.Add(importTxtButton);

            fontChoiceLabel = new Label();
            fontChoiceLabel.Text = "選擇字體:";
            fontChoiceLabel.AutoSize = true;
            fontChoiceLabel.Font = new Font(TextBox.DefaultFont.FontFamily, 10);
            fontChoiceLabel.Location = new Point(260, 30);
            this.Controls.Add(fontChoiceLabel);

            fontAddLabel = new Label();
            fontAddLabel.Text = "新增字體:";
            fontAddLabel.AutoSize = true;
            fontAddLabel.Font = new Font(TextBox.DefaultFont.FontFamily, 10);
            fontAddLabel.Location = new Point(260, 90);
            this.Controls.Add(fontAddLabel);

            fontRemoveLabel = new Label();
            fontRemoveLabel.Text = "請選擇欲刪除字體的順序:";
            fontRemoveLabel.AutoSize = true;
            fontRemoveLabel.Font = new Font(TextBox.DefaultFont.FontFamily, 10);
            fontRemoveLabel.Location = new Point(162, 150);
            this.Controls.Add(fontRemoveLabel);

            fontChoiceComboBox = new ComboBox();
            fontChoiceComboBox.Font = new Font(TextBox.DefaultFont.FontFamily, 10);
            fontChoiceComboBox.Size = new Size(140, 30);
            fontChoiceComboBox.BackColor = Color.White;
            fontChoiceComboBox.Location = new Point(330, 28);
            fontChoiceComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fontChoiceComboBox.Items.AddRange(new object[] {"Arial","Verdana", "Impact" });
            fontChoiceComboBox.SelectedIndexChanged += fontChoiceComboBox_SelectedIndexChanged;
            fontChoiceComboBox.SelectedIndexChanged += fontChoiceComboBox_SelectedIndexChanged;

            this.Controls.Add(fontChoiceComboBox);

            fontAddTextBox = new TextBox();
            fontAddTextBox.Font = new Font(TextBox.DefaultFont.FontFamily, 10);
            fontAddTextBox.Size = new Size(140, 25);
            fontAddTextBox.BackColor = Color.White;
            fontAddTextBox.Location = new Point(330,87);
            fontAddTextBox.KeyDown += fontAddTextBox_KeyDown;
            this.Controls.Add(fontAddTextBox);
            

            removePanel = new Panel();
            removePanel.Dock = DockStyle.Left;
            removePanel.Size = new Size(140,25);
            removePanel.Location = new Point(330,147);
            removePanel.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;

            fontRemoveTextBox = new TextBox();
            fontRemoveTextBox.Font = new Font(TextBox.DefaultFont.FontFamily, 10);
            fontRemoveTextBox.ReadOnly = true;

            updown = new NumericUpDown();
            updown.Dock = DockStyle.Left;
            updown.Size = new Size(140, 25);
            updown.Maximum = 10;
            updown.Minimum = 0;
            updown.ValueChanged += NumericUpDown_ValueChanged;
            removePanel.Controls.Add(updown);

            this.Controls.Add(removePanel);

            fontColorButton = new Button();
            fontColorButton.Text = "字體顏色";
            fontColorButton.Size = new Size(70, 25);
            fontColorButton.Location = new Point(490, 27);
            fontColorButton.Click += fontColorButton_Click;
            this.Controls.Add(fontColorButton);

            linkLabel = new LinkLabel();
            linkLabel.Text = "字體查詢";
            linkLabel.Font = new Font(TextBox.DefaultFont.FontFamily, 10);
            linkLabel.Location = new Point(495, 90);
            linkLabel.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabel.LinkColor = Color.Blue;
            linkLabel.ActiveLinkColor = Color.Purple;
            linkLabel.LinkClicked += linkLabel_LinkClicked;

            this.Controls.Add(linkLabel);


            confirmButton = new Button();
            confirmButton.Text = "確定";
            confirmButton.Size = new Size(60, 25);
            confirmButton.Location = new Point(495, 145);
            confirmButton.Click += confirmButton_Click;
            this.Controls.Add(confirmButton);
        }
        private void importTxtButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog search = new OpenFileDialog();
            search.Filter = "文字檔案(*.txt)|*.txt";
            if (search.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = search.FileName;
                string fileContent = File.ReadAllText(selectedFile);

                outputTextBox.Text = fileContent;
            }

        }

        private void fontColorButton_Click(object sender,EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                outputTextBox.ForeColor = colorDialog.Color;
            }

        }

        private void fontAddTextBox_KeyDown(object sender , KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                string newFont = fontAddTextBox.Text.Trim();
                if (!string.IsNullOrEmpty(newFont) && !
                    fontChoiceComboBox.Items.Contains(newFont))
                {
                    fontChoiceComboBox.Items.Add(newFont);
                    fontChoiceComboBox.SelectedItem = newFont;
                    fontAddTextBox.Clear();
                }
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(
               "https://zh.wikipedia.org/zh-tw/Microsoft_Windows%E5%AD%97%E5%9E%8B%E5%88%97%E8%A1%A8");
        }

        private void fontChoiceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string selectFont = fontChoiceComboBox.SelectedItem.ToString();
            Font selectedFontObj = new Font(selectFont, outputTextBox.Font.Size);
            outputTextBox.Font = selectedFontObj;
        }

        private void UpdateFontRemoveTextBoxRange(object sender , EventArgs e)
        {
            int itemCount = fontChoiceComboBox.Items.Count;
            updown.Maximum = itemCount;

            if (itemCount > 0)
            {
                fontRemoveTextBox.Text = "1";
                updown.Value = 1;
            }
            else
            {
                fontRemoveTextBox.Text = "";
                updown.Value = 0;
            }
        }

        private void confirmButton_Click(object sender,EventArgs e)
        {
            int selectedIndex = (int)updown.Value;
            if (selectedIndex > 0 && selectedIndex <= fontChoiceComboBox.Items.Count)
            {
                fontChoiceComboBox.Items.RemoveAt(selectedIndex - 1);
                updown.Value = 0;
                fontRemoveTextBox.Text = "";
            }
        }

        private void NumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown updown = (NumericUpDown)sender;
            int selectedOption = (int)updown.Value;

            string optionText = GetOptionText(selectedOption);
            fontRemoveTextBox.Text = optionText;
        }

        private string GetOptionText(int option)
        {
            switch (option)
            {
                case 1:
                    return "1";
                case 2:
                    return "2";
                case 3:
                    return "3";
                case 4:
                    return "4";
                case 5:
                    return "5";
                case 6:
                    return "6";
                case 7:
                    return "7";
                case 8:
                    return "8";
                case 9:
                    return "9";
                case 10:
                    return "10";
                default:
                    return "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}