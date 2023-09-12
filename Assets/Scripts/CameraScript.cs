using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float crazy_meter = 1;
    public float offsetX;
    private Quaternion desiredRotation;

    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        desiredRotation = transform.rotation;
    }

    // locks camera's y
    void Update()
    {

        player = GameObject.Find("Player").transform;
        Vector3 pos = transform.position;
        pos.x = player.position.x + offsetX;
        if (player.position.x >= offsetX)
        {
            transform.position = pos;
        }
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, 0.01f);
    }

    public void goCrazy()
    {
        float newz = transform.rotation.eulerAngles.z + crazy_meter; 
        Quaternion quat = Quaternion.AngleAxis(newz, Vector3.forward);
        desiredRotation = quat;
        
        //StartCoroutine(yaaaa());
    }
    IEnumerator yaaaa()
    {
        transform.position = new Vector3(transform.position.x, 1.15f, transform.position.z + crazy_meter);
            yield return new WaitForSeconds(.1f);
        
    }

}
