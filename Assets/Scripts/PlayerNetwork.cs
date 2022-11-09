using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    #region Variables

    // Variables.
    //[SerializeField] private float moveSpeed = 3f;

    //[SerializeField] private WheelCollider frontLeftWheel;
    //[SerializeField] private WheelCollider frontRightWheel;
    //[SerializeField] private WheelCollider backLeftWheel;
    //[SerializeField] private WheelCollider backRightWheel;

    private CarController cc;

    private NetworkVariable<MyCustomData> randomNum = new NetworkVariable<MyCustomData>(
        new MyCustomData
        {
            _int = 42,
            _bool = true
        },
        NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Owner);

    #endregion Variables

    #region Unity Methods

    private void Awake()
    {
        cc = GetComponent<CarController>();
    }

    private void Update()
    {
        if (!IsOwner) return;

        cc.Drive();
    }

    #endregion Unity Methods

    #region Private Methods

    // Private Methods.
    private void Move()
    {
        if (!IsOwner) return;

        if (Input.GetKeyDown(KeyCode.T))
        {
            TestServerRpc();
            //randomNum.Value = new MyCustomData { _int = 10, _bool = false, message = "balls" };
        }

        var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        //transform.Translate(moveSpeed * input * Time.deltaTime);
    }

    [ServerRpc]
    private void TestServerRpc()
    {
        Debug.Log("Test server Rpc " + OwnerClientId);
    }

    #endregion Private Methods

    #region Public Methods

    // Public Methods.
    public override void OnNetworkSpawn()
    {
        randomNum.OnValueChanged += (MyCustomData previousValue, MyCustomData NewValue) =>
        {
            Debug.Log(OwnerClientId + "; RandomNumber: " + NewValue._int + "; " + NewValue._bool + "; " + NewValue.message);
        };
    }

    #endregion Public Methods

    #region Structs

    public struct MyCustomData : INetworkSerializable
    {
        public int _int;
        public bool _bool;
        public FixedString128Bytes message;

        public void NetworkSerialize<T>(BufferSerializer<T> serializer) where T : IReaderWriter
        {
            serializer.SerializeValue(ref _int);
            serializer.SerializeValue(ref _bool);
            serializer.SerializeValue(ref message);
        }
    }

    #endregion Structs
}