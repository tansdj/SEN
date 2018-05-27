using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHSApplication.Business_Layer
{
    public interface IDataModification<T>
    {
        bool InsertData();
        bool UpdateData();
        List<T> GetData();
    }
}
