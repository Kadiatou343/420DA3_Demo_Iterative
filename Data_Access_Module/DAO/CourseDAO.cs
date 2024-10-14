using _420DA3_Demo_Iterative.Domain;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Module.DAO
{
    public class CourseDAO
    {
        private SqlConnection connection;
        private string tableName = "Courses";
        private DataTable table;
        private SqlDataAdapter dataAdapter;

        public CourseDAO()
        {
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

            DataColumn idColumn = this.table.Columns["Id"] ?? throw new Exception("Colonne 'Id' dans la dataTable");
            DataColumn nameColumn = this.table.Columns["Name"] ?? throw new Exception("Colonne 'Name' dans la dataTable");
            DataColumn codeColumn = this.table.Columns["Code"] ?? throw new Exception("Colonne 'Code' dans la dataTable");
            DataColumn durationColumn = this.table.Columns["Duration"] ?? throw new Exception("Colonne 'Duration' dans la dataTable");
            DataColumn createdDateColumn = this.table.Columns["DateCreated"] ?? throw new Exception("Colonne 'DateCreated' non trouvee dans la dataTable!");
            DataColumn modifiedDateColumn = this.table.Columns["DateModified"] ?? throw new Exception("Colonne 'DateModified' non trouvee dans la dataTable!");
            DataColumn deletedDateColumn = this.table.Columns["DateDeleted"] ?? throw new Exception("Colonne 'DateDeleted non trouvee dans la dataTable!");

            idColumn.AutoIncrement = true;
            idColumn.AutoIncrementSeed = -1;
            idColumn.AutoIncrementStep = -1;
            idColumn.ReadOnly = true;

            nameColumn.MaxLength = 164;
            codeColumn.MaxLength = 15;

            createdDateColumn.ReadOnly = true;
            modifiedDateColumn.ReadOnly = true;
            modifiedDateColumn.AllowDBNull = true;
            deletedDateColumn.ReadOnly = true;
            deletedDateColumn.AllowDBNull = true;
        }

        public void SaveChanges()
        {
            if (this.connection.State != ConnectionState.Open)
            {
                this.connection.Open();
            }

            try
            {
                this.dataAdapter.Update(table);
            }
            catch(DBConcurrencyException dbexc)
            {
                dbexc.Row?.RejectChanges();
                dbexc.Row?.ClearErrors();
                MessageBox.Show($"Erreur de concurrence sur la ligne {dbexc.Row?["Id"]} . Les chnagements ont ete annules ");
            }


        }

        private SqlDataAdapter CreateDataAdapter()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter.RowUpdating += OnRowUpdating;

            SqlCommand selectCommand = this.connection.CreateCommand();
            selectCommand.CommandText = $"SELECT * FROM {this.tableName} ;";
            adapter.SelectCommand = selectCommand;

            SqlCommand insertCommand = this.connection.CreateCommand();
            insertCommand.CommandText = $"INSERT INTO {this.tableName} (Name, Code, Duration) " +
                $"VALUES (@name, @code, @duration); SELECT * FROM {this.tableName} WHERE Id = SCOPE_IDENTITY()";

            insertCommand.Parameters.Add("@name", SqlDbType.NVarChar, 164, "Name");
            insertCommand.Parameters.Add("@code", SqlDbType.NVarChar, 15, "Code");
            insertCommand.Parameters.Add("@duration", SqlDbType.Int, 4, "Duration");

            insertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
            adapter.InsertCommand = insertCommand;
            

            SqlCommand updateCommand = this.connection.CreateCommand();
            updateCommand.CommandText = $"UPDATE {this.tableName} SET Name = @name, Code = @code, " +
                $"Duration = @duration, " +
                $"DateModified = @dateModified " +
                $"WHERE Id = @id " +
                $"AND (DateModified IS NULL OR DateModified = @oldDateModified) ;";

            updateCommand.Parameters.Add("@name", SqlDbType.NVarChar, 164, "Name");
            updateCommand.Parameters.Add("@code", SqlDbType.NVarChar, 15, "Code");
            updateCommand.Parameters.Add("@duration", SqlDbType.Int, 4, "Duration");
            updateCommand.Parameters.Add("@dateModified", SqlDbType.DateTime2, 7, "DateModified");
            updateCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");
            updateCommand.Parameters.Add("@oldDateModified", SqlDbType.DateTime2, 7, "DateModified").SourceVersion = DataRowVersion.Original;
            //updateCommand.Parameters.Add("@oldName", SqlDbType.NVarChar, 164, "Name").SourceVersion = DataRowVersion.Original;
            //updateCommand.Parameters.Add("@oldCode", SqlDbType.NVarChar, 15, "Code").SourceVersion = DataRowVersion.Original;
            //updateCommand.Parameters.Add("@oldDuration", SqlDbType.Int, 4, "Name").SourceVersion = DataRowVersion.Original;

            adapter.UpdateCommand = updateCommand;

            SqlCommand deleteCommand = this.connection.CreateCommand();
            deleteCommand = this.connection.CreateCommand();
            deleteCommand.CommandText = $"DELETE * FROM {this.tableName} WHERE Id = @id";

            deleteCommand.Parameters.Add("@id", SqlDbType.Int, 4, "Id");

            adapter.DeleteCommand = deleteCommand;

            return adapter;

        }

        private void OnRowUpdating(object sender, SqlRowUpdatingEventArgs args)
        {
            if (args.StatementType == StatementType.Update)
            {
                args.Command.Parameters["@dateModified"].Value = DateTime.Now;
            }
        }

        /*

        public List<Course> GetAll(SqlTransaction? transaction = null)
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

            List<Course> courses = new List<Course>();

            while (reader.Read())
            {
                int db_id = reader.GetInt32(0);
                string name = reader.GetString(1);
                string code = reader.GetString(2);
                int duration = reader.GetInt32(3);
                DateTime dateCreated = reader.GetDateTime(4);
                DateTime? dateModified = reader.GetValue(5) == DBNull.Value ? null : reader.GetDateTime(5);
                DateTime? dateDeleted = reader.GetValue(6) == DBNull.Value ? null : reader.GetDateTime(6);

                Course course = new Course(db_id, name, code, duration, dateCreated, dateModified, dateDeleted);
                courses.Add(course);
            }

            reader.Close();

            return courses;
        }

        public Course GetById(int id, SqlTransaction? transaction = null)
        {
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

            if (!reader.Read())
            {
                throw new Exception($"No Database record found for Course Id #{id}");
            }

            int db_id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string code = reader.GetString(2);
            int duration = reader.GetInt32(3);
            DateTime dateCreated = reader.GetDateTime(4);
            DateTime? dateModified = reader.GetValue(5) == DBNull.Value ? null : reader.GetDateTime(5);
            DateTime? dateDeleted = reader.GetValue(6) == DBNull.Value ? null : reader.GetDateTime(6);

            reader.Close();

            return new Course(db_id, name, code, duration, dateCreated, dateModified, dateDeleted);

        }

        public Course Create(Course courseDto, SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            string sqlQuery = $"INSERT INTO {this.tableName} (Name, Code, Duration) " +
                $"VALUES (@name, @code, @duration); SELECT SCOPE_IDENTITY;";
            SqlCommand insertCommand = conn.CreateCommand();
            insertCommand.CommandText = sqlQuery;

            SqlParameter nameParam = insertCommand.CreateParameter();
            nameParam.ParameterName = "@name";
            nameParam.Value = courseDto.Name;
            nameParam.DbType = System.Data.DbType.String;
            insertCommand.Parameters.Add(nameParam);

            SqlParameter codeParam = insertCommand.CreateParameter();
            codeParam.ParameterName = "@code";
            codeParam.Value = courseDto.Code;
            codeParam.DbType = System.Data.DbType.String;
            insertCommand.Parameters.Add(codeParam);

            SqlParameter durationParam = insertCommand.CreateParameter();
            durationParam.ParameterName = "@duration";
            durationParam.Value = courseDto.Duration;
            durationParam.DbType = System.Data.DbType.Int32;
            insertCommand.Parameters.Add(durationParam);

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

        public Course Update(Course courseDto, SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            string sqlQuery = $"UPDATE {this.tableName} SET Name = @name, Code = @code, " +
                $"Duration = @duration WHERE Id = @id;";
            SqlCommand updateCommand = conn.CreateCommand();
            updateCommand.CommandText = sqlQuery;

            SqlParameter nameParam = updateCommand.CreateParameter();
            nameParam.ParameterName = "@name";
            nameParam.Value = courseDto.Name;
            nameParam.DbType = System.Data.DbType.String;
            updateCommand.Parameters.Add(nameParam);

            SqlParameter codeParam = updateCommand.CreateParameter();
            codeParam.ParameterName = "@code";
            codeParam.Value = courseDto.Code;
            codeParam.DbType = System.Data.DbType.String;
            updateCommand.Parameters.Add(codeParam);

            SqlParameter durationParam = updateCommand.CreateParameter();
            durationParam.ParameterName = "@duration";
            durationParam.Value = courseDto.Duration;
            durationParam.DbType = System.Data.DbType.Int32;
            updateCommand.Parameters.Add(durationParam);

            SqlParameter idParam = updateCommand.CreateParameter();
            idParam.ParameterName = "@id";
            idParam.Value = courseDto.Id;
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

            if (rowsModified == 0)
            {
                throw new Exception($"Failure to update Course Id #{courseDto.Id}. No rows modified");
            }

            return this.GetById(courseDto.Id, transaction);
        }

        public void Delete(Course courseDto, SqlTransaction? transaction = null)
        {
            SqlConnection conn = transaction?.Connection ?? this.connection;
            string sqlQuery = $"DELETE * FROM {this.tableName} WHERE Id = @id";
            SqlCommand deleteCommand = conn.CreateCommand();
            deleteCommand.CommandText = sqlQuery;

            SqlParameter idParam = deleteCommand.CreateParameter();
            idParam.ParameterName = "@id";
            idParam.Value = courseDto.Id;
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
                throw new Exception($"Failure to delete Course Id #{courseDto.Id}. No rows modified");
            }
        }

        */
    }
}
