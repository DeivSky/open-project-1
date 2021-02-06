using System.Linq;
using UOP1.StateMachine.ScriptableObjects;

namespace UOP1.StateMachine
{
	public class State
	{
		internal StateSO _originSO;
		internal StateMachine _stateMachine;
		private StateAction[] _actions;
		private StateTransition[] _transitions;
		private Condition[] _conditions;

		internal State() { }

		public void OnStateEnter()
		{
			for (int i = 0; i < _actions?.Length; i++)
				_actions[i].OnStateEnter();

			for (int i = 0; i < _conditions?.Length; i++)
				_conditions[i].OnStateEnter();
		}

		public void OnUpdate()
		{
			for (int i = 0; i < _actions?.Length; i++)
				_actions[i].OnUpdate();
		}

		public void OnStateExit()
		{
			for (int i = 0; i < _actions?.Length; i++)
				_actions[i].OnStateExit();

			for (int i = 0; i < _conditions?.Length; i++)
				_conditions[i].OnStateExit();
		}

		public bool TryGetTransition(out State state)
		{
			state = null;

			if (_transitions != null)
			{
				for (int i = 0; i < _transitions.Length; i++)
					if (_transitions[i].TryGetTransiton(out state))
						break;

				ClearConditionsCache();
			}

			return state != null;
		}

		internal void SetActions(StateAction[] actions)
		{
			_actions = actions;
		}

		internal void SetTransitions(StateTransition[] transitions)
		{
			_conditions =
				transitions.Select(transition =>
					transition._conditions.Select(condition =>
						condition._condition)).SelectMany(conds =>
							conds).Distinct().ToArray();

			_transitions = transitions;
		}

		internal void ClearConditionsCache()
		{
			for (int i = 0; i < _conditions.Length; i++)
				_conditions[i].ClearStatementCache();
		}
	}
}
