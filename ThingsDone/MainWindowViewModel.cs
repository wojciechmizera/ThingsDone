using System.Collections.Generic;

namespace ThingsDone
{
    public class MainWindowViewModel
    {
        public LoginPage LoginPage { get; set; } = new LoginPage();
        public MainPage MainPage { get; set; } = new MainPage();


        public List<Entry> Entries;

        public MainWindowViewModel()
        {
            
        }
    }
}