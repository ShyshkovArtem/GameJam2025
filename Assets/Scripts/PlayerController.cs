using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float Timer;
    public float timeBetweenFire;

    Rigidbody2D body;
    public float runSpeed = 400.0f;
    private Vector2 input;
    private Vector2 lastMoveDirection;
    bool isWalking = false;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 rotation = mousePos - transform.position;
        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            GameObject instantiatedBullet = Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            StartCoroutine(DestroyAfterDelay(instantiatedBullet));

        }

        if (!canFire)
        {
            Timer += Time.deltaTime;
            if (Timer > timeBetweenFire)
            {
                Timer = 0;
                canFire = true;
            }
        }


    ProccessInputs();
    }

    IEnumerator DestroyAfterDelay(GameObject obj)
    {
        yield return new WaitForSeconds(2);
        if (obj != null) // Ensure the object still exists
        {
            Destroy(obj);
        }
    }


    private void FixedUpdate()
    {
        body.velocity = input * runSpeed * Time.fixedDeltaTime;
        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * input.x + Vector3.down * input.y;
        }
    }

    void ProccessInputs ()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if ((moveX == 0 && moveY == 0) && (input.x !=0 || input.y !=0)) 
        {
            isWalking = false;
            lastMoveDirection = input;
            Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;  
        }
        else if (moveX != 0 || moveY != 0)
        {
            isWalking = true;
        }

        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        input.Normalize();
    }
}