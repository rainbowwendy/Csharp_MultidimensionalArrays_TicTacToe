using static System.Net.Mime.MediaTypeNames;
using System.Reflection.Metadata;
using System;

namespace Csharp_MultidimensionalArrays_TicTacToe
{
    public partial class Form1 : Form
    {
        // 1. 3 x 3 matrix
        // 2. initial turn / turn swap(Button Click Event to change X and Y)
        // 3. Check Valid Move
        // 4. Turn Function
        // 5. Win Check (Win, Lose, Draw)
        // 6. Reset game

        string[,] MyTicTacToe; // string Array will be shown in richtexbox
        bool[,] b_selected; // check if selected by player-used for enable
        int turnCount = 0; // will check if 9 places are checked fully
        bool b_turn = false;  // false: O's turn, true: X's turn

        public Form1()
        {
            InitializeComponent();

            reset_game();
        }

        void reset_game() // initialize data
        {
            MyTicTacToe = new string[,] // value set in memory  
            {
                { "  -  ", "  -  ", "  -  " },
                { "  -  ", "  -  ", "  -  " },
                { "  -  ", "  -  ", "  -  " }
            };

            b_selected = new bool[,] {
                { false, false, false },
                { false, false, false },
                { false, false, false }
            };

            b_turn = false;
            turnCount = 0;

            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;

            PrintArray(); // Value of MyTicTacToe Array will be printed in RichTextBox
        }

        void takes_turn()
        {
            if (b_turn == true) // If b_turn이 X
            {
                b_turn = false; // b_turn이 O
            }
            else
            {
                b_turn = true;
            }
            print_turn();
        }
      
        //    // 상태값을 바꾼다.
        //    b_turn = !b_turn; // b_turn이 true면 not true(=false)를 b_turn에 넣는다. b_turn이 false면 not false(=true)를 b-turn에 넣는다.
        //    // 화면에 텍스트를 상태값에 맞게 출력한다.

        void print_turn()
        {
            string str = "Who's Turn : ";

            if (b_turn == true)
            {
                button1.Text = str + "X";
            }
            else
            {
                button1.Text = str + "O";
            }

        }

