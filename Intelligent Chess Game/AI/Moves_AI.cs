using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelligent_Chess_Game.AI
{
    public static class Moves_AI
    {

        public static List<Move_Chess> Possible_Move(Chess_Piece[,] chessboard, List<Location> Locations)
        {
            List<Move_Chess> temporary = new List<Move_Chess>();
            foreach (Chess_Piece Piece in chessboard)
            {
                if (Piece != null && Piece.getColor == Chess_Piece_Color.Black)
                {

                    switch (Piece.getType)
                    {
                        case Chess_Piece_Type.Bishop:
                            foreach (Location l in Locations)
                            {
                                if (Possible_Moves.Is_Bishop_Move(Piece, Piece.getLocation, l, chessboard))
                                {
                                    temporary.Add(new Move_Chess(Piece, Piece.getLocation, l));
                                }
                            }
                            break;

                        case Chess_Piece_Type.Rook:
                            foreach (Location l in Locations)
                            {
                                if (Possible_Moves.Is_Rook_Move(Piece, Piece.getLocation, l, chessboard))
                                {
                                    temporary.Add(new Move_Chess(Piece, Piece.getLocation, l));
                                }
                            }
                            break;

                        case Chess_Piece_Type.Pawn:
                            foreach (Location l in Locations)
                            {
                                if (Possible_Moves.Is_Pawn_Move(Piece, Piece.getLocation, l, chessboard))
                                {
                                    temporary.Add(new Move_Chess(Piece, Piece.getLocation, l));
                                }
                            }
                            break;

                        case Chess_Piece_Type.Queen:
                            foreach (Location l in Locations)
                            {
                                if (Possible_Moves.Is_Bishop_Move(Piece, Piece.getLocation, l, chessboard)
                                    || Possible_Moves.Is_Rook_Move(Piece, Piece.getLocation, l, chessboard))
                                {
                                    temporary.Add(new Move_Chess(Piece, Piece.getLocation, l));
                                }
                            }
                            break;

                        case Chess_Piece_Type.Knight:
                            foreach (Location l in Locations)
                            {
                                if (Possible_Moves.Is_Knight_Move(Piece, Piece.getLocation, l, chessboard))
                                {
                                    temporary.Add(new Move_Chess(Piece, Piece.getLocation, l));
                                }
                            }
                            break;

                    }
                }
            }
            return temporary;
        }
    }
}