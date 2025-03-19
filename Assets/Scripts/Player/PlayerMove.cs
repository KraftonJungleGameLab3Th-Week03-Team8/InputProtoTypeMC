using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("이동")]
    private Rigidbody2D _rb;
    private float _moveSpeed = 800f;
    private float _maxSpeed = 5f;

    Transform _visual;

    void Awake()
    {
        Init();
    }

    private void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _visual = transform.Find("Visual");
    }

    void FixedUpdate()
    {
        Move();
    }

    // 이동(좌우)
    private void Move()
    {
        if (InputManager.Instance.MoveDir != Vector2.zero)
        {
            Vector2 moveDirection = new Vector2(InputManager.Instance.MoveDir.x, 0).normalized;
            Flip(moveDirection.x);

            if (Mathf.Abs(moveDirection.x * +_rb.linearVelocityX) < _maxSpeed)   // 최고속도 이전
            {
                _rb.AddForce(new Vector2(moveDirection.x * Time.fixedDeltaTime * _moveSpeed, 0));
            }
            else // 최고속도 이상이면 최고속도로 고정
            {
                float offset = (InputManager.Instance.MoveDir.x > 0) ? 1 : -1;
                _rb.linearVelocityX = _maxSpeed * offset;
                Debug.Log("최대속도");
            }

            //_rb.linearVelocityX = moveDirection.x * _moveSpeed;
            //Debug.Log("이동");
        }
        else
        {
            //_rb.linearVelocityX = 0;
        }
    }

    private void Flip(float x)
    {
        if(x > 0)
        {
            _visual.rotation = Quaternion.identity;
        }
        else if (x < 0)
        {
            _visual.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}