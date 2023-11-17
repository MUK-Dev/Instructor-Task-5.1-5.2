using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float jumpForce = 3f;
    private Rigidbody rb;
    private CapsuleCollider capsuleCollider;
    private bool isJumping = false;
    private bool canClimb = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(h * speed * Time.deltaTime * Vector3.right);

        if (canClimb)
        {
            transform.Translate(v * speed * Time.deltaTime * Vector3.up);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if (isJumping)
        {
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, Mathf.Infinity))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
                Debug.Log(1);
                if (hit.collider.gameObject.TryGetComponent<Barrel>(out var barrel))
                {
                    int score = barrel.GetScore();
                    Debug.Log(2);
                    GameManager.Instance.IncreaseScore(score);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Platform") || other.collider.CompareTag("Floor"))
        {
            isJumping = false;
        }
        else if (other.collider.CompareTag("Barrel"))
        {
            int livesAfterDamage = GameManager.Instance.DecreaseLife();
            Destroy(other.collider.gameObject);
            if (livesAfterDamage < 1) Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            canClimb = true;
            rb.useGravity = false;
            capsuleCollider.isTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            canClimb = false;
            rb.useGravity = true;
            capsuleCollider.isTrigger = false;
        }

    }
}
