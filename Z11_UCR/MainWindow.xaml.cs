using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Z11_UCR
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<User> Users = new List<User>()
        {
            new User("JanK", "haslo1"),
            new User("JanN", "haslo2"),
            new User("JanP", "haslo3"),
        };

        public event EventHandler<LoginFailureEventArgs> LoginFailed;
        public event EventHandler<EventArgs> LoginSuccess;

        public MainWindow()
        {
            InitializeComponent();
            LoginFailed += CustomLoginControl.OnLoginFailure;
            LoginFailed += CustomLoginControl.OnLoginSuccess;
            
        }

        private void CustomLoginControl1_LoginAttempt_1(object sender, LoginEventArgs e)
        {
            //throw new NotImplementedException();
            var user = Users.Where(x => x.CheckLogin(e.Login, e.Password)).SingleOrDefault();
            if (user == null)
            {
                LoginFailed?.Invoke(this, new LoginFailureEventArgs()
                {
                    Errors = new List<LoginFailureEventArgs.LoginError>()
                        {
                            new LoginFailureEventArgs.LoginError()
                            {
                                Field = LoginFields.All,
                                ErrorMessage = "Wrong username or password"
                            }
                        }
                });
            }
            else
            {
                LoginSuccess?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
