using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AttachNode : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var timer = new System.Diagnostics.Stopwatch();
		var temp2 = this.gameObject.AddComponent<BlackboardNode>();		
		var temp3 = this.gameObject.AddComponent<PlainBlackboard>();	

		var temp1 = new SimpleBlackboard();	
		Dictionary<Type, IBlackboard> lookup = new Dictionary<Type, IBlackboard> ();
		lookup.Add (typeof(SimpleBlackboard), temp1);
		lookup.Add (typeof(PlainBlackboard), temp3);

		timer.Start ();
		for(int i = 0; i < 1000; ++i)
		{
			foreach (BlackboardRequest request in temp2.Requests)
			{
				request.Blackboard = lookup[request.Key];

				request.IsPopulated = true;
			}
		}
		timer.Stop ();

		Debug.Log(timer.Elapsed.TotalMilliseconds);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
