using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplitScene : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject turnObj;
    public float turnSpeed;

    void Start()
    {
        Invoke("nextScene",1f);
    }

    private void Update()
    {
        turnObj.transform.Rotate(new Vector3(0,0, turnSpeed * Time.deltaTime));
    }

    public void nextScene()
    {
        SceneManager.LoadSceneAsync("TitleScene");
    }
}
