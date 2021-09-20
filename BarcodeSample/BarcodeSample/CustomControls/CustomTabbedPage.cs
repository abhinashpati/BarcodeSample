using Xamarin.Forms;

namespace BarcodeSample.CustomControls
{
    public class CustomTabbedPage : TabbedPage
    {
        public static readonly BindableProperty TabBarBorderThicknessProperty = BindableProperty.Create(nameof(TabBarBorderThickness), typeof(int), typeof(CustomTabbedPage), 0);
        public static readonly BindableProperty TabBarMinimumHeightProperty = BindableProperty.Create(nameof(TabBarMinimumHeight), typeof(int), typeof(CustomTabbedPage), 0);
        public static readonly BindableProperty TabBarBorderColorProperty = BindableProperty.Create(nameof(TabBarBorderColor), typeof(Color), typeof(CustomTabbedPage), Color.Transparent);
        public static readonly BindableProperty ShowTabIconsOnlyProperty = BindableProperty.Create(nameof(TabBarBorderColor), typeof(bool), typeof(CustomTabbedPage), false);

        public int TabBarBorderThickness
        {
            get => (int)this.GetValue(TabBarBorderThicknessProperty);
            set => this.SetValue(TabBarBorderThicknessProperty, value);
        }

        public int TabBarMinimumHeight
        {
            get => (int)this.GetValue(TabBarMinimumHeightProperty);
            set => this.SetValue(TabBarMinimumHeightProperty, value);
        }

        public Color TabBarBorderColor
        {
            get => (Color)this.GetValue(TabBarBorderColorProperty);
            set => this.SetValue(TabBarBorderColorProperty, value);
        }

        public bool ShowTabIconsOnly
        {
            get => (bool)this.GetValue(ShowTabIconsOnlyProperty);
            set => this.SetValue(ShowTabIconsOnlyProperty, value);
        }
    }
}