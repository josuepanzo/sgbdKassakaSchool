using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Model {
    public abstract class ConnectionToSql
    {
        private readonly string connectionString;
        public ConnectionToSql()
        {
            connectionString = "Server=DESKTOP-HGU46OU;Database= KassakaSchool; integrated security= true";
        }
        protected SqlConnection GetConnection() {
            return new SqlConnection(connectionString);
        }
    }
}
