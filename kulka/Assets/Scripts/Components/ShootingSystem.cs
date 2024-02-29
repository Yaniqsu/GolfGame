using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    [Header("SHOOTING-----------------------------------------")]
    [SerializeField] Transform shootingOrigin;
    [SerializeField] Rigidbody2D shootingInstance;
    [SerializeField] Vector3 direction;
    [SerializeField] float maxSpeed;
    [SerializeField] float launchSpeedGrowthMultiplier;
    float _launchSpeed;
    bool _charging = false;
    [Header("TRAJECTORY DRAWING-------------------------------")]
    [SerializeField] TrajectoryLineRenderer lineRenderer;
    [SerializeField] float minHeight;

    public void InitializeShoot()
    {
        _launchSpeed = 0;
        StartCoroutine(WaitForInput());
    }

    public void ModifyLaunchSpeedGrowthMultiplier(float modifier)
    {
        launchSpeedGrowthMultiplier += modifier;
    }

    IEnumerator WaitForInput()
    {
        yield return new WaitUntil(() => Input.GetKey(KeyCode.Space));
        EnableTrajectory();
        StartCoroutine(IncreaseLaunchSpeed());
        StartCoroutine(WaitForRelease());
    }

    IEnumerator WaitForRelease()
    {
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.Space) || _launchSpeed > maxSpeed);
        DeleteTrajectory();
        Shoot();
    }

    IEnumerator IncreaseLaunchSpeed()
    {
        WaitForEndOfFrame waitForEndOfFrame = new();
        _charging = true;
        while (_charging)
        {
            _launchSpeed += Time.deltaTime * launchSpeedGrowthMultiplier;
            lineRenderer.DrawTrajectory(shootingOrigin.position, _launchSpeed * direction, shootingInstance, minHeight);
            yield return waitForEndOfFrame;
        }
    }
    void Shoot()
    {
        _charging = false;
        shootingInstance.AddForce(_launchSpeed * direction, ForceMode2D.Impulse);
    }
    void DeleteTrajectory()
    {
        lineRenderer.dots.ToggleAllObjects(false);
    }
    void EnableTrajectory()
    {
        lineRenderer.enabled = true;
    }
}
