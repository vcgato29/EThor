using System;

namespace EThor.ApplicationService
{
    public delegate void StatusChanged(OperationStatusDto dto);
    public interface IOperationService :IDisposable
    {
        event StatusChanged ExecutionStatusChanged;
        void RaiseExecutionStatusChanged();
    }
}