using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnContinute : BaseBtn
{
    protected override void OnClick()
    {
        Time.timeScale = 1f;
        transform.parent.parent.parent.gameObject.SetActive(false);
    }
}
