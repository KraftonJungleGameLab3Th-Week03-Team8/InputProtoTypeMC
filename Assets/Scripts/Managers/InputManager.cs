using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    private static InputManager _instance;
    public static InputManager Instance { get { return _instance; } }

    [SerializeField] private Vector2 _moveDir;

    [SerializeField] private bool _isJump;

    [SerializeField] private bool _isDown;

    private PlayerInputSystem _playerInputSystem;
    private InputAction _moveAction;
    private InputAction _jumpAction;
    private InputAction _downAction;
    private InputAction _dashAction;

    Rigidbody2D _rb;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Init();
        }
    }

    private void Init()
    {
        _playerInputSystem = new PlayerInputSystem();

        _moveAction = _playerInputSystem.Player.Move;
        _jumpAction = _playerInputSystem.Player.Jump;
        _downAction = _playerInputSystem.Player.Down;
        _dashAction = _playerInputSystem.Player.Dash;

        // 활성화
        _moveAction.Enable();
        _jumpAction.Enable();
        _downAction.Enable();
        _dashAction.Enable();

        #region 키 입력 이벤트 등록
        _moveAction.performed += OnMove;

        _jumpAction.started += OnJumpStarted;
        _jumpAction.canceled += OnJumpCanceled;

        _downAction.started += OnDown;
        _downAction.canceled += OnDown;

        _dashAction.started += OnDash;
        #endregion

        _rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    //private void OnEnable()
    //{
    //    _jumpAction.Enable();
    //    _landAction.Enable();
    //}

    //private void OnDisable()
    //{
    //    _jumpAction.Disable();
    //    _landAction.Disable();
    //}

    void OnMove(InputAction.CallbackContext context)
    {
        _moveDir =  context.ReadValue<Vector2>();

        Debug.Log("Move: " + _moveDir);
    }

    #region 차지 점프
    void OnJumpStarted(InputAction.CallbackContext context)
    {
        _isJump = true;
    }

    void OnJumpCanceled(InputAction.CallbackContext context)
    {
        _isJump = false;
    }
    #endregion

    void OnDown(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log("Down started");
            _isDown = true;
        }
        else if(context.canceled)
        {
            Debug.Log("Down cancled");
            _isDown = false;
        }
    }

    void OnDash(InputAction.CallbackContext context)
    {
        bool isDash = context.ReadValueAsButton();

        if (isDash)
        {
            Debug.Log("Dash started");
        }
    }
}