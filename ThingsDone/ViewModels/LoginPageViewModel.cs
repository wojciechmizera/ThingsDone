using System;
using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

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
            var passwordContainer = parameter as IHavePassword;

            // TODO implement login
            string login = LoginText;
            string password = passwordContainer.Password.Unsecure();

            Frame pageFrame = FindParentFrame(parameter);
            pageFrame.Content = new MainPage();

            // animation somehow...
            await Task.Delay(100);
        }

        private static Frame FindParentFrame(object parameter)
        {
            Frame pageFrame = null;
            DependencyObject currParent = VisualTreeHelper.GetParent(parameter as DependencyObject);
            while (currParent != null && pageFrame == null)
            {
                pageFrame = currParent as Frame;
                currParent = VisualTreeHelper.GetParent(currParent);
            }

            return pageFrame;
        }
    }
}