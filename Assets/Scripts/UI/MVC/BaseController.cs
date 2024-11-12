using UI.Managers;

namespace UI.MVC
{
    public abstract class BaseController<T> : IController<T> where T : IViewer
    {
        public T viewer { get  ; set ; }
        public void SetViewer(IViewer viewer)
        {
            if (viewer != null)
                this.viewer = (T)viewer;
            
        }

        public virtual void Show() => viewer.OnShow();

        public virtual void Close()
        {
            viewer.OnClose();
            UIManager.Instance.Close(this);
        }
    }
}