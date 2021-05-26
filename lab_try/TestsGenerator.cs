using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public class TestsGenerator
    {
        Point begPoint;
        public List<Point> MazeGenerator(int size, int iterations)
        {
            int[][] Matrix;
            Matrix = new int[size][];
            for (int i = 0; i < size; i++)
            {
                Matrix[i] = new int[size];
            }
            Random rand = new Random();
           
            MatrixPosition position = new MatrixPosition(size / 2, size / 2);
            Matrix[position.x][position.y] = 1;
            Stack<MatrixPosition> positions = new Stack<MatrixPosition>();
            positions.Push(position);
   
            for (int i = 0; i < iterations; i++)
            {
                List<MatrixPosition> avaliablePositions = GetPositions(Matrix, position, size);
                if (avaliablePositions.Count == 0)
                {
                    position = positions.Pop();
                }
                else
                {
                    position = avaliablePositions[rand.Next() % avaliablePositions.Count];
                    positions.Push(position);
                    Matrix[position.x][position.y] = 1;
                }
            }
            PrinterReader.PrintMatrixPolygon(Matrix);
            List<Point> points = GetPoints(Matrix);
            foreach (Point p in points)
            {
                p.X += 1;
            }
            return points;
        }

        private List<MatrixPosition> GetPositions(int[][] matrix, MatrixPosition position, int size)
        {
            List<MatrixPosition> avaliablePositions = new List<MatrixPosition>();
            if (position.x + 2<size&&matrix[position.x + 1][position.y] != 1)
            {
                avaliablePositions.Add(new MatrixPosition(position.x + 1, position.y));
            }
            if (position.x - 2 >0 && matrix[position.x-1][position.y] != 1)
            {
                avaliablePositions.Add(new MatrixPosition(position.x - 1, position.y));
            }
            if (position.y + 2<size && matrix[position.x][position.y+1] != 1)
            {
                avaliablePositions.Add(new MatrixPosition(position.x, position.y+1));
            }
            if (position.y-2>0&&matrix[position.x][position.y-1] != 1)
            {
                avaliablePositions.Add(new MatrixPosition(position.x, position.y-1));
            }
            return avaliablePositions;
        }

        private List<Point> GetPoints(int[][] matrix)
        {
            List<Point> points = new List<Point>();
            int i = 0;
            int j = 0;
            bool empty = true;
            while (empty)
            {
                for (j = 0; j<matrix.Length; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        empty = false;
                        break;
                    }
                }
                i++;
            }
            begPoint = new Point(i-2, j-1);
            points.Add(new Point(i-2, j));
            points.AddRange(GoRight(matrix, new MatrixPosition(i-1, j)));
            points.Reverse();
            return NormalizePoints(points);
        }

        private List<Point> NormalizePoints(List<Point> points)
        {
            int minX = (int)points.OrderBy(x => x.X).FirstOrDefault().X-1;
            int minY = (int)points.OrderBy(x => x.Y).FirstOrDefault().Y-1;
            foreach(Point p in points)
            {
                p.X -= minX;
                p.Y -= minY;
            }
            return points;
        }

        private List<Point> GoRight(int[][] matrix, MatrixPosition position)
        {
            List<Point> points = new List<Point>();
            int x = position.x;
            int y = position.y;
            while (matrix[x][y] == 1 && matrix[x-1][y] == 0)
            {
                y++;
            }
            
            if (matrix[x][y] == 1)
            {
                points.Add(GetPoint(x-1, y,0));
                points.AddRange(GoUp(matrix, new MatrixPosition(x-1, y)));
            }
            else
            {
                points.Add(GetPoint(x-1, y, 0));
                points.AddRange(GoDown(matrix, new MatrixPosition(x, y-1)));
            }

            return points;
        }

        private List<Point> GoUp(int[][] matrix, MatrixPosition position)
        {
            List<Point> points = new List<Point>();
            int x = position.x;
            int y = position.y;
            while (matrix[x][y] == 1 && matrix[x][y-1] == 0)
            {
                x--;
            }
            if (matrix[x][y] == 0)
            {
                
                if (x == begPoint.X && y-1 == begPoint.Y)
                {
                    return points;
                }
                points.Add(GetPoint(x, y, 0));
                points.AddRange(GoRight(matrix, new MatrixPosition(x+1, y)));
            }
            else
            {
                points.Add(GetPoint(x, y, 0));
                points.AddRange(GoLeft(matrix, new MatrixPosition(x, y-1)));
            }
            return points;
        }

        private List<Point> GoDown(int[][] matrix, MatrixPosition position)
        {
            List<Point> points = new List<Point>();
            int x = position.x;
            int y = position.y;
            while (matrix[x][y] == 1 && matrix[x][y+1] == 0)
            {
                x++;
            }
            if (matrix[x][y] == 0)
            {
                points.Add(GetPoint(x-1, y+1, 0));
                points.AddRange(GoLeft(matrix, new MatrixPosition(x-1, y)));
            }
            else
            {
                points.Add(GetPoint(x-1, y+1, 0));
                points.AddRange(GoRight(matrix, new MatrixPosition(x, y+1)));
            }
            return points;
        }

        private List<Point> GoLeft(int[][] matrix, MatrixPosition position)
        {
            List<Point> points = new List<Point>();
            int x = position.x;
            int y = position.y;
            while (matrix[x][y] == 1 && matrix[x+1][y] == 0)
            {
                y--;
            }
            if (matrix[x][y] == 0)
            {
                points.Add(GetPoint(x, y+1, 0));
                points.AddRange(GoUp(matrix, new MatrixPosition(x, y+1)));
            }
            else
            {
                points.Add(GetPoint(x, y+1,0));
                points.AddRange(GoDown(matrix, new MatrixPosition(x+1, y)));
            }
            return points;
        }

        private Point GetPoint(int x, int y, int add)
        {
            return new Point(x * 1 + 0, y * 1 + 0);
        }

        
    }
}

public class MatrixPosition
{
    public int x { get; set; }
    public int y { get; set; }

    public MatrixPosition(int X, int Y)
    {
        x = X;
        y = Y;
    }
    
}
