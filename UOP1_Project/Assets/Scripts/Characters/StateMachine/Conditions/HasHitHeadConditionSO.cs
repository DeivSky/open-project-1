using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(menuName = "State Machines/Conditions/Has Hit the Head")]
public class HasHitHeadConditionSO : StateConditionSO<HasHitHeadCondition> { }

public class HasHitHeadCondition : Condition
{
	//Component references
	private Protagonist _protagonistScript;
	private CharacterController _characterController;
	private Transform _transform;

	public override void Awake()
	{
		_transform = gameObject.GetComponent<Transform>();
		_protagonistScript = gameObject.GetComponent<Protagonist>();
		_characterController = gameObject.GetComponent<CharacterController>();
	}

	protected override bool Statement()
	{
		bool isMovingUpwards = _protagonistScript.movementVector.y > 0f;
		if (isMovingUpwards)
		{
			// Making sure the collision is near the top of the head
			float permittedDistance = _characterController.radius / 2f;
			float topPositionY = _transform.position.y + _characterController.height;
			float distance = Mathf.Abs(_protagonistScript.lastHit.point.y - topPositionY);
			if (distance <= permittedDistance)
			{
				_protagonistScript.jumpInput = false;
				_protagonistScript.movementVector.y = 0f;

				return true;
			}
		}

		return false;
	}
}
