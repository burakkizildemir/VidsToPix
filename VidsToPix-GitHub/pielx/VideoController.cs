using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace pielx
{
    public class VideoController
    {
        readonly List<video> vdList = new List<video>();
        public int totalSeconds { get; set; }
        public bool Isok{ get; set; }
        public VideoController(List<video> _vdList)
        {
            vdList = _vdList;
            Isok = ControlVideos(vdList);
        }
        public bool ControlVideos(List<video> vdList)
        {
            totalSeconds = 0;
            foreach (var item in vdList)
            {
                totalSeconds += item.seconds;
            }
            if (totalSeconds>900)
            {
                Isok = false;
            }
            else
            {
                Isok = true;
            }
            return Isok;
        }
    }
}
