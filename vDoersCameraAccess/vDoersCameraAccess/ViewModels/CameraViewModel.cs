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
        #region Private

        Page page;

        #endregion

        #region Constructor

        public CameraViewModel(Page _page)
        {
            page = _page;
        }

        #endregion

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
                return new Command(async () =>
               {
                   var action = await page.DisplayActionSheet("Select Media", "Nahh", null, MediaSource.Camera.ToString(), MediaSource.Gallery.ToString());
                   if (action == "Nahh")
                       return;
                   AddPicture(action == MediaSource.Camera.ToString() ? true : false);
               });
            }
        }

        #endregion

        #region Click Picture

        void AddPicture(bool fromCamera)
        {
            try
            {
                var camera = Xamarin.Forms.DependencyService.Get<ICameraAccess>();
                camera.GetImageAsync(OnImageTaken, fromCamera);
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
