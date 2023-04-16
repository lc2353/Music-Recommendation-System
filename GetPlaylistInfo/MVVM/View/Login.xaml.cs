using System;
using System.Data.SqlClient;
using System.Windows;

namespace GetPlaylistInfo.MVVM.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static string Username { get; set; }
        public static int UserId { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        static readonly SqlConnection conn = new(@"Data Source=DESKTOP-6HB3967;Initial Catalog=recommendationSystem;Integrated Security=True");

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Username = txtUsername.Text;
            bool present = CheckUsername();
            if (present)
            {
                GetUserId();
                Dashboard dashboard = new();
                dashboard.Show();
                this.Close();

            }
            else
            {
                MessageBox.Show("Invalid Username or Password, Please Try Again", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                txtUsername.Clear();
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Register register = new();
            register.Show();
            this.Close();
        }

        bool CheckUsername()
        {
            try
            {
                bool present = false;
                conn.Open();
                SqlCommand login = new("SELECT * FROM users WHERE username=@username and password=@password ", conn);
                login.Parameters.AddWithValue("@password", txtPassword.Password);
                login.Parameters.AddWithValue("@username", txtUsername.Text);
                SqlDataReader reader = login.ExecuteReader();

                if (reader.Read() == true) present = true;
                conn.Close();
                return present;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return false;
            }
        }

        static void GetUserId()
        {
            string query = "SELECT * FROM users WHERE username=@username";
            try
            {
                conn.Open();
                using SqlCommand getUserId = new(query, conn);
                getUserId.Parameters.AddWithValue("@username", Login.Username);
                UserId = Convert.ToInt32(getUserId.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                conn.Close();
            }
        }
    }
}
