using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float maxHp = 5f;
        private float currentHp;

        public void Awake()
        {
            currentHp = maxHp;
        }

        public void takeDamage(float damage)
        {
            currentHp -= Mathf.Max(0, damage);

            if (currentHp <= float.Epsilon)
                Destroy(gameObject);

            Debug.Log(currentHp);
        }

        public void getHeal(float heal)
        {
            currentHp += Mathf.Min(Mathf.Max(0, heal), maxHp);
        }
    }
}
