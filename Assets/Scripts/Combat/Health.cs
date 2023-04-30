using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace FPS.Combat {
    public class Health : MonoBehaviour {
        public Action OnDead;
        public Action<float> OnDamaged;

        [SerializeField] private float healthPoint = 100;

        public float HealthPoint => healthPoint;

        public void TakeDamage(float damage) {
            healthPoint -= damage;
            OnDamaged?.Invoke(healthPoint);
            
            if (healthPoint <= 0) {
                OnDead?.Invoke();
            }
        }
    }
}