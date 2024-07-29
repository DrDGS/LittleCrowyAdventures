using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float jumpVelocity = 10f;
        [SerializeField] private float jumpHoldingFalloff = 1f;

        public float direction { get; set; }

        private Rigidbody2D rb;

        public void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void Update()
        {
            ApplyMovement();
        }

        public void Jump()
        {
            rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
        }

        private void ApplyMovement()
        {
            rb.velocity = new Vector2(direction * speed * Time.deltaTime, rb.velocity.y);
        }
    }
}