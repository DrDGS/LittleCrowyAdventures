using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Crowy
{
    public class CrowyMovementDirectionSource : MonoBehaviour, IMovementDirectionSource
    {
        public float direction { get; private set; }
        public bool jumped { get; private set; }
        Animator animator;

        public void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void getJumpInput(InputAction.CallbackContext context) //possible danger - players can use macroses?
        {
            if (context.started)
                jumped = true;
            if (context.canceled)
                jumped = false;
        }

        public void getDirectionalInput(InputAction.CallbackContext context)
        {
            direction = context.ReadValue<float>();
            animator.SetBool("Moving", direction != 0);
        }

    }
}
