using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ExemploReproduzirMusicaXamarin
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
       

        public MainPage()
        {
            InitializeComponent();

            var stream = new MemoryStream(GetStreamFromUrl("https://devshow.blob.core.windows.net/audio/devshow-14-carreira-em-ti.mp3"));

            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Load(stream);


            
        }

        public static byte[] GetStreamFromUrl(string url)
        {
            try
            {
                using (var webClient = new HttpClient())
                {
                    var imageBytes = webClient.GetByteArrayAsync(url).Result;

                    return imageBytes;

                }
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return null;

            }
        }

        void btnPlay(System.Object sender, System.EventArgs e)
        {
            Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Play();

            lblTempo.Text = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Duration.ToString();
        }

        void btnPause(System.Object sender, System.EventArgs e)
        {
            if (Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.IsPlaying)
                Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Pause();
        }

        void btnStop(System.Object sender, System.EventArgs e)
        {
            if (Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.IsPlaying)
                Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current.Stop();
        }
    }
}
