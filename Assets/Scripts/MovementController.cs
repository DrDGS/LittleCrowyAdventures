using System.Collections;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Windows.Speech;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private float speed = 200f;
        [SerializeField] private float jumpVelocity = 10f;
        [SerializeField] private float jumpHoldingFalloff = 5f;

        Animator animator;

        public bool canMove { get; set; } = true;

        public float direction { get; set; }

        private Rigidbody2D rb;

        public void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            animator = gameObject.GetComponent<Animator>();
        }

        public void Update()
        {
            ApplyMovement();
        }

        public void Jump()
        {
            if (rb.velocity.y == 0f)
                rb.AddForce(new Vector2(0, jumpVelocity), ForceMode2D.Impulse);
            if (rb.velocity.y > 0f)
                rb.AddForce(new Vector2(0, jumpHoldingFalloff), ForceMode2D.Force);
        }

        private void ApplyMovement()
        {
            if (animator != null)
            {
                canMove = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name != "Draw";
                if (canMove)
                    transform.Translate(new Vector3(direction * speed * Time.deltaTime, 0, 0), Space.World);
            }
        }

        public void AddImpulseForce(Vector2 force)
        {
            rb.velocity += force;
        }
    }
}