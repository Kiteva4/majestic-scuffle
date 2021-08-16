using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    
    private PhotonView _photonView;
    private Camera _mainCamera;
    private Transform _selfTransform;
    private static readonly int VelocityX = Animator.StringToHash("VelocityX");
    private static readonly int VelocityZ = Animator.StringToHash("VelocityZ");

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        _mainCamera = Camera.main;
        _selfTransform = transform;
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movement = new Vector3(horizontal, 0, vertical);

        if (movement.magnitude > 0)
        {
            movement.Normalize();
            movement *= _speed * Time.deltaTime;
            if (!_photonView.IsMine)
                return;
            _selfTransform.Translate(movement, Space.World);
        }

        var velocityZ = Vector3.Dot(movement.normalized, _selfTransform.forward);
        var velocityX = Vector3.Dot(movement.normalized, _selfTransform.right);
        
        if (!_photonView.IsMine)
            return;
        
        _animator.SetFloat(VelocityX, velocityX, 0.01f, Time.deltaTime);
        _animator.SetFloat(VelocityZ, velocityZ, 0.01f, Time.deltaTime);
        
        //AimTowardMouse();
    }

    private void AimTowardMouse()
    {
        var plane = new Plane(_selfTransform.up, _selfTransform.position);
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out var enter))
        {
            var hitPoint = ray.GetPoint(enter);
            if(Vector3.Distance(_selfTransform.position, hitPoint) < 0.3f)
                return;
            var dir = (hitPoint - _selfTransform.position).normalized;
            _selfTransform.forward = new Vector3(dir.x, _selfTransform.forward.y , dir.z);
        }
    }
}
