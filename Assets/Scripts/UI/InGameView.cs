using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FPS.UI {
    public class InGameView : MonoBehaviour {
        [SerializeField] private Slider playerHealthBar;
        [SerializeField] private Slider bossHealthBar;
        [SerializeField] private Slider bulletCountBar;
        
        public Slider PlayerHealthBarBar => playerHealthBar;
        public Slider BossHealthBarBar => bossHealthBar;
        public Slider BulletCountBar => bulletCountBar;
    }
}
