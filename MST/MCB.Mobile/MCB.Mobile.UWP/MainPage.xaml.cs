namespace MCB.Mobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new MCB.Mobile.App());
        }
    }
}
