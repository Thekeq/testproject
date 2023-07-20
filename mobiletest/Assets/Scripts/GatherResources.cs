using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GatherResources : MonoBehaviour
{
    public Text Trees;
    private int points = 0;
    public Animator animator;
    public bool isShooting;

    private float animationDuration;
    private float animationTimer;

    public void restartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void IncrementPoints()
    {
        points++;
        Trees.text = points.ToString();
    }

    public IEnumerator RespawnTree(GameObject tree)
    {
        yield return new WaitForSeconds(15f);
        tree.SetActive(true);
    }
    private void Start()
    {
        isShooting = false;
        animationDuration = animator.runtimeAnimatorController.animationClips[0].length; // �������� ������� ����� ������� (��� ��������� ������ �������, ��� �� ������ �����������)
        animationTimer = 0f;
    }

    private void Update()
    {
        if (isShooting)
        {
            animationTimer += Time.deltaTime;
            if (animationTimer >= animationDuration)
            {
                // ���, �� ���������� ���� ��������� ������� �������
                isShooting = false;
                animator.SetBool("IsShoot", false);
                animationTimer = 0f;

                // ������� ��� ��� �����, ���� �� ������ ��������� ���� ���������� �������
                // ���������, ������� ������� ��� ������� �� ���� �������
            }
        }
    }
    public void Shoot()
    {
        isShooting = true;
        animator.SetBool("IsShoot", true);
    }
}
