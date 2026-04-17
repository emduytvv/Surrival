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
        string mapName = transform.parent.name;
        string index = mapName.Replace("Map_", "");

        if (int.TryParse(index, out int sceneIndex))
            SceneManager.LoadScene(sceneIndex);
    }
}
