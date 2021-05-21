using UnityEngine;
using System.Collections;

public class Movements : MonoBehaviour
{

    private float speed = 7f;
    private float sensitivity = 5f;
    private float pushTime = 0f;
    private float thrust = 1200f;

    private Vector3 velocity;
    private Rigidbody2D rb;
    //private Rigidbody2D rbCursor;
    private GameObject owner;
    private GameObject screenBounds;
    private GameObject playerLegs;
    private GameObject inventory;
    private Rigidbody2D childRb;

    public Camera cam;
    public Animator anim;
    public Animator animLegs;

    CursorLockMode wantedMode;
    public LayerMask guns;

    // Use this for initialization
    void Awake()
    {
        inventory = GameObject.Find("Items");
        rb = GetComponent<Rigidbody2D>();
        //rbCursor = mouseCursor.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        animLegs = GameObject.Find("PlayerLegs").GetComponent<Animator>();
        playerLegs = GameObject.Find("PlayerLegs");
        owner = GameObject.Find("GamePlayer");
        screenBounds = GameObject.Find("ScreenBounds");

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            lockCam();
        }

        GameObject childRef;
        Renderer childRend;
        CircleCollider2D childColl;

        int hasChild = inventory.transform.childCount;

        if (Input.GetKeyDown(KeyCode.Mouse1) && hasChild > 0)
        {
            childRef = inventory.transform.GetChild(0).gameObject;

            anim.SetBool(childRef.transform.tag, false);

            childRef.transform.parent = null;

            childRend = childRef.GetComponent<Renderer>();
            childColl = childRef.GetComponent<CircleCollider2D>();

            childRend.enabled = true;
            childColl.enabled = true;

            childRef.transform.position = transform.position;
            childRb = childRef.gameObject.GetComponent<Rigidbody2D>();

            pushTime = 1f;
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && hasChild == 0)
        {
            RaycastHit2D hit = Physics2D.CircleCast(transform.position, 1f, transform.up, 1f, guns.value);

            Debug.Log(hit.transform.gameObject);

            if (hit)
            {
                childRef = hit.transform.gameObject;

                childRef.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                anim.SetBool(childRef.transform.tag, true);

                childRend = childRef.GetComponent<Renderer>();
                childColl = childRef.GetComponent<CircleCollider2D>();

                childRend.enabled = false;
                childColl.enabled = false;

                childRef.transform.SetParent(inventory.transform);
            }
        }

        //Debug.Log(GameObject.Find("tec9").transform.parent.transform.parent);

        //var mouseXRaw = Input.GetAxisRaw("Mouse X");
        //var mouseYRaw = Input.GetAxisRaw("Mouse Y");

        var inputRight = Input.GetAxisRaw("Horizontal");
        var inputUp = Input.GetAxisRaw("Vertical");

        rotateLegs(inputRight, inputUp);

        //cam.rect = Rect(llPoint.x, llPoint.y, urPoint.x - llPoint.x, urPoint.y - llPoint.y);
        var tempPos = transform.position;

        playerLegs.transform.position = transform.position;
        //cam.transform.position = new Vector3(tempPos.x, tempPos.y, -10f);

        velocity = new Vector3(inputRight, inputUp, 0f).normalized;
        //mouseCursor.transform.position += new Vector3(mouseX + inputRightMouse * 0.1f, mouseY + inputUpMouse * 0.1f, 0f) * sensitivity;

    }

    void FixedUpdate()
    {
        var inputRightRaw = Input.GetAxisRaw("Horizontal");
        var inputUpRaw = Input.GetAxisRaw("Vertical");

        //normalizing limits it to prevent faster diagonal movements

        if (inputRightRaw == 0 && inputUpRaw == 0)
        {
            anim.SetFloat("move", 0f);
            animLegs.SetFloat("move", 0f);
            rb.velocity = new Vector3(0f, 0f, 0f);

        }
        else
        {
            anim.SetFloat("move", 1f);
            animLegs.SetFloat("move", 1f);
            rb.velocity = velocity * speed;
        }

        if (childRb != null)
        {
            if (pushTime == 1f)
            {
                pushTime -= 1f;
                childRb.AddForce(transform.up * thrust);
            }
            else if (childRb.velocity.x < 0.1f && childRb.velocity.y < 0.1f)
            {
                childRb.angularVelocity = 0f;
            }
        }
    }

    void lockCam()
    {
        if (wantedMode == CursorLockMode.None)
        {
            wantedMode = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (wantedMode == CursorLockMode.Locked)
        {
            wantedMode = CursorLockMode.None;
            Cursor.visible = true;
        }

        Cursor.lockState = wantedMode;

    }

    void rotateLegs(float inputRight, float inputUp)
    {
        if (inputRight != 0 && inputUp == 0)
        {
            if (inputRight > 0f)
            {
                playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, -90f);

            }
            else
            {
                playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, 90f);

            }
        }
        else if (inputRight == 0 && inputUp != 0)
        {
            if (inputUp > 0)
            {
                playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

            }
            else
            {
                playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, 180f);

            }
        }
        else if (inputRight != 0 && inputUp != 0)
        {
            if (inputRight > 0 && inputUp < 0)
            {
                playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, -135f);

            }
            else if (inputRight < 0 && inputUp > 0)
            {
                playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, 45f);

            }
            else if (inputRight > 0 && inputUp > 0)
            {
                playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, -45f);

            }
            else if (inputRight < 0 && inputUp < 0)
            {
                playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, 135f);

            }
        }
        else
        {
            playerLegs.transform.localEulerAngles = new Vector3(0f, 0f, 0f);

        }
    }
}
