using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBtn : MonoBehaviour
{
    public void OnButtonClicked()
    {
        SceneManager.LoadScene("MainScene");
    }
}
