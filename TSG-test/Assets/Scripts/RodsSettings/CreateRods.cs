using TMPro;
using UnityEngine;

#pragma warning disable 649
public class CreateRods : MonoBehaviour
{
    [SerializeField] private GameObject singleRodPrefab;
    [SerializeField] private GameObject rodGridPrefab;
    [SerializeField] private GameObject titleLabelRodPrefab;
    [SerializeField] private Transform rodsToSelectTransform;
    [SerializeField] int[] rodTypesToInitialize;

    private void Start()
    {
        Clear();
        if (rodTypesToInitialize != null && rodTypesToInitialize.Length > 0)
        {
            foreach (int rodType in rodTypesToInitialize)
            {
                GameObject textLabel = DisplayUtils.AddContentToParentObject(titleLabelRodPrefab, rodsToSelectTransform);
                textLabel.GetComponent<TMP_Text>().text = "Aaaaa";
                GameObject gridPanel = DisplayUtils.AddContentToParentObject(rodGridPrefab, rodsToSelectTransform);
                for (int i = 0; i < rodType; i++)
                {
                    GameObject singleRodObject = DisplayUtils.AddContentToParentObject(singleRodPrefab, gridPanel.transform);
                    SingleRodPanel singleRodPanel = singleRodObject.GetComponent<SingleRodPanel>();
                    
                }
            }
        }
    }

    private void Clear()
    {
        foreach (Transform child in rodsToSelectTransform)
        {
            Destroy(child.gameObject);
        }
    }
}
