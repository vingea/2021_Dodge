using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text Timetext;
    public Text Recordtext;

    public GameObject level;
    public GameObject bulletSpawnerPrefeb;
    private Vector3[] bulletSpawners = new Vector3[4];
    int spawnercount= 0;

    private float survivetime;
    private bool isGameover;

    void Start()
    {
        survivetime = 0;
        isGameover = false;

        bulletSpawners[0].x = -8f;
        bulletSpawners[0].y = 1f;
        bulletSpawners[0].z = 8f;

        bulletSpawners[1].x = 8f;
        bulletSpawners[1].y = 1f;
        bulletSpawners[1].z = 8f;

        bulletSpawners[2].x = 8f;
        bulletSpawners[2].y = 1f;
        bulletSpawners[2].z = -8f;

        bulletSpawners[3].x = -8f;
        bulletSpawners[3].y = 1f;
        bulletSpawners[3].z = -8f;
    }


    void Update()
    {
        if(!isGameover)
        {
            survivetime += Time.deltaTime;
            Timetext.text = "Time: " + (int)survivetime;

            if(survivetime < 5f && spawnercount == 0)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefeb, bulletSpawners[3], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnercount];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnercount++;
            }
            else if(survivetime >= 5f && survivetime < 10f && spawnercount == 1)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefeb, bulletSpawners[3], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnercount];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnercount++;
            }
            else if (survivetime >= 10f && survivetime < 15f && spawnercount == 2)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefeb, bulletSpawners[3], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnercount];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnercount++;
            }
            else if (survivetime >= 15f && survivetime < 20f && spawnercount == 3)
            {
                GameObject bulletSpawner = Instantiate(bulletSpawnerPrefeb, bulletSpawners[3], Quaternion.identity);
                bulletSpawner.transform.parent = level.transform;
                bulletSpawner.transform.localPosition = bulletSpawners[spawnercount];
                level.GetComponent<Rotator>().rotationSpeed += 15f;
                spawnercount++;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(survivetime > bestTime)
        {
            bestTime = survivetime;
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        
        Recordtext.text = "Best Time: " + (int) bestTime;
    }

    
}
