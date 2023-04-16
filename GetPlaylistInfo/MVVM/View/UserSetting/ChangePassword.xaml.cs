using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GetPlaylistInfo.MVVM.View.UserSetting
{
    /// <summary>
    /// Interaction logic for ChangePassword.xaml
    /// </summary>
    public partial class ChangePassword : Page
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void BtnChangePass2_Click(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Password == "" | txtConPassword.Password == "")
            {
                MessageBox.Show("One or more fields are empty", "Change Password Failed", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else if (txtConPassword.Password != txtPassword.Password)
            {
                MessageBox.Show("Your passwords do not match, try again.", "Passwords don't match", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Clear();
                txtConPassword.Clear();
            }
            else if (txtPassword.Password == txtConPassword.Password)
            {
                bool v = ValidationCheck(txtConPassword.Password);
                if (!v)
                {
                    MessageBox.Show("Your password must be between 8 and 14 characters, include at least one number or special character, and a mixture of upper and lowercase letters.", "Registration Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Clear();
                    txtConPassword.Clear();
                    txtPassword.Focus();

                }
                else
                {
                    UserSettings.conn.Open();
                    SqlCommand updatePass = new("UPDATE users SET password =@password WHERE username =@username", UserSettings.conn);
                    updatePass.Parameters.AddWithValue("@password", txtConPassword.Password);
                    updatePass.Parameters.AddWithValue("@username", Login.Username);
                    updatePass.ExecuteNonQuery();
                    UserSettings.conn.Close();

                    txtPassword.Clear();
                    txtConPassword.Clear();

                    MessageBox.Show("Your password has been successfully updated.", "Changed Password", MessageBoxButton.OK, MessageBoxImage.Information);
                    blckChangePass.Visibility = Visibility.Hidden;

                }

            }
            else
            {
                MessageBox.Show("Unexpected error please try again", "Unexpected error", MessageBoxButton.OK, MessageBoxImage.None);
                txtPassword.Clear();
                txtConPassword.Clear();
                txtPassword.Focus();

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


    }
}
