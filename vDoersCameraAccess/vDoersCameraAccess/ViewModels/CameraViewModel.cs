using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Media;

namespace vDoersCameraAccess
{
    public class CameraViewModel : BaseViewModel
    {
        #region Properties

        private ImageSource _selectedImage = "bgback.png";

        public ImageSource SelectedImage
        {
            get { return _selectedImage; }
            set { _selectedImage = value; OnPropertyChanged(); }
        }


        #endregion

        #region Commands

        public ICommand TakePictureCommand
        {
            get
            {
                return new Command(() =>
               {
                   AddPicture();
               });
            }
        }

        #endregion

        #region Click Picture

        void AddPicture()
        {
            try
            {
                var camera = Xamarin.Forms.DependencyService.Get<ICameraAccess>();
                camera.GetImageAsync(OnImageTaken);
            }
            catch (Exception ex)
            {
                //Swell Exception
            }
        }

        private void OnImageTaken(MediaFile obj)
        {
            if (obj != null)
                SelectedImage = obj.Path;
        }

        #endregion
    }
}
