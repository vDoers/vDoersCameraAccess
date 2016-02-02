using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Media;

namespace vDoersCameraAccess
{
    public class CameraAccess : ICameraAccess
    {
        public void GetImageAsync(Action<MediaFile> imageData, bool fromCamera = true)
        {
            var picker = new MediaPicker();
            MediaPickerController controller = null;
            if (fromCamera)
            {
                controller = picker.GetTakePhotoUI(new StoreCameraMediaOptions
                {
                    Name = string.Format("vDoers_{0}.jpg", DateTime.Now.Ticks),
                    Directory = "vDoersCamera"
                });
            }
            else
            {
                controller = picker.GetPickPhotoUI();
            }

            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            if (vc.PresentedViewController != null)
            {
                vc = vc.PresentedViewController;
                vc.PresentViewController(controller, true, null);
            }
            controller.GetResultAsync().ContinueWith(t =>
            {
                // Dismiss the UI yourself
                controller.DismissViewController(true, () =>
                {
                    MediaFile file = t.Result;
                });

            });
        }
    }
}
