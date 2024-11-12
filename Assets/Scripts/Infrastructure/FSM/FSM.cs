using System;
using System.Collections.Generic;

namespace Infrastructure.FSM
{
    public class FSM<TTrigger, TState> : IFSM<TTrigger,TState> where TState : IState
    {
        private Dictionary<TTrigger, TState> _states;
        private IState _activeState;
        public IState activeState
        {
            get => _activeState;
            set => _activeState = value;
        }

        public Action<TState> OnChangeState { get; set; }


        public void SetConfiguration(Dictionary<TTrigger, TState> states)
        {
            if (_states == null)
                _states = new Dictionary<TTrigger, TState>();
            
            foreach (var state in states)
            {
                if (_states.ContainsKey(state.Key))
                    return;
            
                _states.Add(state.Key,state.Value);
            }
           
        }

        public void Enter(TTrigger trigger) => ChangeState(GetState(trigger));

        private void ChangeState(TState state)
        {
            _activeState = state;
            _activeState.Enter();
            
            OnChangeState?.Invoke(state);
        }

        private TState GetState(TTrigger trigger)
        {
            if (_states.TryGetValue(trigger, out TState state) && _activeState != null)
                _activeState?.Exit();

            return state;
        }
    }
}