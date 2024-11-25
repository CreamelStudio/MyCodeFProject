using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplitScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("nextScene",0.72f);
    }

    public void nextScene()
    {
        SceneManager.LoadSceneAsync("TitleScene");
    }
}
