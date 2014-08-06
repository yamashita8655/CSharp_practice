using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Lesson inst = new Lesson();
            inst.Init();
        }
    }

    class Lesson
    {
        public void Init()
        {
            Select_test();
            Where_test();
            OrderBy_ThenBy_test();
        }

        //Select(他ではmapとか)のテスト。
        private void Select_test()
        {
            Console.WriteLine("Select_test");
            // 各要素に対して、関数を実行できる
            var numlist = new[] { 1,2,4,8 };
            var outputlist = numlist.Select(elem => elem * 2);
            foreach (var num in outputlist)
            {
                Console.WriteLine(num);// 2,4,8,16
            }

            // 予め関数作って、設定も出来る
            outputlist = numlist.Select(select_function);
            foreach (var num in outputlist)
            {
                Console.WriteLine(num);// 3,6,12,24
            }

            // delegateもいける
            outputlist = numlist.Select(delegate(int num) { return num + 1; });
            foreach (var num in outputlist)
            {
                Console.WriteLine(num);// 2,3,5,9
            }

            // 文字列もいけるかね
            var stringlist = new[] { "one", "two", "three", "four" };
            var outputlist2 = stringlist.Select(elem => elem + "_test");
            foreach (var str in outputlist2)
            {
                Console.WriteLine(str);// 各文字に_testがくっつく
            }
        }

        public int select_function(int num)
        {
            return num * 3;
        }

        //Where(他ではfilterとか)のテスト。
        private void Where_test()
        {
            Console.WriteLine("Where_test");
            // 各要素に対して、条件を設定して、それを取り出す
            var numlist = new[] { 1, 2, 4, 8 };
            var outputlist = numlist.Where(elem => elem < 3);
            foreach (var num in outputlist)
            {
                Console.WriteLine(num);// 1,2
            }
        }

        //Orderby/Thenby（他ではSortとか）のテスト。並び替え。
        private void OrderBy_ThenBy_test()
        {
            Console.WriteLine("OrderBy_ThenBy_test");
            // 比較する要素を指定して、昇順にソートする
            var numlist = new[] { 2, 8, 4, 1 };
            var outputlist = numlist.OrderBy(elem => elem);
            foreach (var num in outputlist)
            {
                Console.WriteLine(num);// 1,2,4,8
            }

            outputlist = numlist.OrderByDescending(elem => elem);
            foreach (var num in outputlist)
            {
                Console.WriteLine(num);// 8,4,2,1
            }

            //thenは、複数要素がある場合に、2個目の条件判断で使える。
            var possrc = new[] {
                new { x = 1, y = 2 },
                new { x = 3, y = 4 },
                new { x = 1, y = 1 }
            };

            var outputlist2 = possrc.OrderBy(elem => elem.x).ThenBy(elem => elem.y);
            foreach (var num in outputlist2)
            {
                Console.WriteLine(num);
            }
        }
    }
}
