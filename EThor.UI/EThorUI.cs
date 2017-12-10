using EThor.ApplicationService;
using System;
using System.Windows.Forms;

namespace EThor.UI
{
    public partial class EThorUI : Form
    {
        private IOperationService service;
        public EThorUI(IOperationService opService)
        {
            InitializeComponent();
            service = opService;
            service.ExecutionStatusChanged += OnExecutionStatusChanged;
        }
        
        private void OnExecutionStatusChanged(OperationStatusDto dto)
        {
            if(dto!=null)
            {
                if (!string.IsNullOrEmpty(dto.Status))
                {
                    this.engineBtn.Text = dto.Status;
                    this.operationLabel.Text = dto.LabelText;
                }
                if (dto.CurrentOperation != null)
                {
                    this.resultsView.Rows.Add(dto.CurrentOperation.Parameter1, dto.CurrentOperation.Parameter2,
                    dto.CurrentOperation.Operator, dto.CurrentOperation.Result);
                    this.operationTextBox.Text = dto.OperationText;
                }
            }
        }        
        private void OnButtonClicked(object sender, EventArgs e)
        {
            this.operationTextBox.Visible = true;
            this.operationLabel.Visible = true;
            this.resultsView.Visible = true;
            service.RaiseExecutionStatusChanged();
        }       
    }    
}
