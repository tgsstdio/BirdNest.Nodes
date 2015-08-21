using System.Collections.Generic;
using System.Collections;

namespace BirdNest.Nodes
{
	public class EntireTreeNodeEnumerator : IEnumerator<INode>
	{
		public Tree Parent { get; set; }
		private INode mCurrentChild;
		private bool mFirstTime;

		public EntireTreeNodeEnumerator (Tree parentTree)
		{
			this.Parent = parentTree;
		}

		#region IEnumerator implementation

		public bool MoveNext ()
		{
			// shift then evaluate
			if (mFirstTime) {
				mCurrentChild = Parent.Root;
				mFirstTime = false;
			} 
			else {
				mCurrentChild = null;		
			}

			return (mCurrentChild != null);
		}

		public void Reset ()
		{
			mCurrentChild = null;
			mFirstTime = true;
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

