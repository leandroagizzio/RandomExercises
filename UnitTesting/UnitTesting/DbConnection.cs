using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting {
    public abstract class DbConnection : IDbConnection {

        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }

        public DbConnection(string ConnectionString) {
            if (!String.IsNullOrEmpty(ConnectionString)) {
                this.ConnectionString = ConnectionString;
            } else {
                throw new InvalidOperationException("Connection String cannot be null");
            }
        }

        public abstract void Close();
        public abstract void Open();
        public abstract void Run(string command);
    }
}
