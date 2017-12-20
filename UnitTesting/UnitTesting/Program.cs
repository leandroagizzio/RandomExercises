using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting {
    class Program {
        static void Main(string[] args) {
            var dbcommand = new DbCommand(new OracleConnection("oracle:connectionstring"), 
                "select * from table");
            dbcommand.Execute();
            dbcommand.idbconnection = new SqlConnection("sql:connectionstring");
            dbcommand.Execute();

        }
    }
}
