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
    /// AR�A�v���P�[�V�����ŉ摜�g���b�L���O
    /// </summary>
    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    /// <summary>
    /// �g���b�L���O���ꂽ�摜�Ɋ�Â��ăv���n�u�𐶐�
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
