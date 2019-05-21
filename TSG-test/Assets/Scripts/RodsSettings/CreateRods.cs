using System.Collections.Generic;
using TMPro;
using UnityEngine;

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

    private List<SingleRodPanel> createdRods = new List<SingleRodPanel>();
    private GameObject spawnedObject;
    private int rodModelsCount;

    private void OnEnable()
    {
        EventManager.Instance.OnSingleRodPanelClick += OnSingleRodPanelResponse;
    }

    private void OnDisable()
    {
        EventManager.Instance.OnSingleRodPanelClick -= OnSingleRodPanelResponse;
    }

    private void Awake()
    {
        Clear();
        createdRods.Clear();
        rodModelsCount = ObjectPooler.Instance.Pools.Count;
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
                textLabel.GetComponent<TextMeshProUGUI>().text = rodCategories[i];
                GameObject gridPanel = DisplayUtils.AddContentToParentObject(rodGridPrefab, rodsToSelectTransform);
                for (int j = 0; j < rodTypesToInitialize[i]; j++)
                {
                    GameObject singleRodObject = DisplayUtils.AddContentToParentObject(singleRodPrefab, gridPanel.transform);
                    SingleRodPanel singleRodPanel = singleRodObject.GetComponent<SingleRodPanel>();

                    // always select first rod
                    if (j == 0)
                    {
                        singleRodPanel.IsRodSelected = true;
                        singleRodPanel.SelectedPanel.gameObject.SetActive(true);
                        spawnedObject = ObjectPooler.Instance.SpawnFromPool(singleRodPanel.SelectedRodModel);
                    }

                    int randomIcon = Random.Range(0, rodIcons.Length);
                    int randomFrame = Random.Range(0, rodFrames.Length);
                    int randomName = Random.Range(0, rodNames.Length);
                    int randomModel = Random.Range(0, rodModelsCount);
                    int randomSliderValue = j == 0 ? 100 : Random.Range(0, 100);
                    singleRodPanel.Create(rodIcons[randomIcon], rodFrames[randomFrame], rodNames[randomName], randomModel, randomSliderValue);
                    createdRods.Add(singleRodPanel);
                }
            }
        }
    }

    private void OnSingleRodPanelResponse(SingleRodPanel rod)
    {
        DeselectAllRods();
        rod.IsRodSelected = true;
        rod.SelectedPanel.gameObject.SetActive(true);
        if (spawnedObject != null)
        {
            ObjectPooler.Instance.Despawn(spawnedObject);
        }
        spawnedObject = ObjectPooler.Instance.SpawnFromPool(rod.SelectedRodModel);
    }

    private void DeselectAllRods()
    {
        foreach (SingleRodPanel rod in createdRods)
        {
            rod.IsRodSelected = false;
            rod.SelectedPanel.gameObject.SetActive(false);
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
