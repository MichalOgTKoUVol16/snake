using UnityEngine;

public class Snake : MonoBehaviour
{
    public float speed = 1;

    private Vector3 nextTurn;

    public void Start()
    {
    }

    public void TurnInput(float zRot)
    {
        if (!CanPickDirection(zRot))
            return;

        nextTurn = new Vector3(0, 0, zRot);
    }

    private bool CanPickDirection(float zRot)
    {
        return Mathf.Approximately(Mathf.Abs(Mathf.DeltaAngle(transform.rotation.eulerAngles.z, zRot)), 90f);
    }

    private bool CanTurnNow()
    {
        return transform.position.y % 0.64f < 0.1f;
    }

    public void Update()
    {
        if (nextTurn != Vector3.down && CanTurnNow())
            Turn();

        KeepMoving();
    }

    private void Turn()
    {
        transform.rotation = Quaternion.Euler(nextTurn);
        nextTurn = Vector3.down;
    }

    private void KeepMoving()
    {
        transform.Translate(Vector2.up * speed * 0.1f * Time.deltaTime);
    }
}

