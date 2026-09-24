using System.Collections;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public int counter = 1;   // saltos disponibles

    private Rigidbody2D rb;
    public int powerIndex = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey("left"))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown("space"))
        {
            jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            power(powerIndex);
        }
    }

    public void jump()
    {
        if (counter >= 1)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            counter = 0;
            StartCoroutine(DoAfterDelay(3.0f));
        }
    }

    public void power(int i)
    {
        Transform trans = this.transform;
        switch (i)
        {
            case(1):
                trans.rotation = new Quaternion(trans.rotation.x+90, trans.rotation.y, trans.rotation.z, 1);
            break;
            
            case(2):
                trans.position = new Vector3(Random.Range(-38.0f, 38.0f), Random.Range(-20.0f, 20.0f),0);
            break;
            
            case(3):
            
            break;
            default:
            break;
        }
    }

    IEnumerator DoAfterDelay(float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        counter = 1;
    }
}