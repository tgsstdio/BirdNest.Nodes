using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class PlanNodeList : IList<PlanNode>, ICollection<PlanNode>, IEnumerable<PlanNode>, IList, ICollection, IEnumerable
{
	public List<PlanNode> mInternalList;
	public PlanNode mParent;

	public PlanNodeList (PlanNode parent)
	{
		mInternalList = new List<PlanNode> ();
	}

	#region IList implementation

	public int Add (object value)
	{
		mInternalList.Add (value as PlanNode);
		return mInternalList.Count;
	}

	public bool Contains (object value)
	{
		return mInternalList.Contains (value as PlanNode);
	}

	public int IndexOf (object value)
	{
		return mInternalList.IndexOf (value as PlanNode);
	}

	public void Insert (int index, object value)
	{
		mInternalList.Insert (index, value  as PlanNode);
	}

	public void Remove (object value)
	{
		mInternalList.Remove (value  as PlanNode);
	}

	object IList.this [int index] {
		get {
			return mInternalList[index];
		}
		set {
			mInternalList[index] = value  as PlanNode;
		}
	}

	public bool IsFixedSize {
		get {
			return false;
		}
	}

	#endregion

	#region ICollection implementation

	public void CopyTo (Array array, int index)
	{
		throw new NotImplementedException ();
	}

	public object SyncRoot {
		get {
			throw new NotImplementedException ();
		}
	}

	public bool IsSynchronized {
		get {
			throw new NotImplementedException ();
		}
	}

	#endregion

	#region IList implementation
	public int IndexOf (PlanNode item)
	{
		return mInternalList.IndexOf (item);
	}
	public void Insert (int index, PlanNode item)
	{
		mInternalList.Insert (index,item);
	}
	public void RemoveAt (int index)
	{
		mInternalList.RemoveAt (index);
	}
	public PlanNode this [int index] {
		get {
			return mInternalList[index];
		}
		set {
			mInternalList[index] = value;
		}
	}
	#endregion
	#region ICollection implementation
	public void Add (PlanNode item)
	{
		mInternalList.Add (item);
	}
	public void Clear ()
	{
		mInternalList.Clear ();
	}
	public bool Contains (PlanNode item)
	{
		return mInternalList.Contains (item);
	}
	public void CopyTo (PlanNode[] array, int arrayIndex)
	{
		CopyTo (array, arrayIndex);
	}
	public bool Remove (PlanNode item)
	{
		return mInternalList.Remove (item);
	}
	public int Count {
		get {
			throw new NotImplementedException ();
		}
	}
	public bool IsReadOnly {
		get {
			return false;
		}
	}
	#endregion
	#region IEnumerable implementation
	public IEnumerator<PlanNode> GetEnumerator ()
	{
		return mInternalList.GetEnumerator ();
	}
	#endregion
	#region IEnumerable implementation
	IEnumerator IEnumerable.GetEnumerator ()
	{
		return mInternalList.GetEnumerator ();
	}
	#endregion
}
