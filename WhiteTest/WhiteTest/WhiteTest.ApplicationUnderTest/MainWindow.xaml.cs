namespace WhiteTest.ApplicationUnderTest
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void ButtonOneOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Me was clicked!");
        }

        private void ButtonTwoOnClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Me too was clicked!");
        }
    }
}