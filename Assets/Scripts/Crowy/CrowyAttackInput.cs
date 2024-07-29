using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.Crowy
{
    public class CrowyAttackInput : MonoBehaviour, IAttackInputSource
    {
        public bool X { get; private set; }
        public bool Y { get; private set; }
        public bool Sp { get; private set; }

        public void AttackX(InputAction.CallbackContext context)
        {
            X = context.started;
        }

        public void AttackY(InputAction.CallbackContext context)
        {
            Y = context.started;
        }

        public void Special(InputAction.CallbackContext context)
        {
            Sp = context.started;
        }

    }
}