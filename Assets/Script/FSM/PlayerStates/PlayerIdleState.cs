using UnityEngine;

public class PlayerIdleState : IState
{
	private PlayerController pc;
	public PlayerIdleState(PlayerController pc) => this.pc = pc;

	public void Enter()
	{
		pc.Agent.ResetPath();
		pc.Anim.CrossFade("Idle", 0.25f);
	}
	public void Update() { }
	public void Exit() { }
}
