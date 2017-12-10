using System;
using System.ComponentModel;
using System.Threading;

namespace EThor.ApplicationService
{
    public class OperationService : IOperationService
    {
        public event StatusChanged ExecutionStatusChanged;
        private BackgroundWorker worker;
        private IOperationEngine operationEngine;

        public OperationService(IOperationEngine engine)
        {
            worker = new BackgroundWorker();
            SubscribeToBackgroundWorkerEvents();
            operationEngine = engine;
        }

        

        private void OnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ExecutionStatusChanged(e.UserState as OperationStatusDto);
        }

        public void RaiseExecutionStatusChanged()
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
                return;
            }
            worker.RunWorkerAsync();
        }

        private void OnDoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                OperationStatusDto dto = new OperationStatusDto { Status = ExecutionStatus.Stop.ToString() };
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    dto.Status = ExecutionStatus.Start.ToString();
                    dto.LabelText = "Last Operation:";
                    worker.ReportProgress(1, dto);
                    break;
                }
                Thread.Sleep(1000);
                dto.LabelText = "Current Operation:";                
                dto.CurrentOperation = operationEngine.Run();
                dto.OperationText = string.Format(dto.CurrentOperation.Parameter1 + " " +
                        dto.CurrentOperation.Operator + " " + dto.CurrentOperation.Parameter2 + " = " +
                        dto.CurrentOperation.Result);
                worker.ReportProgress(1, dto);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void SubscribeToBackgroundWorkerEvents()
        {
            worker.DoWork += new DoWorkEventHandler(OnDoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler
                    (OnProgressChanged);
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
        }

        private void UnSubscribeToBackgroundWorkerEvents()
        {
            worker.DoWork -= new DoWorkEventHandler(OnDoWork);
            worker.ProgressChanged -= new ProgressChangedEventHandler
                    (OnProgressChanged);
            worker.WorkerReportsProgress = false;
            worker.WorkerSupportsCancellation = false;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing && worker!=null)
            {
                UnSubscribeToBackgroundWorkerEvents();
            }
            
        }
    }
}
