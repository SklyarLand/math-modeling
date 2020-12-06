using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SearchCore
{
    public class Tree2D : Search
    {
        private TreeNode Tree;
        internal class TreeNode
        {
            public Point Point { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(Point point)
            {
                Point = point;
            }

            //построение дерева, axes: x=0, y=1
            public static TreeNode BuildTree(List<Point> points, int axis)
            {
                if (points.Count < 1) return null;
                if (points.Count == 1)//возврат листа
                {
                    return new TreeNode(points[0]);
                }
                if (points.Count > 20) {
                    var newr = 5; 
                }
                //Пирамидальная сортировка
                //HeapSort(points, compare);
                int nextAxios = 0;
                if (axis > 0)
                    points.Sort(YCompare);
                else
                {
                    points.Sort(XCompare);
                    nextAxios = 1;
                }
                //возврат корня с 1 листом
                if (points.Count == 2)
                {
                    TreeNode newRoot = new TreeNode(points[1]);
                    newRoot.Left = new TreeNode(points[0]);
                    return newRoot;
                }
                //определение делегата сравнения на следующем уровне дерева
                //находим середину списка
                int pLength = points.Count;
                int center = (int)(pLength / 2);
                //создаем новую ветвь
                TreeNode newNode = new TreeNode(points[center]);

                var leftList = points.GetRange(0, center);
                var rightList = points.GetRange(center + 1, pLength - center - 1);

                newNode.Left = BuildTree(leftList, nextAxios);
                newNode.Right = BuildTree(rightList, nextAxios);
                return newNode;
            }
        }

        public Tree2D() :base()
        {
            this.SearchName = "2D дерево";
        }

        public override void Run(Point[] points, Rectangle window)
        {
            //строим дерево, в начале сортируем по X
            Tree = TreeNode.BuildTree(points.ToList(), 0);
            searchedPoins = new List<Point>();
            var windowWithoutBorders = new Rectangle(window.X + 1, window.Y + 1, window.Width - 2, window.Height - 2);
            TreeTraversal(Tree, windowWithoutBorders, 0);
        }

        //Поиск по дереву, axes: x=0, y=1
        private void TreeTraversal(TreeNode node, Rectangle window, int axis) 
        {
            if (node == null)
                return;
            //проверка точки
            var point = node.Point;
            if (window.Left <= point.X && window.Top <= point.Y)
                if (window.Right >= point.X && window.Bottom >= point.Y)
                    searchedPoins.Add(point);
            //если у нее нет потомков
            if (node.Left == null && node.Right == null) 
            {
                return;
            }
            
            if (axis > 0)
            {
                if (window.Top <= point.Y && window.Bottom >= point.Y)
                {
                    Rectangle leftR = new Rectangle(window.Left, window.Top, window.Width, point.Y - window.Top);
                    Rectangle rightR = new Rectangle(window.Left, point.Y, window.Width, window.Bottom - point.Y);

                    TreeTraversal(node.Left, leftR, 0);
                    TreeTraversal(node.Right, rightR, 0);
                }
                else if (window.Top < point.Y && window.Bottom < point.Y)
                {
                    TreeTraversal(node.Left, window, 0);
                }
                else 
                {
                    TreeTraversal(node.Right, window, 0);
                }
            }
            else 
            {
                if (window.Left <= point.X && window.Right >= point.X)
                {
                    Rectangle leftR = new Rectangle(window.Left, window.Top, point.X - window.Left, window.Height);
                    Rectangle rightR = new Rectangle(point.X, window.Top, window.Right - point.X, window.Height);

                    TreeTraversal(node.Left, leftR, 1);
                    TreeTraversal(node.Right, rightR, 1);
                }
                else if (window.Left < point.X && window.Right < point.X)
                {
                    TreeTraversal(node.Left, window, 1);
                }
                else
                {
                    TreeTraversal(node.Right, window, 1);
                }
            }

        }


        //Алгоритм пирамидальной сортировки
        /*private void HeapSort(List<Point> list, AxiosComparer compare)
        {
            int size = list.Count;
            for (int i = (size / 2) - 1; i >= 0; i--)
                siftDown(list, i, size - 1, compare);
            // Просеиваем через пирамиду остальные элементы
            for (int i = size - 1; i >= 1; i--)
            {
                Swap(list, 0, i);
                siftDown(list, 0, i - 1, compare);
            }
        }

        private void siftDown(List<Point> list, int root, int bottom, AxiosComparer compare)
        {
            int maxChild; // индекс максимального потомка
            bool done = false; // флаг того, что куча сформирована
                               // Пока не дошли до последнего ряда
            while ((root * 2 <= bottom) && !done)
            {
                if (root * 2 == bottom)    // если мы в последнем ряду,
                    maxChild = root * 2;    // запоминаем левый потомок
                                            // иначе запоминаем больший потомок из двух
                else if (compare( list[root * 2], list[root * 2 + 1]))
                    maxChild = root * 2;
                else
                    maxChild = root * 2 + 1;
                // если элемент вершины меньше максимального потомка
                if (compare(list[maxChild], list[root]))
                {
                    Swap(list, root, maxChild);
                    root = maxChild;
                }
                else done = true; // пирамида сформирована
            }
        }

        protected void Swap(List<Point> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }*/

        //сортировка точек по X
        private static int XCompare(Point p1, Point p2)
        {
            if (p1.X < p2.X)
                return -1;
            else
                return p1.X > p2.X ? 1: 0;
        }

        //сортировка точек по Y
        private static int YCompare(Point p1, Point p2)
        {
            if (p1.Y < p2.Y)
                return -1;
            else
                return p1.Y > p2.Y ? 1 : 0;
        }
    }
}
