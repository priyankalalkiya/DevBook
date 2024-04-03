using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Developer_book.Models
{
    public class ExperienceModel
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\c#\Developer-book\Developer-book\App_Data\Database1.mdf;Integrated Security=True";

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Job Title is required")]
        [StringLength(30)]
        public string jobtitle { get; set; }

        [Required(ErrorMessage = "Company is required")]
        [StringLength(30)]
        public string company { get; set; }

        [StringLength(30)]
        public string location { get; set; }

        [StringLength(100)] // Adjust the length according to your requirements
        public string description { get; set; } 
        public void AddExperience(ExperienceModel exp)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Experience (jobtitle, company, location, description) " +
                                         "VALUES (@jobtitle, @company, @location, @description)"; // Changed 'desc' to '[desc]'

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@jobtitle", exp.jobtitle);
                        cmd.Parameters.AddWithValue("@company", exp.company);
                        cmd.Parameters.AddWithValue("@location", exp.location);
                        cmd.Parameters.AddWithValue("@description", exp.description); 

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle the exception or log it for debugging
                throw ex;
            }
        }
    }
}
