using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace snake.Snake
{
    public class SnakePhysics : MonoBehaviour
    {
        private const string UNCOLORFUL_TAG = "Uncolorful";
        
        [SerializeField] private float headSpeed;
        [SerializeField] private float segmentSpeed;
        [SerializeField] private Transform head;
        [SerializeField] private Transform lastSegment, tail;
        [SerializeField] private Transform segment;

        private List<Transform> _snakeBody = new List<Transform>();
        private Renderer _renderer;

        private void Start()
        {
            _snakeBody.Add(head);
            _snakeBody.Add(lastSegment);
            _snakeBody.Add(tail);

            _renderer = head.GetComponentInChildren<Renderer>();
        }

        private void Update()
        {
            if (Core.IsGameEnded) return;
            ApplySnakePhysics();
        }

        private void ApplySnakePhysics()
        {
            for (var i = 1; i < _snakeBody.Count; i++)
            {
                var vector = _snakeBody[i - 1].position - _snakeBody[i].position;
                _snakeBody[i].position += new Vector3(vector.x * segmentSpeed * Time.deltaTime, 0, headSpeed * Time.deltaTime);
                _snakeBody[i].forward = vector;
            }
        }

        public void AddSegment()
        {
            if (_snakeBody.Count > 6) return;

            var seg = Instantiate(segment, head.position + new Vector3(0, 0, -1.6f), Quaternion.identity, transform);
            seg.GetComponent<Renderer>().material.color = GetColor();
            _snakeBody.Insert(1, seg.transform);

            for (int i = 2; i < _snakeBody.Count; i++)
                _snakeBody[i].position += new Vector3(0, 0, -1.55f);
        }

        public Transform GetSnakeHead()
        {
            return head;
        }

        public float GetSnakeSpeed()
        {
            return headSpeed;
        }

        public void SetSnakeSpeed(float speed)
        {
            headSpeed = speed;
        }

        public Color GetColor()
        {
            return _renderer.material.color;
        }

        public void ColorSegments(Color color)
        {
            StartCoroutine(SmoothColorSegments(color));
        }

        private IEnumerator SmoothColorSegments(Color color)
        {
            var waitTime = new WaitForSeconds(1 / headSpeed);
            var headRend = head.GetComponentsInChildren<Renderer>();
            foreach (Renderer rend in headRend)
                if (!rend.CompareTag(UNCOLORFUL_TAG)) rend.material.color = color;

            yield return waitTime;
            foreach(Transform obj in _snakeBody)
            {
                if (obj.TryGetComponent(out Renderer rend))
                    rend.material.color = color;
                yield return waitTime;
            }
        }
    }
}