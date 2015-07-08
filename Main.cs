using System;

namespace bt
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var builder = new bt.TreeBuilder ();
	
			builder
				.Sequence ()
				.Begin ()
			//	.AddNode(null)
					.Sequence ()
					.Begin ()
						//.AddAction(new AlwaysFails())
						.Sequence()
						//.AddAction(new UseScript())
						.Sequence()
					.End()
					.Sequence ()
					//.AddAction (null)
				//	.AddDecorator (null)
				//	.AddSelector (null)
					//	.Begin ()
					//		.AddAction (null)
					//		.AddAction (null)
					//	.End ()
				.End ();
			var localPlan = builder.Build();	
			
			var builder2 = new bt.TreeBuilder();
			
			builder2
				.Sequence()
				.Begin()
					.AddTree(localPlan)
					.Parallel()
				.End();
			
			Console.WriteLine("SECOND PLAN");
			var secondPlan = builder2.Build();
			
			
			var walk = new bt.NodeWalker ();
			walk.Initialise(secondPlan.Root);
		//	Debug.Log("Root");
			walk.ComputeAllSteps ();			
		}		
	}
}
