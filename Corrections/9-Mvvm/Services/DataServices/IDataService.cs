using _9_Mvvm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_Mvvm.Services.DataServices
{
    public interface IDataService
    {
        Task<DataItem> GetData();
    }
}
