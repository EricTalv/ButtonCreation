using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonCreation
{
    public partial class Form1 : Form
    {

        int count = 0;

        string Alphabet = "ABCDEFGHIJKLMNOPQRSŠZŽTUVWÕÄÖÜXY";
        Button[] KeyboardButtons;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void ReportStatus(string statusMessage, string logEvent)
        {
            // If the caller passed in a message...
            if ((statusMessage != null) && (statusMessage != String.Empty))
            {
                // ...post the caller's message to the status bar.
                this.SSL_Status.Text = statusMessage;
            }

            TBX_HistoryLog.Text += logEvent + " \n";
        }

        #region Add One Button
        private void B_AddButton_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void B_AddMultiButtons_Click(object sender, EventArgs e)
        {
            /// <summary>
            /// add multiple buttons
            /// on one click
            /// </summary>

            int ButtonAmount = Convert.ToInt32(NUD_ButtonsAmount.Value);

            Button[] _MultiButtons = new Button[ButtonAmount];

            SSL_Status.Text = "Working..";

            for (int i = 0; i < ButtonAmount; i++)
            {
                //Show Status
                SSL_Status.Text = "Adding Buttons:" + i;
                //Report Status
                ReportStatus("Adding Buttons:" + i, "Added!: " + i);
                //Create new object reference for Button
                _MultiButtons[i] = new Button();
                //Color
                _MultiButtons[i].BackColor = Color.White;
                //Set button Height & Width
                _MultiButtons[i].Size = new Size(110, 30);
                //Set Button text
                _MultiButtons[i].Text = "Button:" + i;
                //Set Button Position
                _MultiButtons[i].Top = (int)XPos.Value;
                _MultiButtons[i].Left = (int)YPos.Value;
                //Moveable = true
                _MultiButtons[i].myMove();
                //Click function
                _MultiButtons[i].Click += SecondClick_Function;
                //Add to Panel
                CanvasMain.Controls.Add(_MultiButtons[i]);

            }
            SSL_Status.Text = "Buttons Added:" + CanvasMain.Controls.Count.ToString();

        }

        private void B_Position1_Click(object sender, EventArgs e)
        {
            Button[] _MultiButtons = new Button[(int)NUD_ButtonsAmount.Value];

            if (CBX_AutoRemove.Checked)
            {
                CanvasMain.Controls.Clear();
            }

            SSL_Status.Text = "Working..";

            //Sets how many spaces are between all buttons
            int ix1 = CanvasMain.Width / (int)NUD_Spaces.Value;
            //Sets the padding for buttons
            int ix2 = ix1 / (int)NUD_Padding.Value;

            //Button sizing
            int iy1 = CanvasMain.Height * (int)NUD_First.Value / (int)NUD_Second.Value;
            //Setting Positions
            //Set Y Positions
            int iy2 = iy1 / (int)NUD_YPos.Value;
            //Set X Positions
            int ix = (int)NUD_XPos.Value * ix1 + (int)NUD_XPos2.Value * ix2;

            int iy = iy2;

            for (int i = 0; i < (int)NUD_ButtonsAmount.Value; i++)
            {
                //Show Status
                SSL_Status.Text = "Adding Buttons:" + i;
                //Report Status
                ReportStatus("Adding Buttons:" + i, "Added!: " + i);
                //Create new object reference for Button
                _MultiButtons[i] = new Button();
                //Color
                _MultiButtons[i].BackColor = Color.White;
                //Set button Height & Width
                _MultiButtons[i].Size = new Size(110, 30);
                //Set Button text
                _MultiButtons[i].Text = "Button:" + i;
                //Set Button Positions

                _MultiButtons[i].Top = iy;
                _MultiButtons[i].Left = ix;
                _MultiButtons[i].Height = iy1;
                _MultiButtons[i].Width = ix1;
                //Avoid adding the buttons ontop of each other
                ix = ix - ix1 - ix2;

                //Moveable = true
                _MultiButtons[i].myMove();
                //Click function
                _MultiButtons[i].Click += SecondClick_Function;
                //Add to Panel
                CanvasMain.Controls.Add(_MultiButtons[i]);

            }
            SSL_Status.Text = "Buttons Added:" + CanvasMain.Controls.Count.ToString();
        }

        #region Click Functions
        #region SecondClick Functions
        private void SecondClick_Function(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            ReportStatus("Click!2", "Clicked" + thisButton.Text);
        }
        #endregion

        #region FirstClick Functions
        private void Click_Function(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            ReportStatus("Click!", "Clicked" + thisButton.Text);
        }
        #endregion
        #endregion

        #region Dispose Region
        private void B_Dispose_Click(object sender, EventArgs e)
        {
            CanvasMain.Controls.Clear();
        }
        #endregion End

        private void B_ClearLog_Click(object sender, EventArgs e)
        {
            TBX_HistoryLog.Clear();
        }

        private void NUD_ButtonsAmount_ValueChanged(object sender, EventArgs e)
        {
            ReportStatus("Amount Changed!", "Button Amount:" + NUD_ButtonsAmount.Value);
        }

        private void CanvasMain_ControlAdded(object sender, ControlEventArgs e)
        {
            SSL_ControlAmount.Text = CanvasMain.Controls.Count.ToString();
        }

        private void B_ShowHistory_Click(object sender, EventArgs e)
        {
            if (!P_HistoryPanel.Visible)
            {
                P_HistoryPanel.Visible = true;
            }
            else
            {
                P_HistoryPanel.Visible = false;
            }
        }

        private void B_Keyboard_Click(object sender, EventArgs e)
        {
            if (CBX_AutoRemove.Checked)
            {
                CanvasMain.Controls.Clear();
            }

            int ButtonPerLine = 8;
            int ButtonPerRow = 4;

            KeyboardButtons = new Button[ButtonPerLine * ButtonPerRow];

            int ww = CanvasMain.Width / ButtonPerLine;
            int hh = CanvasMain.Height / ButtonPerRow;

            int www = ww / (int)NUD_First.Value; // 2
            int hhh = hh / (int)NUD_Second.Value; // 2

            for (int i = 0; i < ButtonPerRow; i++)
            {
                for (int j = 0; j < ButtonPerLine; j++)
                {
                    int k = i * ButtonPerLine + j;
                    CanvasMain.Controls.Add(KeyboardButtons[i]);
                    KeyboardButtons[k] = new Button();
                    CanvasMain.Controls.Add(KeyboardButtons[k]);
                    KeyboardButtons[k].Left = ww * j;
                    KeyboardButtons[k].Top = hh * i;
                    KeyboardButtons[k].Width = www + (int)XPos.Value; //10
                    KeyboardButtons[k].Height = hhh + (int)YPos.Value; //12
                    KeyboardButtons[k].BackColor = Color.WhiteSmoke;
                    KeyboardButtons[k].FlatStyle = FlatStyle.System;
                    KeyboardButtons[k].Font = new Font(FontFamily.GenericSansSerif, 20, FontStyle.Bold);
                }
            }
            for (int i = 0; i < KeyboardButtons.Length; i++)
            {
                KeyboardButtons[i].Text = Alphabet[i].ToString();
            }
        }

        private void B_SecondKeyboard_Click(object sender, EventArgs e)
        {

            for (int row = 0; row < 4; row++)
            {
                for (int column = 0; column < 4; column++)
                {
                    Button button = new Button();
                    button.Text = "button text";
                    button.Left = column * 4;
                    button.Top = row * 40;
                    button.Width = 100;
                    button.Height = 30;
                    button.BackColor = Color.PapayaWhip;
                    CanvasMain.Controls.Add(button);
                }
            }
        }

        private void B_KeyBoard2_Click(object sender, EventArgs e)
        {
            Button[] B2 = new Button[32];
            int buttonsPerLine = 3;
            int buttonsPerRow = 3;

            double ButtonWidth = CanvasMain.Width / buttonsPerLine;
            ButtonWidth = Math.Floor(ButtonWidth);

            double ButtonHeight = CanvasMain.Height / buttonsPerRow;
            ButtonHeight = Math.Floor(ButtonHeight);

            int topAmount = 0;
            int leftAmount = Convert.ToInt32(ButtonWidth);

            int j = 0;
            for (int i = 0; i < B2.Length; i++)
            {
                if (j >= buttonsPerLine)
                {
                    topAmount += Convert.ToInt32(ButtonHeight);
                    j = 0;
                }
                B2[i] = new Button()
                {
                    Width = Convert.ToInt32(ButtonWidth),
                    Height = Convert.ToInt32(ButtonHeight),
                    Top = topAmount,
                    Left = leftAmount * j,
                    Text = i.ToString(),
                    BackColor = Color.WhiteSmoke
                };
                CanvasMain.Controls.Add(B2[i]);
                j++;
            }
            for (int i = 0; i < B2.Length; i++)
            {
                B2[i].Text = Alphabet[i].ToString();
            }
        }
    }
}
