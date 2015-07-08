using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class SelectorExaminer<T> : INodeExaminer, INodeValidator
		where T : Branch
	{
		private T mRelatedNode;
		private SelectorEnumerator mIterator;

		public SelectorExaminer(T node)
		{
			mRelatedNode = node;
			mIterator = new SelectorEnumerator(mRelatedNode);
		}
		
	
		#region INodeExaminer implementation
		public IEnumerator<INode> GetEnumerator ()
		{
			return mIterator;
		}

		public INodeValidator GetValidator ()
		{
			return this;
		}
		#endregion

		#region INodeValidator implementation

		public void EvaluateEachChild (Evaluation result)
		{
			if (result.Outcome == Result.SUCCESS || result.Outcome == Result.UNEXCEPTED_ERROR) {
				mIterator.AbortNow = true;
			}
		}

		public Result EvaluateResults (List<Evaluation> tests)
		{
			foreach (Evaluation output in tests)
			{
				if (output.Outcome == Result.SUCCESS) {
					return Result.SUCCESS;
				}
			}
			return Result.FAILED;
		}

		public void BeginLoop ()
		{

		}

		public void CleanupLoop ()
		{

		}

		#endregion
	}
}

