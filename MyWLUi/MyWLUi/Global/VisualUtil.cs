using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Reflection;

namespace MyWLUi.Global
{
    internal static class VisualUtil
    {
        public static string GetName(this DependencyObject obj)
        {
            if (obj is FrameworkElement element)
            {
                return element.Name;
            }

            try
            {
                return obj.GetType().GetProperty("Name")?.GetValue(obj, null)?.ToString();
            }
            catch
            {
                // Last of all, try reflection to get the value of a Name field.
                try
                {
                    return obj.GetType().GetField("Name")?.GetValue(obj)?.ToString();
                }
                catch
                {
                    return null;
                }
            }
        }



        #region Visual Tree Helper

        /// <summary>
        /// 查找对象指定条件的祖先元素。
        /// </summary>
        /// <typeparam name="T">祖先元素的类型</typeparam>
        /// <param name="obj">从哪里开始查找</param>
        /// <param name="name">目标的 Name，默认为空，不做匹配</param>
        /// <returns>目标元素或者 null。</returns>
        public static T FindVisualParent<T>(this DependencyObject obj, string name = null)
            where T : class
        {
            var parent = VisualTreeHelper.GetParent(obj);

            while (parent != null)
            {
                if (parent is T element)
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        return element;
                    }

                    if (string.Equals(parent.GetName(), name))
                    {
                        return element;
                    }
                }

                parent = VisualTreeHelper.GetParent(parent);
            }

            return null;
        }

        /// <summary>
        /// 以横向优先查找的方式查找对象指定条件的子元素。
        /// </summary>
        /// <typeparam name="T">祖先元素的类型</typeparam>
        /// <param name="obj">从哪里开始查找</param>
        /// <param name="name">目标的 Name，默认为空，不做匹配</param>
        /// <returns>目标元素或者 null。</returns>
        public static T FindVisualChildOnFlatSearching<T>(this DependencyObject obj, string name = null)
            where T : DependencyObject
        {
            var queue = new Queue<DependencyObject>();
            while (obj != null)
            {
                for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
                {
                    var child = VisualTreeHelper.GetChild(obj, i);
                    if (child is T element)
                    {
                        if (string.IsNullOrEmpty(name))
                        {
                            return element;
                        }

                        if (string.Equals(element.GetName(), name))
                        {
                            return element;
                        }
                    }

                    queue.Enqueue(child);
                }

                obj = queue.Count > 0 ? queue.Dequeue() : null;
            }

            return null;
        }

        /// <summary>
        /// 查找对象指定条件的子元素集合。
        /// </summary>
        /// <typeparam name="T">祖先元素的类型</typeparam>
        /// <param name="obj">从哪里开始查找</param>
        /// <param name="name">目标的 Name，默认为空，不做匹配</param>
        /// <returns>目标元素或者 null。</returns>
        public static List<T> FindVisualChildren<T>(this DependencyObject obj, string name = null)
            where T : DependencyObject
        {
            var result = new List<T>();
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                var child = VisualTreeHelper.GetChild(obj, i);

                if (child is T element)
                {
                    if (string.IsNullOrEmpty(name))
                    {
                        result.Add(element);
                    }

                    if (string.Equals(element.GetName(), name))
                    {
                        result.Add(element);
                    }
                }

                var grandChildren = child.FindVisualChildren<T>(name);
                if (grandChildren.Any())
                {
                    result.AddRange(grandChildren);
                }
            }

            return result;
        }

        #endregion


        public static bool TryGetProperty<T>(this object source, string propertyName, out T result)
        {
            var type = source.GetType();
            var property = type.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.NonPublic);
            var value = property?.GetValue(source);
            if (value is T t)
            {
                result = t;
                return true;
            }

            result = default;
            return false;
        }
    }
}
