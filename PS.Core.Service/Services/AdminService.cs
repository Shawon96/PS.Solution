using PS.Core.Entities.Other;
using PS.Core.Service.Interface;
using PS.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Core.Service.Services
{
    public class AdminService : IAdminService
    {
        public bool registerAdmin()
        {
            LogInInfo newUser = new LogInInfo
            {
                ID = 10,
                Username = "ift_admin",
                Password = "admin",
                Type = 3,
                IsBlocked = 0
            };

            PsDbContex db = new PsDbContex();
            db.LogInfos.Add(newUser);
            db.SaveChanges();

            return true;
        }
    }
}
