using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelligent_Chess_Game
{
    public class Chess_Piece
    {
        private Location location;
        private Chess_Piece_Color color;
        private Chess_Piece_Type type;


        public Location setLocation
        {
            set { location = value; }
        }
        public Location getLocation
        {
            get { return location; }
        }

        public Chess_Piece_Color getColor
        {
            get { return color; }
        }

        public Chess_Piece_Type getType
        {
            get { return type; }
        }


        public Chess_Piece(Chess_Piece_Color color, Chess_Piece_Type type, Location location)
        {
            this.location = location;
            this.color = color;
            this.type = type;
        }
    }
}
