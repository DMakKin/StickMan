using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private SceneLoader loader;
    [SerializeField] private int sceneIndex;
    [SerializeField] private bool isItLastLevel;

    private void Start()
    {
        loader = GetComponent<SceneLoader>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (isItLastLevel == false)
        {
            loader.LoadSceneByIndex(sceneIndex);
        } else if (isItLastLevel)
        {
            loader.QuitGame();
        }
    }

}
