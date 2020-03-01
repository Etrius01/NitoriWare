﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkRoomLightEffect : MonoBehaviour
{
    public static Transform lampTransformSingleton;
    public static Transform cursorTransformSingleton;

    [Header("Singleton values only necessary in one instance")]
    [SerializeField]
    private Transform lampTransform;
    [SerializeField]
    private Transform cursorTransform;

    private Material material;

	void Start()
    {
        material = GetComponent<Renderer>().material;
        if (lampTransform != null)
            lampTransformSingleton = lampTransform;
        if (cursorTransform != null)
            cursorTransformSingleton = cursorTransform;
    }
	
	void LateUpdate()
    {
        updateValues();
    }

    void updateValues()
    {
        material.SetVector("_LampPos", lampTransformSingleton.position);
        material.SetVector("_CursorPos", cursorTransformSingleton.position);
        material.SetFloat("_LampAnim", DarkRoomEffectAnimationController.instance.lampBoost);
        material.SetFloat("_CursorAnim", DarkRoomEffectAnimationController.instance.cursorBoost);
    }
}
