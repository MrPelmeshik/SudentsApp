using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentsApp.Models;
using Dapper;
using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;

namespace StudentsApp.Repository
{
    public class StudentRepository : IRepository
    {
        private string connectionString;
        public StudentRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Student item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Students (first_name,last_name,email) VALUES(@first_name,@last_name,@email)", item);
            }

        }

        public IEnumerable<Student> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Student>("SELECT * FROM Students");
            }
        }

        public Student FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Student>("SELECT * FROM Students WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Students WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(Student item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Students SET first_name = @first_name,  last_name  = @last_name, email= @email WHERE id = @Id", item);
            }
        }
    }
}
