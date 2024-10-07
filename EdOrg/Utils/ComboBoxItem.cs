using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdOrg.Utils
{
    public class comboBoxItem<T>
    {
        public string Text { get; set; }
        public T Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
        public static List<comboBoxItem<T>> ListFrom(IEnumerable<(string, T)> items)
        {
            List<comboBoxItem<T>> list =  new List<comboBoxItem<T>>();
            foreach (var item in items)
            {
                list.Add(new comboBoxItem<T> { Text = item.Item1, Value = item.Item2 });
            }
            return list;
        }
        public static List<comboBoxItem<T>> ListFrom(IEnumerable<T> items)
        {
            List<comboBoxItem<T>> list = new List<comboBoxItem<T>>();
            foreach (var item in items)
            {
                list.Add(new comboBoxItem<T> { Text = item.ToString(), Value = item });
            }
            return list;
        }
    }

}
