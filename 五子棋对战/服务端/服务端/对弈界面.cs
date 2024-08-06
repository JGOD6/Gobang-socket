using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace 五子棋管理系统
{
    public partial class 对弈界面 : Form
    {
        private int ChessGrid;
        private Graphics g = null;
        private Boolean isBlack;
        private Boolean isWhite;
        private ChessBoard myBoard = null;
        private Socket ServerSocket;
        private Socket socket;
        private CancellationTokenSource cancellationTokenSource;
        private bool isReady1;
        private bool isReady2;
        public 对弈界面()
        {
            InitializeComponent();
            ChessGrid = pic_Chess.Width / 19 > pic_Chess.Height / 19 ? pic_Chess.Height / 19 : pic_Chess.Width / 19;
            g = pic_Chess.CreateGraphics();
            myBoard = new ChessBoard();
        }

        private void ChessBoard()
        {
            g.Clear(Color.Gray);
            Pen pen = new Pen(Color.Black);
            for (int i = 0; i <= 18; i++)
            {
                g.DrawLine(pen, (int)(0.5 * ChessGrid), (int)((0.5 + i) * ChessGrid), (int)(18.5 * ChessGrid), (int)((0.5 + i) * ChessGrid));
            }
            for (int i = 0; i <= 18; i++)
            {
                g.DrawLine(pen, (int)((0.5 + i) * ChessGrid), (int)(0.5 * ChessGrid), (int)((0.5 + i) * ChessGrid), (int)(18.5 * ChessGrid));
            }
        }
        int st = 0;
        private void btn_Start_Click(object sender, EventArgs e)
        {
            //new BLL.Chesslog().DeleteChesslog(appvalue.namevalue);
            if (isReady1 == true && isReady2 == true)
            {
                Random rand = new Random();
                int a = rand.Next(0, 20);
                string message = a % 2 == 0 ? "cai:white" : "cai:black";
                byte[] data = Encoding.ASCII.GetBytes(message);
                socket.Send(data);

                lbl_Caixian.Text = a % 2 == 0 ? "黑棋" : "白棋";
                btn_Start.Enabled = false;
                btn_Caixian.Text = "认输";
                isBlack = a % 2 != 0;
                isWhite = a % 2 == 0;
                if (a % 2 == 0)
                {
                    isBlack = true;
                    isWhite = false;
                    st = 1;
                }
                else
                {
                    isBlack = false;
                    isWhite = true;
                    st = 2;
                }
                ChessBoard();
                Timerun();
            }
            else
            {
                if (isReady1 == false)
                {
                    MessageBox.Show("请准备");
                }
                else if (isReady2 == false)
                {
                    MessageBox.Show("对方未准备");
                }
            }
        }

        private void IsWin(int[,] chessBoard)
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (chessBoard[i, j] != 0 && chessBoard[i, j] == chessBoard[i, j + 1] && chessBoard[i, j] == chessBoard[i, j + 2] && chessBoard[i, j] == chessBoard[i, j + 3] && chessBoard[i, j] == chessBoard[i, j + 4])
                    {
                        if (chessBoard[i, j] == 2)
                        {
                            MessageBox.Show("黑棋胜利！");
                        }
                        else
                        {
                            MessageBox.Show("白棋胜利！");
                        }
                        EndGame();
                        return;
                    }
                }
            }
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    if (chessBoard[i, j] != 0 && chessBoard[i, j] == chessBoard[i + 1, j] && chessBoard[i, j] == chessBoard[i + 2, j] && chessBoard[i, j] == chessBoard[i + 3, j] && chessBoard[i, j] == chessBoard[i + 4, j])
                    {
                        if (chessBoard[i, j] == 2)
                        {
                            MessageBox.Show("黑棋胜利！");
                        }
                        else
                        {
                            MessageBox.Show("白棋胜利！");
                        }
                        EndGame();
                        return;
                    }
                }
            }
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (chessBoard[i, j] != 0 && chessBoard[i, j] == chessBoard[i + 1, j + 1] && chessBoard[i, j] == chessBoard[i + 2, j + 2] && chessBoard[i, j] == chessBoard[i + 3, j + 3] && chessBoard[i, j] == chessBoard[i + 4, j + 4])
                    {
                        if (chessBoard[i, j] == 2)
                        {
                            MessageBox.Show("黑棋胜利！");
                        }
                        else
                        {
                            MessageBox.Show("白棋胜利！");
                        }
                        EndGame();
                        return;
                    }
                }
            }
            for (int i = 0; i < 15; i++)
            {
                for (int j = 4; j < 19; j++)
                {
                    if (chessBoard[i, j] != 0 && chessBoard[i, j] == chessBoard[i + 1, j - 1] && chessBoard[i, j] == chessBoard[i + 2, j - 2] && chessBoard[i, j] == chessBoard[i + 3, j - 3] && chessBoard[i, j] == chessBoard[i + 4, j - 4])
                    {
                        if (chessBoard[i, j] == 2)
                        {
                            MessageBox.Show("黑棋胜利！");
                        }
                        else
                        {
                            MessageBox.Show("白棋胜利！");
                        }
                        EndGame();
                        return;
                    }
                }
            }
        }

        int m1 = 0, m2 = 0, s1 = 0, s2 = 0;
        int[,] XYtypes = new int[19, 19];

        private void 对弈界面_Load(object sender, EventArgs e)
        {
            btn_Caixian.Enabled = true;
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    XYtypes[i, j] = 0;
                }
            }
        }

        private void btn_Caixian_Click(object sender, EventArgs e)
        {
            if(btn_Caixian.Text == "准备")
            {
                btn_Caixian.Text = "已准备";
                isReady1 = true;
                string messageToSend = "ready:1";
                byte[] data = Encoding.ASCII.GetBytes(messageToSend);
                socket.Send(data);
            }
            else if(btn_Caixian.Text == "已准备")
            {
                btn_Caixian.Text = "准备";
                isReady1 = false;
                string messageToSend = "ready:0";
                byte[] data = Encoding.ASCII.GetBytes(messageToSend);
                socket.Send(data);
            }
            else if (btn_Caixian.Text == "认输")
            {
                string messageToSend = "endgame";
                byte[] data = Encoding.ASCII.GetBytes(messageToSend);
                socket.Send(data);
                if (isBlack)
                {
                    MessageBox.Show("白棋胜利");
                }
                else
                {
                    MessageBox.Show("黑棋胜利");
                }
                EndGame();
            }
        }

        private void pic_Chess_MouseDown(object sender, MouseEventArgs e)
        {
            SolidBrush brush = null;
            if (isBlack)
            { brush = new SolidBrush(Color.Black); }
            else
            { brush = new SolidBrush(Color.White); }
            //矫正在交叉线上的棋子
            int ChessX, ChessY;
            ChessX = e.X / ChessGrid;
            ChessY = e.Y / ChessGrid;
            this.Text = "x:y=" + ChessX + "," + ChessY;
            if (ChessX >= 0 && ChessX <= 18 && ChessY >= 0 && ChessY <= 18)
            {
                if (st == 1)
                {
                    if (!myBoard.IsExist(ChessX, ChessY))//不存在棋子才落子
                    {
                        //构造一个棋子对象
                        Chess c = new Chess();
                        c.ChessX = ChessX;
                        c.ChessY = ChessY;
                        c.IsBlack = isBlack;
                        myBoard.board[ChessX, ChessY] = c;//将棋子落在棋盘上
                        g.FillEllipse(brush, ChessX * ChessGrid, ChessY * ChessGrid, ChessGrid, ChessGrid);
                        if (isBlack)
                        {
                            XYtypes[ChessX, ChessY] = 2;
                            string messageToSend = "chess:" + ChessX + "," + ChessY + ",2";
                            byte[] data = Encoding.ASCII.GetBytes(messageToSend);
                            socket.Send(data);

                            //构造一个棋子对象
                            c.ChessX = ChessX;
                            c.ChessY = ChessY;
                            c.IsBlack = isBlack;
                            myBoard.board[ChessX, ChessY] = c;//将棋子落在棋盘上
                            g.FillEllipse(brush, ChessX * ChessGrid, ChessY * ChessGrid, ChessGrid, ChessGrid);
                            IsWin(XYtypes);
                            st = 2;
                        }
                        else
                        {
                            XYtypes[ChessX, ChessY] = 1;
                            string messageToSend = "chess:" + ChessX + "," + ChessY + ",1";
                            byte[] data = Encoding.ASCII.GetBytes(messageToSend);
                            socket.Send(data);

                            //构造一个棋子对象
                            c.ChessX = ChessX;
                            c.ChessY = ChessY;
                            c.IsBlack = isBlack;
                            myBoard.board[ChessX, ChessY] = c;//将棋子落在棋盘上
                            g.FillEllipse(brush, ChessX * ChessGrid, ChessY * ChessGrid, ChessGrid, ChessGrid);
                            IsWin(XYtypes);
                            st = 2;
                        }
                    }
                    else { MessageBox.Show("此处已有子，请重新落子！"); }
                }
                else if (st == 0) { MessageBox.Show("请开始之后再落子！"); }
                else if (st == 2) { MessageBox.Show("现在不是你的回合"); }
            }
            else { MessageBox.Show("请在棋盘内下棋！"); }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            int Port = int.Parse(textPort.Text.Trim());
            IPAddress ip = IPAddress.Any;

            if (btnClient.Text == "开始监听")
            {
                try
                {
                    ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    ServerSocket.Bind(new IPEndPoint(ip, Port));
                    ServerSocket.Listen(10);

                    Thread thread = new Thread(ListenForConnections);
                    thread.Start();
                }
                catch (SocketException ex) when (ex.SocketErrorCode == SocketError.AddressAlreadyInUse)
                {
                    Console.WriteLine("端口已被占用，请更换端口: " + ex.Message);
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("错误: " + ex.Message);
                    return;
                }

                btnClient.Text = "停止监听";
            }
            else
            {
                try
                {
                    if (socket != null && socket.Connected)
                    {
                        socket.Shutdown(SocketShutdown.Both);
                        socket.Close();
                    }
                    if (ServerSocket != null)
                    {
                        ServerSocket.Close();
                        labeltest.Text = "no connection!";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("断开错误: " + ex.Message);
                }

                btnClient.Text = "开始监听";
            }
        }

        private void ListenForConnections()
        {
            socket = ServerSocket.Accept();
            while (true)
            {
                try
                {
                    ReceiveData(socket);
                }
                catch (SocketException ex)
                {
                    Console.WriteLine("接收连接时出错: " + ex.Message);
                    break;
                }
            }
        }

        private void ReceiveData(Socket socket)
        {
            byte[] receive = new byte[1024];
            try
            {
                int bytesReceived = socket.Receive(receive, SocketFlags.None);

                if (bytesReceived > 0)
                {
                    Console.WriteLine(Encoding.ASCII.GetString(receive, 0, bytesReceived));
                    if (Encoding.ASCII.GetString(receive, 0, 4) == "link")
                    {
                        UpdateLabelText(Encoding.ASCII.GetString(receive, 5, bytesReceived - 5));
                    }
                    if (Encoding.ASCII.GetString(receive, 0, 5) == "ready")
                    {
                        isReady2 = Encoding.ASCII.GetString(receive, 6, bytesReceived - 6) == "1" ? true : false;
                    }
                    if (Encoding.ASCII.GetString(receive, 0, 5) == "chess")
                    {
                        //矫正在交叉线上的棋子
                        int ChessX, ChessY;
                        string[] parts = Encoding.ASCII.GetString(receive, 0, bytesReceived).Substring("chess:".Length).Split(',');
                        if (parts.Length == 3 && int.TryParse(parts[0], out int chessX) && int.TryParse(parts[1], out int chessY) && int.TryParse(parts[2], out int colorMarker))
                        {
                            ChessX = chessX;
                            ChessY = chessY;
                            SolidBrush brush = null;
                            if (colorMarker == 2)
                            { brush = new SolidBrush(Color.Black); }
                            else
                            { brush = new SolidBrush(Color.White); }
                            if (this.InvokeRequired)
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    this.Text = "x:y=" + ChessX + "," + ChessY;
                                });
                            }
                            else
                            {
                                this.Text = "x:y=" + ChessX + "," + ChessY;
                            }
                            if (ChessX >= 0 && ChessX <= 18 && ChessY >= 0 && ChessY <= 18)
                            {
                                if (st == 2)
                                {
                                    if (!myBoard.IsExist(ChessX, ChessY))//不存在棋子才落子
                                    {
                                        //构造一个棋子对象
                                        Chess c = new Chess();
                                        c.ChessX = ChessX;
                                        c.ChessY = ChessY;
                                        c.IsBlack = isBlack;
                                        myBoard.board[ChessX, ChessY] = c;//将棋子落在棋盘上
                                        g.FillEllipse(brush, ChessX * ChessGrid, ChessY * ChessGrid, ChessGrid, ChessGrid);
                                        if (colorMarker == 2)
                                        {
                                            XYtypes[ChessX, ChessY] = 2;

                                            //构造一个棋子对象
                                            c.ChessX = ChessX;
                                            c.ChessY = ChessY;
                                            c.IsBlack = isBlack;
                                            myBoard.board[ChessX, ChessY] = c;//将棋子落在棋盘上
                                            g.FillEllipse(brush, ChessX * ChessGrid, ChessY * ChessGrid, ChessGrid, ChessGrid);
                                            IsWin(XYtypes);
                                        }
                                        else
                                        {
                                            XYtypes[ChessX, ChessY] = 1;

                                            //构造一个棋子对象
                                            c.ChessX = ChessX;
                                            c.ChessY = ChessY;
                                            c.IsBlack = isBlack;
                                            myBoard.board[ChessX, ChessY] = c;//将棋子落在棋盘上
                                            g.FillEllipse(brush, ChessX * ChessGrid, ChessY * ChessGrid, ChessGrid, ChessGrid);
                                            IsWin(XYtypes);
                                        }
                                    }
                                    st = 1;
                                }
                            }
                        }
                    }
                    if (Encoding.ASCII.GetString(receive, 0, bytesReceived) == "endgame")
                    {
                        if (isBlack)
                        {
                            MessageBox.Show("黑棋胜利");
                        }
                        else
                        {
                            MessageBox.Show("白棋胜利");
                        }
                        EndGame();
                    }
                }
            }
            catch (SocketException ex)
            {
                Console.WriteLine("接收数据出错: " + ex.Message);
                if (socket != null && socket.Connected)
                {
                    socket.Shutdown(SocketShutdown.Both);
                    socket.Close();
                }
            }
        }

        private void UpdateLabelText(string text)
        {
            if (labeltest.InvokeRequired)
            {
                labeltest.Invoke((MethodInvoker)delegate
                {
                    labeltest.Text = text;
                });
            }
            else
            {
                labeltest.Text = text;
            }
        }

        private void Timerun()
        {
            this.timer1.Start();
            this.timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //计时器逻辑
            if (s2 < 10)
            {
                s2++;
                if (s2 == 10)
                {
                    s2 = 0;
                    s1++;
                    if (s1 == 6)
                    {
                        s1 = 0;
                        s2 = 0;
                        m2++;
                        if (m2 == 10)
                        {
                            m1++;
                            m2 = 0;
                            s1 = 0;
                            s2 = 0;
                            if (m1 == 6)
                            {
                                MessageBox.Show("平局!");
                                ChessBoard();
                            }
                        }
                    }
                }
            }
            if (lbl_time1.InvokeRequired)
            {
                lbl_time1.Invoke((MethodInvoker)delegate
                {
                    lbl_time1.Text = m1.ToString();
                });
            }
            else
            {
                lbl_time1.Text = m1.ToString();
            }
            if (lbl_time2.InvokeRequired)
            {
                lbl_time2.Invoke((MethodInvoker)delegate
                {
                    lbl_time2.Text = m2.ToString();
                });
            }
            else
            {
                lbl_time2.Text = m2.ToString();
            }
            if (lbl_time3.InvokeRequired)
            {
                lbl_time3.Invoke((MethodInvoker)delegate
                {
                    lbl_time3.Text = s1.ToString();
                });
            }
            else
            {
                lbl_time3.Text = s1.ToString();
            }
            if (lbl_time4.InvokeRequired)
            {
                lbl_time4.Invoke((MethodInvoker)delegate
                {
                    lbl_time4.Text = s2.ToString();
                });
            }
            else
            {
                lbl_time4.Text = s2.ToString();
            }
        }

        private void EndGame()
        { 
            this.timer1.Stop();
            m1 = 0;
            m2 = 0;
            s1 = 0;
            s2 = 0;
            if (lbl_time1.InvokeRequired)
            {
                lbl_time1.Invoke((MethodInvoker)delegate
                {
                    lbl_time1.Text = "0";
                });
            }
            else
            {
                lbl_time1.Text = "0";
            }
            if (lbl_time2.InvokeRequired)
            {
                lbl_time2.Invoke((MethodInvoker)delegate
                {
                    lbl_time2.Text = "0";
                });
            }
            else
            {
                lbl_time2.Text = "0";
            }
            if (lbl_time3.InvokeRequired)
            {
                lbl_time3.Invoke((MethodInvoker)delegate
                {
                    lbl_time3.Text = "0";
                });
            }
            else
            {
                lbl_time3.Text = "0";
            }
            if (lbl_time4.InvokeRequired)
            {
                lbl_time4.Invoke((MethodInvoker)delegate
                {
                    lbl_time4.Text = "0";
                });
            }
            else
            {
                lbl_time4.Text = "0";
            }
            if (btn_Caixian.InvokeRequired)
            {
                btn_Caixian.Invoke((MethodInvoker)delegate
                {
                    btn_Caixian.Text = "准备";
                });
            }
            else
            {
                btn_Caixian.Text = "准备";
            }
            if (btn_Start.InvokeRequired)
            {
                btn_Start.Invoke((MethodInvoker)delegate
                {
                    btn_Start.Enabled = true;
                });
            }
            else
            {
                btn_Start.Enabled = true;
            }
            isReady1 = false;
            string messageToSend = "ready:0";
            byte[] data = Encoding.ASCII.GetBytes(messageToSend);
            socket.Send(data);
            g.Clear(Color.Gray);
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    XYtypes[i, j] = 0;
                }
            }
            myBoard.ClearAllChess();
        }
    }
}
