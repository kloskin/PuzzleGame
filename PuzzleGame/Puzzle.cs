using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleGame
{
    public class Puzzle
    {
        public Bitmap Picture;
        public Rectangle HomeLocation, CurrentLocation;

        public Puzzle(Bitmap new_picture, Rectangle home_location)
        {
            Picture = new_picture;
            HomeLocation = home_location;
        }

        // Zwraca True jeśli puzzel jest w odpowiednim miejscu
        public bool IsHome()
        {
            return HomeLocation.Equals(CurrentLocation);
        }

        // Zwraca True jeśli miejsce jest w zakresie Puzzla
        public bool Contains(Point pt)
        {
            return CurrentLocation.Contains(pt);
        }

        // Jeśli Puzzel jest blisko miejsca w którym ma się znaleźć to wrzuca go do niego 
        public bool SnapToHome()
        {
            if ((Math.Abs(CurrentLocation.X - HomeLocation.X) < 20) &&
                (Math.Abs(CurrentLocation.Y - HomeLocation.Y) < 20))
            {
                CurrentLocation = HomeLocation;
                return true;
            }
            return false;
        }
    }
}
