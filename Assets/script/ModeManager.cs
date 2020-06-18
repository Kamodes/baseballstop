using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeManager : MonoBehaviour
{
    public static bool mode = true;
    public AudioClip choiceBgm;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void easy()
    {
        GameObject audio_res = (GameObject)Resources.Load("MusicManager");
        audioSource = GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioSource.PlayOneShot(choiceBgm);
        mode = true;
        Invoke("SceneChange", 0.3f);
    }

    public void hard()
    {
        GameObject audio_res = (GameObject)Resources.Load("MusicManager");
        audioSource = GameObject.Instantiate(audio_res, transform.position, Quaternion.identity).GetComponent<AudioSource>();
        audioSource.PlayOneShot(choiceBgm);
        mode = false;
        Invoke("SceneChange", 0.3f);
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("select");
    }
}
