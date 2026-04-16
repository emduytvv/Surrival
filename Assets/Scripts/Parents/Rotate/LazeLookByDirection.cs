using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class LazeLookByDirection : SaiMonoBehaviour
{
    // [SerializeField] protected Vector3 direction;
    // public void SetDirection(Vector3 direction)
    // {
    //     this.direction = direction;
    //     LookDirection();
    // }
    protected virtual void OnEnable()
    {
        StartCoroutine(LookDirection());
    }
    protected virtual IEnumerator LookDirection()
    {
        yield return new WaitForSeconds(0.5f);
        // direction.Normalize();
        // float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        Quaternion targetRotation = transform.parent.rotation;
        transform.parent.rotation = targetRotation;
        float rot_z = targetRotation.eulerAngles.z;
        // Debug.Log(rot_z);
        for (int i = 0; i < 360; i++)
        {
            rot_z++;
            targetRotation = Quaternion.Euler(0f, 0f, rot_z);
            transform.parent.rotation = targetRotation;
            yield return new WaitForSeconds(0.01f);
        }

    }

}
