using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Camera
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private GameObject targetGameObject;
        [SerializeField] private Vector3 offset = new Vector3(0, 0, -10);
        [SerializeField] private float smoothingFactor;
        private Vector3 targetPosition;

        void Start()
        {
            targetPosition = targetGameObject.transform.position + offset;
            transform.position = targetPosition;
        }

        void LateUpdate()
        {
            targetPosition = targetGameObject.transform.position + offset;
            transform.position = targetPosition;
        }
    }
}