using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D _rb;
    private BoxCollider2D _collider;
    private float _jumpPower = 5f;
    private bool _isGround;
    public bool IsGround { get { return !_isGround; } }
    [SerializeField] LayerMask _groundLayer = 1 << 3;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _collider = GetComponent<BoxCollider2D>();
        
        InputManager.Instance.jumpAction += Jump;
    }

    void Jump()
    {
        _isGround = Physics2D.Raycast(transform.position, -transform.up, _collider.size.y * 0.55f, _groundLayer);
        if (_isGround)
        {
            Debug.Log("점프");
            _rb.AddForce(transform.up * _jumpPower, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmos()
    {
        if (_collider != null)
        { 
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, -transform.up * _collider.size.y * 0.55f);
        }
    }
}
