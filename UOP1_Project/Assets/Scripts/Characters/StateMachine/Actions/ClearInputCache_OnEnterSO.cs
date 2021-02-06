﻿using UnityEngine;
using UOP1.StateMachine;
using UOP1.StateMachine.ScriptableObjects;

[CreateAssetMenu(fileName = "ClearInputCache_OnEnter", menuName = "State Machines/Actions/Clear Input Cache On Enter")]
public class ClearInputCache_OnEnterSO : StateActionSO
{
	protected override StateAction CreateAction() => new ClearInputCache_OnEnter();
}

public class ClearInputCache_OnEnter : StateAction
{
	private Protagonist _protagonist;
	private InteractionManager _interactionManager;

	public override void Awake()
	{
		_protagonist = gameObject.GetComponent<Protagonist>();
		_interactionManager = gameObject.GetComponentInChildren<InteractionManager>();
	}

	public override void OnUpdate()
	{
	}

	public override void OnStateEnter()
	{
		_protagonist.jumpInput = false;
		_protagonist.attackInput = false;
		_interactionManager.currentInteraction = InteractionType.None;
	}
}
