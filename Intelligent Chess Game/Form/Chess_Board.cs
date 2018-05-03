using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intelligent_Chess_Game.Algorithm
{
    public class Chess_Game
    {
        private Chess_Piece[,] board;
        private List<Location> locations;
        private List<Location> White_Piece_Under_Attack;
        private List<Location> Black_Piece_Under_Attack;
        private List<Move_Chess> List_Move;
        private Chess_Piece_Color turn;
        private Form form;


        public Chess_Piece[,] get_board
        {
            get { return board; }
        }

        public List<Location> Locations
        {
            get
            {
                List<Location> list = new List<Location>();
                for (int i = 0; i <= 7; i++)
                {
                    for (int j = 0; j <= 7; j++)
                    {
                        list.Add(new Location(i, j));
                    }
                }
                return list;
            }
        }

        public Chess_Piece_Color Turn
        {
            get { return turn; }
            set { turn = value; }
        }


        private void init_board(Chess_Piece[,] chessboard)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 7)
                    {
                        chessboard[0, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.Rook, new Location(0, j));
                        chessboard[1, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.Knight, new Location(1, j));
                        chessboard[2, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.Bishop, new Location(2, j));
                        chessboard[3, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.King, new Location(3, j));
                        chessboard[4, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.Queen, new Location(4, j));
                        chessboard[5, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.Bishop, new Location(5, j));
                        chessboard[6, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.Knight, new Location(6, j));
                        chessboard[7, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.Rook, new Location(7, j));
                    }
                    else if (j == 6)
                    {
                        chessboard[i, j] = new Chess_Piece(Chess_Piece_Color.White, Chess_Piece_Type.Pawn, new Location(i, j));
                    }
                    else if (j == 1)
                    {
                        chessboard[i, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.Pawn, new Location(i, j));
                    }
                    else if (j == 0)
                    {
                        chessboard[0, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.Rook, new Location(0, j));
                        chessboard[1, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.Knight, new Location(1, j));
                        chessboard[2, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.Bishop, new Location(2, j));
                        chessboard[3, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.King, new Location(3, j));
                        chessboard[4, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.Queen, new Location(4, j));
                        chessboard[5, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.Bishop, new Location(5, j));
                        chessboard[6, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.Knight, new Location(6, j));
                        chessboard[7, j] = new Chess_Piece(Chess_Piece_Color.Black, Chess_Piece_Type.Rook, new Location(7, j));
                    }
                }
            }
        }

        public bool Move_Possible(Move_Chess move_chess)
        {
            Chess_Piece piece = move_chess.piece;
            Location start_loc = move_chess.start_pos;
            Location end_loc = move_chess.end_pos;

            if (piece.getType == Chess_Piece_Type.Bishop)
            {
                if (Possible_Moves.Is_Bishop_Move(piece, start_loc, end_loc, this.get_board))
                    return true;
            }

            else if (piece.getType == Chess_Piece_Type.Rook)
            {
                if (Possible_Moves.Is_Rook_Move(piece, start_loc, end_loc, this.get_board))
                    return true;
            }

            else if (piece.getType == Chess_Piece_Type.Pawn)
            {
                if (Possible_Moves.Is_Pawn_Move(piece, start_loc, end_loc, this.get_board))
                    return true;
            }

            else if (piece.getType == Chess_Piece_Type.Queen)
            {
                if (Possible_Moves.Is_Rook_Move(piece, start_loc, end_loc, this.get_board)
                    || Possible_Moves.Is_Bishop_Move(piece, start_loc, end_loc, this.get_board))
                    return true;
            }

            else if (piece.getType == Chess_Piece_Type.Knight)
            {
                if (Possible_Moves.Is_Knight_Move(piece, start_loc, end_loc, this.get_board))
                    return true;
            }

            else if (piece.getType == Chess_Piece_Type.King)
            {
                if (Possible_Moves.Is_King_Move(piece, start_loc, end_loc, this.get_board))
                    return true;
            }
            
            return false;
        }

        public Chess_Game(Form form)
        {
            board = new Chess_Piece[8, 8];
            init_board(board);
            locations = new List<Location>();
            White_Piece_Under_Attack = new List<Location>();
            Black_Piece_Under_Attack = new List<Location>();
            List_Move = new List<Move_Chess>();
            turn = Chess_Piece_Color.White;
            this.form = form;
        }

        private void Check_White_Piece_Under_Attack()
        {
            White_Piece_Under_Attack.Clear();
            White_Piece_Under_Attack = Attack.Get_White_Piece_Under_Attack(board).Distinct().ToList();
            White_Piece_Under_Attack.RemoveAll(x => x.c < 0 || x.c > 7 || x.r < 0 || x.r > 7);
        }

        private void Check_Black_Piece_Under_Attack()
        {
            Black_Piece_Under_Attack.Clear();
            Black_Piece_Under_Attack = Attack.Get_Black_Piece_Under_Attack(board);
            Black_Piece_Under_Attack.RemoveAll(x => x.c < 0 || x.c > 7 || x.r < 0 || x.r > 7);
        }


        private bool King_In_Mate(Location King_Loc)
        {
            return true;
        }

        private string King_In_Check()
        {
            foreach (Location loc in White_Piece_Under_Attack)
            {
                if (board[loc.c, loc.r] != null)
                {
                    if (board[loc.c, loc.r].getType == Chess_Piece_Type.King && board[loc.c, loc.r].getColor == Chess_Piece_Color.White)
                    {
                        (form as Form1).Check_Label.Text = "King in Check : YOU";
                        return "White";
                    }
                }
            }

            foreach (Location loc in Black_Piece_Under_Attack)
            {
                if (board[loc.c, loc.r] != null)
                {
                    if (board[loc.c, loc.r].getType == Chess_Piece_Type.King && board[loc.c, loc.r].getColor == Chess_Piece_Color.Black)
                    {

                        if (King_In_Mate(loc))
                        {
                            (form as Form1).Check_Label.Text = "King in Check : AI";
                            return "Black";

                        }
                    }
                }

            }
            
            return "None";           
        }

        private bool White_Piece_Won()
        {
            for (int i = 0; i <= board.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                {
                    if (board[i, j] != null)
                    {
                        if (board[i, j].getType == Chess_Piece_Type.King && board[i, j].getColor == Chess_Piece_Color.Black)
                            return false;
                    }
                }
            }
            return true;
        }

        private bool Black_Piece_Won()
        {
            for (int i = 0; i <= board.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                {
                    if (board[i, j] != null)
                    {
                        if (board[i, j].getType == Chess_Piece_Type.King && board[i, j].getColor == Chess_Piece_Color.White)
                            return false;
                    }
                }
            }
            return true;
        }


        public bool Piece_Move(Chess_Piece chesspiece, Panel first, Panel second)
        {
            if (chesspiece.getColor == turn)
            {
                if (first.BackgroundImage != null)
                {
                    second.BackgroundImage = first.BackgroundImage;
                    first.BackgroundImage = null;
                    if (turn == Chess_Piece_Color.White)
                        turn = Chess_Piece_Color.Black;
                    else
                        turn = Chess_Piece_Color.White;
    
                    string[] First_Coordinates = first.Name.Split(',');
                    string[] Second_Coordinates = second.Name.Split(',');
                    board[Convert.ToInt32(Second_Coordinates[0]), Convert.ToInt32(Second_Coordinates[1])] = board[Convert.ToInt32(First_Coordinates[0]), Convert.ToInt32(First_Coordinates[1])];
                    board[Convert.ToInt32(Second_Coordinates[0]), Convert.ToInt32(Second_Coordinates[1])].setLocation = new Location(Convert.ToInt32(Second_Coordinates[0]), Convert.ToInt32(Second_Coordinates[1]));
                    board[Convert.ToInt32(First_Coordinates[0]), Convert.ToInt32(First_Coordinates[1])] = null;
                    Check_Black_Piece_Under_Attack();
                    Check_White_Piece_Under_Attack();
                    if (King_In_Check() == "White")
                    {
                        (form as Form1).Check_Label.Text = "King in Check : YOU";
                    }
                    else if (King_In_Check() == "Black")
                    {
                        (form as Form1).Check_Label.Text = "King in Check : AI";
                    }
                    if (White_Piece_Won())
                    {
                        if (DialogResult.OK == MessageBox.Show("YOU WON ! Starting a New Game ...", "GAME OVER..."))
                        {
                            (form as Form1).AI_Chess_Game = new Intelligent_Chess_Game.Algorithm.Chess_Game(form);
                            (form as Form1).Player_Label.Text = "Current turn: YOU";
                            (form as Form1).chessboard.Draw_Piece();
                        }
                    }
                    if (Black_Piece_Won())
                    {
                        if (DialogResult.OK == MessageBox.Show("AI WON ! Starting a New Game ...", "GAME OVER..."))
                        {
                            (form as Form1).AI_Chess_Game = new Intelligent_Chess_Game.Algorithm.Chess_Game(form);
                            (form as Form1).Player_Label.Text = "Current turn: YOU";
                            (form as Form1).chessboard.Draw_Piece();
                        }
                    }

                    return true;
                }
                else
                    return false;
            }
            else
                return false;

        }

        private Panel Panel_Check(Location location)
        {
            foreach (Panel p in (form as Form1).chessboard.Board_Panel)
            {

                string[] coordinate = p.Name.Split(',');
                if (location.c == Convert.ToInt32(coordinate[0]) && location.r == Convert.ToInt32(coordinate[1]))
                {
                    return p;
                }
            }
            return null;
        }

        public bool movePieceWithChessMove(Move_Chess moves)
        {
            Chess_Piece chesspiece = moves.piece;
            Panel first = Panel_Check(moves.start_pos);
            Panel second = Panel_Check(moves.end_pos);
            if (chesspiece.getColor == turn)
            {
                if (first.BackgroundImage != null)
                {
                    second.BackgroundImage = first.BackgroundImage;
                    first.BackgroundImage = null;
                    if (turn == Chess_Piece_Color.White)
                        turn = Chess_Piece_Color.Black;
                    else
                        turn = Chess_Piece_Color.White;

                    string[] First_Coordinates = first.Name.Split(',');
                    string[] Second_Coordinates = second.Name.Split(',');
                    board[Convert.ToInt32(Second_Coordinates[0]), Convert.ToInt32(Second_Coordinates[1])] = board[Convert.ToInt32(First_Coordinates[0]), Convert.ToInt32(First_Coordinates[1])];
                    board[Convert.ToInt32(Second_Coordinates[0]), Convert.ToInt32(Second_Coordinates[1])].setLocation = new Location(Convert.ToInt32(Second_Coordinates[0]), Convert.ToInt32(Second_Coordinates[1]));
                    board[Convert.ToInt32(First_Coordinates[0]), Convert.ToInt32(First_Coordinates[1])] = null;

                    if (King_In_Check() == "White")
                    {
                        (form as Form1).Check_Label.Text = "King in Check : YOU";
                    }
                    else if (King_In_Check() == "Black")
                    {
                        (form as Form1).Check_Label.Text = "King in Check : AI";
                    }

                    return true;
                }
                else
                    return false;
            }
            else
                return false;

            (form as Form1).Check_Label.Text = "King in Check : YOU";
        }

    }
}

