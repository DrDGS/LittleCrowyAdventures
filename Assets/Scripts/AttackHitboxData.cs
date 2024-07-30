using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AttackHitboxData : MonoBehaviour
    {
        [field: SerializeField] public int damage { get; private set; } = 1;
        [field: SerializeField] public Vector2 hitForce { get; private set; } = new Vector2(0, 0);

    }
}