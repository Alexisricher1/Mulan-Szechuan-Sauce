using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;
    public Camera deathCam1;
    public Camera deathCam2;

    void Start()
    {
        deathCam1.enabled = false;
        deathCam2.enabled = false;
    }

    public void EndGame(int deadPlayerNumber)
    {
        mainCamera.enabled = false;

        Camera deathCamera = (deadPlayerNumber == 1) ? deathCam1 : deathCam2;
        StartCoroutine(DeathCamAndWait(deathCamera, 5));
    }

    IEnumerator DeathCamAndWait(Camera cam, float seconds)
    {
        cam.enabled = true;
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 1f;
        cam.enabled = false;
        mainCamera.enabled = true;
        SceneManager.LoadScene("lvl1");
        // END GAME TO RESTART SCENE.
    }
}
