using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class CapsuleMultiplayerBh : NetworkBehaviour
{
    public float MovementSpeed;
    public Color MyRemoteColor = Color.red;

    MeshRenderer myMeshRender;
    NetworkVariable<Color> remoteColor = new NetworkVariable<Color>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myMeshRender = GetComponent<MeshRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {

        myMeshRender.material.color = remoteColor.Value;


        if (IsLocalPlayer)
        {
            remoteColor.Value = MyRemoteColor;

            if (Input.GetKey(KeyCode.D))

            {
                transform.Translate(MovementSpeed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(0, 0, -MovementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(0, 0, MovementSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(-MovementSpeed * Time.deltaTime, 0, 0);
            }
        }

        else
        {
            myMeshRender.material.color = Random.ColorHSV();
        }
    }
}
