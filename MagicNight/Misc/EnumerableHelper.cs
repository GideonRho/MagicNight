using System;
using System.Collections.Generic;

namespace MagicNight.Misc
{
    public static class EnumerableHelper
    {
        
        public static void ForEach<T>(
            this IEnumerable<T> source,
            Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }

        public static void Do<T>(
            this IEnumerable<T> source,
            Action<T> action)
        {
            foreach (T element in source)
                action(element);
        }
        
        /// <summary>
        /// Returns the index of the first value that matches the given condition
        /// or -1 when no value matches the condition.
        /// </summary>
        public static int IndexOf<T>(this IEnumerable<T> self, Func<T, bool> condition)
        {
            int x = 0;
            foreach (var v in self)
            {
                if (condition.Invoke(v)) return x;
                x++;
            }

            return -1;
        }
        
        public static IEnumerable<T> Lowest<T>(this IEnumerable<T> self, Func<T, int> function)
        {
            int? i = null;
            T t = default(T);
            List<T> l = new List<T>();
            foreach (var v in self)
            {
                if (!i.HasValue)
                {
                    i = function(v);
                    t = v;
                    l.Add(t);
                    continue;
                }

                int ii = function(v);

                if (ii == i)
                {
                    l.Add(v);
                    continue;
                }
                
                if (ii < i)
                {
                    i = ii;
                    t = v;
                    l.Clear();
                    l.Add(v);
                }
            }

            if (l.Count > 0)
            {
                foreach (var x in l) yield return x;
            }
            else yield return t;
        }

        public static IEnumerable<T> Highest<T>(this IEnumerable<T> self, Func<T, int> function)
        {
            int? i = null;
            T t = default(T);
            List<T> l = new List<T>();
            foreach (var v in self)
            {
                if (!i.HasValue)
                {
                    i = function(v);
                    t = v;
                    l.Add(t);
                    continue;
                }

                int ii = function(v);

                if (ii == i)
                {
                    l.Add(v);
                    continue;
                }
                
                if (ii > i)
                {
                    i = ii;
                    t = v;
                    l.Clear();
                    l.Add(v);
                }
            }

            if (l.Count > 0)
            {
                foreach (var x in l) yield return x;
            }
            else yield return t;
        }
        
    }
}