using PS.Core.Entities.Other;
using PS.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure
{
    public class Test
    {
        public bool blockUser(int userId)
        {
            // Caution: Update May Not Work..
            PsDbContex db = new PsDbContex();

            LogInInfo el = db.LogInfos.SingleOrDefault(r => r.ID == userId);
            if (el == null) return false;

            el.IsBlocked = 1;
            db.SaveChanges();

            return true;
        }
        public bool registerAdmin()
        {
            LogInInfo newInfo = new LogInInfo
            {
                ID = 10,
                Username = "ift_khan",
                Password = "ift123",
                Type = 1,
                IsBlocked = 0
            };

            PsDbContex db = new PsDbContex();
            db.LogInfos.Add(newInfo);
            db.SaveChanges();

            string _username = "ift_khan";
            List<LogInInfo> logs;

            try
            {
                var res = from info in db.LogInfos
                          where info.Username == _username
                          select info;
                logs = res.ToList();
            }
            catch (Exception)
            {
                return false;
            }

            if (logs.Count != 1) return false;

            User newUser = new User
            {
                ID = 10,
                UserId = logs[0].ID,
                Email = "ifty93@gmail.com",
                Mobile = "01674646624",
                CarModel = "Toyota Premio 2017",
                LicensNumber = "KA-1234"
            };

            db.Users.Add(newUser);
            db.SaveChanges();

            return true;
        }

        public int PlaceChk() 
        {
            PlaceReview rev = new PlaceReview()
            {
                CarUserId = 2,
                Time = DateTime.Today.Date,
                ToPlaceId = 7,
                Rating = 5,
                Comment = "OK"
            };
            PsDbContex db = new PsDbContex();
            var x = db.PlaceReviews.Add(rev);
            db.SaveChanges();
            return x.ID;
        }
    }
}
