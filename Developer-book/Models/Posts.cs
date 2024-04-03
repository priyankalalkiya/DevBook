using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Developer_book.Models
{
    public class Posts
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Post content is required")]
        [StringLength(50)]
        public string Content { get; set; }

        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\c#\Developer-book\Developer-book\App_Data\Database1.mdf;Integrated Security=True";

        // Method to insert data into the database
        public void AddPost(Posts post)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertQuery = "INSERT INTO Posts (Content) " +
                                     "VALUES (@Content)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Content", post.Content);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
