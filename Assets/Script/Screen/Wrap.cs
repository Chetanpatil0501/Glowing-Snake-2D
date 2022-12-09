using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
    [SerializeField]
    private ScreenWrapping screenBounds;

    public void TestColliderForWrapping(Collider2D collider)
    {
        if (collider.GetComponent<WrapTrigge>())
        {
            Vector3 newPosition = screenBounds
                .CalculateWrappedPosition(collider.transform.position);
            collider.gameObject.transform.position = newPosition;
        }
    }
}
