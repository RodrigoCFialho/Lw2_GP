using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using System.Collections;

public class InputSystem : MonoBehaviour
{
    public static InputSystem Instance { get; private set; }

    private CustomInput customInput;

    private float moveInput;

    [SerializeField]
    private UnityEvent<float> onEnableMovementEvent;

    [SerializeField]
    private UnityEvent onEnableLaunchEvent;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        customInput = CustomInputManager.Instance.GetCustomInput();

        customInput.Player.Movement.performed += InputMovementPerformed;
        customInput.Player.Movement.canceled += InputMovementCancelled;

        customInput.Player.Launch.performed += InputLaunchPerformed;
    }

    private void OnDisable()
    {
        customInput.Player.Movement.performed -= InputMovementPerformed;
        customInput.Player.Movement.canceled -= InputMovementCancelled;

        customInput.Player.Launch.performed -= InputLaunchPerformed;
    }

    private void InputMovementPerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<float>();
        onEnableMovementEvent.Invoke(moveInput);
    }

    private void InputMovementCancelled(InputAction.CallbackContext context)
    {
        moveInput = 0f;
        onEnableMovementEvent.Invoke(moveInput);
    }

    private void InputLaunchPerformed(InputAction.CallbackContext context)
    {
        onEnableLaunchEvent.Invoke();
    }

    public void DisablePlayerControls()
    {
        customInput.Player.Disable();
    }

    public void DisablePlayerLaunch()
    {
        customInput.Player.Launch.Disable();
    }

    public void EnablePlayerLaunch()
    {
        customInput.Player.Launch.Enable();
    }
}
