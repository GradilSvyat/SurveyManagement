using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class Question
    {
        private int Id { get; set; }
        private int Survey_id { get; set; }
        public string Text { get; set; }
        public string Coment { get; set; }

        public Question (int Id, string Text, string Coment, int Survey_id)
        {
            this.Id = Id;
            this.Text = Text;
            this.Coment = Coment;
            this.Survey_id = Survey_id;
        }
        public List<Question> SelectQuestion(int Survey_id)
        {
            string sqlExpression = "SELECT * FROM Questions WERE Survey_id=@Survey_id";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter Survey_idParam = new SqlParameter("Survey_id", Survey_id);
                command.Parameters.Add(Survey_idParam);
                SqlDataReader reader = command.ExecuteReader();
                List<Question> questions = new List<Question>();
                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Text = reader.GetString(1);
                    string Coment = reader.GetString(2);
                    questions.Add(new Question(Id, Text, Coment, Survey_id));
                }
                return questions;
            }
        }
        public int AddQuestion(string Text, string Coment, int Survey_id)
        {
            string sqlExpression = "INSERT INTO Questions (Text, Coment, Survey_id) VALUES (@Text, @Coment, @Survey_id)";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter textParam = new SqlParameter("@Text", Text);
                command.Parameters.Add(textParam);
                SqlParameter comentParam = new SqlParameter("@Coment", Coment);
                command.Parameters.Add(comentParam);
                SqlParameter Survey_idParam = new SqlParameter("@Survey_id", Survey_id);
                command.Parameters.Add(Survey_idParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int AddQuestion(string Text, int Survey_id)
        {
            string sqlExpression = "INSERT INTO Questions (Text, Survey_id) VALUES (@Text, @Survey_id)";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter textParam = new SqlParameter("@Text", Text);
                command.Parameters.Add(textParam);
                SqlParameter Survey_idParam = new SqlParameter("@Survey_id", Survey_id);
                command.Parameters.Add(Survey_idParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int UpdateTextQuestion(int Id, string Text)
        {
            string sqlExpression = "UPDATE Questions SET Text=@Text WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter textParam = new SqlParameter("@Text", Text);
                command.Parameters.Add(textParam);
                SqlParameter idParam = new SqlParameter("@Id", Id);
                command.Parameters.Add(idParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int UpdateComentQuestion(int Id, string Coment)
        {
            string sqlExpression = "UPDATE Questions SET Coment=@Coment WHERE Id=@Id";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter comentParam = new SqlParameter("@Coment", Coment);
                command.Parameters.Add(comentParam);
                SqlParameter idParam = new SqlParameter("@Id", Id);
                command.Parameters.Add(idParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int DeleteQuestion(int Id)
        {
            string sqlExpression = "DELETE  FROM Questions WHERE Id=@Id";
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
