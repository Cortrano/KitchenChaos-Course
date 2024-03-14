using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour {
    private Material defaultMaterial;
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private ClearCounter clearCounter;
    [SerializeField] private GameObject geometry;

    private void Awake() {
        defaultMaterial = geometry.GetComponent<MeshRenderer>().material;
    }

    private void Start() {
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e) {
        if (e.selectedCounter == clearCounter) {
            geometry.GetComponent<MeshRenderer>().material = selectedMaterial;
        }
        else {
            geometry.GetComponent<MeshRenderer>().material = defaultMaterial;
        }
    }
}
