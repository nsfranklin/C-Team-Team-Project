using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaycastSelect : MonoBehaviour
{
    public string SceneToLoad;

    void Update()
    {
        RaycastHit hit;
        float theDistance;

        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        if (Physics.Raycast(transform.position, (forward), out hit) && OVRInput.Get(OVRInput.Button.One))
        {
            print("Scene Selected");
            theDistance = hit.distance;
            SceneManager.LoadScene(SceneToLoad);
        }

    }
}