using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class  UIClearPopup: MonoBehaviour
{
    public void GoToEnding()
    {
        SceneManager.LoadScene("05.Ending");
    }
} 
