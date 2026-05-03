using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerStats", menuName = "Stats/PlayerStats")]
public class PlayerStats : EntityStats
{
	[Header("Dash System")]
	[Tooltip("구르기 이동 거리")]
	public float dashDistance;
	[Tooltip("구르기 쿨타임")]
	public float dashCooldown;
	[Tooltip("구르기 무적 시간")]
	public float dashInvincibleTime;
}
