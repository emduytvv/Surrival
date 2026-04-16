using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseParent : BaseBtn
{
    protected override void OnClick()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
