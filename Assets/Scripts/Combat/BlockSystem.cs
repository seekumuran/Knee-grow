using UnityEngine;

public class BlockSystem : MonoBehaviour
{
    public bool isBlocking;

    public Animator animator;

    private readonly int blockHash =
        Animator.StringToHash("Block");

    void Update()
    {
        HandleBlock();
    }

    void HandleBlock()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            isBlocking = true;

            animator.SetBool(blockHash, true);
        }
        else
        {
            isBlocking = false;

            animator.SetBool(blockHash, false);
        }
    }
}
