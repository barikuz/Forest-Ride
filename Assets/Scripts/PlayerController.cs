using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    InputAction inputActions;
    Rigidbody2D rigidbody2D;
    SurfaceEffector2D surfaceEffector2D;
    [SerializeField] ScoreManager scoreManager;

    [SerializeField] ParticleSystem powerUpParticles;

    Vector2 moveVector;

    [SerializeField] float torqueAmount;
    [SerializeField] float baseSpeed;
    [SerializeField] float boostSpeed;

    public bool canControl = true;

    float currentRotation;
    float previousRotation;
    float totalRotation;
    int activePowerUps = 0;

    // States from mobile buttons
    private bool isRotatingLeft = false;
    private bool isRotatingRight = false;
    private bool isBoosting = false;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        inputActions = InputSystem.actions.FindAction("Move");
        rigidbody2D = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        moveVector = inputActions.ReadValue<Vector2>();
        if (canControl)
        {   
            BoostPlayer();
        }      
    }

    void FixedUpdate()
    {
        if (canControl)
        {
            RotatePlayer();
            CalculateFlips();
        }
    }

    void RotatePlayer()
    {
        if(moveVector.x < 0 || isRotatingLeft)
        {
            AddTorque(torqueAmount);
        }

        else if(moveVector.x > 0 || isRotatingRight)
        {
            AddTorque(-torqueAmount);
        }
    }

    public void AddTorque(float amount)
    {
        rigidbody2D.AddTorque(amount);
    }   

    void BoostPlayer()
    {
        if (moveVector.y > 0 || isBoosting)
        {
            SetSpeed(boostSpeed);
        }
        else
        {
            SetSpeed(baseSpeed);
        }
    }

    public void SetSpeed(float amount)
    {
        surfaceEffector2D.speed = amount;
    }

    public void DisableControls()
    {
        canControl = false;
    }

    void CalculateFlips()
    {
        currentRotation = transform.rotation.eulerAngles.z;

        totalRotation += Mathf.DeltaAngle(previousRotation, currentRotation);

        if(totalRotation > 340 || totalRotation < -340)
        {
            totalRotation = 0;
            scoreManager.AddScore(10);
        }

        previousRotation = currentRotation;

    }

    public void ActivatePowerUp(PowerUpSO powerUp)
    {
        powerUpParticles.Play();
        activePowerUps++;
        if(powerUp.GetPowerUpType() == "speed")
        {
            baseSpeed += powerUp.GetValueChange();
            boostSpeed += powerUp.GetValueChange();
        }
        else if (powerUp.GetPowerUpType() == "torque")
        {
            torqueAmount += powerUp.GetValueChange();
        }
    }

    public void DeactivatePowerUp(PowerUpSO powerUp)
    {
        activePowerUps--;
        if(activePowerUps == 0)
        {
            powerUpParticles.Stop();
        }
        if(powerUp.GetPowerUpType() == "speed")
        {
            baseSpeed -= powerUp.GetValueChange();
            boostSpeed -= powerUp.GetValueChange();
        }
        else if (powerUp.GetPowerUpType() == "torque")
        {
            torqueAmount -= powerUp.GetValueChange();
        }
    }

    
    // --- Functions to be called from UI buttons for mobile controls ---

    public void OnPressRotateLeft() { isRotatingLeft = true; }
    public void OnReleaseRotateLeft() { isRotatingLeft = false; }

    public void OnPressRotateRight() { isRotatingRight = true; }
    public void OnReleaseRotateRight() { isRotatingRight = false; }

    public void OnPressBoost() { isBoosting = true; }
    public void OnReleaseBoost() { isBoosting = false; }
}
