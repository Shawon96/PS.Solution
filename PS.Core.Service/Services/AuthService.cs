using PS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Core.Entities.Other;
using PS.Infrastructure;

namespace PS.Core.Service.Services
{
    //0=admin, 1=user, 2=owner
    public class AuthService : IAuthService
    {
        public bool ChangePassword(string Cpassword, string newpassword, string conpassword, int ownerid)
        {
            throw new NotImplementedException();
        }

        public bool ChanPassword(string Cpassword, string newpassword, string conpassword, int userid)
        {
            throw new NotImplementedException();
        }

        public string getUsername(int id)
        {
            PsDbContex db = new PsDbContex();

            LogInInfo el = db.LogInfos.SingleOrDefault(r => r.ID == id);
            if (el == null) return "undefined";
            return el.Username;
        }
        public int getType(int id)
        {
            PsDbContex db = new PsDbContex();

            LogInInfo el = db.LogInfos.SingleOrDefault(r => r.ID == id);
            if (el == null) return -1;
            return el.Type;
        }

        public int login(string aUserName, string password)
        {
            PsDbContex db = new PsDbContex();
            List<LogInInfo> logs;

            try
            {
                var res = from info in db.LogInfos
                          where info.Username == aUserName && info.Password == password
                          select info;
                logs = res.ToList();
            }
            catch (Exception ex)
            {
                return 0;
            }

            if (logs.Count == 1) return logs[0].ID;
            else return 0;
        }
    }
}
