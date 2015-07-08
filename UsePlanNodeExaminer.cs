using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class UsePlanNodeExaminer : INodeExaminer, INodeValidator
	{
		private UsePlanNode mRelated;
		private UsePlanNodeEnumerator mTreeEnumerator;
		
		public UsePlanNodeExaminer (UsePlanNode node)
		{
			mRelated = node;
			mTreeEnumerator = new UsePlanNodeEnumerator(node);			
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
