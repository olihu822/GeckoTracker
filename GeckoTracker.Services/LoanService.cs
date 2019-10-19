using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GeckoTracker.Data;
using GeckoTracker.Models;
using GT.Data;

namespace GeckoTracker.Services
{
    public class LoanService
    {
        private readonly Guid _userID;

        public LoanService(Guid userID)
        {
            _userID = userID;
        }

        public static void Date()
        {
            DateTime date1 = new DateTime();
            Console.WriteLine(date1.ToString("d"));
        }

        public IEnumerable<LoanListView> GetLoans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Loans
                        .Where(e => e.OwnerID == _userID).ToList();
                List<LoanListView> loans = new List<LoanListView>();
                foreach (var loan in query)
                {
                    loans.Add(new LoanListView
                    {
                        LoanID = loan.LoanID,
                        LoanedGeckoID = loan.LoanedGecko.GeckoID,
                        LoanedGeckoName = loan.LoanedGecko.GeckoName,
                        LeaseeName = loan.LeaseeName,
                        LoanStart = loan.LoanStart.ToString("d"),
                        LoanDuration = loan.LoanDuration
                    });
                }
                return loans;
            }
        }

        public LoanDetail GetLoanByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var loanEntity =
                    ctx
                        .Loans
                        .Single(e => e.LoanID == id && e.OwnerID == _userID);
                return
                    new LoanDetail
                    {
                        LoanID = loanEntity.LoanID,
                        LoanedGeckoID = loanEntity.LoanedGeckoID,
                        LoanedGeckoName = loanEntity.LoanedGecko.GeckoName,
                        LeaseeName = loanEntity.LeaseeName,
                        LoanStart = loanEntity.LoanStart,
                        LoanDuration = loanEntity.LoanDuration
                    };
            }
        }

        public bool CreateLoan(LoanCreate model)
        {
            var loanEntity = new Loan()
            {
                OwnerID = _userID,
                LoanedGeckoID = model.LoanedGeckoID,
                LoanedGeckoName = model.LoanedGeckoName,
                LeaseeName = model.LeaseeName,
                LoanStart = model.LoanStart,
                LoanDuration = model.LoanDuration
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Loans.Add(loanEntity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool UpdateLoan(LoanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Loans
                        .Single(e => e.LoanID == model.LoanID && e.OwnerID == _userID);

                entity.LoanID = model.LoanID;
                entity.LoanedGeckoID = model.LoanedGeckoID;
                entity.LoanedGeckoName = model.LoanedGeckoName;
                entity.LeaseeName = model.LeaseeName;
                entity.LoanStart = model.LoanStart;
                entity.LoanDuration = model.LoanDuration;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteLoan(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Loans
                    .Single(e => e.LoanID == id && e.OwnerID == _userID);

                ctx.Loans.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
