using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace MultiplayerTest.Scripts.InputsFeature
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Vector3> OnMove;
        [SerializeField] private UnityEvent<Vector3> OnRotate;

        private PlayerInputAction _input;

        private void Awake()
        {
            _input = new PlayerInputAction();
        }

        private void OnEnable()
        {
            _input.Enable();

            _input.Player.Movement.performed += HandleMoving;
            _input.Player.Rotate.performed += HandleLook;
            _input.Player.Movement.canceled += HandleStopMoving;
            _input.Player.Rotate.canceled += HandleStopMouse;
        }

        private void OnDisable()
        {
            _input.Player.Movement.performed -= HandleMoving;
            _input.Player.Rotate.performed -= HandleLook;
            _input.Player.Movement.canceled -= HandleStopMoving;
            _input.Player.Rotate.canceled -= HandleStopMouse;

            _input.Disable();
        }

        private void HandleMoving(InputAction.CallbackContext context)
        {
            Vector2 directionInput = context.ReadValue<Vector2>();
            Vector3 direction = new Vector3(directionInput.x, 0, directionInput.y);

            OnMove?.Invoke(direction);
        }

        private void HandleStopMoving(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(Vector3.zero);
        }

        private void HandleLook(InputAction.CallbackContext context)
        {
            Vector2 lookInput = context.ReadValue<Vector2>();
            Vector3 look = new Vector3(lookInput.x, lookInput.y, 0);

            OnRotate?.Invoke(look);
        }

        private void HandleStopMouse(InputAction.CallbackContext context)
        {
            OnRotate?.Invoke(Vector3.zero);
        }
    }
}