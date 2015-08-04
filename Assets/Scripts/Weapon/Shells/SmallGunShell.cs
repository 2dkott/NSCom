using UnityEngine;
using System.Collections;

public class SmallGunShell : MonoBehaviour {

    public float speed;
    public float damage;
    public LayerMask layerMask; //make sure we aren't in this layer 
    public float skinWidth = 0.1f; //probably doesn't need to be changed 

    private float minimumExtent;
    private float partialExtent;
    private float sqrMinimumExtent;
    private Vector3 previousPosition;
    private Rigidbody myRigidbody;


    //initialize values 
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        previousPosition = myRigidbody.position;
        minimumExtent = Mathf.Min(Mathf.Min(GetComponent<Collider>().bounds.extents.x, GetComponent<Collider>().bounds.extents.y), GetComponent<Collider>().bounds.extents.z);
        partialExtent = minimumExtent * (1.0f - skinWidth);
        sqrMinimumExtent = minimumExtent * minimumExtent;
    } 
	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("!!!!");
        Destroy(gameObject);
    }

	// Update is called once per frame
    //void Update () {
    //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
    //}
    
    void FixedUpdate()
    {
        //rigidbody.AddForce(Vector3.forward * speed);
        gameObject.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed);

        //have we moved more than our minimum extent? 
        Vector3 movementThisStep = myRigidbody.position - previousPosition;
        float movementSqrMagnitude = movementThisStep.sqrMagnitude;

        if (movementSqrMagnitude > sqrMinimumExtent)
        {
            float movementMagnitude = Mathf.Sqrt(movementSqrMagnitude);
            RaycastHit hitInfo;

            //check for obstructions we might have missed 
            if (Physics.Raycast(previousPosition, movementThisStep, out hitInfo, movementMagnitude, layerMask.value))
                myRigidbody.position = hitInfo.point - (movementThisStep / movementMagnitude) * partialExtent;
        }

        previousPosition = myRigidbody.position; 

    }
}
