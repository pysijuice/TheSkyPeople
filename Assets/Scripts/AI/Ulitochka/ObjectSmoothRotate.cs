using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSmoothRotate : MonoBehaviour
{
    [SerializeField]
    private int lerp = 1;
    [SerializeField]
    private float angle = 0;
    public string rot = "z";
    public int negativeEuler;
    public int positiveEuler;
    public Vector3 moving;
    private int cs = 2;
    // Start is called before the first frame update
    void Start()
    {
        lerp = 1;
    }

    // Update is called once per frame
    void Update()
    {
        rotateBody(rot);
        transform.Rotate(moving * Time.deltaTime * lerp);
        angle = Mathf.Round(transform.eulerAngles.z);

        
    }
    void rotateBody(string rot){
        switch (rot){

            case "x":
                if (Mathf.Round(transform.eulerAngles.x) >= positiveEuler &&  Mathf.Round(transform.eulerAngles.x) < 180){
                lerp = -1;
                } else if (Mathf.Round(transform.eulerAngles.x) <= 360 + negativeEuler && Mathf.Round(transform.eulerAngles.x) > 180){
                    lerp = 1;
                }
                // Debug.Log(Mathf.Round(transform.eulerAngles.x));
                break;
            case "y":
                if (Mathf.Round(transform.eulerAngles.y) >= positiveEuler &&  Mathf.Round(transform.eulerAngles.y) < 180){
                lerp = -1;
                } else if (Mathf.Round(transform.eulerAngles.y) <= 360 + negativeEuler && Mathf.Round(transform.eulerAngles.y) > 180){
                    lerp = 1;
                }
                break;
            case "z":
                if (Mathf.Round(transform.eulerAngles.z) >= positiveEuler &&  Mathf.Round(transform.eulerAngles.z) < 180){
                lerp = -1;
                } else if (Mathf.Round(transform.eulerAngles.z) <= 360 + negativeEuler && Mathf.Round(transform.eulerAngles.z) > 180){
                    lerp = 1;
                }
                break;
            default: 
                if (Mathf.Round(transform.eulerAngles.z) >= positiveEuler &&  Mathf.Round(transform.eulerAngles.z) < 180){
                    lerp = -1;
                } else if (Mathf.Round(transform.eulerAngles.z) <= 360 + negativeEuler && Mathf.Round(transform.eulerAngles.z) > 180){
                    lerp = 1;
                }
                break;
            
                 
        }
    }
}
