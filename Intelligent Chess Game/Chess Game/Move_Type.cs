using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelligent_Chess_Game
{
    public enum Move_Type
    {
       Pawn_Pormotion_To_Bishop,
       Pawn_Pormotion_To_Rook,
       Pawn_Pormotion_To_Pawn,
       Pawn_Pormotion_To_Knight,
       Pawn_Pormotion_To_Queen,
       Castle,
       Eat_Piece,
       Normal,
    }
}
