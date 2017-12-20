using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting {
    public class DbCommand {
        public string Command { get; set; }
        public IDbConnection idbconnection { get; set; }

        public DbCommand(IDbConnection idbconnection, string Command) {            
            this.idbconnection = idbconnection;
            this.Command = Command;
            Validate();
        }

        private void Validate() {
            if ((idbconnection == null) || (String.IsNullOrEmpty(Command))) {
                throw new InvalidOperationException("IDbConnection or Command cannot be null or empty");
            }
        }

        public void Execute() {
            Validate();
            idbconnection.Open();
            idbconnection.Run(Command);
            idbconnection.Close();
        }
    }
}
