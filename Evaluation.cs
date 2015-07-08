using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class Evaluation
	{
		public Evaluation (INode parent, Result output)
		{
			this.Node = parent;
			Outcome = output;
		}

		public INode Node {get; set;}
		public int Order {get;set;}
		public Result Outcome {get; set;}
	}
}

