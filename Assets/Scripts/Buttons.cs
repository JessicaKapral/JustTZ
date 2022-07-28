using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void RestartButton() //если нажать рестарт, сцена запустится снова
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
