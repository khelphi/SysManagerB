using Dapper;
using SysManager.Application.Contracts;
using SysManager.Application.Contracts.Unity.Request;
using SysManager.Application.Data.MySql.Entities;
using SysManager.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class UnityRepository
    {
        private readonly MySqlContext _context;
        public UnityRepository(MySqlContext ctt)
        {
            this._context = ctt;
        }

        public virtual async Task<ResponseDefault> PostAsync(UnityEntity entity)
        {
            string strQuery = @"insert into unity(id, name, active)
                                          Values(@id, @name, @active)";

            using (var cnx = _context.Connection())
            {
                var result = await cnx.ExecuteAsync(strQuery, new
                {
                    id = entity.Id,
                    Name = entity.Name,
                    active = entity.Active
                });

                if (result > 0)
                    return new ResponseDefault(entity.Id.ToString(), "Unidade de Medida criada com sucesso", false);
            }
            return new ResponseDefault("", "Erro ao tentar criar Unidade de Medida", true);
        }

        public virtual async Task<ResponseDefault> PutAsync(UnityEntity entity)
        {
            string strQuery = $"update unity set name = '{entity.Name}', active = {entity.Active} where id = '{entity.Id}'";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.ExecuteAsync(strQuery);

                if (result > 0)
                    return new ResponseDefault(entity.Id.ToString(), "Unidade de Medida alterada com sucesso", false);
            }
            return new ResponseDefault("", "Erro ao tentar alterada Unidade de Medida", true);
        }

        public virtual async Task<ResponseDefault> DeleteAsync(Guid id)
        {
            string strQuery = $"delete from unity where id = '{id}'";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.ExecuteAsync(strQuery);
                if (result > 0)
                    return new ResponseDefault(id.ToString(), "Unidade de Medida excluída com sucesso", false);
            }
            return new ResponseDefault("", "Erro ao tentar excluír Unidade de Medida", true);
        }

        public virtual async Task<UnityEntity> GetByIdAsync(Guid id)
        {
            string strQuery = $"select id, name, active from unity where id = '{id}'";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<UnityEntity>(strQuery);
                return result;
            }
        }

        public virtual async Task<UnityEntity> GetUnityByNameAsync(string name)
        {
            string strQuery = $"select id, name, active from unity where name = '{name}' limit 1";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<UnityEntity>(strQuery);
                return result;
            }
        }

        public virtual async Task<PaginationResponse<UnityEntity>> GetByFilterAsync(UnityGetFilterRequest filter)
        {
            var _sql = new StringBuilder("select id, name, active from unity where 1=1");
            var _where = new StringBuilder();

            if (!string.IsNullOrEmpty(filter.Name))
                _where.Append($" AND name = '{filter.Name}'");

            if (filter.Active != "todos")
            {
                string _booleanField = "";
                if (filter.Active == "ativos")
                    _booleanField = " AND active = true";
                else if (filter.Active == "inativos")
                    _booleanField = " AND active = false";

                _where.Append(_booleanField);
            }
            _sql.Append(_where);

            if (filter.page > 0 && filter.pageSize > 0)
                _sql.Append($" limit {filter.pageSize * (filter.page - 1)}, {filter.pageSize}");

            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryAsync<UnityEntity>(_sql.ToString());
                var resultCount = await cnx.QueryAsync<int>("select count(*) from unity where 1=1" + _where.ToString());
                var totalRows = resultCount.FirstOrDefault();

                return new PaginationResponse<UnityEntity>
                {
                    Items = result.ToArray(),
                    _pageSize = filter.pageSize,
                    _page = filter.page,
                    _total = totalRows
                };
            }

        }

    }
}