        void PrintArray(string toFill = "")
        {
            richTextBox1.Text = " Tic Tac Toe\n\n";
            for (int i = 0; i <= MyTicTacToe.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= MyTicTacToe.GetUpperBound(1); j++)
                {
                    richTextBox1.Text += MyTicTacToe[i, j];
                }
                richTextBox1.Text += "\n";
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {      
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PrintArray();
        }

        private int WinCheck()
        {
            if ((MyTicTacToe[0, 0] == " X " && MyTicTacToe[0, 1] == " X " && MyTicTacToe[0, 2] == " X ") ||
                (MyTicTacToe[1, 0] == " X " && MyTicTacToe[1, 1] == " X " && MyTicTacToe[1, 2] == " X ") ||
                (MyTicTacToe[2, 0] == " X " && MyTicTacToe[2, 1] == " X " && MyTicTacToe[2, 2] == " X ") ||
                (MyTicTacToe[0, 0] == " X " && MyTicTacToe[1, 0] == " X " && MyTicTacToe[2, 0] == " X ") ||
                (MyTicTacToe[0, 1] == " X " && MyTicTacToe[1, 1] == " X " && MyTicTacToe[2, 1] == " X ") ||
                (MyTicTacToe[0, 2] == " X " && MyTicTacToe[1, 2] == " X " && MyTicTacToe[2, 2] == " X ") ||
                (MyTicTacToe[0, 0] == " X " && MyTicTacToe[1, 1] == " X " && MyTicTacToe[2, 2] == " X ") ||
                (MyTicTacToe[0, 2] == " X " && MyTicTacToe[1, 1] == " X " && MyTicTacToe[2, 0] == " X "))
            {
                return 0;   // X win
            }
            else if
                ((MyTicTacToe[0, 0] == " O " && MyTicTacToe[0, 1] == " O " && MyTicTacToe[0, 2] == " O ") ||
                (MyTicTacToe[1, 0] == " O " && MyTicTacToe[1, 1] == " O " && MyTicTacToe[1, 2] == " O ") ||
                (MyTicTacToe[2, 0] == " O " && MyTicTacToe[2, 1] == " O " && MyTicTacToe[2, 2] == " O ") ||
                (MyTicTacToe[0, 0] == " O " && MyTicTacToe[1, 0] == " O " && MyTicTacToe[2, 0] == " O ") ||
                (MyTicTacToe[0, 1] == " O " && MyTicTacToe[1, 1] == " O " && MyTicTacToe[2, 1] == " O ") ||
                (MyTicTacToe[0, 2] == " O " && MyTicTacToe[1, 2] == " O " && MyTicTacToe[2, 2] == " O ") ||
                (MyTicTacToe[0, 0] == " O " && MyTicTacToe[1, 1] == " O " && MyTicTacToe[2, 2] == " O ") ||
                (MyTicTacToe[0, 2] == " O " && MyTicTacToe[1, 1] == " O " && MyTicTacToe[2, 0] == " O "))
            {
                return 1;   // O win
            }
            else if (turnCount == 9)
            {
                return 2;   // draw
            }
            else
            {
                return 3;   // continue game
            }
        }

        string get_turn()
        {
            if (b_turn == false)     // false -> O's turn
            {
                return " O ";
            }
            else
            {
                return " X ";
            }
        }

        void set_array_value_with_index(int x, int y)
        {
            string str = get_turn();
            MyTicTacToe[x, y] = str;
            b_selected[x, y] = true; // x, y자리가 지금 눌렸다는 뜻
        }

        void set_array_value(int button_num) // 
        {
            if (button_num == 2)        // 1 x 1
            {
                set_array_value_with_index(0, 0);
                button2.Enabled = false;        // 버튼을 비활성화 한다.
                // button2.Visible = false;        // 버튼을 사라지게 한다.
            }
            else if (button_num == 3)
            {
                set_array_value_with_index(0, 1);
                button3.Enabled = false;
            }
            else if (button_num == 4)
            {
                set_array_value_with_index(0, 2);
                button4.Enabled = false;
            }
            else if (button_num == 5)
            {
                set_array_value_with_index(1, 0);
                button5.Enabled = false;
            }
            else if (button_num == 6)
            {
                set_array_value_with_index(1, 1);
                button6.Enabled = false;
            }
            else if (button_num == 7)
            {
                set_array_value_with_index(1, 2);
                button7.Enabled = false;
            }
            else if (button_num == 8)
            {
                set_array_value_with_index(2, 0);
                button8.Enabled = false;
            }
            else if (button_num == 9)
            {
                set_array_value_with_index(2, 1);
                button9.Enabled = false;
            }
            else if (button_num == 10)
            {
                set_array_value_with_index(2, 2);
                button10.Enabled = false;
            }
        }


        private void button2_Click(object sender, EventArgs e)  // button2: 1 x 1
        {
            if (b_selected[0, 0] == true)
            {
                MessageBox.Show("This index is already selected!");
                return;
            }

            // wincheck
            set_array_value(2);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return 은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻, 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            takes_turn();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // wincheck
            set_array_value(3);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return 은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻, 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            // button3: 1 x 2
            takes_turn();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // wincheck
            set_array_value(4);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return 은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            // button4: 1 x 3
            takes_turn();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            // wincheck
            set_array_value(5);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return 은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻, 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            // button5: 2 x 1
            takes_turn();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // wincheck
            set_array_value(6);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return 은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻, 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            // button6: 2 x 2
            takes_turn();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // wincheck
            set_array_value(7);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return 은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻, 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            // button7: 2 x 3
            takes_turn();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            // 3.wincheck
            set_array_value(8);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return 은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻, 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            // button8: 3 x 1
            takes_turn();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            // 3.wincheck
            set_array_value(9);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return 은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻, 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            // button9: 3 x 2
            takes_turn();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            // wincheck
            set_array_value(10);

            PrintArray();

            turnCount += 1;

            if (WinCheck() == 0)
            {
                MessageBox.Show("X wins!");
                reset_game();
                return; //return은 함수를 종료하겠다는 뜻, 이 지점에서 return으로 종료하지 않으면
                        //아래 takes_turn() 으로 이어서 진행이 됨. 값을 리턴하면서 종료하면 return 값이 있다는 뜻, 
            }
            else if (WinCheck() == 1)
            {
                MessageBox.Show("O wins!");
                reset_game();
                return;
            }
            else if (WinCheck() == 2)
            {
                MessageBox.Show($"No one wins You are both losers!!");
                reset_game();
                return;
            }

            // button10: 3 x 3
            takes_turn();

        }
    }
}
