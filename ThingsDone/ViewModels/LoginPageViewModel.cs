using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ThingsDone
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Commands

        public ICommand LoginCommand { get; set; }
        #endregion

        #region Public properties

        public string LoginText { get; set; }

        #endregion



        public LoginPageViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter), () => true);
        }


        public async Task Login(object parameter)
        {
            // check user and password
            // animate

            bool tete = parameter is SecureString;

            string s = ((SecureString)parameter).ToString();

            var password = (parameter as SecureString).Unsecure();

            //string pass = new System.Net.NetworkCredential(LoginText, parameter as SecureString).Password;

            System.Windows.Forms.MessageBox.Show(LoginText + "\n" + password);

            await Task.Delay(100);
        }
    }
}