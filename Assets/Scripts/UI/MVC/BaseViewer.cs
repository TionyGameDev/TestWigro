using UnityEngine;
using UnityEngine.UI;

namespace UI.MVC
{
    public abstract class BaseViewer<T> : MonoBehaviour, IViewer<T> where T : IController
    {
        [SerializeField] private Button _closeBtn;
        protected T controller { get; set;}
        
        public void SetController(IController controller,int index) 
        { 
            this.controller = (T)controller; 
            if (controller != null)
                controller.SetViewer(this);
            
            if (_closeBtn)
                _closeBtn.onClick.AddListener(controller.Close);

            var canvas = GetComponent<Canvas>();
            if (canvas)
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = Camera.main;
                canvas.sortingOrder = index;
            }
        }

        public abstract void OnShow();

        public virtual void OnClose(){}
    }
}