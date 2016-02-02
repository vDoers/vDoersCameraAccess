using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Media;

namespace vDoersCameraAccess
{
    public interface ICameraAccess
    {
        void GetImageAsync(Action<MediaFile> imageData, bool fromCamera = true);
    }
}
