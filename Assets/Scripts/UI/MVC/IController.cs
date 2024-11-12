namespace UI.MVC
{
    interface IController<T> : IController
    {
        T viewer { get;set;} 
    }

    public interface IController
    {
        void SetViewer(IViewer viewer);
        void Show();
        void Close();
    }
}