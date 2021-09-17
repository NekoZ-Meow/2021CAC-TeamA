using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_changer : MonoBehaviour
{
    private bool firstPush = false;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Press Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (!firstPush && Input.GetKeyDown("s")) {
            //Debug.Log("Go Next Scene");
            SceneManager.LoadScene("");
            firstPush = true;
        }
    }
}
