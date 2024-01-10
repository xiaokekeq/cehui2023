using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 点云
{
    class Kd_tree
    {
    }

public class KDNode
    {
        public double[] Point; // 点的坐标
        public int Axis; // 选择的轴
        public KDNode Left; // 左子树
        public KDNode Right; // 右子树

        public KDNode(double[] point, int axis)
        {
            Point = point;
            Axis = axis;
        }
    }

    public class KDTree
    {
        private KDNode root; // 根节点

        public KDTree(List<double[]> points)
        {
            root = BuildTree(points, 0);
        }

        private KDNode BuildTree(List<double[]> points, int depth)
        {
            if (points == null || points.Count == 0)
            {
                return null;
            }

            int axis = depth % points[0].Length;
            points = points.OrderBy(p => p[axis]).ToList();

            int median = points.Count / 2;
            KDNode node = new KDNode(points[median], axis);
            node.Left = BuildTree(points.Take(median).ToList(), depth + 1);
            node.Right = BuildTree(points.Skip(median + 1).ToList(), depth + 1);

            return node;
        }

        public List<double[]> KNN(double[] query, int k)
        {
            List<double[]> knn = new List<double[]>();
            FindKNN(root, query, k, knn);
            return knn;
        }

        private void FindKNN(KDNode node, double[] query, int k, List<double[]> knn)
        {
            if (node == null)
            {
                return;
            }
            double dist = Distance(knn[0], query);
            int index = knn.Count;

            for (int i = 0; i < knn.Count; i++)
            {
                double d = Distance(knn[i], query);
                if (d < dist)
                {
                    dist = d;
                    index = i;
                }
            }

            if (index < k)
            {
                knn.Add(node.Point);
            }
            else if (dist < Distance(knn[index], query))
            {
                knn[index] = node.Point;
            }

            int axis = node.Axis;
            double diff = query[axis] - node.Point[axis];

            if (diff < 0)
            {
                FindKNN(node.Left, query, k, knn);
            }
            else
            {
                FindKNN(node.Right, query, k, knn);
            }

            if (knn.Count < k || Math.Abs(diff) < Distance(knn[knn.Count - 1], query))
            {
                if (diff < 0)
                {
                    FindKNN(node.Right, query, k, knn);
                }
                else
                {
                    FindKNN(node.Left, query, k, knn);
                }
            }
        }

        private double Distance(double[] p1, double[] p2)
        {
            double sum = 0;
            for (int i = 0; i < p1.Length; i++)
            {
                sum += Math.Pow(p1[i] - p2[i], 2);
            }
            return Math.Sqrt(sum);
        }
    }

}
