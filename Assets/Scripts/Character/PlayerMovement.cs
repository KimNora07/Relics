using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerRunData Data;

    #region COMPONENTS
    public Rigidbody2D RB { get; private set; }
    #endregion


    #region STATE PARAMETERS
    public bool IsFacingRight { get; private set; }
    public float LastOnGroundTime { get; private set; }
    #endregion


    #region INPUT PARAMETERS
    private Vector2 _moveInput;
    #endregion

  
    #region CHECK PARAMETERS
    [Header("Checks")]
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.49f, 0.03f);
    #endregion

    #region LAYERS & TAGS
    [Header("Layers & Tags")]
    [SerializeField] private LayerMask _groundLayer;
    #endregion

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        IsFacingRight = true;
    }

    private void Update()
    {
        #region TIMERS
        LastOnGroundTime -= Time.deltaTime;
        #endregion

        #region INPUT HANDLER
        _moveInput.x = Input.GetAxisRaw("Horizontal");

        if (_moveInput.x != 0)
            CheckDirectionToFace(_moveInput.x > 0);
        #endregion

        #region COLLISION CHECKS
        if (Physics2D.OverlapBox(_groundCheckPoint.position, _groundCheckSize, 0, _groundLayer))
            LastOnGroundTime = 0.1f;
        #endregion
    }

    private void FixedUpdate()
    {
        Run();
    }

    #region RUN METHODS
    private void Run()
    {
        float targetSpeed = _moveInput.x * Data.runMaxSpeed;

        #region Calculate AccelRate
        float accelRate;

        if (LastOnGroundTime > 0)
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount : Data.runDeccelAmount;
        else
            accelRate = (Mathf.Abs(targetSpeed) > 0.01f) ? Data.runAccelAmount * Data.accelInAir : Data.runDeccelAmount * Data.deccelInAir;
        #endregion

        #region Conserve Momentum
        if (Data.doConserveMomentum && Mathf.Abs(RB.velocity.x) > Mathf.Abs(targetSpeed) && Mathf.Sign(RB.velocity.x) == Mathf.Sign(targetSpeed) && Mathf.Abs(targetSpeed) > 0.01f && LastOnGroundTime < 0)
        {
            accelRate = 0;
        }
        #endregion

        float speedDif = targetSpeed - RB.velocity.x;
        float movement = speedDif * accelRate;

        RB.AddForce(movement * Vector2.right, ForceMode2D.Force);
    }

    private void Turn()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        IsFacingRight = !IsFacingRight;
    }
    #endregion

    #region CHECK METHODS
    public void CheckDirectionToFace(bool isMovingRight)
    {
        if (isMovingRight != IsFacingRight)
            Turn();
    }
    #endregion
}