using UnityEngine;
using System.Collections;

public class GrapplingGun : MonoBehaviour {

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    Rigidbody playerRB;
    PlayerMovement playerMV;
    public GameObject attachPlayerTwice;
    //coroutine
    private IEnumerator coroutine;
    //Check for collide
    private bool isNearCollide = false;
    RaycastHit checkForCollide;
    private Vector3 positionOfPsevdoCollide;

    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    void Update() {
        positionOfPsevdoCollide = new Vector3(player.position.x, player.position.y+2.5f, player.position.z);
        // if (Physics.Raycast(camera.position, camera.forward, out checkForCollide, 1, whatIsGrappleable) || 
        // Physics.Raycast(camera.position, -camera.forward, out checkForCollide, 1, whatIsGrappleable) ||
        // Physics.Raycast(camera.position, camera.right, out checkForCollide, 1, whatIsGrappleable) || 
        // Physics.Raycast(camera.position, -camera.right, out checkForCollide, 1, whatIsGrappleable)) {
            if (Physics.Raycast(player.position, player.forward, out checkForCollide, 0.5f, whatIsGrappleable) || 
        Physics.Raycast(player.position, player.forward, out checkForCollide, 0.5f, whatIsGrappleable)){
                isNearCollide = true; 
        } 
        if (Input.GetMouseButtonDown(0) ) {
            // if (!Physics.Raycast(camera.position, camera.forward, out checkForCollide, 10, whatIsGrappleable)) {
            //     StartGrapple();
            //     isNearCollide == true; 
            // }
            StartGrapple();
            
            
        }
        else if (Input.GetMouseButtonUp(0) || isNearCollide == true) {
            StopGrapple();
            isNearCollide = false;
        }
        Debug.DrawRay( positionOfPsevdoCollide,player.forward, Color.red);
        Debug.DrawRay( positionOfPsevdoCollide, -player.forward, Color.red);

    }

    //Called after Update
    void LateUpdate() {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple() {
        RaycastHit hit;
        
       
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            attachPlayerTwice.AddComponent<Rigidbody>();
            playerRB = attachPlayerTwice.GetComponent<Rigidbody>();
            playerMV = attachPlayerTwice.GetComponent<PlayerMovement>();
            playerMV.enabled = false;
            playerRB.mass = 100;
            playerRB.freezeRotation = true;
            Debug.DrawLine(camera.position, hit.point);
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.3f;
            joint.minDistance = distanceFromPoint * 0.18f;

            //Adjust these values to fit your game.
            // joint.spring = 20f;
            // joint.damper = 20f;
            // joint.massScale = 4.5f;
            joint.spring = 20f;
            joint.damper = 20f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple() {
        if (!joint) return;
        // player.position = new Vector3(camera.position.x, camera.position.y-0.3f,camera.position.z);
        lr.positionCount = 0;
        Destroy(joint);
        playerMV.enabled = true;
        Destroy(playerRB);
    }

    private Vector3 currentGrapplePosition;
    
    void DrawRope() {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);
        
        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling() {
        return joint != null;
    }

    public Vector3 GetGrapplePoint() {
        return grapplePoint;
    }
}
