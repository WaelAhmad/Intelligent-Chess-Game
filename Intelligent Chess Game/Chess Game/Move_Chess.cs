using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelligent_Chess_Game
{
    public class Move_Chess
    {
        public Chess_Piece piece;
        public Location start_pos;
        public Location end_pos;
        public Chess_Piece_Color player;

        public string type
        {
            get { return piece.getType.ToString(); }
        }

        public Move_Chess(Chess_Piece chesspiece, Location start_pos, Location end_pos)
        {
            this.piece = chesspiece;
            this.start_pos = start_pos;
            this.end_pos = end_pos;
            this.player = chesspiece.getColor;

        }

    }
}
