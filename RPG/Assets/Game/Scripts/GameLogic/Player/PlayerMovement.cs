using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

namespace Game.GameLogic
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 200;
        [SerializeField] private Animator animator;

        private Vector2 _moveForce;
        private Rigidbody2D _rigidbody;
        private CharacterFlipStatus _characterBodyPartsHolder;

        private void Start()
        {
            _characterBodyPartsHolder = GetComponentInChildren<CharacterFlipStatus>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void OnMovement(InputValue value)
        {
            _moveForce = value.Get<Vector2>();
        }

        private void FixedUpdate()
        {
            if (GameManager.Instance.IsInputAllowed == false) return;

            var nextPosition = _moveForce * _speed * Time.fixedDeltaTime;

            animator.SetBool("Is_Running", nextPosition.x != 0 || nextPosition.y != 0);

            _characterBodyPartsHolder.Flip(nextPosition);
            _rigidbody.velocity = nextPosition;
        }
    }
}