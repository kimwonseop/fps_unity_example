using System;
using UnityEngine;

namespace FPS.Combat {
    public class Projectile : MonoBehaviour {
        public Action<Health> OnHit;

        [SerializeField] private float damage = 10f;

        private void OnEnable() {
            Invoke(nameof(SetInactive), 5f);
        }

        private void SetInactive() {
            gameObject.SetActive(false);
        }

        public void OnTriggerEnter(Collider other) {
            var health = other.GetComponent<Health>();

            if (health == null) {
                return;
            }

            health.TakeDamage(damage);
            OnHit?.Invoke(health);
            gameObject.SetActive(false);
        }
    }
}
