using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Observer
{
    private PlayerMovement playerMovement;
    [SerializeField] GameObject gOUI;

    public override void Notify(Subject subject)
    {
        if (!playerMovement) playerMovement = subject.GetComponent<PlayerMovement>();

        if (playerMovement)
        {
            if (playerMovement.isDead) gOUI.SetActive(true);
        }
    }

    public void Reload(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
