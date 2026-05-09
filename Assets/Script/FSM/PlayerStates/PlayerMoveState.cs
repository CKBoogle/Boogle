using UnityEngine;

public class PlayerMoveState : IState
{
	private PlayerController pc;
	public PlayerMoveState(PlayerController pc) => this.pc = pc;

	public void Enter()
	{
		pc.LookAt(pc.MouseWorldPosition); // 즉시 회전
		pc.Agent.SetDestination(pc.MouseWorldPosition); // 도착지를 마우스 위치로 설정
		pc.Anim.CrossFade("Move", 0.1f);
	}

	public void Update()
	{
		// 다음 꺾이는 지점 바라보기
		if (pc.Agent.path.corners.Length >= 2)
		{
			Vector3 targetDir = (pc.Agent.path.corners[1] - pc.transform.position).normalized;
			targetDir.y = 0;

			if (targetDir != Vector3.zero)
			{
				pc.transform.rotation = Quaternion.Slerp(pc.transform.rotation, Quaternion.LookRotation(targetDir),Time.deltaTime * 10f);
			}
		}
		
		if (!pc.Agent.pathPending && pc.Agent.remainingDistance <= pc.Agent.stoppingDistance +0.1f) // 애니메이션이 멈추는중에도 풀파워로 달리는 애니메이션이라 그냥 미리 멈춰버리기 ( +0.1 더하기)
		{
			pc.ChangeState(pc.IdleState);
		}
	}

	public void Exit() { Debug.Log("ASD"); }
}
