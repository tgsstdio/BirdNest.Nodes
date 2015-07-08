using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class LeafExaminer : INodeExaminer, INodeValidator
	{
		private Leaf mRelatedLeaf;

		public LeafExaminer (Leaf related)
		{
			mRelatedLeaf = related;
		}

		public IEnumerator<INode> GetEnumerator ()
		{
			return new NullEnumerator ();
		}

		public INodeValidator GetValidator ()
		{
			return this;
		}

		public void BeginLoop ()
		{
			//throw new NotImplementedException ();
		}

		public void EvaluateEachChild (Evaluation result)
		{

		}

		public Result EvaluateResults (List<Evaluation> tests)
		{
			return mRelatedLeaf.DoStuff ();
		}

		public void CleanupLoop ()
		{
			//throw new NotImplementedException ();
		}
	}
}

