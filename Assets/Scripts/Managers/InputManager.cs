using System.Collections;
using System.Collections.Generic;
using FPS.Core.Managers;
using FPS.Input;
using UnityEngine;

public class InputManager : Singleton<InputManager> {
    private PlayerInput playerInput;
    public PlayerInput PlayerInput {
        get {
            if (playerInput == null) {
                playerInput = new PlayerInput();
            }

            if (isDisable) {
                playerInput.Enable();
                isDisable = false;
            }

            return playerInput;
        }
    }

    public PlayerInput.PlayerInputActionActions PlayerActions => playerInput.PlayerInputAction;

    private bool isDisable = false;

    private void Awake() {
        playerInput = new PlayerInput();
    }
    
    private void OnEnable() {
        playerInput.Enable();
        isDisable = false;
    }

    private void OnDisable() {
        playerInput.Disable();
        isDisable = true;
    }

    public void DisableInputAction() {
        playerInput.Disable();
        isDisable = true;
    }
}
