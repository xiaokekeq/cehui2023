using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 点云
{
    public class KD_Node{
        public double[] Point;
        public int Axis;
        public KD_Node Left;
        public KD_Node Right;
        public KD_Node(double[] Point ,int axis)
        {
            this.Point = Point;
            this.Axis = axis;
        }
    }
    public class KD_Tree
    {
        KD_Node root;
        public KD_Tree(List<double[]>points)
        {
            root = BuildTree(points, 0);
        }
        public KD_Node BuildTree(List<double[]> point, int depth)
        {
            if (point == null||point.Count()==0)
            {
                return null;
            }
            int axis = depth % point[0].Length;
            point = point.OrderBy(p => p[axis]).ToList();

            int median = point.Count() / 2;
            KD_Node node = new KD_Node(point[median], axis);
            node.Left = BuildTree(point.Take(median).ToList(), depth + 1);
            node.Right = BuildTree(point.Skip(median).ToList(), depth + 1);
            return node;
        }

        public List<double[]> KNN(double[] query,int k)
        {
            List<double[]> knn = new List<double[]>();
            FindKNN(root,query,k,knn);
            return knn;
        }
        public void FindKNN(KD_Node node,double[] query,int k,List<double[]>knn)
        {
            if (node==null)
            {
                return;
            }
            double dist= Distance(knn[0], query);
            int index = knn.Count();
            for (int i = 0; i < knn.Count(); i++)
            {
                double d = Distance(knn[i], query);
                if (d<dist)
                {
                    dist = d;
                    index = i;
                }
            }
            if (index<k)
            {
                knn.Add(node.Point);
            }
            else if (dist<Distance(knn[index],query))
            {
                knn[index] = node.Point;
            }
            int axis = node.Axis;
            double diff = query[axis] - node.Point[axis];
            if (diff<0)
            {
                FindKNN(node.Left, query, k, knn);
            }
            else
            {
                FindKNN(node.Right, query, k, knn);
            }
            if (knn.Count<k||Math.Abs(diff)<Distance(knn[knn.Count()-1],query))
            {
                if (diff<0)
                {
                    FindKNN(node.Right, query, k, knn);
                }
                else
                {
                    FindKNN(node.Left, query, k, knn);
                }
            }
        }

        public double Distance(double[] p1,double[] p2)
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
