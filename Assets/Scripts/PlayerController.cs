using System;
using Photon.Pun;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PhotonView _photonView;

    private void Awake()
    {
        _photonView.GetComponent<PhotonView>();
    }

    private void Update()
    {
        if(!_photonView.IsMine)
            return;

        Look();
        Move();
    }

    private void FixedUpdate()
    {
        if(!_photonView.IsMine)
            return;
        
        
    }

    private void Look()
    {
        
    }
    private void Move()
    {
        
    }
}
