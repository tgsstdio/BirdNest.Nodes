using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class NullEnumerator : IEnumerator<INode>
	{
		public NullEnumerator ()
		{
		}

		#region IEnumerator implementation

		public bool MoveNext ()
		{
			return false;
		}

		public void Reset ()
		{
			//throw new NotImplementedException ();
		}

		public INode Current {
			get {
				return null;
			}
		}

		#endregion

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
	}
}

