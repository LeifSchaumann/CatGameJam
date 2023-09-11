using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float crazy_meter = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // locks camera's y
    void LateUpdate() {
        transform.position = new Vector3(transform.position.x, 1.15f, transform.position.z);
    }

    void goCrazy()
    {
        StartCoroutine(yaaaa());
    }
    IEnumerator yaaaa()
    {
        transform.position = new Vector3(transform.position.x, 1.15f, transform.position.z + crazy_meter);
            yield return new WaitForSeconds(.1f);
        
    }
}
