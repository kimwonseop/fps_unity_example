using System;
using System.Collections;
using FPS.Core;
using UnityEngine;

namespace FPS.Combat {
    public class Weapon : MonoBehaviour {
        public Action<int> OnBulletCountChanged;
        public int MaxBulletCount => maxBulletCount;

        private readonly int RELOAD_TIME = 1;
        
        [SerializeField] private Transform aimTransform;
        [SerializeField] private Projectile projectile;
        [SerializeField] private float bulletSpeed = 50f;
        [SerializeField] private float damage = 10f;
        [SerializeField] private int maxBulletCount = 30;

        private int currentBulletCount;
        private bool isReloading = false;
        private ObjectPool bulletPool;

        private void Awake() {
            currentBulletCount = maxBulletCount;
            bulletPool = GameObject.Find("BulletPool").GetComponent<ObjectPool>();
        }

        public void Fire() {
            if (currentBulletCount <= 0 || isReloading) {
                return;
            }

            var bulletObject = bulletPool.GetPooledObj();

            if (bulletObject == null) {
                return;
            }
            
            bulletObject.gameObject.SetActive(true);
            bulletObject.transform.position = aimTransform.position;
            bulletObject.transform.forward = aimTransform.forward;
            bulletObject.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

            currentBulletCount -= 1;
            OnBulletCountChanged?.Invoke(currentBulletCount);
        }

        public void Reload() {
            isReloading = true;

            StartCoroutine(ReloadCoroutine());
        }

        private IEnumerator ReloadCoroutine() {
            yield return new WaitForSeconds(1);

            currentBulletCount = maxBulletCount;
            isReloading = false;
            OnBulletCountChanged?.Invoke(currentBulletCount);
        }
    }
}
