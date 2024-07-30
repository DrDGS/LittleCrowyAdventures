using System.Collections;
using UnityEngine;

namespace Assets.Scripts.DestructibleProps
{
    public class PropMovementDirectionSource : MonoBehaviour, IMovementDirectionSource
    {
        public float direction { get; private set; } = 0f;

        public bool jumped { get; private set; } = false;

    }
}