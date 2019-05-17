using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 649
public class CreateRods : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject singleRodPrefab;
    [SerializeField] private GameObject rodGridPrefab;
    [SerializeField] private GameObject titleLabelRodPrefab;

    [Header("Inits values")]
    [SerializeField] int[] rodTypesToInitialize;
    [SerializeField] string[] rodCategories;
    [SerializeField] string[] rodNames;
    [SerializeField] private Sprite[] rodFrames;
    [SerializeField] private Sprite[] rodIcons;

    [SerializeField] private Transform rodsToSelectTransform;
    

    private void Awake()
    {
        Clear();
        InitRods();
    }

    private void Start()
    {
        rodsToSelectTransform.GetComponent<Animator>().SetTrigger("Start");
    }

    private void InitRods()
    {
        if (rodTypesToInitialize != null && rodTypesToInitialize.Length > 0 && rodTypesToInitialize.Length.Equals(rodCategories.Length))
        {
            for (int i = 0 ; i < rodTypesToInitialize.Length; i++)
            {
                GameObject textLabel = DisplayUtils.AddContentToParentObject(titleLabelRodPrefab, rodsToSelectTransform);
                textLabel.GetComponent<TMP_Text>().text = rodCategories[i];
                GameObject gridPanel = DisplayUtils.AddContentToParentObject(rodGridPrefab, rodsToSelectTransform);
                for (int j = 0; j < rodTypesToInitialize[i]; j++)
                {
                    GameObject singleRodObject = DisplayUtils.AddContentToParentObject(singleRodPrefab, gridPanel.transform);
                    SingleRodPanel singleRodPanel = singleRodObject.GetComponent<SingleRodPanel>();

                    int randomIcon = Random.Range(0, rodIcons.Length);
                    int randomFrame = Random.Range(0, rodFrames.Length);
                    int randomName = Random.Range(0, rodNames.Length);
                    singleRodPanel.Create(rodIcons[randomIcon], rodFrames[randomFrame], rodNames[randomName]);

                }
            }
        }
    }

    private IEnumerator DelayInit()
    {
        yield return new WaitForEndOfFrame();
        rodsToSelectTransform.gameObject.SetActive(true);
    }

    private void Clear()
    {
        foreach (Transform child in rodsToSelectTransform)
        {
            Destroy(child.gameObject);
        }
    }
}
