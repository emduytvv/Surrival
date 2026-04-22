using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageLockMapSelect : SaiMonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("OnEnable", gameObject);
        CloseParents();
    }
    private void CloseParents()
    {

        string namePreviousMap = GetPreviousMap.GetNamePreviousMap(transform.parent.name);

        if (namePreviousMap == null) return;
        if (PlayerPrefs.GetInt(namePreviousMap, 0) != 1) return;

        Debug.Log(namePreviousMap, gameObject);
        gameObject.SetActive(false);

    }
}