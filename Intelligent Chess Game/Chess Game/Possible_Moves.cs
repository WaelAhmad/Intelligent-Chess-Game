using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Intelligent_Chess_Game.Algorithm;

namespace Intelligent_Chess_Game
{
    public static class Possible_Moves
    {
        public static bool Is_Bishop_Move(Chess_Piece chesspiece, Location start_loc, Location new_loc, Chess_Piece[,] board)
        {
            int r = start_loc.r;
            int c = start_loc.c;

            // if new_loc is a legal move
            if (board[new_loc.c, new_loc.r] != null && board[new_loc.c, new_loc.r].getColor == chesspiece.getColor)
                return false;

            // move up->right
            if (r - new_loc.r == new_loc.c - c
                && new_loc.r < r)
            {
                for (int i = c + 1, j = r - 1;
                    i < new_loc.c && j > new_loc.r;
                    i++, j--)
                {
                    if (board[i, j] != null)
                        return false;
                }

                return true;
            }

            // move up->left
            if (r - new_loc.r == c - new_loc.c
                && new_loc.r < r)
            {
                for (int i = c - 1, j = r - 1;
                    i > new_loc.c && j > new_loc.r;
                    i--, j--)
                {
                    if (board[i, j] != null)
                        return false;
                }

                return true;
            }

            // move down->right
            if (r - new_loc.r == new_loc.c - c
                && new_loc.r > r)
            {
                for (int i = c - 1, j = r + 1;
                    i > new_loc.c && j < new_loc.r;
                    i--, j++)
                {
                    if (board[i, j] != null)
                        return false;
                }

                return true;
            }

            // move down->left
            if (r - new_loc.r == c - new_loc.c
                && new_loc.r > r)
            {
                for (int i = c + 1, j = r + 1;
                    i < new_loc.c && j < new_loc.r;
                    i++, j++)
                {
                    if (board[i, j] != null)
                        return false;
                }

                return true;
            }

            else return false;
        }

        public static bool Is_Rook_Move(Chess_Piece chesspiece, Location start_loc, Location new_loc, Chess_Piece[,] board)
        {
            int r = start_loc.r;
            int c = start_loc.c;

            // if new_loc is a legal move
            if (board[new_loc.c, new_loc.r] != null && board[new_loc.c, new_loc.r].getColor == chesspiece.getColor)
                return false;

            // move up
            else if (c == new_loc.c
                && r > new_loc.r)
            {
                for (int i = r - 1;
                    i > new_loc.r;
                    i--)
                {
                    if (board[c, i] != null)
                        return false;
                }

                return true;
            }

            // move right
            else if (r == new_loc.r
                && c < new_loc.c)
            {
                for (int i = c + 1;
                    i < new_loc.c;
                    i++)
                {
                    if (board[i, r] != null)
                        return false;
                }

                return true;
            }

            // move down
            else if (c == new_loc.c
                && r < new_loc.r)
            {
                for (int i = r + 1;
                    i < new_loc.r;
                    i++)
                {
                    if (board[c, i] != null)
                        return false;
                }

                return true;
            }

            // move left
            else if (r == new_loc.r
                && c > new_loc.c)
            {
                for (int i = c - 1;
                    i > new_loc.c;
                    i--)
                {
                    if (board[i, r] != null)
                        return false;
                }

                return true;
            }

            return false;
        }

        public static bool Is_Pawn_Move(Chess_Piece chesspiece, Location start_loc, Location new_loc, Chess_Piece[,] board)
        {
            int r = start_loc.r;
            int c = start_loc.c;

            // White Pawn
            if (chesspiece.getColor == Chess_Piece_Color.White)
            {
                // Normal move
                if (r - new_loc.r == 1 && c == new_loc.c && board[new_loc.c, new_loc.r] == null)
                {
                    return true;
                }

                // Special move
                else if (r - new_loc.r == 2 && c == new_loc.c)
                {
                    // allow to special move
                    if (r == 6 && board[new_loc.c, new_loc.r] == null && board[new_loc.c, new_loc.r + 1] == null)
                        return true;
                }
                else if (r - new_loc.r == 1 && board[new_loc.c, new_loc.r] != null &&
                    board[new_loc.c, new_loc.r].getColor != Chess_Piece_Color.White)
                {
                    if (c - new_loc.c == -1 || c - new_loc.c == 1)
                        return true;
                }

            }

            // Black Pawn
            else
            {
                // Normal move
                if (r - new_loc.r == -1 && c == new_loc.c && board[new_loc.c, new_loc.r] == null)
                {
                    return true;
                }

                // Special move
                else if (r - new_loc.r == -2 && c == new_loc.c)
                {
                    // allow to special move
                    if (r == 1 && board[new_loc.c, new_loc.r] == null && board[new_loc.c, new_loc.r - 1] == null)
                        return true;
                }
                else if (r - new_loc.r == -1 && board[new_loc.c, new_loc.r] != null &&
                    board[new_loc.c, new_loc.r].getColor != Chess_Piece_Color.Black)
                {
                    if (c - new_loc.c == -1 || c - new_loc.c == 1)
                        return true;
                }

            }

            return false;
        }

