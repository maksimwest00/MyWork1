using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace MyWork1
{
    public partial class Main : Form
    {
        public VlcControl control;

        public Main()
        {
            InitializeComponent();
            StartTV();
        }

        public void Player(string url, int volume)
        {
            this.vlcControl1.Stop();
            this.vlcControl1.SetMedia(new Uri(@"" + url + ""));
            this.vlcControl1.Play();
            this.vlcControl1.Audio.Volume = volume;
        }

        public void StartTV()
        {
            lstChannels.Items.Clear();
            string url = "http://limehd.online/playlist/";
            string request = GET(url);
            DeserializeJSON.Root ParseJSON = JsonConvert.DeserializeObject<DeserializeJSON.Root>(request);
            List<DeserializeJSON.Channel> namechannels = ParseJSON.channels;
            string name_ru;
            string image;
            string urlch;
            foreach (DeserializeJSON.Channel item in namechannels)
            {
                name_ru = item.name_ru;
                image = item.image;
                urlch = item.url;
                lstChannels.Items.Add(name_ru);
            }
        }

        private static string GET(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        private void lstChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            string url = "http://limehd.online/playlist/";
            string request = GET(url);
            DeserializeJSON.Root ParseJSON = JsonConvert.DeserializeObject<DeserializeJSON.Root>(request);
            List<DeserializeJSON.Channel> namechannels = ParseJSON.channels;
            string name_ru;
            string image;
            string urlch;
            foreach (DeserializeJSON.Channel item in namechannels)
            {
                name_ru = item.name_ru;
                image = item.image;
                urlch = item.url;
                if (lstChannels.SelectedItem != null)
                {
                    string selected = lstChannels.SelectedItem.ToString();
                    if (selected == name_ru)
                    {
                        int volume = 100;
                        //string urlm3u8 = "http://livetv.mylifeisgood.ml/mfolive.m3u8?media=fox";
                        //Player(urlm3u8, volume);
                        Player(urlch, volume);
                        return;
                    }
                }
            }
        }
        private void stopbtn_Click(object sender, EventArgs e)
        {
            this.vlcControl1.Stop();
        }
    }
}
