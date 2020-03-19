using System;
using System.Collections.Generic;
using System.Text;

namespace MovieNight
{
    class ActorLibrary
    {
        public static List<Actor> ActorList(string search)
        {
            return Dal.GetActors(search);
        }
    }
}
