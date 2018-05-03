using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Intelligent_Chess_Game.Algorithm;

namespace Intelligent_Chess_Game
{
    public partial class Form1 : Form
    {
        Panel temporary;
        public Label Player_Label;
        public Label Check_Label;

        public Chess_Board chessboard = new Chess_Board();

        public Chess_Game AI_Chess_Game;
        public Form1()
        {
            InitializeComponent();
            AI_Chess_Game = new Intelligent_Chess_Game.Algorithm.Chess_Game(this);
            this.Size = new System.Drawing.Size(600, 700);
        }

        private void clickpanel (object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                var panel = (Panel)sender;
                if (panel.BackgroundImage != null && temporary == null)
                {
                    if (Chess_Board.Get_Piece_On_Panel(panel, AI_Chess_Game).getColor == Chess_Piece_Color.White)
                    {
                        temporary = panel;
                        using (var graphicspanel = CreateGraphics())
                        {
                            var paintEventArgs = new PaintEventArgs(panel.CreateGraphics(), panel.ClientRectangle);
                            border(panel, paintEventArgs);
                        }
                    }
                }

                else if (temporary != null)
                {
                    Location start_loc = Chess_Board.Get_Location_Of_Panel(temporary);
                    Location end_loc = Chess_Board.Get_Location_Of_Panel(panel);
                    if (AI_Chess_Game.Move_Possible(new Move_Chess(Chess_Board.Get_Piece_On_Panel(temporary, AI_Chess_Game),
                        start_loc, end_loc)))
                    {
                        AI_Chess_Game.Piece_Move(Chess_Board.Get_Piece_On_Panel(temporary, AI_Chess_Game), temporary, panel);
                        temporary = null;
                        List<Move_Chess> list = AI.Moves_AI.Possible_Move(AI_Chess_Game.get_board, AI_Chess_Game.Locations);
                        Random rand = new Random();
                        int i = rand.Next(0, list.Count - 1);
                        if (!AI_Chess_Game.movePieceWithChessMove(list[i]))
                        {
                            string s = list[i].piece.getType.ToString();
                            string start = list[i].start_pos.r.ToString() + " " + list[i].start_pos.c.ToString();
                            string end = list[i].end_pos.r.ToString() + " " + list[i].end_pos.c.ToString();
                            MessageBox.Show("No Move !!! " + s + " " + end + " from " + start);
                        }
                    }

                    else
                    {
                        using (var graphicspanel = CreateGraphics())
                        {
                            var paintEventArgs = new PaintEventArgs(temporary.CreateGraphics(), temporary.ClientRectangle);
                            noborder(temporary, paintEventArgs);
                        }
                        temporary = null;
                    }
                        
                }
            }
        }

        private Panel Panel_Check (Location location)
        {
            foreach (Panel p in chessboard.Board_Panel)
            {
                string[] coordinate = p.Name.Split(',');
                if (location.c == Convert.ToInt32(coordinate[0]) && location.r == Convert.ToInt32(coordinate[1]))
                {
                    return p;
                }
            }
            return null;
        }

        private void border(object sender, PaintEventArgs p)
        {
            ControlPaint.DrawBorder(p.Graphics, (sender as Panel).ClientRectangle, Color.LawnGreen, ButtonBorderStyle.Solid);
        }

        private void noborder(Panel sender, PaintEventArgs p)
        {
            if (sender.BackColor == Color.DarkBlue)
                ControlPaint.DrawBorder(p.Graphics, (sender as Panel).ClientRectangle, Color.DarkBlue, ButtonBorderStyle.Solid);
            else
                ControlPaint.DrawBorder(p.Graphics, (sender as Panel).ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chessboard.Draw_Btn(this);
            chessboard.Draw_Board(this);

            foreach (Panel p in chessboard.Board_Panel)
            {
                p.MouseClick += clickpanel;
            }

            Player_Label = new Label
            {
                Location = new Point (50, 620),
            };

            Check_Label = new Label
            {
                Location = new Point(50, 640),
            };

            Controls.Add(Player_Label);
            Controls.Add(Check_Label);
        }
    }
}
