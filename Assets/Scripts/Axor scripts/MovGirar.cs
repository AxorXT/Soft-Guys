using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovGirar : MonoBehaviour
{
    public Vector3 rotationSpeed = new Vector3(0, 100, 0);

    // Update is called once per frame
    void Update()
    {
        // Aplica la rotación en el objeto
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
