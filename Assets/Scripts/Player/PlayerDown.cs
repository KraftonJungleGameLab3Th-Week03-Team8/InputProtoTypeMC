using UnityEngine;

public class PlayerDown : MonoBehaviour
{
    Rigidbody2D _rb;
    LayerMask _groundLayerMask = 1 << 3;
    float downForce = 150f;

    void Start()
    {
        Init();
    }

    void Init()
    {
        _rb = GetComponent<Rigidbody2D>();

        InputManager.Instance.downAction += Down;
    }

    private void Down()
    {
        _rb.linearVelocity = Vector2.zero;
        _rb.AddForceY(-downForce, ForceMode2D.Impulse);

        Debug.LogWarning("아래");
        //transform.position = hit.point;
    }
}