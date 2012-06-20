using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using NHibernate.Connection;

namespace OpenCurtain.UnitTests
{
    public class SQLiteInMemoryTestConnectionProvider : DriverConnectionProvider
    {
        private static IDbConnection connection;

        public override IDbConnection GetConnection()
        {
            if (connection == null)
            {
                connection = base.GetConnection();
            }
            return connection;
        }

        public override void CloseConnection(IDbConnection conn)
        {
            // Do nothing in order to keep the in-memory database available until the test has finished
        }

        /// <summary>
        /// Destroys the connection that is kept open in order to 
        /// keep the in-memory database alive.  Destroying
        /// the connection will destroy all of the data stored in 
        /// the mock database. Call this method when the
        /// test is complete.
        /// </summary>
        public static void ExplicitlyDestroyConnection()
        {
            if (connection != null)
            {
                connection.Close();
                connection = null;
            }
        }
    }
}
