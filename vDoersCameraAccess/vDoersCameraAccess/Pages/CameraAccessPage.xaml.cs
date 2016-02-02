using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace vDoersCameraAccess.Pages
{
	public partial class CameraAccessPage : ContentPage
	{
		public CameraAccessPage ()
		{
			InitializeComponent ();
            BindingContext = new CameraViewModel();
		}
	}
}
