using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class EntireTreeNodeExaminer<T> : INodeExaminer, INodeValidator
		where T : IEntireTreeNode
	{
		private T mRelated;
		private EntireTreeNodeEnumerator mTreeEnumerator;
		
		public EntireTreeNodeExaminer (T node)
		{
			mRelated = node;
			mTreeEnumerator = new EntireTreeNodeEnumerator(mRelated.ExistingTree);			
		}

		#region INodeExaminer implementation
		public IEnumerator<INode> GetEnumerator ()
		{
			return mTreeEnumerator;
		}

		public INodeValidator GetValidator ()
		{
			return this;
		}
		#endregion

		#region INodeValidator implementation

		public void EvaluateEachChild (Evaluation result)
		{

		}

		public Result EvaluateResults (List<Evaluation> tests)
		{
			if (tests.Count != 1) {
				return Result.UNEXCEPTED_ERROR;
			} else {
				return tests [0].Outcome;
			}
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
