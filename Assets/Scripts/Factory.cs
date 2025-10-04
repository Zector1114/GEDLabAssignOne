using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Factory : MonoBehaviour
{
    int limit = 2;
    int score = 0;
    float timer = 0;
    public float targetTime = 0.5f;
    [SerializeField] List<BlockSpawn> spawns = new List<BlockSpawn>();
    [SerializeField] TextMeshProUGUI text;

    void Update()
    {
        if (timer >= targetTime)
        {
            if (score == 20 || score == 30)
            {
                limit--;
            }

            //Instantiate(block, new Vector3(Random.Range(-8f, 8f), gameObject.transform.position.y, 0), Quaternion.identity);
            spawns[Random.Range(0, spawns.Count - limit)].Spawn();

            timer = 0;

            score++;
            text.text = "Score: " + score.ToString();
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    public void Reload(string str)
    {
        SceneManager.LoadScene(str);
    }

    public void AppQuit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
