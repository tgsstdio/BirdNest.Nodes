using System;

namespace BirdNest.Nodes
{
	public interface INode
	{
		bool HasChildren ();
		bool AcceptsChildren();
		void AddChild (INode child);
		INode Sibiling { get; set; }
		INode Child { get; set; }
		INodeExaminer CreateNodeExaminer ();
	}
}

