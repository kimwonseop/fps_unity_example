using FPS.Combat;
using UnityEngine;

namespace FPS.Character {
    public class Player : MonoBehaviour {
        [SerializeField] private float moveSpeed = 1;
        [SerializeField] private Weapon weapon;
        [SerializeField] private float fireSpeed = 0.5f;
        [SerializeField] private float sensivity = 5f;
        private readonly float GRAVITY_VALUE = -9.8f;

        private CharacterController characterController;
        private Transform cameraTransform;
        private Animator animator;
        private float lastFireTime = 0;
        private Health health;
        public Health Health => health;
        public Weapon Weapon => weapon;

        private void Awake() {
            characterController = GetComponent<CharacterController>();
            animator = GetComponent<Animator>();
            cameraTransform = Camera.main.transform;
            health = GetComponent<Health>();
        }

        private void Start() {
            InputManager.Instance.PlayerActions.Fire.performed += context => OnFire();
            InputManager.Instance.PlayerActions.Reload.performed += context => OnReload();
        }

        private void FixedUpdate() {
            Rotate();

            if (!characterController.isGrounded) {
                characterController.Move(GRAVITY_VALUE * Vector3.up * Time.deltaTime);
            }

            if (InputManager.Instance.PlayerActions.Move.IsPressed()) {
                OnMove(InputManager.Instance.PlayerActions.Move.ReadValue<Vector2>());
            }
        }

        private void Rotate() {
            var currentRotation = Weapon.transform.rotation.eulerAngles;
            var mouseValue = InputManager.Instance.PlayerActions.Look.ReadValue<Vector2>();
            var xValue = Mathf.Clamp(-mouseValue.y * Time.deltaTime * sensivity, -60, 60);
            var yValue = Mathf.Clamp(mouseValue.x * Time.deltaTime * sensivity, -60, 60);
            
            Weapon.transform.rotation = Quaternion.Euler(currentRotation.x + xValue, currentRotation.y + yValue, 0);
        }

        private void OnMove(Vector2 vector) {
            var move = cameraTransform.forward * vector.y + cameraTransform.right * vector.x;
            characterController.Move(move.normalized * Time.deltaTime * moveSpeed);
        }
        
        private void OnReload() {
            weapon.Reload();
        }

        private void OnFire() {
            if (weapon.MaxBulletCount <= 0) {
                return;
            }

            animator.SetTrigger("Fire");
            weapon.Fire();
        }
    }
}
