using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PrefabCreator : MonoBehaviour
{
    [SerializeField] private GameObject actorPrefab;
    [SerializeField] private Vector3 prefabOffset;

    private GameObject actor;
    private ARTrackedImageManager aRTrackedImageManager;

    /// <summary>
    /// ARアプリケーションで画像トラッキング
    /// </summary>
    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    /// <summary>
    /// トラッキングされた画像に基づいてプレハブを生成
    /// </summary>
    /// <param name="args"></param>
    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage image in args.added) 
        {
            actor = Instantiate(actorPrefab , image.transform);
            actor.transform.position += prefabOffset;
        }
    }
}
