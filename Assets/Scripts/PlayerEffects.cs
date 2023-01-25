using UnityEngine;
using System.Collections;

public class PlayerEffects : MonoBehaviour
{

    public void AddMoveSpeed(int moveSpeedGiven, float moveSpeedDuration)
    {
        PlayerMovement.instance.moveSpeed += moveSpeedGiven;
        StartCoroutine(RemoveMoveSpeed(moveSpeedGiven, moveSpeedDuration));
    }

    private IEnumerator RemoveMoveSpeed(int moveSpeedGiven, float moveSpeedDuration)
    {
        yield return new WaitForSeconds(moveSpeedDuration);
        PlayerMovement.instance.moveSpeed -= moveSpeedGiven;
    }

    public void AddJumpForce(int jumpForceGiven, float jumpForceDuration)
    {
        PlayerMovement.instance.jumpForce += jumpForceGiven;
        StartCoroutine(RemoveJumpForce(jumpForceGiven, jumpForceDuration));
    }

    private IEnumerator RemoveJumpForce(int jumpForceGiven, float jumpForceDuration)
    {
        yield return new WaitForSeconds(jumpForceDuration);
        PlayerMovement.instance.jumpForce -= jumpForceGiven;
    }

    public void AddClimbSpeed(int climbSpeedGiven, float climbSpeedDuration)
    {
        PlayerMovement.instance.climbSpeed += climbSpeedGiven;
        StartCoroutine(RemoveClimbSpeed(climbSpeedGiven, climbSpeedDuration));
    }

    private IEnumerator RemoveClimbSpeed(int climbSpeedGiven, float climbSpeedDuration)
    {
        yield return new WaitForSeconds(climbSpeedDuration);
        PlayerMovement.instance.climbSpeed -= climbSpeedGiven;
    }
}
