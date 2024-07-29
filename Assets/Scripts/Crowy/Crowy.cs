using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Crowy
{
    [RequireComponent(typeof(CrowyMovementDirectionSource), typeof(CrowyAttackInput), typeof(Animator))]
    public class Crowy : Entity
    {
        private int comboX = 0;

        public void FixedUpdate()
        {
            AnimationLogic();
        }

        private void AnimationLogic()
        {
            animator.SetInteger("ComboX", comboX);
            animator.SetTrigger("Draw");
            animator.SetBool("Moving", movementDirectionSource.direction != 0);
        }
    }
}