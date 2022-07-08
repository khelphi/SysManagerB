using Dapper;
using SysManager.Application.Contracts;
using SysManager.Application.Data.MySql.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SysManager.Application.Data.MySql.Repositories
{
    public class UserRepository
    {
        private readonly MySqlContext _context;
        public UserRepository(MySqlContext ctt)
        {
            this._context = ctt;
        }

        public async Task<ResponseDefault> PostAsync(UserEntity entity)
        {
            var _query = @$"insert into user(id, username, email, password, active)
                            value (@id, @username, @email, @password, @active)";

            using (var cnx = _context.Connection())
            {
                var mapper = new
                {
                    id = entity.Id,
                    username = entity.UserName,
                    email = entity.Email,
                    password = entity.Password,
                    active = entity.Active
                };
                var result = await cnx.ExecuteAsync(_query, mapper);

                if (result > 0)
                    return new ResponseDefault(entity.Id.ToString(), "Usuário criado com sucesso", false);
            }
            return new ResponseDefault("", "Erro ao criar usuário", true);
        }

        public async Task<ResponseDefault> RecoveryAsync(Guid id, string newpassword)
        {
            var _query = $"update user set password = '{newpassword}' where id = '{id}' and active = true";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.ExecuteAsync(_query);
                if (result > 0)
                    return new ResponseDefault(id.ToString(), "senha do usuário alterada com sucesso", false);
            }
            return new ResponseDefault("", "Erro ao tentar alterar senha de usuário", true);
        }
        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            var _query = $"select id, username, email, password, active from user where email = '{email}' and active = true limit 1";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<UserEntity>(_query);
                return result;
            }
        }

        public async Task<UserEntity> GetUserByCredentialsAsync(string email, string password)
        {
            var _query = $"select id, username, email, password, active from user where email = '{email}' and password = '{password}' and active = true limit 1";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<UserEntity>(_query);
                return result;
            }
        }

        public async Task<UserEntity> GetUserByUserNameAndPasswordAsync(string username, string password)
        {
            var _query = $"select id, username, email, password, active from user where username = '{username}' and password = '{password}' limit 1";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<UserEntity>(_query);
                return result;
            }
        }
        public async Task<UserEntity> GetUserByUserNameAndEmailAsync(string username, string email)
        {
            var _query = $"select id, username, email, password, active from user where username = '{username}' and email = '{email}' limit 1";
            using (var cnx = _context.Connection())
            {
                var result = await cnx.QueryFirstOrDefaultAsync<UserEntity>(_query);
                return result;
            }
        }



    }
}
