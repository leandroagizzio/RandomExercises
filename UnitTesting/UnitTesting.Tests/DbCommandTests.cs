using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting.Tests {
    [TestClass]
    public class DbCommandTests {

        //METHODNAME_CONDITION_EXPECTATION
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Execute_CommandIsEmpty_ThrowsAnException() {
            var dbcommand = new DbCommand(new FakeDbConnection(), "a");
            dbcommand.Command = "";
            dbcommand.Execute();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Execute_IDbConnectionIsNull_ThrowsAnException() {
            var dbcommand = new DbCommand(new FakeDbConnection(), "a");
            dbcommand.idbconnection = null;
            Assert.IsNull(dbcommand.idbconnection);
            Assert.AreEqual("a", dbcommand.Command);
            dbcommand.Execute();
        }
    }

    public class FakeDbConnection : IDbConnection {
        public void Close() {
            Console.WriteLine("close");
        }

        public void Open() {
            Console.WriteLine("open");
        }

        public void Run(string command) {
            Console.WriteLine("run "+command);
        }
    }
}
