using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelligent_Chess_Game
{
    public static class Attack
    {
        public static List<Location> Get_White_Piece_Under_Attack(Chess_Piece[,] board)
        {
            List<Location> White_Piece_Under_Attack = new List<Location>();
            foreach (Chess_Piece Piece in board)
            {
                if (Piece != null && Piece.getColor == Chess_Piece_Color.Black)
                {
                    switch (Piece.getType)
                    {
                        case Chess_Piece_Type.Bishop:
                            Check_Bishop(board, White_Piece_Under_Attack, Piece);
                            break;
                        case Chess_Piece_Type.Rook:
                            Check_Rook(board, White_Piece_Under_Attack, Piece);
                            break;
                        case Chess_Piece_Type.Pawn:
                            White_Piece_Under_Attack.Add(new Location(Piece.getLocation.c + 1, Piece.getLocation.r + 1));
                            White_Piece_Under_Attack.Add(new Location(Piece.getLocation.c - 1, Piece.getLocation.r + 1));
                            break;
                        case Chess_Piece_Type.Knight:
                            Check_Knight(board, White_Piece_Under_Attack, Piece);
                            break;
                        case Chess_Piece_Type.Queen:
                            Check_Bishop(board, White_Piece_Under_Attack, Piece);
                            Check_Rook(board, White_Piece_Under_Attack, Piece);
                            break;
                    }
                }
            }

            return White_Piece_Under_Attack;
        }

        public static List<Location> Get_Black_Piece_Under_Attack(Chess_Piece[,] board)
        {
            List<Location> Black_Piece_Under_Attack = new List<Location>();
            foreach (Chess_Piece Piece in board)
            {
                if (Piece != null && Piece.getColor == Chess_Piece_Color.White)
                {
                    switch (Piece.getType)
                    {
                        case Chess_Piece_Type.Bishop:
                            Check_Bishop(board, Black_Piece_Under_Attack, Piece);
                            break;
                        case Chess_Piece_Type.Rook:
                            Check_Rook(board, Black_Piece_Under_Attack, Piece);
                            break;
                        case Chess_Piece_Type.Pawn:
                            if (Piece.getLocation.c < 7 && Piece.getLocation.r > 0)
                                Black_Piece_Under_Attack.Add(new Location(Piece.getLocation.c + 1, Piece.getLocation.r - 1));
                            if (Piece.getLocation.c > 0 && Piece.getLocation.r > 0)
                                Black_Piece_Under_Attack.Add(new Location(Piece.getLocation.c - 1, Piece.getLocation.r - 1));
                            break;
                        case Chess_Piece_Type.Knight:
                            Check_Knight(board, Black_Piece_Under_Attack, Piece);
                            break;
                        case Chess_Piece_Type.Queen:
                            Check_Bishop(board,Black_Piece_Under_Attack, Piece);
                            Check_Rook(board, Black_Piece_Under_Attack, Piece);
                            break;
                    }
                }
            }

            return Black_Piece_Under_Attack;
        }

        private static void Check_Bishop(Chess_Piece[,] board, List<Location> Attack_List, Chess_Piece Piece)
        {
            // check up->right
            for (int i = Piece.getLocation.c + 1, j = Piece.getLocation.r - 1;
                i <= 7 && j >= 0;
                i++, j--)
            {
                if (board[i, j] == null)
                {
                    Attack_List.Add(new Location(i, j));
                }
                else
                {
                    Attack_List.Add(new Location(i, j));
                    break;
                }
            }

            // check up->left
            for (int i = Piece.getLocation.c - 1, j = Piece.getLocation.r - 1;
                i >= 0 && j >= 0;
                i--, j--)
            {
                if (board[i, j] == null)
                {
                    Attack_List.Add(new Location(i, j));
                }
                else
                {
                    Attack_List.Add(new Location(i, j));
                    break;
                }
            }

            // check down->right
            for (int i = Piece.getLocation.c + 1, j = Piece.getLocation.r + 1;
                i < 7 && j < 7;
                i++, j++)
            {
                if (board[i, j] == null)
                {
                    Attack_List.Add(new Location(i, j));
                }
                else
                {
                    Attack_List.Add(new Location(i, j));
                    break;
                }
            }

            // check down->left
            for (int i = Piece.getLocation.c - 1, j = Piece.getLocation.r + 1;
                i >= 0 && j < 7;
                i--, j++)
            {
                if (board[i, j] == null)
                {
                    Attack_List.Add(new Location(i, j));
                }
                else
                {
                    Attack_List.Add(new Location(i, j));
                    break;
                }
            }
        }

        private static void Check_Rook(Chess_Piece[,] board, List<Location> Attack_List, Chess_Piece Piece)
        {
            // check right
            for (int i = Piece.getLocation.c + 1; i <= 7; i++)
            {
                if (board[i, Piece.getLocation.r] == null)
                {
                    Attack_List.Add(new Location(i, Piece.getLocation.r));
                }
                else
                {
                    Attack_List.Add(new Location(i, Piece.getLocation.r));
                    break;
                }
            }

            // check left
            for (int i = Piece.getLocation.c - 1; i >= 0; i--)
            {
                if (board[i, Piece.getLocation.r] == null)
                {
                    Attack_List.Add(new Location(i, Piece.getLocation.r));
                }
                else
                {
                    Attack_List.Add(new Location(i, Piece.getLocation.r));
                    break;
                }
            }

            // check up
            for (int i = Piece.getLocation.r - 1; i >= 0; i--)
            {
                if (board[Piece.getLocation.c, i] == null)
                {
                    Attack_List.Add(new Location(Piece.getLocation.c, i));
                }
                else
                {
                    Attack_List.Add(new Location(Piece.getLocation.c, i));
                    break;
                }
            }

            // check down
            for (int i = Piece.getLocation.r + 1; i <= 7; i++)
            {
                if (board[Piece.getLocation.c, i] == null)
                {
                    Attack_List.Add(new Location(Piece.getLocation.c, i));
                }
                else
                {
                    Attack_List.Add(new Location(Piece.getLocation.c, i));
                    break;
                }
            }
        }

        private static void Check_Knight(Chess_Piece[,] board, List<Location> Attack_List, Chess_Piece Piece)
        {

        }
    }
}

