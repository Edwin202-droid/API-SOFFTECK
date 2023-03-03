using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Base
{
    public interface IUnitOfWork
    {
        Task<int> Save(bool validate = true);
        IDbContextTransaction BeginTransaction();
    }
}
