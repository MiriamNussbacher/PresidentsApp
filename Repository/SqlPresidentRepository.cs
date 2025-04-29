using Dapper;
using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class SqlPresidentRepository: IPresidentRepository
    { 
        private readonly SqlConnection _connection;

        public SqlPresidentRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<President>> GetPresidentsAsync()
        {
            await _connection.OpenAsync();
            // Implement SQL query to fetch Presidents from the database
            var presidents = await _connection.QueryAsync<President>("SELECT * FROM Presidents");
            _connection.Close();
            return presidents;
        }

        public async Task<President> GetPresidentByIdAsync(int id)
        {
            await _connection.OpenAsync();
            // Implement SQL query to fetch a President by ID from the database
            var president = await _connection.QueryFirstOrDefaultAsync<President>("SELECT * FROM Presidents WHERE Id = @Id", new { Id = id });
            _connection.Close();
            return president;
        }

        public async Task AddPresidentAsync(President president)
        {
            await _connection.OpenAsync();
            // Implement SQL query to insert a President into the database
            await _connection.ExecuteAsync("INSERT INTO Presidents (Name, Birthdate, InaugurationDate, TermCount) VALUES (@Name, @Birthdate, @InaugurationDate, @TermCount)", president);
            _connection.Close();
        }

        public async Task UpdatePresidentAsync(President president)
        {
            await _connection.OpenAsync();
            // Implement SQL query to update a President in the database
            await _connection.ExecuteAsync("UPDATE Presidents SET Name = @Name, Birthdate = @Birthdate, InaugurationDate = @InaugurationDate, TermCount = @TermCount WHERE Id = @Id", president);
            _connection.Close();
        }

        public async Task DeletePresidentAsync(int id)
        {
            await _connection.OpenAsync();
            // Implement SQL query to delete a President by ID from the database
            await _connection.ExecuteAsync("DELETE FROM Presidents WHERE Id = @Id", new { Id = id });
            _connection.Close();
        }
    }

}
