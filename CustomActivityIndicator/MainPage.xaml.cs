namespace CustomActivityIndicator
{
    using System;

    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BtnChangeBusyIndicator.Clicked += BtnChangeBusyIndicator_Clicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            BtnChangeBusyIndicator.Clicked -= BtnChangeBusyIndicator_Clicked;
        }

        private void BtnChangeBusyIndicator_Clicked(object sender, EventArgs e)
        {
            BusyIndicator.IsRunning = !BusyIndicator.IsRunning;
            BtnChangeBusyIndicator.Text = BusyIndicator.IsRunning ? "Stop" : "Run";
        }
    }
}
