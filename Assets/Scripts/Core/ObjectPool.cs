using System.Collections.Generic;
using UnityEngine;

namespace FPS.Core {
    public class ObjectPool : MonoBehaviour {
        private List<GameObject> poolObjects = new List<GameObject>();
        [SerializeField] private int poolCounts = 30;
        [SerializeField] private GameObject poolTarget;

        private void Start() {
            for (int i = 0; i < poolCounts; i++) {
                var obj = Instantiate(poolTarget, transform);
                obj.SetActive(false);
                poolObjects.Add(obj);
            }
        }

        public GameObject GetPooledObj() {
            for (int i = 0; i < poolCounts; i++) {
                if (!poolObjects[i].activeInHierarchy) {
                    return poolObjects[i];
                }
            }

            return null;
        }
    }
}

