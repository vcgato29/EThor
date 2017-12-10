namespace EThor.UI
{
    partial class EThorUI
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
                service.ExecutionStatusChanged -= OnExecutionStatusChanged;
                service.Dispose();
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
            this.engineBtn = new System.Windows.Forms.Button();
            this.resultsView = new System.Windows.Forms.DataGridView();
            this.operand1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operand2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.op = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.operationLabel = new System.Windows.Forms.Label();
            this.operationTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.resultsView)).BeginInit();
            this.SuspendLayout();
            // 
            // engineBtn
            // 
            this.engineBtn.Location = new System.Drawing.Point(282, 80);
            this.engineBtn.Name = "engineBtn";
            this.engineBtn.Size = new System.Drawing.Size(116, 33);
            this.engineBtn.TabIndex = 0;
            this.engineBtn.Text = "Start";
            this.engineBtn.UseVisualStyleBackColor = true;
            this.engineBtn.Click += new System.EventHandler(this.OnButtonClicked);
            // 
            // resultsView
            // 
            this.resultsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultsView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.operand1,
            this.operand2,
            this.op,
            this.result});
            this.resultsView.Location = new System.Drawing.Point(76, 198);
            this.resultsView.Name = "resultsView";
            this.resultsView.RowTemplate.Height = 24;
            this.resultsView.Size = new System.Drawing.Size(601, 500);
            this.resultsView.TabIndex = 1;
            this.resultsView.Visible = false;
            // 
            // operand1
            // 
            this.operand1.HeaderText = "Operand1";
            this.operand1.Name = "operand1";
            // 
            // operand2
            // 
            this.operand2.HeaderText = "Operand2";
            this.operand2.Name = "operand2";
            // 
            // op
            // 
            this.op.HeaderText = "Operator";
            this.op.Name = "op";
            // 
            // result
            // 
            this.result.HeaderText = "Result";
            this.result.Name = "result";
            // 
            // operationLabel
            // 
            this.operationLabel.AutoSize = true;
            this.operationLabel.Location = new System.Drawing.Point(223, 144);
            this.operationLabel.Name = "operationLabel";
            this.operationLabel.Size = new System.Drawing.Size(126, 17);
            this.operationLabel.TabIndex = 2;
            this.operationLabel.Text = "Current Operation:";
            this.operationLabel.Visible = false;
            // 
            // operationTextBox
            // 
            this.operationTextBox.Location = new System.Drawing.Point(356, 144);
            this.operationTextBox.Name = "operationTextBox";
            this.operationTextBox.ReadOnly = true;
            this.operationTextBox.Size = new System.Drawing.Size(140, 22);
            this.operationTextBox.TabIndex = 3;
            this.operationTextBox.Visible = false;
            // 
            // EThorUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 753);
            this.Controls.Add(this.operationTextBox);
            this.Controls.Add(this.operationLabel);
            this.Controls.Add(this.resultsView);
            this.Controls.Add(this.engineBtn);
            this.Name = "EThorUI";
            this.Text = "EThor Operation UI";
            ((System.ComponentModel.ISupportInitialize)(this.resultsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button engineBtn;
        private System.Windows.Forms.DataGridView resultsView;
        private System.Windows.Forms.DataGridViewTextBoxColumn operand1;
        private System.Windows.Forms.DataGridViewTextBoxColumn operand2;
        private System.Windows.Forms.DataGridViewTextBoxColumn op;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.Label operationLabel;
        private System.Windows.Forms.TextBox operationTextBox;
    }
}

