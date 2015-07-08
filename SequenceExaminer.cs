using System;
using System.Collections.Generic;
using System.Collections;

namespace BirdNest.Nodes
{
	public class SequenceExaminer<T> : INodeExaminer, INodeValidator
		where T : Branch
	{
		private T mSequence;
		private SequenceEnumerator mEnumerator;

		public SequenceExaminer (T related)
		{
			mSequence = related;
			mEnumerator = new SequenceEnumerator (mSequence);
			mEnumerator.AbortNow = false;
		}

		#region INodeValidator implementation

		public void CleanupLoop ()
		{
			//throw new NotImplementedException ();
		}

		public void BeginLoop ()
		{
			//throw new NotImplementedException ();
		}

		private int GetNoOfChildren()
		{
			int count = 0;
			INode current = mSequence.Child;
			while (current != null) {
				++count;
				current = current.Sibiling;
			}
			return count;
		}

		#region INodeValidator implementation

		public void EvaluateEachChild (Evaluation result)
		{
			if (result.Outcome != Result.SUCCESS) {
				mEnumerator.AbortNow = true;
			}
		}

		#endregion

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

		#region INodeExaminer implementation
		public IEnumerator<INode> GetEnumerator ()
		{
			return mEnumerator;
		}

		public INodeValidator GetValidator ()
		{
			return this;
		}
		#endregion
	}
}

