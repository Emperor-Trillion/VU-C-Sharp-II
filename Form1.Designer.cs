using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
namespace calc
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        public Label _DisplayHolder = new Label();
        public Label _ResultDisplay = new Label();
        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>

        private void DisplayBox()
        {
            _DisplayHolder.Size = new Size(190, 20);
            _DisplayHolder.TextAlign = ContentAlignment.TopRight;
            _DisplayHolder.Font = new Font("Arial", 12f, FontStyle.Regular);
            int innerX = _ResultDisplay.Location.X + 48;
            int innerY = _ResultDisplay.Location.Y + 1;
            _DisplayHolder.Location = new Point(innerX, innerY);
            this.Controls.Add(_DisplayHolder);

            _ResultDisplay.Text = "0";
            _ResultDisplay.BorderStyle = BorderStyle.FixedSingle;
            _ResultDisplay.Size = new Size(240, 100);
            _ResultDisplay.TextAlign = ContentAlignment.BottomRight;
            _ResultDisplay.Font = new Font("Arial", 20f, FontStyle.Bold);
            this.Controls.Add(_ResultDisplay);
        }
        private void Createbuttons()
        {
            List<string> _table = new List<string>();
            int arrayIndex = 0;

            _table.AddRange(new string[] { "+/-", "0", ".", "=" });
            _table.AddRange(new string[] { "1", "2", "3", "+" });
            _table.AddRange(new string[] { "4", "5", "6", "-" });
            _table.AddRange(new string[] { "7", "8", "9", "X" });
            _table.AddRange(new string[] { "C", "%", "DEL", "÷" });
            for (int i = 5; i >= 1; i--)
            {
                for (int j = 1; j <= 4; j++)
                {
                    Button Btn = new Button();
                    Btn.Text = _table[arrayIndex];
                    Btn.Location = new System.Drawing.Point((j - 1) * 60, (i * 60) + 40);
                    Btn.Size = new System.Drawing.Size(60, 60);
                    Btn.Click += HandleInputOfNums;
                    this.Controls.Add(Btn);
                    arrayIndex++;
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 400);
            this.Text = "calc";
            Createbuttons();
            DisplayBox();
        }
        #endregion
    }
}
