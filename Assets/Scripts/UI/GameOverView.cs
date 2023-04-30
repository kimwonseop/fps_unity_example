using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverView : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI gameOverMessage;

    public void SetInactiveAfterSeconds(float seconds, Action onEndSeconds = null) {
        StartCoroutine(SetInactive(seconds, onEndSeconds));
    }

    public void SetGameOverMessage(string message) {
        gameOverMessage.text = message;
    }

    private IEnumerator SetInactive(float seconds, Action onEndSeconds = null) {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
        onEndSeconds?.Invoke();
    }
}
