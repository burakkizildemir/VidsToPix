using MediaToolkit;
using MediaToolkit.Model;
using MediaToolkit.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pielx
{
    public class video
    {
        public string filename { get; set; }
        public string safeFileName { get; set; }
        public int seconds { get; set; }
        public Uri fileUri{ get; set; }  
        public video(string _filename)
        {
            filename = _filename;
            seconds = GetSeconds(filename);
            fileUri = new Uri(filename);
        }
        public int GetSeconds(string _fileName)
        {
            using (var engine = new Engine())
            {
                var mp4 = new MediaFile { Filename = _fileName };
                engine.GetMetadata(mp4);
                seconds = (int)Math.Round(mp4.Metadata.Duration.TotalSeconds);                
            }
            return seconds;    
        }
    }
}
