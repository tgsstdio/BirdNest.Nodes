using System;
using System.Collections.Generic;

namespace BirdNest.Nodes
{
	public class BlackboardLinker : IBlackboardLinker
	{
		private List<IBlackboardParameter> mInstances;
		public BlackboardLinker ()
		{
			mInstances = new List<IBlackboardParameter> ();
		}

		#region IBlackboardLinker implementation

		public void AddParameter<T> (IBlackboardParameter param) where T : class
		{
			mInstances.Add (param);
		}

		public void AddDependency<TParent, TChild> (Func<TParent, TChild> getter)
			where TParent : class
			where TChild : class
		{
			var param = new DependencyParameter<TParent, TChild> (this, getter);
			mInstances.Add (param);
		}

		public void Link (INode node)
		{
			foreach (var param in mInstances) {
				param.Assign (node);
			}
		}

		public void Link<TParent> (IBlackboardNode<TParent> node) where TParent : class
		{

		}

		#endregion
	}
}

