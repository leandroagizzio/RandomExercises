using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting {
    public class SqlConnection : DbConnection {
        public SqlConnection(string ConnectionString) : base(ConnectionString) {
        }

        public override void Close() {
            Console.WriteLine("Closing connection Sql Server");
        }

        public override void Open() {
            Console.WriteLine("Opening connection Sql Server: {0}", ConnectionString);
        }

        public override void Run(string command) {
            Console.WriteLine("Running sqlserver: {0}", command);
        }
    }
}
