using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int stage = 3;
    public AudioClip clip2, clip3;
    void Awake()
    {
        if (instance == null) instance = this;

        else if (instance != this) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void End()
    {
        if (stage > 0)
        {
            stage--;
            SceneManager.LoadScene(1);
        }
        
    }
    private void OnLevelWasLoaded()
    {
        if (stage == 2)
        {
            gameObject.GetComponent<AudioSource>().clip = clip2;
        }
        else if (stage == 0)
        {
            gameObject.GetComponent<AudioSource>().clip = clip3;
        }
        gameObject.GetComponent<AudioSource>().Play();
    }
}
