using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    public GameObject leftMountingPoint;
    public GameObject rightMountingPoint;

    public GameObject left;
    public GameObject right;

    private LoadoutObject leftLoadout;
    private LoadoutObject rightLoadout;

    // Start is called before the first frame update
    void Start()
    {
        if(left != null)
        {
            GameObject tmpLeft = Instantiate(left, leftMountingPoint.transform.position, left.transform.rotation, transform);
            leftLoadout = tmpLeft.GetComponent<LoadoutObject>();
        }

        if (right != null)
        {
            GameObject tmpRight = Instantiate(right, rightMountingPoint.transform.position, right.transform.rotation, transform);
            rightLoadout = tmpRight.GetComponent<LoadoutObject>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootLeftLoadout(InputAction.CallbackContext callbackContext)
    {
        if (leftLoadout != null)
        {
            leftLoadout.Fire();
        }
    }

    public void ShootRightLoadout(InputAction.CallbackContext callbackContext)
    {
        if(rightLoadout != null)
        {
            rightLoadout.Fire();
        }
    }
}
