using System.Collections;
using UnityEngine;

namespace Assets.Scripts.DestructibleProps
{
    [RequireComponent(typeof(PropMovementDirectionSource))]
    public class Prop : Entity
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (LayerUtils.isPlayerHitbox(collision.gameObject))
                takeDamage(collision.gameObject.GetComponent<AttackHitboxData>());
        }
    }
}