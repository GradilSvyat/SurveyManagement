using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class Survey
    {
        private int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public DateTime Date { get; set; }
        public Survey (int Id, string Name, string Creator, DateTime Date)
        {
            this.Id = Id;
            this.Name = Name;
            this.Creator = Creator;
            this.Date = Date;
        }
        public List<Survey> ShowSurveys()
        {
            string sqlExpression = "SELECT * FROM Survey";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Survey> surveys = new List<Survey>();
                    while (reader.Read())
                    {
                    int Id = reader.GetInt32(0);
                    string Name = reader.GetString(1);
                    string Creator = reader.GetString(2);
                    DateTime Date = reader.GetDateTime(3);
                    surveys.Add(new Survey(Id, Name, Creator, Date));
                    }
                reader.Close();
                return surveys;
            }
        }
        public Survey SelectSurvey(int Id)
        {
            string sqlExpression = "SELECT * FROM Survey WERE Id=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@Id", Id);
                command.Parameters.Add(idParam);
                SqlDataReader reader = command.ExecuteReader();
                    string Name = reader.GetString(1);
                    string Creator = reader.GetString(2);
                    DateTime Date = reader.GetDateTime(3);
                return new Survey(Id, Name, Creator, Date);
            }
        }
        public int AddSurvey(string Name, string Creator, DateTime Date)
        {
            string sqlExpression = "INSERT INTO Surveys (Name, Creator, Date) VALUES (@Name, @Creator, @Date)";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@Name", Name);
                command.Parameters.Add(nameParam);
                SqlParameter creatorParam = new SqlParameter("@Creator", Creator);
                command.Parameters.Add(creatorParam);
                SqlParameter dateParam = new SqlParameter("@Date", Date);
                command.Parameters.Add(dateParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int AddSurvey(string Name, string Creator)
        {
            string sqlExpression = "INSERT INTO Surveys (Name, Creator) VALUES (@Name, @Creator)";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@Name", Name);
                command.Parameters.Add(nameParam);
                SqlParameter creatorParam = new SqlParameter("@Creator", Creator);
                command.Parameters.Add(creatorParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int UpdateSurvey(int Id, string Name)
        {
            string sqlExpression = "UPDATE Surveys SET Name=@Name WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter nameParam = new SqlParameter("@Name", Name);
                command.Parameters.Add(nameParam);
                SqlParameter idParam = new SqlParameter("@Id", Id);
                command.Parameters.Add(idParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int UpdateSurvey(int Id, DateTime Date)
        {
            string sqlExpression = "UPDATE Surveys SET Date=@Date WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter dateParam = new SqlParameter("@Date", Date);
                command.Parameters.Add(dateParam);
                SqlParameter idParam = new SqlParameter("@Id", Id);
                command.Parameters.Add(idParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int DeleteSurvey(int Id)
        {
            string sqlExpression = "DELETE  FROM Surveys WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter idParam = new SqlParameter("@Id", Id);
                command.Parameters.Add(idParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
    }
}