        public static bool Is_Knight_Move(Chess_Piece chesspiece, Location start_loc, Location new_loc, Chess_Piece[,] board)
        {
            int r = start_loc.r;
            int c = start_loc.c;

            // White Knight
            if (chesspiece.getColor == Chess_Piece_Color.White)
            {
                if (((r - new_loc.r == 1 && (c == new_loc.c + 2 || c == new_loc.c - 2)
                    || (r - new_loc.r == -1 && (c == new_loc.c + 2 || c == new_loc.c - 2)))
                    || (r - new_loc.r == 2 && (c == new_loc.c + 1 || c == new_loc.c - 1))
                    || (r - new_loc.r == -2 && (c == new_loc.c + 1 || c == new_loc.c - 1)))
                    && board[new_loc.c, new_loc.r] == null)

                    return true;

                else if ((r - new_loc.r == 1 || r - new_loc.r == -1) && board[new_loc.c, new_loc.r] != null
                    && board[new_loc.c, new_loc.r].getColor != Chess_Piece_Color.White)
                {
                    if (c - new_loc.c == 2 || c - new_loc.c == -2)
                        return true;
                }
                else if ((r - new_loc.r == 2 || r - new_loc.r == -2) && board[new_loc.c, new_loc.r] != null
                    && board[new_loc.c, new_loc.r].getColor != Chess_Piece_Color.White)
                {
                    if (c - new_loc.c == 1 || c - new_loc.c == -1)
                        return true;
                }
            }

            // Black Knight
            else
            {
                if (((r - new_loc.r == 1 && (c == new_loc.c + 2 || c == new_loc.c - 2)
                    || (r - new_loc.r == -1 && (c == new_loc.c + 2 || c == new_loc.c - 2)))
                    || (r - new_loc.r == 2 && (c == new_loc.c + 1 || c == new_loc.c - 1))
                    || (r - new_loc.r == -2 && (c == new_loc.c + 1 || c == new_loc.c - 1)))
                    && board[new_loc.c, new_loc.r] == null)

                    return true;

                else if ((r - new_loc.r == 1 || r - new_loc.r == -1) && board[new_loc.c, new_loc.r] != null
                    && board[new_loc.c, new_loc.r].getColor != Chess_Piece_Color.Black)
                {
                    if (c - new_loc.c == 2 || c - new_loc.c == -2)
                        return true;
                }
                else if ((r - new_loc.r == 2 || r - new_loc.r == -2) && board[new_loc.c, new_loc.r] != null
                    && board[new_loc.c, new_loc.r].getColor != Chess_Piece_Color.Black)
                {
                    if (c - new_loc.c == 1 || c - new_loc.c == -1)
                        return true;
                }
            }

            return false;
        }

        public static bool Is_King_Move(Chess_Piece chesspiece, Location start_loc, Location new_loc, Chess_Piece[,] board)
        {
            int r = start_loc.r;
            int c = start_loc.c;

            // if new_loc is a legal move
            if (board[new_loc.c, new_loc.r] != null && board[new_loc.c, new_loc.r].getColor == chesspiece.getColor)
                return false;

            // move diagonal
            else if ((new_loc.r == start_loc.r + 1 && new_loc.c == start_loc.c - 1)
                || (new_loc.r == start_loc.r - 1 && new_loc.c == start_loc.c - 1)
                || (new_loc.r == start_loc.r + 1 && new_loc.c == start_loc.c + 1)
                || (new_loc.r == start_loc.r - 1 && new_loc.c == start_loc.c + 1))
            {
                return true;
            }

            // move up & down
            else if (c == new_loc.c)
            {
                if (r - new_loc.r == 1 || r - new_loc.r == -1)
                    return true;
            }

            // move right & left
            else if (r == new_loc.r)
            {
                if (c - new_loc.c == 1 || c - new_loc.c == -1)
                    return true;
            }

            return false;
        }
    }
}
