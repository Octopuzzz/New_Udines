using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed = 3f;
    [SerializeField] private Collider PickUpCollider;
    public float pickUpRange = 10,moveForce = 250;
    public bool PickedUp = false;
    private Vector2 PlayerInput;
    private Vector3 Direction;
    public Animator animator;
    private GameObject heldObj,temp;
    public Transform holdParent;
    Rigidbody objRig;
    RaycastHit Hit;
    void Start()
    {
        holdParent = GameObject.Find("Pickup Destination").transform;
    }
    void Update()
    {
        PlayerInput.x = Input.GetAxis("Horizontal");
        PlayerInput.y = Input.GetAxis("Vertical");
        PlayerInput.Normalize();
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(heldObj == null )
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, pickUpRange) && !PickedUp && (Hit.transform.gameObject.CompareTag("Food") || Hit.transform.gameObject.CompareTag("Raw Food")))
                {
                    PickingUp(Hit.transform.gameObject);
                }else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.left), out Hit, pickUpRange) && !PickedUp && (Hit.transform.gameObject.CompareTag("Food") || Hit.transform.gameObject.CompareTag("Raw Food")))
                {
                    PickingUp(Hit.transform.gameObject);
                }
                else if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out Hit, pickUpRange) && !PickedUp && (Hit.transform.gameObject.CompareTag("Food") || Hit.transform.gameObject.CompareTag("Raw Food")))
                {
                    PickingUp(Hit.transform.gameObject);
                }
                else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.back), out Hit, pickUpRange) && !PickedUp && (Hit.transform.gameObject.CompareTag("Food") || Hit.transform.gameObject.CompareTag("Raw Food")))
                {
                    PickingUp(Hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
        } 
        if (heldObj != null && PickedUp)
        {
            MoveObject();
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(PlayerInput.x * speed * Time.deltaTime, 0, PlayerInput.y * speed * Time.deltaTime);
    }
    public void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldObj.transform.parent = null;
        heldObj = null;
        PickedUp = false;
    }
    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 15f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }
    private void PickingUp(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>())
        {
            objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;
            objRig.transform.position = holdParent.transform.position;
            objRig.transform.parent = holdParent;
            heldObj = pickObj;
            PickedUp = true;
        }
    }
}
