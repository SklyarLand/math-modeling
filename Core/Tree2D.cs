using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace SearchCore
{
    public class Tree2D : Search, IPreprocessable
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
                if (points.Count == 1)//возврат листа
                {
                    return new TreeNode(points[0]);
                }
                //сортировка элементов по нужной оси
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
                //находим середину списка
                int pLength = points.Count;
                int center = (int)(pLength / 2);
                //создаем новую ветвь
                TreeNode newNode = new TreeNode(points[center]);
                //делим список на левую и правую часть и передаем их в соответствующие ветви дерева
                var leftList = points.GetRange(0, center);
                var rightList = points.GetRange(center + 1, pLength - center - 1);

                newNode.Left = BuildTree(leftList, nextAxios);
                newNode.Right = BuildTree(rightList, nextAxios);
                return newNode;
            }
        }

        public Tree2D() : base()
        {
            this.SearchName = "2D дерево";
        }

        public override void Run(Point[] points, Rectangle window)
        {
            Preprocess(points);
            SearchAfterProprocessing(window);
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

        public void Preprocess(Point[] points)
        {
            //строим дерево, в начале сортируем по X
            Tree = TreeNode.BuildTree(points.ToList(), 0);
            searchedPoins = new List<Point>();
        }

        public void SearchAfterProprocessing(Rectangle window)
        {
            var windowWithoutBorders = new Rectangle(window.X + 1, window.Y + 1, window.Width - 2, window.Height - 2);
            TreeTraversal(Tree, windowWithoutBorders, 0);
        }
    }
}
