using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour

{
    public Material newMaterial; // Assign the new material in the Inspector
    public float spee = 1;
    




    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void materialChange()
    {
        Debug.Log("hellooooo");
        GameObject[] objectsToAffect = GameObject.FindGameObjectsWithTag("cloud");
        foreach (GameObject e in objectsToAffect)
        {
            e.GetComponent<Renderer>().material = newMaterial;
            newMaterial.SetFloat("Speed", spee + spee);
        }
    }

}
