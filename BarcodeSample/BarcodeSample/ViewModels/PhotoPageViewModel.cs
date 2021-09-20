using System;
using System.Threading.Tasks;
using BarcodeSample.Services;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Essentials.Interfaces;

namespace BarcodeSample.ViewModels
{
    public class PhotoPageViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IMediaPicker mediaPicker;
        private string photoPath;

        public PhotoPageViewModel(
            INavigationService navigationService,
            IMediaPicker mediaPicker)
        {
            this.navigationService = navigationService;
            this.mediaPicker = mediaPicker;
        }
        
        public IAsyncCommand TakeBarcodePhotoCommand => new AsyncCommand(this.TakePhoto);

        public string PhotoPath
        {
            get => this.photoPath;
            set => this.SetProperty(ref this.photoPath, value);
        }

        private async Task TakePhoto()
        {
            try
            {
                var photoFile = await this.mediaPicker.CapturePhotoAsync();

                // canceled by user
                if (photoFile == null)
                {
                    return;
                }

                this.PhotoPath = photoFile.FullPath;

            }
            catch (Exception ex)
            {
                // ignored
            }
        }
    }
}