using Assets.Scripts;
using Assets.Scripts.Crowy;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(HealthComponent), typeof(MovementController))]
    abstract public class Entity : MonoBehaviour
    {
        protected IMovementDirectionSource movementDirectionSource;
        protected IAttackInputSource attackSource;
        protected MovementController movementController;
        protected HealthComponent healthComponent;
        
        void Awake()
        {
            movementDirectionSource = GetComponent<IMovementDirectionSource>();
            attackSource = GetComponent<IAttackInputSource>();
            movementController = GetComponent<MovementController>();
            healthComponent = GetComponent<HealthComponent>();
        }

        public void Update()
        {
            movementLogic();
        }

        protected void movementLogic()
        {
            movementController.direction = movementDirectionSource.direction;
            if (movementController.direction > 0 && movementController.canMove) transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            else if (movementController.direction < 0 && movementController.canMove) transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            if (movementDirectionSource.jumped)
                    movementController.Jump();
        }

        protected void takeDamage(AttackHitboxData attackData)
        {
            int isReversed = attackData.gameObject.transform.position.x < transform.position.x ? 1 : -1;
            movementController.AddImpulseForce(new Vector2(attackData.hitForce.x * isReversed, attackData.hitForce.y));
            healthComponent.takeDamage(attackData.damage);
        }
    }
}