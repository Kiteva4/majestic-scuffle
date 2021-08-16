using System;
using System.IO;
using Photon.Pun;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (_photonView.IsMine)
        {
            CreatePlayerController();
        }
    }

    private void CreatePlayerController()
    {
        Debug.Log("Create PlayerController");
        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerControllerVariatn_MedicGirl"), Vector3.zero,
            Quaternion.identity);
    }
}
