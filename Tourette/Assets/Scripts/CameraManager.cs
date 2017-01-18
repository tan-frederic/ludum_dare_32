using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour {

	public Transform target;
	public bool follow = true;

	// Use this for initialization
	void Start () 
	{
	    if (target && follow)
        {
            Vector3 pos = transform.position;
            pos.x = target.position.x;
            transform.position = pos;
        }
	}

    public void SetFollow(bool n)
    {
        follow = n;
        Debug.Log("Follow = " + n.ToString());
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (target != null && follow)
		{
			if (target.position.x > transform.position.x)
			{
				transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);
			}
		}
	}
}
