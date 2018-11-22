using System;
using UnityEngine;

[Serializable]
public class GameObjectFilter
{
	private enum Comparison { LAYER, TAG }

	[SerializeField] private Comparison m_FilterBy = Comparison.LAYER;
	[SerializeField] private LayerMask m_LayerMask = 1;
	[SerializeField] private string m_Tag = "";

	public bool IsMatch(Transform target)
	{
		return m_FilterBy == Comparison.LAYER ? CompareLayer(target.gameObject) : CompareTag(target);
	}

	public bool IsMatch(GameObject target)
	{
		return m_FilterBy == Comparison.LAYER ? CompareLayer(target) : CompareTag(target.transform);
	}

	private bool CompareTag(Transform target)
	{
		return target.CompareTag(m_Tag);
	}

	private bool CompareLayer(GameObject target)
	{
		return m_LayerMask.value == (m_LayerMask.value | (1 <<  target.layer));
	}
}
