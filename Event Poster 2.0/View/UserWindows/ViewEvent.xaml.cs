using System.Windows.Input;
using System.Windows;


namespace Event_Poster_2._0.View.UserWindows
{
    /// <summary>
    /// Логика взаимодействия для ViewEvent.xaml
    /// </summary>
    public partial class ViewEvent : Window
    {
        public ViewEvent()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
