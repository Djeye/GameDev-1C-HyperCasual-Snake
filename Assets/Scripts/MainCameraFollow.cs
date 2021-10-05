using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace snake
{
    public class MainCameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform snakeHead;
        private Transform _transform;
        private float _offset;

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _offset = _transform.position.z - snakeHead.position.z;

        }
        void Update()
        {
            _transform.position = new Vector3(_transform.position.x, transform.position.y, snakeHead.position.z + _offset);
        }
    }
}
