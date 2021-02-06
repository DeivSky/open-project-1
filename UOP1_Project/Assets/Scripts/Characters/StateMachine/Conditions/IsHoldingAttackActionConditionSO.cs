using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Conditions/Is Holding Attack Action")]
public class IsHoldingAttackActionConditionSO : StateConditionSO<IsHoldingAttackActionCondition> { }

public class IsHoldingAttackActionCondition : Condition
{
	//Component references
	private Protagonist _protagonistScript;

	public override void Awake()
	{
		_protagonistScript = gameObject.GetComponent<Protagonist>();
	}

	protected override bool Statement()
	{
		if (_protagonistScript.attackInput)
		{
			// Consume the input
			_protagonistScript.attackInput = false;

			return true;
		}
		else
		{
			return false;
		}
	}
}
