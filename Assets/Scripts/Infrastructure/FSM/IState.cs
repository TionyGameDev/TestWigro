﻿namespace Infrastructure.FSM
{
    public interface IState 
    {
        public void Enter();
        public void Exit();
    }
}