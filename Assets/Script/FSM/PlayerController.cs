using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : BaseFSM
{
	[Header("Settings")]
	public PlayerStats stats;

	public NavMeshAgent Agent {  get; private set; }
	public Vector3 MouseWorldPosition { get; private set; }

	public PlayerIdleState IdleState;
	public PlayerMoveState MoveState;
	public PlayerDashState DashState;

	void Awake()
	{
		Agent = GetComponent<NavMeshAgent>();
		Agent.speed = stats.moveSpeed;
        Agent.updateRotation = false;

		// 상태 초기화
		IdleState = new PlayerIdleState(this);
		MoveState = new PlayerMoveState(this);
		DashState = new PlayerDashState(this);

		ChangeState(IdleState);
    }

	// PlayerInputSystem에서 우클릭 입력 -> 호출
	public void OnMove(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			GetMouseWorldPosition();
			ChangeState(MoveState);
		}
	}
	
	// PlayerInputSystem에서 스페이스바 입력 -> 호출
	public void OnDash(InputAction.CallbackContext context)
	{
		if (context.performed)
		{
			GetMouseWorldPosition();
			ChangeState(DashState);
		}
	}

	// 마우스의 좌표를 구하는 함수
	private void GetMouseWorldPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		if(Physics.Raycast(ray, out RaycastHit hit))
		{
			MouseWorldPosition = hit.point;
		}
	}

	// target Vector를 바라보는 함수
	public void LookAt(Vector3 target)
	{
		Vector3 direction = (target - transform.position).normalized;
		direction.y = 0;
		if(direction != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(direction);
		}
	}
}
