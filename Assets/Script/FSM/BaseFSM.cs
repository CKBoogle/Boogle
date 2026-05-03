using UnityEngine;

//상태 인터페이스
public interface IState
{
	void Enter();
	void Update();
	void Exit();
}

//부모 FSM 클래스
public abstract class BaseFSM : MonoBehaviour
{
	protected IState currentState;

	protected virtual void Update()
	{
		currentState?.Update();
	}

	//상태 변화 함수
	public void ChangeState(IState newState)
	{
		currentState?.Exit();
		currentState = newState;
		currentState?.Enter();
	}
}