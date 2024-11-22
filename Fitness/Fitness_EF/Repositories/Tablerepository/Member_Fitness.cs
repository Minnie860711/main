using Fitness_EF.DbContextEF;
using Fitness_EF.Interface.ITableRespository;
using Fitness_EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_EF.Repositories.Tablerepository
{
    public class Member_Fitness : GenericRepository_Fitness<Member>, IMember_Fitness
    {
        public Member_Fitness(DbContext_Fitness dbContext) : base(dbContext)
        {

        }

    }
}
