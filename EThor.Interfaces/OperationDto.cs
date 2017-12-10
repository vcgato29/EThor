

namespace EThor.ApplicationService
{
    public class OperationDto
    {
        public string Parameter1 { get; set; }
        public string Parameter2 { get; set; }
        public string Operator { get; set; }
        public string Result { get; set; }
    }

    public class OperationStatusDto
    {
        public string Status { get; set; }
        public OperationDto CurrentOperation { get; set; }
        public string OperationText { get; set; }
        public string LabelText { get; set; }
    }
}
