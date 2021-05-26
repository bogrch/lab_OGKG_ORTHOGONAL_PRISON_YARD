using lab_try.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_try
{
    public class RandomizedVisibility
    {
        private double EPS = 1e-6;
        private List<Vector> points;
        private static Random random = new Random();
        private int iterations;

        public int Size => points.Count;
        public Vector this[int index]
        {
            get { return points[(index) % Size]; }
        }

        public RandomizedVisibility(int iterations)
        {
            this.iterations = iterations;
            points = new List<Vector>();
        }

       

        public void Add(Vector v)
        {
            points.Add(v);
        }

        public List<Vector> Solve()
        {
            return SolveRecur();
        }

        List<Vector> SolveRecur()
        {
            List<Vector> guards = new List<Vector>();
            double bestScore = 1e9;
            int bestPos = -1;
            for (int i = 0; i < iterations; i++)
            {
                int pos = random.Next(Size);
                double score = GetScore(pos);
                if (score < bestScore)
                {
                    bestScore = score;
                    bestPos = pos;
                }
            }
            List<RandomizedVisibility> polygons = new List<RandomizedVisibility>();
            List<Vector> vision = new List<Vector>();
            SetPoint(bestPos, polygons, vision);
            guards.Add(points[bestPos]);
            foreach (RandomizedVisibility p in polygons)
            {
                foreach (Vector v in p.Solve())
                {
                    guards.Add(v);
                }
            }
            return guards;
        }

        public double GetScore(int pos)
        {
            double score = 0;
            List<RandomizedVisibility> polygons = new List<RandomizedVisibility>();
            List<Vector> vision = new List<Vector>();
            SetPoint(pos, polygons, vision);
            foreach (RandomizedVisibility p in polygons)
            {
                score = Math.Max(score, p.Size * polygons.Count);
            }
            return score;
        }

        public void SetPoint(int pos, List<RandomizedVisibility> polygons, List<Vector> vision)
        {
            vision.Clear();
            polygons.Clear();
            if (Size <= 4)
            {
                foreach (Vector p in points)
                    vision.Add(p);
                return;
            }
            List<Vector> stack = vision;
            List<int> visibleIndices = new List<int>();
            stack.Add(points[pos]);
            stack.Add(points[(pos + 1) % Size]);
            visibleIndices.Add(pos);
            visibleIndices.Add((pos + 1) % Size);
            Vector center = points[pos];
            bool caveRight = false;
            bool caveLeft = false;
            bool caveLeftInCaveRight = false;
            double angle = 0;
            double angleLeft = 0;
            Vector last = null;
            for (int i = 2; i < Size; i++)
            {
                int prevIndex = (pos + i - 1 + Size) % Size;
                int index = (pos + i) % Size;
                Vector candidate = points[index];
                Func<double> crossLastToCandidate = () => Vector.Cross(center, stack[stack.Count - 1], candidate);
                Func<double> crossLastToCandidate2 = () => Vector.Cross(center, points[prevIndex], candidate);
                Func<double> crossTwoLastToCandidate = () => Vector.Cross(stack[stack.Count - 2], stack[stack.Count - 1], candidate);

                if (caveLeftInCaveRight)
                {
                    int prevPrevIndex = (prevIndex + Size - 1) % Size;
                    if (crossLastToCandidate2() > 0 || crossLastToCandidate2() == 0 && center.Distance(points[prevIndex]) > center.Distance(candidate))
                    {
                        if (Vector.Cross(points[prevPrevIndex], points[prevIndex], candidate) < 0)
                        {
                            caveLeftInCaveRight = false;
                        }
                        angleLeft += Vector.Angle(points[prevIndex] - center, candidate - center);
                    }
                }

                if (caveRight)
                {
                    angle += Vector.Angle(points[prevIndex] - center, candidate - center);
                    if (angle > -EPS && crossLastToCandidate() >= 0 && !caveLeftInCaveRight)
                    {
                        if (crossLastToCandidate() > 0)
                            stack.Add(Vector.Proection(points[prevIndex], candidate, center, stack[stack.Count - 1]));
                        caveRight = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                if (crossLastToCandidate2() >= 0)
                {
                    if (caveLeft)
                    {
                        int prevPrevIndex = (prevIndex + Size - 1) % Size;
                        if (angleLeft < EPS && Vector.Cross(points[prevPrevIndex], points[prevIndex], candidate) < 0)
                        {
                            Vector e = points[(visibleIndices[visibleIndices.Count - 1] + 1) % Size];
                            Vector s = stack[stack.Count - 1];
                            if (Vector.Cross(center, e, points[prevIndex]) < 0)
                            {
                                stack.Add(Vector.Proection(s, e, center, points[prevIndex]));
                            }
                            stack.Add(points[prevIndex]);
                            visibleIndices.Add(prevIndex);
                            caveLeft = false;
                        }
                        angleLeft += Vector.Angle(points[prevIndex] - center, candidate - center);
                    }
                    if (!caveLeft)
                    {
                        visibleIndices.Add(index);
                        stack.Add(candidate);
                    }
                }
                else
                {
                    if (crossTwoLastToCandidate() > 0 || caveLeft)
                    {
                        if (caveLeft)
                        {
                            angleLeft += Vector.Angle(points[prevIndex] - center, candidate - center);
                            if (angleLeft >= 0) continue;
                        }
                        caveLeft = true;
                        while (crossLastToCandidate() < 0)
                        {
                            last = stack[stack.Count - 1];
                            if (last == points[visibleIndices[visibleIndices.Count - 1]])
                            {
                                visibleIndices.RemoveAt(visibleIndices.Count - 1);
                            }
                            stack.RemoveAt(stack.Count - 1);
                            if (Vector.Cross(stack[stack.Count - 1], last, points[index]) < 0)
                            {
                                if (Vector.Cross(points[prevIndex], candidate, stack[stack.Count - 1]) < 0)
                                {
                                    angleLeft = 0;
                                    caveRight = true;
                                    caveLeft = false;
                                    caveLeftInCaveRight = true;
                                    angle = Vector.Angle(stack[stack.Count - 1] - center, candidate - center);
                                    break;
                                }
                            }
                        }

                        if (!caveRight)
                        {
                            angleLeft = 0;
                            if (i == Size - 1)
                            {
                                if (crossLastToCandidate() > 0)
                                {
                                    stack.Add(Vector.Proection(stack[stack.Count - 1], last, center, candidate));
                                }
                                stack.Add(candidate);
                                visibleIndices.Add(index);
                            }
                        }
                    }
                    else
                    {
                        angle = Vector.Angle(points[prevIndex] - center, candidate - center);
                        caveRight = true;
                    }
                }
            }

            for (int i = 0; i < visibleIndices.Count; i++)
            {
                int lIndex = visibleIndices[i];
                int rIndex = visibleIndices[(i + 1) % visibleIndices.Count];
                if ((lIndex + 1) % Size != rIndex)
                {
                    RandomizedVisibility polygon = new RandomizedVisibility(iterations);
                    for (int j = lIndex; j != rIndex; j = (j + 1) % Size)
                    {
                        polygon.Add(points[j]);
                    }
                    polygon.Add(points[rIndex]);
                    polygons.Add(polygon);
                }
            }
        }

    }
}
