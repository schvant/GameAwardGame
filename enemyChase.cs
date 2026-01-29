using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Windows;
using static UnityEngine.GraphicsBuffer;

public class enemyChase : MonoBehaviour
{

    //Player detection
    public float castDistance;
    public LayerMask playerLayer;
    public Vector2 boxSize;
    public GameObject Player;
    public bool playerDetected;

    //Movement 
    public float chasingSpeed;
    public float chillingSpeed;
    public Rigidbody2D myRigidbody;

    //playerChasing
    public GameObject Bird;
    public Transform playerPOS;

    //just chillin
    public float turnTimer;
    public bool facingDirection=true;

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position - transform.up * castDistance, boxSize);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerDetection();

        if(playerDetected)
        {
            chasing();
        }
        else if(!playerDetected)
        {
            chilling();
        }

        
    }

    private void chilling()
    {
        Debug.Log("im chilling");

        turnTimer -= Time.deltaTime;

        if (turnTimer < 0 && facingDirection == true)
        {
            turnTimer = 5;
            facingDirection = false;
        }
        else if (turnTimer < 0 && facingDirection == false)
        {
            turnTimer = 5;
            facingDirection = true;
        }

        if (facingDirection == true)
        {
            Bird.transform.position = new Vector2(Bird.transform.position.x + chillingSpeed * Time.deltaTime, transform.position.y + 0 * Time.deltaTime);

        }
        else if (facingDirection == false)
        {
            Bird.transform.position = new Vector2(Bird.transform.position.x - chillingSpeed * Time.deltaTime, transform.position.y + 0 * Time.deltaTime);
        }


    }

    private void chasing()
    {
        Debug.Log("Im chasing");

        float step = chasingSpeed * Time.deltaTime;
        Bird.transform.position = Vector2.MoveTowards(Bird.transform.position, playerPOS.transform.position, step);
    }

    private void playerDetection()
    {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, playerLayer))
        {
            playerDetected=true;
        }
        else
        {
            playerDetected=false;
        }

    }
}
