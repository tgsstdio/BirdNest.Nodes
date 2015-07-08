using System;

public class BlackboardRequest {
	public IBlackboard Blackboard { get; set; }
	public Type Key { get; set;}
	public bool IsPopulated { get; set; }

	public void Reset()
	{
		Blackboard = null;
		Key = null;
		IsPopulated = false;
	}
}
