using UnityEngine;

public class DisplayUtils
{
    public static GameObject AddContentToParentObject(GameObject contentPrefab, Transform parent)
    {
        GameObject contentObject = GameObject.Instantiate(contentPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        contentObject.transform.SetParent(parent);
        contentObject.transform.localScale = Vector3.one;
        contentObject.transform.localPosition = Vector3.zero;
        return contentObject;
    }
}