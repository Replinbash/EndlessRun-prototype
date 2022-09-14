using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessRun.ObjectSettings;
using UnityEngine.Events;

namespace EndlessRun.Movement
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private Animator _animation;
        [SerializeField] private PlayerMovementSettings _translateSettings;
        [SerializeField] UnityEvent onJump;
        [SerializeField] UnityEvent onSpin;

        private bool _isRight = true;
        private bool _isGrounded = true;

        private void Start()
        {
            _translateSettings.CurrentSpeed = 10f;
        }

        private void Update()
        {
            Forward();
            Turn();
            JumpAndRoll();
        }

        private void Forward()
        {
            transform.Translate(Vector3.forward * _translateSettings.CurrentSpeed * Time.deltaTime);

            _translateSettings.CurrentSpeed = Mathf.MoveTowards(_translateSettings.CurrentSpeed, _translateSettings.MaxSpeed, _translateSettings.AccelerationSpeed * Time.deltaTime);
        }

        private void Turn()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                onSpin.Invoke();
                _isRight = true;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                onSpin.Invoke();
                _isRight = false;
            }

            var _vectorA = new Vector3(-2.5f, transform.position.y, transform.position.z);
            var _vectorD = new Vector3(2.5f, transform.position.y, transform.position.z);

            if (_isRight)
            {
                transform.position = Vector3.Lerp(transform.position, _vectorA, Time.deltaTime * _translateSettings.Lerp);
            }

            else
            {
                transform.position = Vector3.Lerp(transform.position, _vectorD, Time.deltaTime * _translateSettings.Lerp);
            }
        }

        private void JumpAndRoll()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
            {
                onJump.Invoke();
                _animation.SetBool("jump", true);                
                _rigidbody.AddForce(_translateSettings.Jump * _translateSettings.Force, ForceMode.Impulse);
                Invoke("CancelAnimation", 0.5f);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                // _animation.SetBool("roll", true);
                //Invoke("CancelAnimation", 0.5f);                
            }
        }

        private void CancelAnimation()
        {
            _animation.SetBool("jump", false);
            //_animation.SetBool("roll", false);
        }

        // bool degiskeninin stay'de kullanýlmamasý gerekiyor!
        private void OnCollisionStay(Collision other)
        {
            if (other.gameObject.tag == "ground")
            {
                _isGrounded = true;
                Debug.Log(_isGrounded);
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.tag == "ground")
            {
                _isGrounded = false;
            }
        }
    }
}
