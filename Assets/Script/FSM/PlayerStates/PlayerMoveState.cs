using UnityEngine;

public class PlayerMoveState : IState
{
	private PlayerController pc;
	public PlayerMoveState(PlayerController pc) => this.pc = pc;

	public void Enter()
	{
		pc.LookAt(pc.MouseWorldPosition); // 즉시 회전
		pc.Agent.SetDestination(pc.MouseWorldPosition);
    }

	public void Update()
	{
		// 이동 중에도 계속 회전 방향 유지
		if (pc.Agent.velocity.sqrMagnitude > 0.1f)
		{
			pc.LookAt(pc.transform.position + pc.Agent.velocity);
		}

		// 목적지 도착 체크
		if (!pc.Agent.pathPending && pc.Agent.remainingDistance <= pc.Agent.stoppingDistance)
		{
			pc.ChangeState(pc.IdleState); 
        }
	}
	public void Exit() { }
}
