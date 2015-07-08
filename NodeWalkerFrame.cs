using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class NodeWalkerFrame
	{
		public INode Parent { get; private set;}
		public List<Evaluation> TaskSummary { get; set; }
		private IEnumerator<INode> mIterator;
		private INodeValidator mValidator;

		public NodeWalkerFrame (INode parentNode)
		{
			this.Parent = parentNode;
			INodeExaminer examiner = parentNode.CreateNodeExaminer ();
			mIterator = examiner.GetEnumerator ();
			mValidator = examiner.GetValidator ();
			mIterator.Reset();

			TaskSummary = new List<Evaluation>();
		}

		public IEnumerator<INode> GetEnumerator ()
		{
			return mIterator;
		}

		public INodeValidator GetValidator()
		{
			return mValidator;
		}


		public void Add(Evaluation result)
		{
			result.Order = TaskSummary.Count;
			TaskSummary.Add (result);
			mValidator.EvaluateEachChild (result);
		}
	}
}

