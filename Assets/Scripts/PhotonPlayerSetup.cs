using Photon.Pun;
using UnityEngine;

public class PhotonPlayerSetup : MonoBehaviour
{
    [SerializeField] private PhotonView _photonView;
    [SerializeField] private Transform _virtualCamera;
    [SerializeField] private Rigidbody _rigidbody;
    private void Awake()
    {
        if (_photonView.IsMine)
            _virtualCamera.transform.parent = Camera.main.transform;
        else
        {
            Destroy(_virtualCamera.gameObject);
            Destroy(_rigidbody);
        }
    }
}
