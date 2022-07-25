using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vacay.Models;
using Dapper;
using System.Data;

namespace vacay.Repositories
{
    public class CruisesRepository
    {
        private readonly IDbConnection _db;
        public CruisesRepository(IDbConnection db)
        {
            _db = db;
        }
        internal Cruise GetById(int id)
        {
            string sql = "SELECT a.*,  FROM cruises c JOIN accounts a ON a.id = c.creatorId WHERE c.id = @id";
            return _db.QueryFirstOrDefault<Cruise>(sql, new { id });


        }

        internal Cruise FindExisting(Cruise newCruise)
        {
            string sql = @"SELECT * FROM Cruises WHEREVacationId = @VacationId AND accountId = @AccountId";
            return _db.QueryFirstOrDefault<Cruise>(sql, newCruise);
        }

        internal Cruise Create(Cruise newCruise)
        {
            throw new NotImplementedException();
        }

        internal void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}