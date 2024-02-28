

namespace Tarea2_4_Gruepo1
{
    public partial class MainPage : ContentPage
    {

        FileResult video;



        public MainPage()
        {
            InitializeComponent();
        }
        private async void btngrabar_Clicked(object sender, EventArgs e)
        {
            video = await MediaPicker.CaptureVideoAsync();

            if (video != null)
            {
                string path = Path.Combine(FileSystem.CacheDirectory, video.FileName);

                // Guardar el video en el directorio de caché
                using (Stream sourceStream = await video.OpenReadAsync())
                using (FileStream fileStream = File.OpenWrite(path))
                {
                    await sourceStream.CopyToAsync(fileStream);
                }

                //ponerlo en el mediaElement
                mediaElement.Source = path;
                await DisplayAlert("Aviso", "El video se ha guardado correctamente", "OK");
            }
        }
        
    }

}
