using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Infraestructure
{
	public interface IUnitOfWork : IDisposable
	{
		NpgsqlConnection? connection { get; }
		NpgsqlTransaction? transaction { get; }

		public void Begin();
		public void Commit();
		public void Rollback();
	}
}
