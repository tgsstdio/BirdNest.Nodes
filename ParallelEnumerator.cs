using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class ParallelEnumerator<T> : IEnumerator<INode>
		where T : Branch
	{
		#region IDisposable implementation

		public void Dispose ()
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region IEnumerator implementation

		object System.Collections.IEnumerator.Current {
			get {
				throw new NotImplementedException ();
			}
		}

		#endregion
		
		
		private T mParent;
		private INode mCurrentChild;
		private bool mProcessingChildren;

		public int NoOfVisitedNodes { get; set; }

		public bool AbortNow {
			get;
			set;
		}

		public ParallelEnumerator (T parent)
		{
			this.mParent = parent;
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
				mCurrentChild = mParent.Child;
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
	}
}

