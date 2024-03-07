using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2TP
{
    internal class TriangleManager
    {
        private static isoscelesTriangle activeTriangle;

        public static isoscelesTriangle GetActiveTriangle()
        {
            return activeTriangle;
        }

        public static void SetActiveTriangle(isoscelesTriangle triangle)
        {
            activeTriangle = triangle;
        }
    }
    public class TrianglesARR
    {
        private IsoscelesTriangle activeTriangle;

        public TrianglesARR(IsoscelesTriangle triangle)
        {
            activeTriangle = triangle;
        }

        public void DisplayInfoInListBox(ListBox listBox)
        {
            if (activeTriangle != null)
            {
                listBox.Items.Clear();
                listBox.Items.Add($"Base: {activeTriangle.GetBaseLength()}");
                listBox.Items.Add($"Height: {activeTriangle.GetSideLength()}");
                listBox.Items.Add($"Area: {activeTriangle.calculateSquare()}");
                listBox.Items.Add($"Perimeter: {activeTriangle.calculatePerimeter()}");
            }
        }
    }
    public class IsoscelesTriangle
    {
        private int baseLength;
        private int sideLength;

        public IsoscelesTriangle(int baseLength, int sideLength)
        {
            SetBaseLength(baseLength);
            SetSideLength(sideLength);
        }

        public void SetBaseLength(int length)
        {
            if (length >= 0)
            {
                baseLength = length;
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
        public override string ToString()
        {
            return $"Основание: {baseLength}, Сторона: {sideLength}, Периметр: {calculatePerimeter()}, Площадь: {calculateSquare()}";
        }
    }
}
