using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private float maxHp = 5f;
        private float currentHp;

        public HealthComponent(float maxHp)
        {
            this.maxHp = maxHp;
            currentHp = maxHp;
        }

        public void takeDamage(float damage)
        {
            currentHp -= Mathf.Max(0, damage);

            if (currentHp <= float.Epsilon)
                Destroy(gameObject);
        }

        public void getHeal(float heal)
        {
            currentHp += Mathf.Max(0, heal);
        }
    }
}
