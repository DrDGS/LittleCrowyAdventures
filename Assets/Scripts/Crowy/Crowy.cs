using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Crowy
{
    [RequireComponent(typeof(CrowyMovementDirectionSource), typeof(CrowyAttackInput), typeof(Animator))]
    public class Crowy : Entity
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (LayerUtils.isEnemyHitbox(collision.gameObject))
                takeDamage(collision.gameObject.GetComponent<AttackHitboxData>());
        }
    }
}