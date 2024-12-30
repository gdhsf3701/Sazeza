using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStage1 : MonoBehaviour
{
    public void Scene1()    
    {
        SceneManager.LoadScene("MySweetHome");
    }
}
