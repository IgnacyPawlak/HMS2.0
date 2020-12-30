using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HSM2._0.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
    }
}
