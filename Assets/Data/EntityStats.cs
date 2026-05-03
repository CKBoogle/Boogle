using UnityEngine;

public abstract class EntityStats : ScriptableObject
{
	[Header("Common Stats")]
	[Tooltip("최대 체력")]
	public float maxHp;
	[Tooltip("이동 속도")]
	public float moveSpeed;
}
