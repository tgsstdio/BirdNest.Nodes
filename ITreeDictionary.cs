//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
namespace BirdNest.Nodes
{
	public interface ITreeDictionary
	{
		void Register<T, TParent> (TParent stub)
			where T : class
			where TParent : Action, IBlackboardNode<T>;
		INode AddStub<T, TParent>(Tree treeNode)
			where T : class
			where TParent : Action, IBlackboardNode<T>;
		INode Resolve<T, TParent>()
			where T : class
			where TParent : Action;

	}
}

