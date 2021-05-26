using lab_try.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Rectangle = lab_try.Models.Rectangle;

namespace lab_try
{
    public partial class Form : System.Windows.Forms.Form
    {

        private System.Drawing.Graphics graphicsObj;
        private PolygonModel model;
        private string path = @"D:\Education\3 course\ComputerGeometry\lab_try\lab_try\Tests\";

        private Polygon polygon;
        int index = 0;
        int scale = 20;

        private Random rand = new Random();

        public Form()
        {
            InitializeComponent();
            graphicsObj = this.CreateGraphics();
            inputType.SelectedIndex = 0;
            inputFile.Text = "PointsTest1.txt";

            numericUpDownRepeiteCount.Minimum = 1;
            numericUpDownRepeiteCount.Maximum = 30;
        }
        
        // GenerateModel
        private void button1_Click(object sender, EventArgs e)
        {
            if (inputType.SelectedIndex == 0)
            {
                model = Conditions.ReadPointsFromFile(path + inputFile.Text);
            }
            else
            {
                model = Conditions.GeneratePoints(rand.Next(20, 200), rand.Next(20, 100));
            }
            //PrinterReader.PrintPointList(model.Points, "");
            DrawPolygon();
        }
        
        //BuildPolygon
        private void button2_Click(object sender, EventArgs e)
        {
            DrawPolygon();
        }

        private void DrawPolygon()
        {
            if (model!=null)
            {
                DrawLines();
            }
        }

        private void DrawLines()
        {
            Pen linesPen = new Pen(System.Drawing.Color.Gray, 3);
            for (int i = 0; i < model.Points.Count; i++)
            {
                Point current = model.Points[i];
                Point next = model.Points[(i + 1) % model.Points.Count];
                graphicsObj.DrawLine(linesPen, (int)current.X * scale, (int)current.Y * scale,
                    (int)next.X * scale, (int)next.Y * scale);
            }
        }

        private void DrawGuards(List<Point> guards)
        {
            result.Text = guards.Count.ToString();
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.YellowGreen);

            for (int i = 0; i < guards.Count; i++)
            {
                Brush brush = drawBrush;
                int x = (int)(guards[i].X * scale);
                int y = (int)(guards[i].Y * scale);
                graphicsObj.FillEllipse(brush, x - 3, y - 3, 8, 8);
                
            }
        }

        private Brush GetBrush(Point point)
        {
            return new SolidBrush(System.Drawing.Color.Gray);
            switch (point.Color)
            {
                case Color.RED:
                    return new SolidBrush(System.Drawing.Color.Red);
                case Color.GREEN:
                    return new SolidBrush(System.Drawing.Color.Green);
                case Color.YELLOW:
                    return new SolidBrush(System.Drawing.Color.Yellow);
                default:
                    return new SolidBrush(System.Drawing.Color.Gray);
            }
        }

        //Clear
        private void button3_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            result.Text = "";
        }


        private void button4_Click(object sender, EventArgs e)
        {
            int increment = (int)numericUpDownRepeiteCount.Value;

            RandomizedVisibility rv = new RandomizedVisibility(increment);
            foreach (Point p in model.Points)
            {
                rv.Add(new Vector(p.X, p.Y));
            }
            var watch = System.Diagnostics.Stopwatch.StartNew();
            List<Vector> guardsVectors = rv.Solve();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Randomized visibility areas: " + elapsedMs.ToString());
            List<Point> guards = new List<Point>();
            foreach(Vector v in guardsVectors)
            {
                guards.Add(new Point(v.X, v.Y));
            }
            DrawGuards(guards);
        }

        //MontonePolygons
        private void button5_Click(object sender, EventArgs e)
        {
            Polygon polygon = new Polygon(model);

            Pen linesPen = new Pen(System.Drawing.Color.Green, 3);
            for (int i = 0; i < polygon.Lines.Count; i++)
            {
                Point current = polygon.Lines[i].Start;
                Point next = polygon.Lines[i].End;
                graphicsObj.DrawLine(linesPen, (int)current.X * scale, (int)current.Y * scale,
                    (int)next.X * scale, (int)next.Y * scale);
            }

        }

        //Rectangles
        private void button6_Click(object sender, EventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            PolygonMatrix polygonMatrix = new PolygonMatrix(model);
            List<Point> guards = polygonMatrix.GetGuards();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Rectangles: " + elapsedMs.ToString());
            foreach (Rectangle rec in polygonMatrix.Rectangles)
            {
                graphicsObj.DrawRectangle(new Pen(System.Drawing.Color.Blue, 4), (int)(rec.LeftDown.X * scale), (int)(rec.RightUp.Y * scale)- rec.GetHeight() * scale, rec.GetWidth() * scale, rec.GetHeight() * scale);
            }
           
            
            DrawGuards(guards);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void button8_Click(object sender, EventArgs e)
        {
            TestsGenerator gen = new TestsGenerator();
            gen.MazeGenerator(10, 10);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void inputType_SelectedIndexChanged(object sender, EventArgs e)
        {
            inputFileLabel.Visible = (inputType.SelectedIndex == 0);
            inputFile.Visible = (inputType.SelectedIndex == 0);

            labelRandomly.Visible = (inputType.SelectedIndex != 0);
        }

        private void scale_ValueChanged(object sender, EventArgs e)
        {
            scale = (int)Scale.Value;
        }

        private void Form_Load(object sender, EventArgs e)
        {

        }
    }
}
