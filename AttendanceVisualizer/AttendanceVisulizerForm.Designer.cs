using System;
using System.Windows.Forms;

namespace AttendanceVisualizer
{
    partial class AttendanceVisulizerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReadSheet_Button = new System.Windows.Forms.Button();
            this.DrawButton = new System.Windows.Forms.Button();
            this.TimeLineDrawingPanel = new System.Windows.Forms.Panel();
            this.SheetContents_ListBox = new System.Windows.Forms.ListBox();
            this.Scroller = new System.Windows.Forms.VScrollBar();
            this.SuspendLayout();
            // 
            // ReadSheet_Button
            // 
            this.ReadSheet_Button.Location = new System.Drawing.Point(36, 75);
            this.ReadSheet_Button.Name = "ReadSheet_Button";
            this.ReadSheet_Button.Size = new System.Drawing.Size(138, 41);
            this.ReadSheet_Button.TabIndex = 1;
            this.ReadSheet_Button.Text = "Read Sheet";
            this.ReadSheet_Button.UseVisualStyleBackColor = true;
            this.ReadSheet_Button.Click += new System.EventHandler(this.ReadSheet_Button_Click);
            // 
            // DrawButton
            // 
            this.DrawButton.Location = new System.Drawing.Point(774, 176);
            this.DrawButton.Name = "DrawButton";
            this.DrawButton.Size = new System.Drawing.Size(10, 10);
            this.DrawButton.TabIndex = 122;
            this.DrawButton.Text = "Draw";
            this.DrawButton.UseVisualStyleBackColor = true;
            this.DrawButton.Click += new System.EventHandler(this.DrawButton_Click);
            // 
            // TimeLineDrawingPanel
            // 
            this.TimeLineDrawingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TimeLineDrawingPanel.Location = new System.Drawing.Point(180, 28);
            this.TimeLineDrawingPanel.Name = "TimeLineDrawingPanel";
            this.TimeLineDrawingPanel.Size = new System.Drawing.Size(588, 614);
            this.TimeLineDrawingPanel.TabIndex = 121;
            // 
            // SheetContents_ListBox
            // 
            this.SheetContents_ListBox.FormattingEnabled = true;
            this.SheetContents_ListBox.Location = new System.Drawing.Point(36, 122);
            this.SheetContents_ListBox.Name = "SheetContents_ListBox";
            this.SheetContents_ListBox.Size = new System.Drawing.Size(138, 615);
            this.SheetContents_ListBox.TabIndex = 120;
            // 
            // Scroller
            // 
            this.Scroller.Location = new System.Drawing.Point(771, 122);
            this.Scroller.Name = "Scroller";
            this.Scroller.Size = new System.Drawing.Size(17, 615);
            this.Scroller.TabIndex = 123;
            this.Scroller.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Scroller_scroll);
            // 
            // AttendanceVisulizerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 773);
            this.Controls.Add(this.Scroller);
            this.Controls.Add(this.DrawButton);
            this.Controls.Add(this.TimeLineDrawingPanel);
            this.Controls.Add(this.SheetContents_ListBox);
            this.Controls.Add(this.ReadSheet_Button);
            this.Name = "AttendanceVisulizerForm";
            this.Text = "AttendanceVisulizerForm";
            this.ResumeLayout(false);

        }

        private void Scroller_scroll(object sender, ScrollEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #endregion

        internal System.Windows.Forms.Button ReadSheet_Button;
        internal System.Windows.Forms.Button DrawButton;
        internal System.Windows.Forms.Panel TimeLineDrawingPanel;
        internal System.Windows.Forms.ListBox SheetContents_ListBox;
        private System.Windows.Forms.VScrollBar Scroller;
    }
}