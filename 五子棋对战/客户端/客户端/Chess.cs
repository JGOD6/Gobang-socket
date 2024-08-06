using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋管理系统
{
    public class Chess
    {
        private int mChessX;
        private int mChessY;
        private Boolean mIsBlack;
        public int ChessX
        {
            get { return mChessX; }
            set
            {
                if (value >= 0 && value <= 18)
                {
                    mChessX = value;
                }
                else
                {
                    mChessX = 0;
                }
            }
        }
        public int ChessY
        {
            get { return mChessY; }
            set
            {
                if (value >= 0 && value <= 18)
                {
                    mChessY = value;
                }
                else
                {
                    mChessY = 0;
                }
            }
        }
        public Boolean IsBlack
        {
            get { return mIsBlack; }
            set { mIsBlack = value; }
        }
    }
}
