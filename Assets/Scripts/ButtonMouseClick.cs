using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMouseClick : MonoBehaviour
{

    public GameObject catPrefab;

    private void OnMouseDown()
    {
        Instantiate(catPrefab, new Vector3(-7, 5, 0), Quaternion.identity);
    }
}
