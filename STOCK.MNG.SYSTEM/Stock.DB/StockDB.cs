using System;

namespace Stock.DB {
    public class StockDb {


        public object LoadConfigurationFromDb() {
            throw new global::System.Exception("Not implemented");
        }
        public object GetExistingUserListFromDb() {
            throw new global::System.Exception("Not implemented");
        }
        public void SaveNewMainVaultToDb() {
            throw new global::System.Exception("Not implemented");
        }
        public static void AddNewBranchToDb(Branch branch) {
            using (var db = new StockDbContext()) {
                db.Branches.Add(branch);
                db.SaveChanges();
            }
        }
        public void SaveRule() {
            throw new global::System.Exception("Not implemented");
        }
        public void LoadBalancesDb() {
            throw new global::System.Exception("Not implemented");
        }
        public void SetBalanceDb() {
            throw new global::System.Exception("Not implemented");
        }
        public void AddUsrAsignment() {
            throw new global::System.Exception("Not implemented");
        }
        public void DeleteUsrAsignment() {
            throw new global::System.Exception("Not implemented");
        }
        public void GetUsrDetailsDb() {
            throw new global::System.Exception("Not implemented");
        }
    }
}
