using System;

namespace BirdNest.Nodes
{
	public interface IBlackboardLinker
	{
		void AddParameter<TParent>(IBlackboardParameter board) where TParent : class;
		void AddDependency<TParent, TChild>(Func<TParent, TChild> getter)
			where TParent : class
			where TChild : class;
		void Link(INode node);
		void Link<TParent>(IBlackboardNode<TParent> node) where TParent : class;
	}
}

