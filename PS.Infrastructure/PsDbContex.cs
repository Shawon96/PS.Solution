using PS.Core.Entities.Other;
using PS.Core.Entities.Owner;
using PS.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.Infrastructure
{
    public class PsDbContex : DbContext
    {
        public DbSet<LogInInfo> LogInfos { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Owner> Owners { get; set; }

        public DbSet<ParkingPlace> ParkingPlaces { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }

        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Promo> Promos { get; set; }

        public DbSet<Review> Reviews { get; set; }
        public DbSet<PlaceReview> PlaceReviews { get; set; }
    }
}