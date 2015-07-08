using System;

namespace BirdNest.Nodes
{
	public interface ITreeBuilder
	{
		ITreeBuilder AddNode(INode newNode);
		ITreeBuilder AddTree(Tree existTree);
		// to allow chaining
		ITreeBuilder Parallel();
		ITreeBuilder Sequence();
		ITreeBuilder Selector();
//		ITreeBuilder AddAction(Action act);
//		ITreeBuilder AddDecorator(Decorator dec);
//		ITreeBuilder AddCondition(Condition con);
		ITreeBuilder Begin();
		ITreeBuilder End();

		Tree Build();
	}
}

