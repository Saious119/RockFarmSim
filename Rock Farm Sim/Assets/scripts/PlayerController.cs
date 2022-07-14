using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float movementSpeed;
    public bool isMoving;
    private Vector2 input;
    private RaycastHit2D hity;
    private RaycastHit2D hitx;
    public bool isColliding = true;

    private BoxCollider2D boxCollider;
    void Start()
    {
        isMoving = false;
        movementSpeed = 5;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");
            if(input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                hity = Physics2D.BoxCast(transform.position, boxCollider.size,0, new Vector2(0, input.y), Mathf.Abs(input.y * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
                hitx = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, input.x), Mathf.Abs(input.x * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
                

                if (hity.collider == null || hitx.collider == null)
                {
                    isColliding = false;
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        
    }
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, movementSpeed*Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;
    }
}
