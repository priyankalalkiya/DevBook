using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace Developer_book.Models
{
    public class ProfileModel
    {
        private readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\c#\Developer-book\Developer-book\App_Data\Database1.mdf;Integrated Security=True";

        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string status { get; set; }

        [StringLength(50)]
        public string company { get; set; }

        [StringLength(255)]
        public string website { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [Required]
        [StringLength(50)]
        public string field { get; set; }

        [StringLength(50)]
        public string githubname { get; set; }

        [StringLength(255)]
        public string bio { get; set; }

        public void CreateProfile(ProfileModel profile)
        {
            using (SqlConnection connect = new SqlConnection(connectionString))
            {
                connect.Open();

                string insertQuery = "INSERT INTO tbl_Profile (status, company, website, city, field, githubname, bio) " +
                                     "VALUES (@status, @company, @website, @city, @field, @githubname, @bio)";

                using (SqlCommand cmd = new SqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("@status", profile.status);
                    cmd.Parameters.AddWithValue("@company", profile.company);
                    cmd.Parameters.AddWithValue("@website", profile.website);
                    cmd.Parameters.AddWithValue("@city", profile.city);
                    cmd.Parameters.AddWithValue("@field", profile.field);
                    cmd.Parameters.AddWithValue("@githubname", profile.githubname);
                    cmd.Parameters.AddWithValue("@bio", profile.bio);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
