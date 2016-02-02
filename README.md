# vDoersCameraAccess
## Media in Xamarin Forms ##

Take picture from `Camera` and `Gallery`. 

**Feature:**

- Camera
- Gellery

**Available:**

- Android
- iOS


![](https://raw.githubusercontent.com/vDoers/vDoersCameraAccess/master/Screens/main.png)


**ViewModel Code:**

Take Pic Command

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


**Dependencies:**

- [Xamarin.Mobile](https://components.xamarin.com/view/xamarin.mobile)
- Dependency Service


Cheers!!
