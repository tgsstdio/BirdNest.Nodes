using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class NodeWalker : INodeWalker
	{
		public Stack<NodeWalkerFrame> CallStack;
		public Result Outcome { get; set; }
		public bool IsComplete { get; set; }
		public int NoOfJumps { get; private set; }

		private Tree mPlanTree;

		public INode Root 
		{
			get
			{
				return mPlanTree.Root;
			}
		}

		private void Reset ()
		{
			CallStack.Clear ();
			IsComplete = false;
			Outcome = Result.INCOMPLETE;
			NoOfJumps = 0;
		}

		private void AttachBillboards()
		{

		}

		public void Restart ()
		{
			Reset ();
			Initialise();
		}

		private IBlackboardLinker mLinker;
		public NodeWalker (Tree tree, IBlackboardLinker linker)
		{
			CallStack = new Stack<NodeWalkerFrame> ();
			mPlanTree = tree;
			mLinker = linker;
		}

		public void ComputeAllSteps()
		{
			while (!IsComplete) {
				Run ();
			}
		}

		public void ComputeStep()
		{
			if (!IsComplete) {
				Run ();
			}
		}

		private void Initialise()
		{
			NoOfJumps = 0;
			DownOneLevel (Root);
		}

		private void LogDebuggingInfo (string message)
		{
			//UnityEngine.Debug.Log(message);
			#if DEBUG
			//Console.WriteLine(message);
			#endif
		}

		void DownOneLevel (INode current)
		{
			LogDebuggingInfo ("Before Push :" + CallStack.Count);
			var frame = new NodeWalkerFrame (current);
			mLinker.Link (current);
			CallStack.Push (frame);
			LogDebuggingInfo("After Push :" + CallStack.Count);

			// Prepare loop
			frame.GetValidator ().BeginLoop();
		}

		void UpOneLevel ()
		{
			LogDebuggingInfo("Before Pop :" + CallStack.Count);

			var top = CallStack.Pop();
			top.GetValidator().CleanupLoop ();
			// before

			// Evaluate node
			Result output = top.GetValidator ().EvaluateResults (top.TaskSummary);
			LogDebuggingInfo("After Pop :" + CallStack.Count);
			if (CallStack.Count > 0)
			{
				CallStack.Peek().Add (new Evaluation (top.Parent, output));
			}
			else
			{
				Outcome = output;
			}
		}

		public bool Run()
		{
			if (CallStack.Count <= 0) {
				IsComplete = true;
				return true;
			}

			var frame = CallStack.Peek ();
			LogDebuggingInfo("RUN => Node Type :" + frame.Parent.GetType().Name);
			IEnumerator<INode> loopAgent = frame.GetEnumerator ();
			if (loopAgent.MoveNext ()) {
				DownOneLevel (loopAgent.Current);
				++NoOfJumps;
				return true; // RESTART
			} else {
				UpOneLevel ();
				++NoOfJumps;
				return false; // RESTART
			}
		}

	}
}

