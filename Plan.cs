using System.Collections;
using System;
using System.Collections.Generic;


public class Plan  {
	public PlanNode root;

	public void BindSibilings()
	{
		AttachNextSibiling(root.children);
	}

	// recursive
	private void AttachNextSibiling(List<PlanNode> siblings)
	{
		for(int i = 0; i < siblings.Count; ++i)
		{
			var parent = siblings[i];
			if (parent.GetNodeTraversal() != null)
			{
				parent.GetNodeTraversal().Sibiling = null;
				if (i < siblings.Count - 1)
				{
					parent.GetNodeTraversal().Sibiling = siblings[i + 1].GetNodeTraversal();
				}
			}
			AttachNextSibiling(parent.children);
		}
	}
}

