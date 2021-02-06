using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Actions/Play Jump Particles")]
public class PlayJumpParticlesActionSO : StateActionSO<PlayJumpParticlesAction> { }

public class PlayJumpParticlesAction : StateAction
{
	//Component references
	private DustParticlesController _dustController;

	public override void Awake()
	{
		_dustController = gameObject.GetComponent<DustParticlesController>();
	}

	public override void OnStateEnter()
	{
		_dustController.PlayJumpParticles();
	}

	public override void OnUpdate() { }
}
