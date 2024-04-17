using Repair.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repair.Business.Interfaces
{
    public interface ITypeDomageRepository
    {
        public List<ItemModel> GetDomageList();

    }
}
