using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    public static Util Instance;

    #region Singleton
    private void Awake()
    {
        if (Instance != null)
            Destroy(this);
        else
            Instance = this;
    }

    #endregion

    public static Vector3 Click(int distance, LayerMask mask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, mask))
        {
            GameObject obj = Pooler.Singleton.InstantiateFromPool("ClickFeedback");
            Pooler.Singleton.DestroyToPoolWithTimer("ClickFeedback", obj, 1f);
            obj.transform.position = hit.point;
            return hit.point;
        }

        return Vector3.zero;
    }


    public static Vector3 GetMousePosition(int distance, LayerMask mask)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distance, mask))
            return hit.point;        
        return Vector3.zero;
    }

    public static Vector3 DashMovimentation(Vector3 position, Vector3 forward, float distance)
    {
        Vector3 newPosition;
        newPosition = position + forward * distance;
        return newPosition;
    }
    public static void Instantiate(GameObject obj) => Instantiate(obj);
    

    public static void Instantiate(GameObject obj, Transform transform, Quaternion rotation) =>  Instantiate(obj, transform, rotation);
    

    public static Quaternion RotateTowards(Vector3 player, Vector3 target)
    {
        Vector3 direction = (target - player).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        return lookRotation;
    }
}
