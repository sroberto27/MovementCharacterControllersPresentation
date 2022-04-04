using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            SceneManager.LoadScene("2dPlataform");
        }
        if (Input.GetKeyDown("2"))
        {
            SceneManager.LoadScene("2DUpperView");
        }
        if (Input.GetKeyDown("3"))
        {
            SceneManager.LoadScene("3DClick3erdPerson");
        }
        if (Input.GetKeyDown("4"))
        {
            SceneManager.LoadScene("3DTankMove");
        }
    }
}
