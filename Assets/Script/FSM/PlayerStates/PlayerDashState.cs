using UnityEngine;

public class PlayerDashState : IState
{
	private PlayerController pc;
	private float timer;

	public PlayerDashState(PlayerController pc) => this.pc = pc;

	public void Enter()
	{
		timer = 0;
		pc.LookAt(pc.MouseWorldPosition); // 마우스 방향 응시
		pc.Agent.ResetPath();

		// Dash처리는 Velocity로 수정할예정(임시로 즉시이동)
		Vector3 dashDir = (pc.MouseWorldPosition - pc.transform.position).normalized;
		pc.Agent.velocity = dashDir * (pc.stats.dashDistance / 0.2f); // 0.2초간 대시
	}

	public void Update()
	{
		timer += Time.deltaTime;
		if (timer >= 0.2f) pc.ChangeState(pc.IdleState); // 대시 종료
	}
	public void Exit() => pc.Agent.velocity = Vector3.zero;
}
