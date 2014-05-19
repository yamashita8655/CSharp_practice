using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;

public class CSharpTest : MonoBehaviour {

	// Use this for initialization
	delegate void PrintLog();
	delegate void PrintLog2(string arg);
	void Start () {
		// 匿名メソッド
		PrintLog func1 = delegate() { Debug.Log("匿名メソッド"); };
		func1();
		func1 = Delegate;
		func1();
		
		PrintLog2 func2 = delegate(string arg) { Debug.Log("匿名メソッド2" + arg); };
		func2("arg");
		func2 = Delegate2;
		func2("arg2");
		
		// ラムダメソッド
		PrintLog func3 = () => { Debug.Log("ラムダメソッド"); };
		func3();
		PrintLog2 func4 = (string arg) => { Debug.Log("ラムダメソッド2" + arg); };
		func4("arg");

		// Dictionaryとforeach
		Dictionary<string, int> list = new Dictionary<string, int>{ {"data1", 1}, {"data2", 3 }, {"data3", 5 }};
		Debug.Log(list.Count);
		Debug.Log(list["data1"]);
		int res = 0;
		list.TryGetValue("data3", out res);
		Debug.Log(res);
		
		list.Add("data4", 10);
		list.Remove("data1");

		foreach(KeyValuePair<string, int> pair in list)
		{
			Debug.Log(pair.Key + pair.Value);
		}
	}

	void Delegate()
	{
		Debug.Log("Delegate");
	}
	
	void Delegate2(string arg)
	{
		Debug.Log("Delegate2" + arg);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
