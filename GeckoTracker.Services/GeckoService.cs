using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoTracker.Data;
using GeckoTracker.Models;

namespace GeckoTracker.Services
{
    public class GeckoService
    {
        private readonly Guid _userID;

        public GeckoService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateGecko(GeckoCreate model)
        {
            var geckoEntity =
                new Gecko()
                {
                    OwnerID = _userID,
                    GeckoName = model.GeckoName,
                    GeckoSexIsMale = model.GeckoSexIsMale,
                    GeckoWeight = model.GeckoWeight,
                    HatchDate = model.HatchDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Geckos.Add(geckoEntity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GeckoListView> GetMaleGeckos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Geckos
                        .Where( e => e.GeckoSexIsMale == true && e.OwnerID == _userID)
                        .Select(
                            e =>
                                new GeckoListView
                                {
                                    GeckoID = e.GeckoID,
                                    GeckoName = e.GeckoName,
                                    GeckoSexIsMale = e.GeckoSexIsMale,
                                    GeckoWeight = e.GeckoWeight,
                                    HatchDate = e.HatchDate
                                }
                                );

                return query.ToList();
            }
        }

        public IEnumerable<GeckoListView> GetFemaleGeckos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Geckos
                        .Where(e => e.GeckoSexIsMale == false && e.OwnerID == _userID)
                        .Select(
                            e =>
                                new GeckoListView
                                {
                                    GeckoID = e.GeckoID,
                                    GeckoName = e.GeckoName,
                                    GeckoSexIsMale = e.GeckoSexIsMale,
                                    GeckoWeight = e.GeckoWeight,
                                    HatchDate = e.HatchDate
                                }
                                );

                return query.ToList();
            }
        }

        public IEnumerable<GeckoListView> GetGeckos()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Geckos
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new GeckoListView
                                {
                                    GeckoID = e.GeckoID,
                                    GeckoName = e.GeckoName,
                                    GeckoSexIsMale = e.GeckoSexIsMale,
                                    GeckoWeight = e.GeckoWeight,
                                    HatchDate = e.HatchDate
                                }
                                );

                return query.ToArray();
            }
        }

        public GeckoDetail GetGeckoById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var geckoEntity =
                    ctx
                        .Geckos
                        .Single(e => e.GeckoID == id && e.OwnerID == _userID);
                return
                    new GeckoDetail
                    {
                        GeckoID = geckoEntity.GeckoID,
                        GeckoName = geckoEntity.GeckoName,
                        GeckoSexIsMale = geckoEntity.GeckoSexIsMale,
                        GeckoWeight = geckoEntity.GeckoWeight,
                        HatchDate = geckoEntity.HatchDate,

                    };
            }
        }

        public bool UpdateGecko(GeckoEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Geckos
                        .Single(e => e.GeckoID == model.GeckoID && e.OwnerID == _userID);

                entity.GeckoName = model.GeckoName;
                entity.GeckoSexIsMale = model.GeckoSexIsMale;
                entity.GeckoWeight = model.GeckoWeight;
                entity.HatchDate = model.HatchDate;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGecko(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Geckos
                        .Single(e => e.GeckoID == id && e.OwnerID == _userID);

                ctx.Geckos.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
