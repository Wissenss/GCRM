using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCRM.Infraestructure
{
	public interface IRepository<T>
	{
		UnitOfWork UOW { get; }

		T? GetById(int id);
		IEnumerable<T> GetAll();
		int Add(T entity);
		void Update(T entity);
		void Delete(int id);
	}
}
