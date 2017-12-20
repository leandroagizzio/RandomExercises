using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting {
    public class OracleConnection : DbConnection {
        public OracleConnection(string ConnectionString) : base(ConnectionString) {
        }

        public override void Close() {
            Console.WriteLine("Closing connection Oracle");
        }

        public override void Open() {
            Console.WriteLine("Opening connection Oracle: {0}", ConnectionString);
        }

        public override void Run(string command) {
            Console.WriteLine("Running oracle: {0}", command);
        }
    }
}
