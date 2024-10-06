using _420DA3_Demo_Iterative.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Data_Access_Module.DAO
{
    public class StudentDAO
    {
        private SqlConnection connection;
        private string tableName = "Students";
        private string dateTimeFormat = "yyyy-MM-dd HH:mm:ss.ffffff";
        private DataTable table;
        private SqlDataAdapter dataAdapter;

        public StudentDAO() {
            this.connection = DbConnectionProvider.GetConnexion();
            this.table = new DataTable(this.tableName);
            this.dataAdapter = this.CreateDataAdapter();
        }

        public DataTable GetDataTable()
        {
            return this.table;
        }

        public void ReloadDataTable()
        {
            this.table.Clear();
            this.dataAdapter.Fill(table);
        }

        public void SaveChanges()
        {
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }

            this.dataAdapter.Update(table);

        }

        private SqlDataAdapter CreateDataAdapter()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            return adapter;

            //config du DataAdapater a faire

        }

        /*

        public List<Student> GetAll(SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            SqlCommand getAllCommand = conn.CreateCommand();
            getAllCommand.CommandText = $"SELECT * FROM {this.tableName};";

            if (transaction != null)
            {
                getAllCommand.Transaction = transaction;
            }

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            SqlDataReader reader = getAllCommand.ExecuteReader();

            List<Student> students = new List<Student>();

            while (reader.Read())
            {
                int db_id = reader.GetInt32(0);
                string firstName = reader.GetString(1);
                string lastName = reader.GetString(2);
                string code = reader.GetString(3);
                DateTime registrationDate = reader.GetDateTime(4);
                DateTime dateCreated = reader.GetDateTime(5);
                DateTime? dateModified = reader.GetValue(6) == DBNull.Value ? null : reader.GetDateTime(6);
                DateTime? dateDeleted = reader.GetValue(7) == DBNull.Value ? null : reader.GetDateTime(7);

                Student student = new Student(db_id, firstName, lastName, code, registrationDate, dateCreated, dateModified, dateDeleted);
                students.Add(student);
            }

            reader.Close();

            return students;
        }

        public Student GetById(int id, SqlTransaction? transaction = null) {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = $"SELECT * FROM {this.tableName} WHERE Id = @id;";

            SqlParameter idParam = cmd.CreateParameter();
            idParam.ParameterName = "@id";
            idParam.Value = id;
            idParam.DbType = System.Data.DbType.Int32;
            cmd.Parameters.Add(idParam);

            if (transaction != null)
            {
                cmd.Transaction = transaction;
            }

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            SqlDataReader reader = cmd.ExecuteReader();
            
            if (!reader.Read()) {
                throw new Exception($"No Database record found for Student Id #{id}");
            }

            int db_id = reader.GetInt32(0);
            string firstName = reader.GetString(1);
            string lastName = reader.GetString(2);
            string code = reader.GetString(3);
            DateTime registrationDate = reader.GetDateTime(4);
            DateTime dateCreated = reader.GetDateTime(5);
            DateTime? dateModified = reader.GetValue(6) == DBNull.Value ? null : reader.GetDateTime(6);
            DateTime? dateDeleted = reader.GetValue(7) == DBNull.Value ? null : reader.GetDateTime(7);

            reader.Close();

            return new Student(db_id, firstName, lastName, code, registrationDate, dateCreated, dateModified, dateDeleted);
        }

        public Student Create(Student studentDto, SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            string sqlQuery = $"INSERT INTO {this.tableName} (FirstName, LastName, Code, RegistrationDate) " +
                "VALUE (@firstName, @lastName, @code, @registrationDate); SELECT SCOPE_IDENTITY();";
            SqlCommand insertCommand = conn.CreateCommand();
            insertCommand.CommandText = sqlQuery;

            SqlParameter firstNameParam = insertCommand.CreateParameter();
            firstNameParam.ParameterName = "@firstName";
            firstNameParam.Value = studentDto.FirstName;
            firstNameParam.DbType = System.Data.DbType.String;
            insertCommand.Parameters.Add(firstNameParam);

            SqlParameter lastNameParam = insertCommand.CreateParameter();
            lastNameParam.ParameterName = "@lastName";
            lastNameParam.Value = studentDto.LastName;
            lastNameParam.DbType = System.Data.DbType.String;
            insertCommand.Parameters.Add(lastNameParam);

            SqlParameter codeParam = insertCommand.CreateParameter();
            codeParam.ParameterName = "@code";
            codeParam.Value = studentDto.Code;
            codeParam.DbType = System.Data.DbType.String;
            insertCommand.Parameters.Add(codeParam);

            SqlParameter regDateParam = insertCommand.CreateParameter();
            regDateParam.ParameterName = "@registrationDate";
            regDateParam.Value = studentDto.RegistrationDate;
            regDateParam.DbType = System.Data.DbType.DateTime2;
            insertCommand.Parameters.Add(regDateParam);

            if (transaction != null)
            {
                insertCommand.Transaction = transaction;
            }

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            int createdId = (int)insertCommand.ExecuteScalar();

            return this.GetById(createdId, transaction);
        }

        public Student Update(Student studentDto, SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            string sqlQuery = $"UPDATE {this.tableName} SET FirstName = @firstName , LastName = @lastName , Code = @code , RegistrationDate = @registrationDate WHERE Id = @id;";
            SqlCommand updateCommand = conn.CreateCommand();
            updateCommand.CommandText = sqlQuery;


            SqlParameter firstNameParam = updateCommand.CreateParameter();
            firstNameParam.ParameterName = "@firstName";
            firstNameParam.Value = studentDto.FirstName;
            firstNameParam.DbType = System.Data.DbType.String;
            updateCommand.Parameters.Add(firstNameParam);

            SqlParameter lastNameParam = updateCommand.CreateParameter();
            lastNameParam.ParameterName = "@lastName";
            lastNameParam.Value = studentDto.LastName;
            lastNameParam.DbType = System.Data.DbType.String;
            updateCommand.Parameters.Add(lastNameParam);

            SqlParameter codeParam = updateCommand.CreateParameter();
            codeParam.ParameterName = "@code";
            codeParam.Value = studentDto.Code;
            codeParam.DbType = System.Data.DbType.String;
            updateCommand.Parameters.Add(codeParam);

            SqlParameter regDateParam = updateCommand.CreateParameter();
            regDateParam.ParameterName = "@registrationDate";
            regDateParam.Value = studentDto.RegistrationDate;
            regDateParam.DbType = System.Data.DbType.DateTime2;
            updateCommand.Parameters.Add(regDateParam);

            SqlParameter idParam = updateCommand.CreateParameter();
            idParam.ParameterName = "@id";
            idParam.Value = studentDto.Id;
            idParam.DbType = System.Data.DbType.Int32;
            updateCommand.Parameters.Add(idParam);

            if (transaction != null)
            {
                updateCommand.Transaction = transaction;
            }

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            int rowsModified = updateCommand.ExecuteNonQuery();

            if (rowsModified == 0) {
                throw new Exception($"Failure to update Student Id #{studentDto.Id}. No rows modified");
            }

            return this.GetById(studentDto.Id, transaction);

        }

        public void Delete(Student studentDto, SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            string sqlQuery = $"DELETE FROM {this.tableName} WHERE Id = @id;";
            SqlCommand deleteCommand = conn.CreateCommand();
            deleteCommand.CommandText = sqlQuery;

            SqlParameter idParam = deleteCommand.CreateParameter();
            idParam.ParameterName = "@id";
            idParam.Value = studentDto.Id;
            idParam.DbType = System.Data.DbType.Int32;
            deleteCommand.Parameters.Add(idParam);

            if (transaction != null)
            {
                deleteCommand.Transaction = transaction;
            }

            if (conn.State != System.Data.ConnectionState.Open)
            {
                conn.Open();
            }

            int rowsModified = deleteCommand.ExecuteNonQuery();

            if (rowsModified == 0)
            {
                throw new Exception($"Failure to delete Student Id #{studentDto.Id}. No rows modified");
            }

        }

        */
    }
}
