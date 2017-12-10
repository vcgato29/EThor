using EThor.ApplicationService;
using EThor.Core.DataAccess;
using EThor.Core.Models;
using System;
using System.Data;

namespace EThor.Core
{
    public class OperationEngine : IOperationEngine
    {
        private IDataProvider dataProvider;
        public OperationEngine(IDataProvider dp)
        {
            dataProvider = dp;
        }
        public OperationDto Run()
        {
            OperationDto dto = null;
            string json = dataProvider.Provide();
            if (!string.IsNullOrEmpty(json))
            {
                Operation opertion = JsonParser.ConvertTo<Operation>(json);
                if (opertion != null)
                {
                    string expression = opertion.parm1 + opertion.op + opertion.parm2;
                    double result = Convert.ToDouble(new DataTable().Compute(expression, null));
                    dto = new OperationDto
                    {
                        Parameter1 = opertion.parm1.ToString(),
                        Parameter2 = opertion.parm2.ToString(),
                        Operator = opertion.op,
                        Result = result.ToString()
                    };
                }
            }
            return dto;
        }
    }
}
