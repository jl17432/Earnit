using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllor : MonoBehaviour
{

    private Transform target;
    // [SerializeField] private float smoothSpeed = 3.0f;
    // MARKER limit the camera range
    [SerializeField] private float minY, maxY, minX, maxX;

   
   
   
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //MARKER tradition method of move camera
        transform.position = new Vector3(target.position.x, target.position.y, -10);
    
        // //MARKER smoothly move camera
        // transform.position = Vector3.Lerp(transform.position, 
        //                                 new Vector3(target.position.x, 
        //                                             target.position.y, 
        //                                             transform.position.z), 
        //                                 smoothSpeed * Time.deltaTime);

        //MARKER Limit the camera range
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX),
                                         Mathf.Clamp(transform.position.y, minY, maxY),
                                         transform.position.z); 
    }
}
