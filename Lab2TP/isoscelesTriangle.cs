using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2TP
{
    internal class isoscelesTriangle
    {
        private int baseLength;
        private int sideLength;

        public isoscelesTriangle()
        {
            baseLength = 0;
            sideLength = 0;
        }

        public isoscelesTriangle(int baseLength, int sideLength)
        {
            SetBaseLength(baseLength);
            SetSideLength(sideLength);
        }

        public void SetBaseLength(int length)
        {
            if (length >= 0)
            {
                if (length > 6 && length < 10)
                {
                    baseLength = length;
                }
                else
                {
                    MessageBox.Show("Длина основания не может быть меньше 6 и больше 10", "Ошибка");
                }
            }
            else
            {
                MessageBox.Show("Длина основания не может быть отрицательной", "Ошибка");
            }

        }

        public int GetBaseLength()
        {
            return baseLength;
        }

        public void SetSideLength(int length)
        {
            if (length >= 0)
                sideLength = length;
            else
                MessageBox.Show("Длина стороны не может быть отрицательной", "Ошибка");
        }

        public int GetSideLength()
        {
            return sideLength;
        }

        public int calculatePerimeter()
        {
            return baseLength + 2 * sideLength;
        }

        public int calculateSquare()
        {
            return baseLength * sideLength / 2;
        }
    }
}
