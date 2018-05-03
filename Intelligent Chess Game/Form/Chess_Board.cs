    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Intelligent_Chess_Game.Algorithm;

namespace Intelligent_Chess_Game
{
    public class Chess_Board
    {
        private const int Grid_Size = 8;
        private const int Title_Size = 60;
        private Color color_1 = Color.White;
        private Color color_2 = Color.DarkBlue;
        private Panel[,] board_panel;
        private Chess_Piece[,] board_piece;

        public Panel[,] Board_Panel
        {
            set { board_panel = value; }
            get { return board_panel; }
        }
        public Chess_Piece[,] Board_Piece
        {
            set { board_piece = value; }
            get { return board_piece; }
        }

        public Chess_Board()
        {
            // initialize 2D array which represent chess board
            board_panel = new Panel[Grid_Size, Grid_Size];
            board_piece = new Chess_Piece[Grid_Size, Grid_Size];
        }

        public void Draw_Board(Form form)
        {
            for (int i = 1; i <= Grid_Size; i++)
            {
                for (int j = 1; j <= Grid_Size; j++)
                {
                    Panel new_Panel = new Panel
                    {
                        Name = (i - 1).ToString() + "," + (j - 1).ToString(),
                        Location = new Point(Title_Size * i, Title_Size * j),
                        Size = new Size(Title_Size, Title_Size)
                    };

                    form.Controls.Add(new_Panel);
                    board_panel[i - 1, j - 1] = new_Panel;

                    if (i % 2 == 0)
                        new_Panel.BackColor = j % 2 != 0 ? color_2 : color_1;
                    else
                        new_Panel.BackColor = j % 2 != 0 ? color_1 : color_2;
                }
            }

          //  Draw_Position_Labels(form);
        }


        public void Draw_Piece()
        {
            foreach(Panel p in board_panel)
            {
                if (p.BackgroundImage != null)
                    p.BackgroundImage = null;
            }

            for (int i = 0; i < 8; i++)
            {
                Board_Panel[0, 0].BackgroundImage = Properties.Resources.Chess_Black_Rook;
                Board_Panel[1, 0].BackgroundImage = Properties.Resources.Chess_Black_Kinght;
                Board_Panel[2, 0].BackgroundImage = Properties.Resources.Chess_Black_Bishop;
                Board_Panel[3, 0].BackgroundImage = Properties.Resources.Chess_Black_King;
                Board_Panel[4, 0].BackgroundImage = Properties.Resources.Chess_Black_Queen;
                Board_Panel[5, 0].BackgroundImage = Properties.Resources.Chess_Black_Bishop;
                Board_Panel[6, 0].BackgroundImage = Properties.Resources.Chess_Black_Kinght;
                Board_Panel[7, 0].BackgroundImage = Properties.Resources.Chess_Black_Rook;
                Board_Panel[i, 1].BackgroundImage = Properties.Resources.Chess_Black_Pawn;
                Board_Panel[i, 6].BackgroundImage = Properties.Resources.Chess_White_Pawn;
                Board_Panel[0, 7].BackgroundImage = Properties.Resources.Chess_White_Rook;
                Board_Panel[1, 7].BackgroundImage = Properties.Resources.Chess_White_Kinght;
                Board_Panel[2, 7].BackgroundImage = Properties.Resources.Chess_White_Bishop;
                Board_Panel[3, 7].BackgroundImage = Properties.Resources.Chess_White_King;
                Board_Panel[4, 7].BackgroundImage = Properties.Resources.Chess_White_Queen;
                Board_Panel[5, 7].BackgroundImage = Properties.Resources.Chess_White_Bishop;
                Board_Panel[6, 7].BackgroundImage = Properties.Resources.Chess_White_Kinght;
                Board_Panel[7, 7].BackgroundImage = Properties.Resources.Chess_White_Rook;
            }
        }
        
        public void Draw_Btn(Form form)
        {
            Button Btn_PlayNow = new Button
            {
                Text = "PLAY NOW",
                Location = new Point(250, 600)
            };

            Btn_PlayNow.Click += (s, e) =>
            {
                DialogResult Dialog_Result = MessageBox.Show("Do you want to play now ?", "Play Now", MessageBoxButtons.YesNo);
                if (Dialog_Result == DialogResult.Yes)
                {
                    Draw_Piece();
                    (form as Form1).AI_Chess_Game = new Intelligent_Chess_Game.Algorithm.Chess_Game(form);
                    (form as Form1).Check_Label.Text = "King In Check : ";
                    (form as Form1).Player_Label.Text = "Current turn: YOU";
                }
            };

            form.Controls.Add(Btn_PlayNow);
        }

        public static Chess_Piece Get_Piece_On_Panel(Panel panel, Chess_Game chessgame)
        {
            string[] coordinate = panel.Name.Split(',');
            return chessgame.get_board[Convert.ToInt32(coordinate[0]), Convert.ToInt32(coordinate[1])];
        }

        public static Location Get_Location_Of_Panel(Panel panel)
        {
            string[] coordinate = panel.Name.Split(',');
            return new Location(Convert.ToInt32(coordinate[0]), Convert.ToInt32(coordinate[1]));
        }
        
    }
}
