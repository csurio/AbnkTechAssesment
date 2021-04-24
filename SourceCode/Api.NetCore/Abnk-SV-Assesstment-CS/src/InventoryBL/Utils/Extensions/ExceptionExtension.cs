using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBL.Utils.Extensions
{
    public static class ExceptionExtensions
    {
        //Extension Method to Get Messages in Exception
        public static string GetInnerMessages(this Exception ex)
        {
            StringBuilder messages = new StringBuilder();
            messages.AppendLine(ex.Message);
            Exception _innerExcepcion = ex.InnerException;
            while (_innerExcepcion != null)
            {
                messages.AppendLine(_innerExcepcion.Message);
                _innerExcepcion = _innerExcepcion.InnerException;
            }

            return messages.ToString();
        }
    }
}
