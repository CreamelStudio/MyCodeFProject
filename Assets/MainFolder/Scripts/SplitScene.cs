using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SplitScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject turnObj;
    [SerializeField]
    private float turnSpeed;

    private AsyncOperation asyncOper;

    void Start()
    {
        asyncOper = SceneManager.LoadSceneAsync("TitleScene");
        asyncOper.allowSceneActivation = false;
        Invoke("nextScene",2.5f);
    }

    private void Update()
    {
        turnObj.transform.Rotate(new Vector3(0,0, turnSpeed * Time.deltaTime));
    }

    public void nextScene()
    {
        asyncOper.allowSceneActivation = true;
    }
}
