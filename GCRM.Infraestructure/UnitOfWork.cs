using Connection;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Infraestructure
{
	public class UnitOfWork : IUnitOfWork
	{
		public NpgsqlConnection connection { get; private set; }
		public NpgsqlTransaction? transaction { get; private set; }

		public UnitOfWork()
		{
			connection = ConnectionPool.GetConnection();
		}

		public void Begin()
		{
			transaction = connection.BeginTransaction();
		}

		public void Commit()
		{
			transaction?.Commit();
		}

		public void Rollback()
		{
			transaction?.Rollback();
		}

		public void Dispose()
		{
			try
			{
				// transaction dispose may throw an exception in some connection failure states 

				transaction?.Dispose();
			}
			finally
			{
				if (connection != null)
					ConnectionPool.ReleaseConnection(connection);
			}
		}
	}
}
