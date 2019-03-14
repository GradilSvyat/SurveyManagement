using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyManagement.Models
{
    public class Variants_answer
    {
        private int Id { get; set; }
        private int Question_id { get; set; }
        public string Text { get; set; }


        public Variants_answer(int Id, string Text, int Question_id)
        {
            this.Id = Id;
            this.Text = Text;
            this.Question_id = Question_id;
        }
        public List<Variants_answer> SelectVariants_answer(int Question_id)
        {
            string sqlExpression = "SELECT * FROM Variants_answers WERE Question_id=@Question_id";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter Question_idParam = new SqlParameter("Question_id", Question_id);
                command.Parameters.Add(Question_idParam);
                SqlDataReader reader = command.ExecuteReader();
                List<Variants_answer> variants_answers = new List<Variants_answer>();
                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Text = reader.GetString(1);
                    variants_answers.Add(new Variants_answer(Id, Text, Question_id));
                }
                return variants_answers;
            }
        }
        public int AddVariants_answer(string Text, int Question_id)
        {
            string sqlExpression = "INSERT INTO Variants_answers (Text, Question_id) VALUES (@Text, @Question_id)";
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                SqlParameter textParam = new SqlParameter("@Text", Text);
                command.Parameters.Add(textParam);
                SqlParameter Question_idParam = new SqlParameter("@Question_id", Question_id);
                command.Parameters.Add(Question_idParam);
                int number = command.ExecuteNonQuery();
                return number;
            }
        }
        public int UpdateVariants_answer(int Id, string Text)
        {
            string sqlExpression = "UPDATE Variants_answers SET Text=@Text WHERE Id=@Id";
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
        public int DeleteVariants_answer(int Id)
        {
            string sqlExpression = "DELETE  FROM Variants_answers WHERE Id=@Id";
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
