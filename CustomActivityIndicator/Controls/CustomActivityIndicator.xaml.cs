namespace CustomActivityIndicator.Controls
{
    using Xamarin.Forms;

    public partial class CustomActivityIndicator : ContentView
    {
        private readonly Animation animation;
        private const string ANIMATION_NAME = "ActivityIndicatorRotation";

        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create(nameof(IsRunning), typeof(bool), typeof(CustomActivityIndicator), false, propertyChanged: IsRunningChanged);
        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(ImageSource), typeof(CustomActivityIndicator), default(ImageSource));

        public CustomActivityIndicator()
        {
            InitializeComponent();
            BindingContext = this;

            animation = new Animation(v => Rotation = v, 0, 360);
        }

        public bool IsRunning
        {
            get => (bool)GetValue(IsRunningProperty);
            set => SetValue(IsRunningProperty, value);
        }

        public ImageSource Source
        {
            get => (ImageSource)GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        private static void IsRunningChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if ((bool)newValue)
                ((CustomActivityIndicator)bindable).StartAnimation();
            else
                ((CustomActivityIndicator)bindable).StopAnimation();
        }

        private void StartAnimation()
        {
            IsVisible = true;
            this.ScaleTo(1, 500);
            animation.Commit(this, ANIMATION_NAME, 16, 1000, Easing.Linear, (v, c) => Rotation = 0, () => true);
        }

        private async void StopAnimation()
        {
            await this.ScaleTo(0, 500);
            this.AbortAnimation(ANIMATION_NAME);
            IsVisible = false;
        }
    }
}
