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
            Aggregate_test();
            Other_test();
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

        //Aggregate（他ではfoldとか）のテスト。結果を次に持ち越して、処理を行う？
        private void Aggregate_test()
        {
            Console.WriteLine("Aggregate_test");
            var numlist = new[] { 2, 8, 4, 1 };
            var output = numlist.Aggregate((sum, elem) => sum + elem);
            Console.WriteLine(output);// 15
        }

        //他、便利な物とか
        private void Other_test()
        {
            Console.WriteLine("Other_test");

            // 数を数える
            var numlist = new[] { 2, 8, 4, 1 };
            var output = numlist.Count();
            Console.WriteLine(output);// 4

            // 指定した要素の取り出し
            var output2 = numlist.Take(3);
            foreach (var num in output2)
            {
                Console.WriteLine(num);// 2,8,4
            }

            // 条件に合う最初の要素を取り出す
            output = numlist.First(elem => elem > 3);
            Console.WriteLine(output);// 8

            // 条件に合う最後の要素を取り出す
            output = numlist.Last(elem => elem > 3);
            Console.WriteLine(output);// 4

            // 要素の最大値
            output = numlist.Max();
            Console.WriteLine(output);// 8

            // 要素の最小値
            output = numlist.Min();
            Console.WriteLine(output);// 1

            // 要素が含まれているかどうか
            var output3 = numlist.Contains(8);
            Console.WriteLine(output3);// true

            // 全てに要素に対して条件を満たしているか
            output3 = numlist.All(elem => elem >= 8);
            Console.WriteLine(output3);// false

            // 一部に要素に対して条件を満たしているか
            output3 = numlist.Any(elem => elem >= 8);
            Console.WriteLine(output3);// true
        }
    }
}
