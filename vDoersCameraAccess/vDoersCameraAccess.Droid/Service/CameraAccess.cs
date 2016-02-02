using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Media;
using Xamarin.Forms;
using vDoersCameraAccess.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(CameraAccess))]
namespace vDoersCameraAccess.Droid
{
    public class CameraAccess : ICameraAccess
    {
        public Action<MediaFile> OnImageData { get; set; }

        public void GetImageAsync(Action<MediaFile> imageData, bool fromCamera = true)
        {
            OnImageData = imageData;
            var context = Forms.Context as MainActivity;
            var picker = new MediaPicker(context);
            if (!picker.IsCameraAvailable)
                Console.WriteLine("No camera!");
            else
            {
                Intent intent = null;
                if (fromCamera)
                {
                    intent = picker.GetTakePhotoUI(new StoreCameraMediaOptions
                    {
                        Name = string.Format("vDoers_{0}.jpg", DateTime.Now.Ticks),
                        Directory = "vDoersCamera"
                    });
                }
                else
                {
                    intent = picker.GetPickPhotoUI();
                }

                context.OnActvitiResultCallback -= OnActvitiResultCallback;
                context.OnActvitiResultCallback += OnActvitiResultCallback;
                context.StartActivityForResult(intent, 1);
            }
        }

        public async void OnActvitiResultCallback(int requestCode, Result resultCode, Intent data)
        {
            // User canceled
            if (resultCode == Result.Canceled)
                return;

            await data.GetMediaFileExtraAsync(Forms.Context).ContinueWith(t =>
            {
                if (OnImageData != null)
                {
                    OnImageData(t.Result);
                }
            });
        }
    }
}