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
        }

        //Select(他ではmapとか)のテスト。
        private void Select_test()
        {
            // 各要素に対して、関数を実行できる
            var numlist = new[] { 1,2,4,8 };
            var outputlist = numlist.Select(elem => elem * 2);
            foreach (var num in outputlist)
            {
                Console.WriteLine(num);// 2,4,8,16
            }

            // 予め関数作って、設定も出来る
            var outputlist2 = numlist.Select(select_function);
            foreach (var num in outputlist2)
            {
                Console.WriteLine(num);// 3,6,12,24
            }

            // delegateもいける
            var outputlist3 = numlist.Select(delegate(int num) { return num + 1; });
            foreach (var num in outputlist3)
            {
                Console.WriteLine(num);// 2,3,5,9
            }
        }

        public int select_function(int num)
        {
            return num * 3;
        }
    }
}
