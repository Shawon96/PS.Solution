using PS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Core.Entities.User;
using PS.Infrastructure;
using System.Data.Entity;
using PS.Core.Entities.Other;

namespace PS.Core.Service.Services
{
    public class UserService : IUserService
    {
        public bool blockUser(int userId)
        {
            // Caution: Update May Not Work..
            PsDbContex db = new PsDbContex();

            LogInInfo el = db.LogInfos.SingleOrDefault(r => r.ID == userId);
            if (el == null) return false;

            el.IsBlocked = 0;
            db.SaveChanges();

            return true;
        }

        public IEnumerable<User> getUsers()
        {
            throw new NotImplementedException();
        }


        public bool register(LogInInfo log, User aUser)
        {
            PsDbContex db = new PsDbContex();

            LogInInfo el = db.LogInfos.SingleOrDefault(r => r.Username == log.Username);
            if (el != null) return false;

            LogInInfo newInfo = new LogInInfo
            {
                ID = 10,
                Username = log.Username,
                Password = log.Password,
                Type = 1,
                IsBlocked = 0
            };

            
            db.LogInfos.Add(newInfo);
            db.SaveChanges();

            string _username = log.Username;
            List<LogInInfo> logs;

            try
            {
                var res = from info in db.LogInfos
                          where info.Username == _username
                          select info;
                logs = res.ToList();
            }
            catch (Exception ex)
            {
                return false;
            }

            if (logs.Count != 1) return false;

            User newUser = new User
            {
                ID = 10,
                UserId = logs[0].ID,
                Email = aUser.Email,
                Mobile = aUser.Mobile,
                CarModel = aUser.CarModel,
                LicensNumber = aUser.LicensNumber
            };

            db.Users.Add(newUser);
            db.SaveChanges();

            return true;
        }
    }
}
