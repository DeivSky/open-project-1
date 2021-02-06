using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "IsSliding", menuName = "State Machines/Conditions/Is Sliding")]
public class IsSlidingConditionSO : StateConditionSO<IsSlidingCondition> { }

public class IsSlidingCondition : Condition
{
	private CharacterController _characterController;
	private Protagonist _protagonistScript;

	public override void Awake()
	{
		_characterController = gameObject.GetComponent<CharacterController>();
		_protagonistScript = gameObject.GetComponent<Protagonist>();
	}

	protected override bool Statement()
	{
		if (_protagonistScript.lastHit == null)
			return false;

		float currentSlope = Vector3.Angle(Vector3.up, _protagonistScript.lastHit.normal);
		return (currentSlope >= _characterController.slopeLimit);
	}
}
