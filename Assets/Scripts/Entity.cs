using Assets.Scripts;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(HealthComponent))]
    abstract public class Entity : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpVelocity = 10f;
        [SerializeField] private float jumpHoldingFalloff = 1f;

        private IMovementDirectionSource movementDirectionSource;
        private HealthComponent healthComponent;
        private Rigidbody2D rb;

        private float direction;
        private bool jumped;
        
        void Awake()
        {
            movementDirectionSource = GetComponent<IMovementDirectionSource>();
            healthComponent = GetComponent<HealthComponent>();
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            direction = movementDirectionSource.direction;
            jumped = movementDirectionSource.jumped;

            rb.velocity = new Vector2(direction * speed, 0);
            if (jumped)
                rb.AddForce(new Vector2(0, jumpVelocity));
        }
    }
}