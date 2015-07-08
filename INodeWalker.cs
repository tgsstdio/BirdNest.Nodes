using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public interface INodeWalker
	{
		Result Outcome { get; }
		bool IsComplete { get; }
		int NoOfJumps { get; }
		INode Root { get; }

		void ComputeAllSteps();
		void ComputeStep();
		//void Initialise();
		void Restart ();
	}
}

