using System.Linq;
using System.Windows.Input;
using GoogleVisionBarCodeScanner;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BarcodeSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeScannerView : ContentView
    {
        public static readonly BindableProperty IsTorchOnProperty =
            BindableProperty.Create(nameof(IsTorchOn), typeof(bool), typeof(BarcodeScannerView), false, propertyChanged: OnIsTorchChanged);

        public static readonly BindableProperty ScanResultCommandProperty =
            BindableProperty.Create(nameof(ScanResultCommand), typeof(ICommand), typeof(BarcodeScannerView), default(ICommand));

        public static readonly BindableProperty ResultProperty =
            BindableProperty.Create(nameof(ScanResult), typeof(string), typeof(BarcodeScannerView), default(string));

        public static readonly BindableProperty IsAnalyzingProperty =
            BindableProperty.Create(nameof(IsAnalyzing), typeof(bool), typeof(BarcodeScannerView), false, propertyChanged: OnIsScanningChanged);

        public BarcodeScannerView()
        {
            this.InitializeComponent();
        }

        public bool IsTorchOn
        {
            get => (bool)this.GetValue(IsTorchOnProperty);
            set => this.SetValue(IsTorchOnProperty, value);
        }

        public ICommand ScanResultCommand
        {
            get => (ICommand)this.GetValue(ScanResultCommandProperty);
            set => this.SetValue(ScanResultCommandProperty, value);
        }

        public string ScanResult
        {
            get => (string)this.GetValue(ResultProperty);
            set => this.SetValue(ResultProperty, value);
        }

        public bool IsAnalyzing
        {
            get => (bool)this.GetValue(IsAnalyzingProperty);
            set => this.SetValue(IsAnalyzingProperty, value);
        }

        private static void OnIsTorchChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Methods.ToggleFlashlight();
        }

        private static void OnIsScanningChanged(BindableObject bindable, object oldValue, object newValue)
        {
            Methods.SetIsScanning((bool)newValue);
        }

        private void CameraView_OnOnDetected(object sender, OnDetectedEventArg e)
        {
            this.ScanResult = e.BarcodeResults?.First().DisplayValue;
            this.ScanResultCommand?.Execute(this.ScanResult);
        }
    }
}