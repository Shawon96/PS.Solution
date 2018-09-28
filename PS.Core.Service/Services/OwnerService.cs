using PS.Core.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS.Core.Entities.Owner;
using PS.Infrastructure;
using PS.Core.Entities.Other;

namespace PS.Core.Service.Services
{
    public class OwnerService : IOwnerService
    {
        //Approved = 0  and  Blocked = 1
        public bool approveOwner(int ownerId)
        {
            // Caution: Update May Not Work..
            PsDbContex db = new PsDbContex();

            LogInInfo el = db.LogInfos.SingleOrDefault(r => r.ID == ownerId);
            if (el == null) return false;

            el.IsBlocked = 0;
            db.SaveChanges();

            return true;
        }

        public bool blockOwner(int ownerId)
        {
            // Caution: Update May Not Work..
            PsDbContex db = new PsDbContex();

            LogInInfo el = db.LogInfos.SingleOrDefault(r => r.ID == ownerId);
            if (el == null) return false;

            el.IsBlocked = 1;
            db.SaveChanges();

            return true;
        }

        public IEnumerable<Owner> getOwners()
        {
            PsDbContex db = new PsDbContex();
            List<Owner> data;

            try
            {
                var el = from r in db.Owners
                         select r;
                data = el.ToList();
            }
            catch
            {
                return null;
            }

            return data;
        }

        public bool register(LogInInfo log, Owner aOwner)
        {
            PsDbContex db = new PsDbContex();

            LogInInfo el = db.LogInfos.SingleOrDefault(r => r.Username == log.Username);
            if (el != null) return false;

            LogInInfo newInfo = new LogInInfo
            {
                ID = 10,
                Username = log.Username,
                Password = log.Password,
                Type = 2,
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

            Owner newOwner = new Owner
            {
                ID = 10,
                OwnerId = logs[0].ID,
                Email = aOwner.Email,
                Mobile = aOwner.Mobile,
            };

            db.Owners.Add(newOwner);
            db.SaveChanges();

            return true;
        }
    }
}
