using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋管理系统
{
    public class ChessBoard
    {
        public Chess[,] board = null;
        public ChessBoard()
        {
            board = new Chess[19, 19];
        }
        public Boolean IsExist(int x, int y)
        {
            if (x < 0 || x > 18) return false;
            if (y < 0 || y > 18) return false;
            if (board[x, y] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void ClearAllChess()
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 19; j++)
                {
                    board[i, j] = null;
                }
            }
        }
    }
}
