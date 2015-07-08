using System.Collections.Generic;
using System;
using BirdNest.Nodes;

public enum NodeType
{
	Sequence,
	Selector,
	Parallel,
	Action,
	Condition,
	UsePlan,
	Decorator
};


[Serializable]
public class PlanNode 
{
	public NodeType nodeType = NodeType.Sequence;
	private BirdNest.Nodes.INode mInternalNode;

	public string name;
	public List<PlanNode> children;
	public Plan existingPlan;

	Blackboard<PlanNode> Board
	{
		get;
		set;
	}

	public PlanNode ()
	{
		children = new List<PlanNode>();	
		Board = new Blackboard<PlanNode>();
	}

	public void Update(NodeType nextType)
	{
		if (nextType == nodeType)
		{
			return;
		}

		switch(nextType)
		{
			case NodeType.Sequence:
				mInternalNode = new BirdNest.Nodes.Sequence();
				break;
			case NodeType.Selector:
				mInternalNode = new BirdNest.Nodes.Selector();
				break;
			case NodeType.Parallel:
				mInternalNode = new BirdNest.Nodes.Parallel();
				break;
			case NodeType.UsePlan:
				mInternalNode = new BirdNest.Nodes.UsePlanNode(this);
				break;
			default:
				mInternalNode = null;
				return;
		}
		nodeType = nextType;
	}

	public BirdNest.Nodes.INode GetNodeTraversal() 
	{
		return mInternalNode;
	}
}
