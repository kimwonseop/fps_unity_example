using FPS.UI;
using FPS.Character;
using UnityEngine;

namespace FPS.Core.Managers {
    public class GameManager : Singleton<GameManager> {
        private Player player;
        private InGameView inGameView;
        private GameOverView gameOverView;
        private float currentTime = 0;

        private void Awake() {
            player = GameObject.Find("Player").GetComponent<Player>();
            inGameView = GameObject.Find("InGameView").GetComponent<InGameView>();
        }

        private void Start() {
            inGameView.PlayerHealthBarBar.maxValue = player.Health.HealthPoint;
            inGameView.PlayerHealthBarBar.value = player.Health.HealthPoint;
            inGameView.BulletCountBar.maxValue = player.Weapon.MaxBulletCount;
            inGameView.BulletCountBar.value = player.Weapon.MaxBulletCount;

            player.Health.OnDamaged += value => inGameView.PlayerHealthBarBar.value = value;
            player.Weapon.OnBulletCountChanged += OnPlayerShoot;
        }

        private void OnPlayerShoot(int bulletCount) {
            inGameView.BulletCountBar.value = bulletCount;
        }
    }
}
