using System;
using System.Collections.Generic;

namespace Infrastructure.FSM
{
    public interface IFSM<TTrigger,TState>
    {
        public void SetConfiguration(Dictionary<TTrigger, TState> states);
        public void Enter(TTrigger state);
        public Action<TState> OnChangeState {get;set;}
        public IState activeState { set; get; }
    }
}