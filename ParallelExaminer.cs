using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class ParallelExaminer<T> : INodeExaminer, INodeValidator
		where T : Branch
	{
		private T mParallel;
		private ParallelEnumerator<T> mIterator;

		public ParallelExaminer(T related)
		{
			mParallel = related;
			mIterator = new ParallelEnumerator<T>(mParallel);
		}
		
		private int GetNoOfChildren()
		{
			int count = 0;
			INode current = mParallel.Child;
			while (current != null) {
				++count;
				current = current.Sibiling;
			}
			return count;
		}		

		#region INodeValidator implementation

		public void BeginLoop ()
		{

		}

		#endregion

		#region INodeValidator implementation

		public void EvaluateEachChild (Evaluation result)
		{
			if (result.Outcome == Result.UNEXCEPTED_ERROR) {
				mIterator.AbortNow = true;
			}
		}

		public Result EvaluateResults (List<Evaluation> tests)
		{
			if (GetNoOfChildren () != tests.Count) {
				return Result.FAILED;
			}

			foreach (Evaluation output in tests)
			{
				if (output.Outcome == Result.FAILED) {
					return Result.FAILED;
				}
			}
			return Result.SUCCESS;			
		}

		#endregion

		#region INodeValidator implementation

		public void CleanupLoop ()
		{

		}

		#endregion

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
	}
}

