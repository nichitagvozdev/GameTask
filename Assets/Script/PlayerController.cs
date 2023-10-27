using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ClearSky
{
    public class PlayerController : MonoBehaviour
    {
        public float movePower = 10f;
        public float KickBoardMovePower = 15f;
        public Text scoreText;

        private int _score = 0;
        private Rigidbody2D _rb;
        private Animator _anim;
        Vector3 movement;
        private int _direction = 1;
        private bool _alive = true;
        private bool _isKickboard = false;
        



        void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }

        private void Update()
        {
            Restart();
            if (_alive)
            {
                Hurt();
                Die();
                Attack();
                KickBoard();
                Run();
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "CollectiveCube")
            {
                _score++;
                Destroy(other.gameObject);

                if (_score < 5)
                    scoreText.text = "Score: " + _score;
                else
                    scoreText.text = "You win!";
            }
        }
        void KickBoard()
        {
            if (Input.GetKeyDown(KeyCode.Alpha4) && _isKickboard)
            {
                _isKickboard = false;
                _anim.SetBool("isKickBoard", false);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4) && !_isKickboard )
            {
                _isKickboard = true;
                _anim.SetBool("isKickBoard", true);
            }

        }

        void Run()
        {
            if (!_isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                _anim.SetBool("isRun", false);


                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    _direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(_direction, 1, 1);
                    if (!_anim.GetBool("isJump"))
                        _anim.SetBool("isRun", true);

                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    _direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(_direction, 1, 1);
                    if (!_anim.GetBool("isJump"))
                        _anim.SetBool("isRun", true);

                }
                transform.position += moveVelocity * movePower * Time.deltaTime;

            }
            if (_isKickboard)
            {
                Vector3 moveVelocity = Vector3.zero;
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    _direction = -1;
                    moveVelocity = Vector3.left;

                    transform.localScale = new Vector3(_direction, 1, 1);
                }
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    _direction = 1;
                    moveVelocity = Vector3.right;

                    transform.localScale = new Vector3(_direction, 1, 1);
                }
                transform.position += moveVelocity * KickBoardMovePower * Time.deltaTime;
            }
        }
        void Attack()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _anim.SetTrigger("attack");
            }
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _anim.SetTrigger("hurt");
                if (_direction == 1)
                    _rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    _rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _isKickboard = false;
                _anim.SetBool("isKickBoard", false);
                _anim.SetTrigger("die");
                _alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                _isKickboard = false;
                _anim.SetBool("isKickBoard", false);
                _anim.SetTrigger("idle");
                _alive = true;
            }
        }
    }

}