using Microsoft.EntityFrameworkCore;
using RestWithAspNet.Model.Base;
using RestWithAspNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithAspNet.Repository.Generic
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected MySQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MySQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public T Create(T item)
        {
            try
            {
                _dataset.Add(item);
                _context.SaveChanges();

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T Update(T item)
        {
            if (!Existis(item.Id)) return null;

            var result = _dataset.SingleOrDefault(p => p.Id.Equals(item.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(item);
                    _context.SaveChanges();

                    return result;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                return null;
            }
        }

        public void Delete(long id)
        {
            var result = _dataset.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                _dataset.Remove(result);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool Existis(long id)
        {
            return _dataset.Any(p => p.Id.Equals(id));
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }

        public T FindById(long id)
        {
            return _dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return _dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";

            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    result = command.ExecuteScalar().ToString();
                }
            }

            return int.Parse(result);
        }
    }
}
