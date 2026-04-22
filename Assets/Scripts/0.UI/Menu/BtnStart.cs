using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnStart : BaseBtn
{
    protected override void OnClick()
    {
        LoadSceneByParentName();
    }

    private void LoadSceneByParentName()
    {
        if (transform.parent.name == "Tutorial") { SceneManager.LoadScene(transform.parent.name); return; }
        string namePreviousMap = GetPreviousMap.GetNamePreviousMap(transform.parent.name);
        if (namePreviousMap == null || PlayerPrefs.GetInt(namePreviousMap, 0) != 1)
        {
            Debug.Log("Map is locked", gameObject);
            return;
        }
        SceneManager.LoadScene(transform.parent.name);
    }
}
