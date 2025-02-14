using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class playerMovement : MonoBehaviour
{
    #region Variables

    //The inputs that we need to retrieve from the input system.
    private InputAction m_moveAction;
    private InputAction m_attackAction;

    //The components that we need to edit to make the player move smoothly.
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    
    //The direction that the player is moving in.
    private Vector2 m_playerDirection;

    //Reference to Teleport value
    public VectorValue startingPosition;

    //Reference to walkingSFX
    private AudioSource walkingsfx;

    //Make sure walkingSFX doesn't spam play
    private bool canHearWalking;
   

    [Header("Movement parameters")]
    //The speed at which the player moves
    [SerializeField] private float m_playerSpeed = 200f;
    //The maximum speed the player can move
    [SerializeField] private float m_playerMaxSpeed = 1000f;

    #endregion

    private void Awake()
    {
        m_moveAction = InputSystem.actions.FindAction("Move");
        m_attackAction = InputSystem.actions.FindAction("Attack");

        m_moveAction.performed += OnMove;
        m_moveAction.canceled += StopMove;
        //m_attackAction.performed += OnAttack;


        //get components from Character game object so that we can use them later.
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.position = startingPosition.initialValue;
        walkingsfx = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //clamp the speed to the maximum speed for if the speed has been changed in code.
        float speed = m_playerSpeed > m_playerMaxSpeed ? m_playerMaxSpeed : m_playerSpeed;
        
        //apply the movement to the character using the clamped speed value.
        m_rigidbody.linearVelocity = m_playerDirection * (speed * Time.fixedDeltaTime);
    }

    private void OnDestroy()
    {
        m_moveAction.performed -= OnMove;
        m_moveAction.canceled -= StopMove;
    }

    #region Movement Handler Functions

    public void OnMove(InputAction.CallbackContext context)
    {
        m_playerDirection = context.ReadValue<Vector2>();

        //should be somth else in here to check if null
        if (m_playerDirection != null)
        {
            HandleAnimOnMove();
        }
    }

    public void StopMove(InputAction.CallbackContext context)
    {
        m_playerDirection = Vector2.zero;

        if (m_playerDirection != null)
        {
            HandleAnimOnMove();
        }
    }

    private void HandleAnimOnMove()
    {
        m_animator.SetFloat("Speed", m_playerDirection.magnitude);

        if (m_playerDirection.magnitude > 0 && m_playerDirection != null)
        {
            m_animator.SetFloat("Horizontal", m_playerDirection.x);
            m_animator.SetFloat("Vertical", m_playerDirection.y);
        }
    }

    #endregion
    void Update()
    {

        if (m_moveAction.IsPressed() && !walkingsfx.isPlaying)
        {
            walkingsfx.Play();
        }
        else if (!m_moveAction.IsPressed() && walkingsfx.isPlaying)
        {
            walkingsfx.Stop();
        }
    }
}
