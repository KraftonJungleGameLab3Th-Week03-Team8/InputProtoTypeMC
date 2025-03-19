using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    private Rigidbody2D _rb;
    float _dashPower = 25f;

    private void Start()
    {
        Init();
    }

    void Init()
    {
        _rb = GetComponent<Rigidbody2D>();

        InputManager.Instance.dashAction += Dash;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.GetChild(0).rotation.eulerAngles.y == 0f)
        {
            Debug.Log($"{transform.GetChild(0).name}가 오른쪽 봄");
        }
        else if(transform.GetChild(0).rotation.eulerAngles.y == 180f)
        {
            Debug.Log($"{transform.GetChild(0).name}가 왼쪽 봄");
        }
        Debug.Log(transform.GetChild(0).rotation.eulerAngles);
    }

    private void Dash()
    {
        float force = _dashPower;
        if(transform.GetChild(0).rotation.eulerAngles.y == 180f)
        {
            Debug.Log("왼쪽 대쉬");
            force *= -1;
        }
        else if(transform.GetChild(0).rotation.eulerAngles.y == 0f)
        {
            Debug.Log("오른쪽 대쉬");
        }

        _rb.linearVelocityX = force;

        //Debug.Log("대쉬~");
    }
}