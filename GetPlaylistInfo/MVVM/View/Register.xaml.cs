using System.Data.SqlClient;
using System.Linq;
using System.Windows;


namespace GetPlaylistInfo.MVVM.View
{
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        static readonly SqlConnection conn = new(@"Data Source=DESKTOP-6HB3967;Initial Catalog=recommendationSystem;Integrated Security=True");

    

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text == "" | txtPassword.Password == "" || txtConPassword.Password == "")
            {
                MessageBox.Show("One or more fields are empty", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txtPassword.Password == txtConPassword.Password)
            {
                bool u = UniqueCheck(txtUsername.Text);
                bool v = ValidationCheck(txtConPassword.Password);
                if (!(u && v)) //if they are both false
                {
                    if (!u)
                    {
                        MessageBox.Show("This username already exists, please choose a new one.", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtUsername.Clear();
                        txtUsername.Focus();
                    }

                    if (!v)
                    {
                        MessageBox.Show("Your password must be between 8 and 14 characters, include at least one number or special character, and a mixture of upper and lowercase letters.", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtPassword.Clear();
                        txtConPassword.Clear();

                    }

                }
                else
                {
                    conn.Open();
                    SqlCommand register = new()
                    {
                        Connection = conn,
                        CommandText = "INSERT INTO users VALUES (@username, @password, @admin)"
                    };
                    register.Parameters.AddWithValue("@username", txtUsername.Text);
                    register.Parameters.AddWithValue("@password", txtPassword.Password);
                    register.Parameters.AddWithValue("@admin", "0");
                    register.ExecuteNonQuery();
                    conn.Close();

                    txtUsername.Clear();
                    txtPassword.Clear();
                    txtConPassword.Clear();

                    MessageBox.Show("Your account has been successfuly created", "Registration Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoginPage();
                }
            }

            else
            {
                MessageBox.Show("Passwords do not match, please re-enter", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Clear();
                txtConPassword.Clear();
                txtPassword.Focus();
            }
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginPage();
        }

        static bool UniqueCheck(string username)
        {
            conn.Open();
            SqlCommand unique = new("SELECT * FROM users WHERE username=@username ", conn);
            unique.Parameters.AddWithValue("@username", username); 
            SqlDataReader reader = unique.ExecuteReader();

            if (reader.Read() == true)
            {
                conn.Close();
                return false;
            }
            else
            {
                conn.Close();
                return true;
            }

        }
        static bool ValidationCheck(string password)
        {
            int error = 0;
            if (password.Length < 8 || password.Length > 14) error++;
            if (!password.Any(char.IsLower)) error++;
            if (!password.Any(char.IsUpper)) error++;
            if (!password.Any(char.IsPunctuation)) error++;
            if (password.Any(char.IsWhiteSpace)) error++;
            if (!password.Any(char.IsDigit)) error++;

            if (error == 0) return true;
            else return false;
        }

        void LoginPage()
        {
            Login login = new();
            login.Show();
            this.Close();
        }
    }
}
