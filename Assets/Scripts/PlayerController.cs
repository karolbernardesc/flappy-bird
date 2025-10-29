using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody thisRigidbody;
    public float jumpPower = 10;
    public float jumpInterval = 0.5f;
    private float jumpCooldown = 0;

    void Start()
    {
        thisRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Update cooldown
        jumpCooldown -= Time.deltaTime;
        bool isGameActive = GameManager.Instance.IsGameActive();
        bool canJump = jumpCooldown <= 0 && isGameActive;

        //Jump
        if (canJump)
        {
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput)
            {
                Jump();
            }
        }

        //toggle gravity
        thisRigidbody.useGravity = isGameActive;
    }

    void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    private void OnCustomCollisionEnter(GameObject other) {
        bool isSensor = other.CompareTag("Sensor");
        if (isSensor){
            //score
            GameManager.Instance.score++;
            // game over
        }else{
            GameManager.Instance.EndGame();
        }
    }
    

    private void Jump() {
        //Reset cooldown
        jumpCooldown = jumpInterval;

        //Apply force
        this.thisRigidbody.linearVelocity = Vector3.zero;
        this.thisRigidbody.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
    }
}
