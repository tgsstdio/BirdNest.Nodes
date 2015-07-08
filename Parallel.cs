using System;

namespace BirdNest.Nodes
{
	public class Parallel : Branch
	{
		public Parallel ()
		{
		}

		#region implemented abstract members of Branch
		public override INodeExaminer CreateNodeExaminer ()
		{
			return new ParallelExaminer<Parallel>(this);
		}
		#endregion
	}
}

