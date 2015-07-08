using System;
using System.Collections.Generic;
using System.Collections;

namespace BirdNest.Nodes
{ 
	public class SequenceEnumerator : IEnumerator<INode>
	{
		public INode Parent { get; set; }
		private INode mCurrentChild;
		private bool mProcessingChildren;

		public int NoOfVisitedNodes { get; set; }

		public bool AbortNow {
			get;
			set;
		}

		public SequenceEnumerator (INode parent)
		{
			this.Parent = parent;
			this.NoOfVisitedNodes = 0;
		}

		#region IEnumerator implementation

		public bool MoveNext ()
		{
			if (AbortNow) {
				return false;
			}

			// shift then evaluate
			if (!mProcessingChildren) {
				mCurrentChild = Parent.Child;
				mProcessingChildren = true;
			} else {
				if (mCurrentChild == null) {
					return false;
				}

				mCurrentChild = mCurrentChild.Sibiling;	
			}

			if (mCurrentChild != null) {
				++NoOfVisitedNodes;
				return true;
			} else {

				return false;
			}

		}

		public void Reset ()
		{
			mCurrentChild = null;
			mProcessingChildren = false;
		}

		public INode Current {
			get {
				return mCurrentChild;
			}
		}

		#endregion

		#region IEnumerator[INode] implementation
		INode IEnumerator<INode>.Current {
			get {
				return mCurrentChild;
			}
		}
		#endregion

		#region IEnumerator implementation
		object IEnumerator.Current {
			get {
				return mCurrentChild;
			}
		}
		#endregion

		#region IDisposable implementation
		public void Dispose ()
		{

		}
		#endregion
	}
}
