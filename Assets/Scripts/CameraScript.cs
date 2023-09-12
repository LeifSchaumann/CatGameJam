using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float crazy_meter = 1;
    public Transform player;
    public float offsetX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // locks camera's y
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x = player.position.x + offsetX;
        if (player.position.x >= offsetX)
        {
            transform.position = pos;
        }
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
