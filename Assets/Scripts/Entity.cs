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
        private SpriteRenderer spriteRenderer;
        protected MovementController movementController;
        private HealthComponent healthComponent;
        protected Animator animator;
        
        void Awake()
        {
            movementDirectionSource = GetComponent<IMovementDirectionSource>();
            attackSource = GetComponent<IAttackInputSource>();
            movementController = GetComponent<MovementController>();
            spriteRenderer= GetComponent<SpriteRenderer>();
            healthComponent = GetComponent<HealthComponent>();
            animator = GetComponent<Animator>();
        }

        public void Update()
        {
            movementLogic();
        }

        protected void movementLogic()
        {
            movementController.direction = movementDirectionSource.direction;
            if (movementController.direction > 0) spriteRenderer.flipX = false;
            else if (movementController.direction < 0) spriteRenderer.flipX = true;
            if (movementDirectionSource.jumped)
                movementController.Jump();
        }
    }
}