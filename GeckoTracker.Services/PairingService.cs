using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeckoTracker.Data;
using GeckoTracker.Models;

namespace GeckoTracker.Services
{
    public class PairingService
    {
        private readonly Guid _userID;

        public PairingService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePairing(PairingCreate model)
        {
            var pairingEntity =
                new Pairing()
                {
                    OwnerID = _userID,
                    MaleGeckoID = model.MaleGeckoID,
                    MaleGeckoName = model.MaleGeckoName,
                    FemaleGeckoID = model.FemaleGeckoID,
                    FemaleGeckoName = model.FemaleGeckoName,
                    Season = model.Season
                };

            using (var ctx = new
                ApplicationDbContext())
            {
                ctx.Pairings.Add(pairingEntity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PairingListView> GetPairings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Pairings
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                        e =>
                        new PairingListView
                        {
                            PairingID = e.PairingID,
                            MaleGeckoID = e.MaleGeckoID,
                            MaleGeckoName = e.MaleGecko.GeckoName,
                            FemaleGeckoID = e.FemaleGeckoID,
                            FemaleGeckoName = e.FemaleGecko.GeckoName,
                            Season = e.Season
                        }
                        );

                return query.ToArray();
            }
        }

        public PairingDetail GetPairingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var pairingEntity =
                    ctx
                        .Pairings
                        .Single(e => e.PairingID == id && e.OwnerID == _userID);
                return
                    new PairingDetail
                    {
                        PairingID = pairingEntity.PairingID,
                        MaleGeckoID = pairingEntity.MaleGeckoID,
                        MaleGeckoName = pairingEntity.MaleGecko.GeckoName,
                        FemaleGeckoID = pairingEntity.FemaleGeckoID,
                        FemaleGeckoName = pairingEntity.FemaleGecko.GeckoName,
                        Season = pairingEntity.Season
                    };
            }
        }

        public bool UpdatePairing(PairingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pairings
                        .Single(e => e.PairingID == model.PairingID && e.OwnerID == _userID);

                entity.PairingID = model.PairingID;
                entity.MaleGeckoID = model.MaleGeckoID;
                entity.MaleGeckoName = model.MaleGeckoName;
                entity.FemaleGeckoID = model.FemaleGeckoID;
                entity.FemaleGeckoName = model.FemaleGeckoName;
                entity.Season = model.Season;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePairing(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Pairings
                        .Single(e => e.PairingID == id && e.OwnerID == _userID);

                ctx.Pairings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
