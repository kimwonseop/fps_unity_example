using UnityEngine;

namespace FPS.Core.Managers {
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
        private static T instance;
        public static T Instance {
            get {
                if (instance != null) {
                    return instance;
                }

                instance = FindObjectOfType(typeof(T)) as T;

                if (instance != null) {
                    return instance;
                }

                var singletonObject = new GameObject();
                instance = singletonObject.AddComponent<T>();
                singletonObject.name = typeof(T).Name;
                DontDestroyOnLoad(singletonObject);

                return instance;
            }
        }
    }
}
