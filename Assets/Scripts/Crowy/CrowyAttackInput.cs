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
        Animator animator;

        private int XComboCounter = 0;
        private float ComboTimer = 0f;

        public void Awake()
        {
            animator = GetComponent<Animator>();
        }

        public void AttackX(InputAction.CallbackContext context)
        {
            X = context.started;

            if (X && XComboCounter < 2) { 
                XComboCounter++;
                ComboTimer = 0f;
            }
        }

        public void AttackY(InputAction.CallbackContext context)
        {
            Y = context.started;
        }

        public void Special(InputAction.CallbackContext context)
        {
            Sp = context.performed;

            if (context.started)
                animator.SetTrigger("Draw");
        }

        public void Update()
        {
            ComboTimer += Time.deltaTime;

            XComboCounter = Mathf.Min(XComboCounter, 2);
            
            if (ComboTimer > 0.5f * XComboCounter)
            {
                animator.SetInteger("ComboX", 0);
                XComboCounter = 0;
            }
            else
                animator.SetInteger("ComboX", XComboCounter);
        }

    }
}