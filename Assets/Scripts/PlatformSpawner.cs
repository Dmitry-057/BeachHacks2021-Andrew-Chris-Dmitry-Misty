using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public float respawnTime;
    private Vector2 screenBounds;
    //public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        respawnTime = 2.0f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //player = GameObject.Find("player");
        StartCoroutine(platformWave());
    }

    private void spawnPlatform() {
        GameObject platform = Instantiate(platformPrefab) as GameObject;
        platform.transform.position = new Vector2(screenBounds.x * 2, Random.Range(-3.0f, -1.0f));
        //Debug.Log(player.transform.position.x);
    }

    IEnumerator platformWave() {
        while (true) {
            yield return new WaitForSeconds(respawnTime);
            spawnPlatform();
        }
    
    }
}
