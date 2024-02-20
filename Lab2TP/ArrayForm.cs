using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Lab2TP.MainForm;
using static Lab2TP.InputForm;

namespace Lab2TP
{
    public partial class ArrayForm : Form
    {
        private List<IsoscelesTriangle> trianglesList = new List<IsoscelesTriangle>();
        public ArrayForm()
        {
            InitializeComponent();
            InitializeTriangles();
        }
        private void InitializeTriangles()
        {
            for (int i = 0; i < 25; i++)
            {
                trianglesList.Add(new IsoscelesTriangle(0, 0));
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < trianglesList.Count; i++)
            {
                IsoscelesTriangle triangle = trianglesList[i];
                string triangleInfo = $"Треугольник {i + 1}: {triangle.ToString()}";
                listBox1.Items.Add(triangleInfo);
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (IsoscelesTriangle triangle in trianglesList)
            {
                triangle.SetBaseLength(0);
                triangle.SetSideLength(0);
            }
            listBox1.Items.Clear();
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            label3.Text = "Периметр треугольника:";
            label4.Text = "Площадь треугольника:";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            int selectedIndex = listBox1.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < trianglesList.Count)
            {
                IsoscelesTriangle selectedTriangle = trianglesList[selectedIndex];

                if (ValidateInput())
                {
                    selectedTriangle.SetBaseLength(int.Parse(textBox1.Text));
                    selectedTriangle.SetSideLength(int.Parse(textBox2.Text));

                    label3.Text = $"Периметр треугольника: {selectedTriangle.calculatePerimeter()}";
                    label4.Text = $"Площадь треугольника: {selectedTriangle.calculateSquare()}";



                    listBox1.Items[selectedIndex] = $"Треугольник {selectedIndex + 1}: {selectedTriangle.ToString()}";
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите треугольник из списка", "Ошибка выбора");
            }
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Введите значения для длины основания и длины стороны", "Ошибка");
                return false;
            }

            if (!int.TryParse(textBox1.Text, out int baseLength) || !int.TryParse(textBox2.Text, out int sideLength))
            {
                MessageBox.Show("Введите числовые значения для длины основания и длины стороны", "Ошибка");
                return false;
            }

            if (baseLength <= 0 || sideLength <= 0)
            {
                MessageBox.Show("Введите положительные значения для длины основания и длины стороны", "Ошибка");
                return false;
            }

            if (baseLength >= sideLength * 2 || sideLength >= baseLength * 2)
            {
                MessageBox.Show("Стороны должны соответствовать правилу треугольника", "Ошибка");
                return false;
            }

            return true;
        }
    }
}
