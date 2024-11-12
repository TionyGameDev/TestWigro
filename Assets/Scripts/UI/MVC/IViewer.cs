namespace UI.MVC
{
    public interface IViewer 
    {
        void SetController(IController controller,int index);
        void OnShow();
        void OnClose();
    }

    interface IViewer<TController> : IViewer
    {

    }
}