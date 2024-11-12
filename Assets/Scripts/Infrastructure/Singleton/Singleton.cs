using UnityEngine;

namespace Infrastructure.Singleton
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour, new()
    {
        protected static T _instance;
        public static T Instance
        {
            get
            {
                {
                    if (_instance == null)
                    {
                        _instance = (T)FindObjectOfType(typeof(T));

                        if (FindObjectsOfType(typeof(T)).Length > 1)
                            return _instance;

                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "(singleton) " + typeof(T).Name.ToString();
                        }
                    }

                    return _instance;
                }
            }
        }
    }
}