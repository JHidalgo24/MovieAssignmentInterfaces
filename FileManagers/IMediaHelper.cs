using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieAssignmentInterfaces.MediaObjects;

namespace MovieAssignmentInterfaces.FileManagers
{
    public interface IMediaHelper
    {
        public abstract void WriteLists();//writes the lists to it's files 
        public abstract void Shows();//reads shows to list
        public abstract void Movies(); //reads movies to list
        public abstract void Videos();//reads videos to list
        //adds media to it's file
        public abstract void ShowAdd(int id, string title, int season, int episode, List<string> writers);
        public abstract void MovieAdd(int id, string title, List<string> genres);
        public abstract void VideoAdd(int id, string title, List<string> format, int length, List<int> regions);
        public abstract void SearchMedia(string type, string title);
    }

}