using UnityEngine;
using UnityEngine.Events;

public class CollisionEvent : MonoBehaviour
{
	public enum TriggerMode {COLLISION_ENTER, COLLISION_STAY, COLLISION_EXIT, TRIGGER_ENTER, TRIGGER_STAY, TRIGGER_EXIT }

	[SerializeField] private TriggerMode m_TriggerMode;
	[SerializeField] private GameObjectFilter m_GameObjectFilter;
	[SerializeField] private UnityEvent m_Event;

	private void OnCollisionEnter(Collision collision)
	{
		InvokeIfMode(TriggerMode.COLLISION_ENTER, collision.transform);
	}
	private void OnCollisionStay(Collision collision)
	{
		InvokeIfMode(TriggerMode.COLLISION_STAY, collision.transform);
	}
	private void OnCollisionExit(Collision collision)
	{
		InvokeIfMode(TriggerMode.COLLISION_EXIT, collision.transform);
	}
	private void OnTriggerEnter(Collider other)
	{
		InvokeIfMode(TriggerMode.TRIGGER_ENTER, other.transform);
	}
	private void OnTriggerStay(Collider other)
	{
		InvokeIfMode(TriggerMode.TRIGGER_STAY, other.transform);
	}
	private void OnTriggerExit(Collider other)
	{
		InvokeIfMode(TriggerMode.TRIGGER_EXIT, other.transform);
	}

	private void InvokeIfMode(TriggerMode mode, Transform target)
	{
		if (m_TriggerMode == mode && m_GameObjectFilter.IsMatch(target))
			m_Event.Invoke();
	}
}
