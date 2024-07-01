using UnityEngine;

public class CheckNearbyBox : MonoBehaviour
{
    Player player;
    Vector3 difference;
    float dotProduct;

    bool keyPressed;

    private void Start()
    {
        player = GetComponentInParent<Player>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.E))
            keyPressed = true;
        else
            keyPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            difference = (other.transform.position - player.transform.position).normalized;
            dotProduct = Vector3.Dot(difference.normalized, player.transform.forward);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            if (!keyPressed)
                return;

            if (dotProduct > .5f)
                UseCommand(other.transform, other.transform.forward, 1);
            else if (dotProduct < -.5f)
                UseCommand(other.transform, other.transform.forward, -1);
            else
            {
                dotProduct = Vector3.Dot(difference, player.transform.right);

                if (dotProduct > 0)
                    UseCommand(other.transform, other.transform.right, 1);
                else
                    UseCommand(other.transform, other.transform.right, -1);
            }

        }
    }

    private void UseCommand(Transform transform, Vector3 direction, float angle)
    {
        MoveCommand<Transform> command = new MoveCommand<Transform>(transform, direction * angle, 1);
        GameManager.Instance.commandProcessor.Execute(command);
    }
}
