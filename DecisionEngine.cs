using System.Collections.Generic;
using System;

public class DecisionEngine {
	private bt.Tree localPlan;	
	
	// Use this for initialization
	void Start () {
		var builder = new bt.TreeBuilder ();

		builder
			.AddSequence ()
			.Begin ()
		//	.AddNode(null)
				.AddSequence ()
				.Begin ()
					//.AddAction(new AlwaysFails())
					.AddSequence()
					//.AddAction(new UseScript())
					.AddSequence()
				.End()
				.AddSequence ()
				//.AddAction (null)
			//	.AddDecorator (null)
			//	.AddSelector (null)
				//	.Begin ()
				//		.AddAction (null)
				//		.AddAction (null)
				//	.End ()
			.End ();
		localPlan = builder.Build();	
		//Debug.Log("Start");
	}
	
	// Update is called once per frame
	void Update () {
		Instruct("players", null);
		//Instruct("enemies", null);
	}
	
	void Instruct(string tag, object tree)
	{
		var groupMembers = GameObject.FindGameObjectsWithTag(tag);
		foreach(var member in groupMembers)
		{
			
		}
		var walk = new bt.NodeWalker ();
		walk.Initialise(localPlan.Root);
	//	Debug.Log("Root");
		walk.ComputeAllSteps ();

		//Debug.Log("Stopped : " + walk.Outcome.ToString());		
	//	Debug.Log("Instruct : " + tag);
	}
}
