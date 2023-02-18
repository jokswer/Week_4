using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerView : MonoBehaviour
    {
        [SerializeField] private Transform _cameraCenter;

        private Rigidbody _rigidbody;
        private List<Vector3> _velocityList = new List<Vector3>();

        public Vector3 Position => transform.position;
        public float VelocityMagnitude => _rigidbody.velocity.magnitude;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();

            InitVelocityList();
        }

        private void FixedUpdate()
        {
            _velocityList.Add(_rigidbody.velocity);
            _velocityList.RemoveAt(0);
        }

        public void AddTorque(float vertical, float horizontal)
        {
            _rigidbody.AddTorque(_cameraCenter.right * vertical);
            _rigidbody.AddTorque(-_cameraCenter.forward * horizontal);
        }

        public Vector3 GetVelocitiesSum()
        {
            var sum = Vector3.zero;

            foreach (var velocity in _velocityList)
            {
                sum += velocity;
            }

            return sum;
        }

        private void InitVelocityList()
        {
            for (var i = 0; i < 10; i++)
            {
                _velocityList.Add(Vector3.zero);
            }
        }
    }
}