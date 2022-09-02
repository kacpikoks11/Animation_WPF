using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpf
{
    internal class Animation
    {
        public readonly static int max_val = 10;
        public const int wall_val = 999;
        public int row = 100;
        public int column = 200;
        private int[,] _BitMap = new int[900, 450]; 

        public int this[int index1, int index2]  
        {
            get
            {
                if (index1 >= row || index1 < 0 || index2 >= column || index2 < 0)
                    return wall_val;
                return _BitMap[index1, index2];
            }
            set
            {
                if (index1 >= row || index1 < 0 || index2 >= column || index2 < 0)
                    return;
                if ((value <= max_val && value >= 0) || value == wall_val)
                    _BitMap[index1, index2] = value;
            }
        }
        public int[,] ReturnBitmap()
        {
            return _BitMap;
        }

        public Animation(int i = 49, int j = 0)
        {
            this[i, j] = 10;
            this[i, j] = 1;


            for (int r = 99; r > 1; r--)
                this[r, 10] = wall_val;

            for (int r = 0; r < 100; r++)
                this[r, 45] = wall_val;
            this[40, 45] = 0;
        }

        
                  
        public void AnimationStep2()
            {
                for (int i = 0; i < row; ++i)
                    for(int j = 0; j < column; ++j)
                        {
                            if (this[i,j] < max_val && this[i,j] > 0 )
                                {
                                    if (this[i - 1, j] == 0)
                                        this[i - 1, j] = max_val;
                                    if (this[i + 1, j] == 0)
                                        this[i + 1, j] = max_val;
                                    if (this[i, j + 1] == 0)
                                        this[i, j + 1] = max_val;
                                    if (this[i, j - 1] == 0)
                                        this[i, j - 1] = max_val;
                                }
                            }
                    }
                 
        public void AnimationStep1()
        {
            for (int i = 0; i < row; ++i)
                for (int j = 0; j < column; ++j)
                {
                    if (this[i, j] > 1 && this[i, j] <= max_val)
                        this[i, j]--;
                }
        }
    }



    /*
        public void AnimationStep2()
        {
            for (int i = 0; i < row; ++i)
                for (int j = 0; j < column; ++j)
                {
                    if (this[i, j] < max_val && this[i, j] > 0)
                    {
                        if (this[i, j, 1] == 1 && this[i - 1, j] != wall_val)
                        {
                            this[i - 1, j] = max_val;
                            Swap_vel(i, j, i - 1, j);
                            this[i, j, 1] = 0;
                        }

                        else if (this[i, j, 1] == 1 && this[i - 1, j] == wall_val)
                        {
                            this[i, j, 1] = 0;
                            this[i, j, 3] = 1;
                        }
                        if (this[i, j, 2] == 1 && this[i, j + 1] != wall_val)
                        {
                            this[i, j + 1] = max_val;
                            Swap_vel(i, j, i, j + 1);
                            this[i, j, 2] = 0;
                        }

                        else if (this[i, j, 2] == 1 && this[i, j + 1] == wall_val)
                        {

                            this[i, j, 2] = 0;
                            this[i, j, 4] = 1;
                        }

                        if (this[i, j, 3] == 1 && this[i + 1, j] != wall_val)
                        {
                            this[i + 1, j] = max_val;
                            Swap_vel(i, j, i + 1, j);
                            this[i, j, 3] = 0;
                        }
                        else if (this[i, j, 3] == 1 && this[i + 1, j] == wall_val)
                        {
                            this[i, j, 3] = 0;
                            this[i, j, 1] = 1;
                        }
                        if (this[i, j, 4] == 1 && this[i, j - 1] != wall_val)
                        {
                            this[i, j - 1] = max_val;
                            Swap_vel(i, j, i, j - 1);
                            this[i, j, 4] = 0;
                        }
                        else if (this[i, j, 4] == 1 && this[i, j - 1] == wall_val)
                        {
                            this[i, j, 4] = 0;
                            this[i, j, 2] = 1;
                        }
                    }
                }
        }
        */
}
