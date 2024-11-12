namespace Infrastructure.FSM.States
{
    public class FinishGameState : IState
    {
        public void Enter()
        {
            
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else 
            Application.Quit();

        #endif
        }

        public void Exit()
        {
        }
    }
}