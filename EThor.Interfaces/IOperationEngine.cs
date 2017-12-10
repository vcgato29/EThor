using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EThor.ApplicationService
{
    public interface IOperationEngine
    {
        OperationDto Run();
    }
}
