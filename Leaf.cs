using System;

namespace BirdNest.Nodes
{
	public abstract class Leaf : INode
	{
		public Leaf ()
		{
		}

		public abstract Result DoStuff ();

		#region INode implementation

		public void AddChild (INode child)
		{
			throw new NotImplementedException ();
		}

		#endregion

		#region INode implementation

		public bool AcceptsChildren ()
		{
			return false;
		}

		public bool HasChildren ()
		{
			return false;
		}

		public INodeExaminer CreateNodeExaminer ()
		{
			return new LeafExaminer(this);
		}

		public INode Sibiling { get; set; }

		public INode Child {
			get {
				return null;
			}
			set {

			}
		}

		#endregion
	}
}

