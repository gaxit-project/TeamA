using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialOnCollision : MonoBehaviour
{
    public Material newMaterial; // �V�����}�e���A�����A�T�C�����邽�߂̕ϐ�

    private void OnCollisionEnter(Collision collision)
    {
        // �Փ˂����I�u�W�F�N�g�̃^�O������̂��̂ł���ꍇ�Ƀ}�e���A����ύX
        if (collision.gameObject.CompareTag("YourTagHere"))
        {
            Renderer objectRenderer = GetComponent<Renderer>();

            // �}�e���A���̕ύX
            if (objectRenderer != null && newMaterial != null)
            {
                objectRenderer.material = newMaterial;
            }
        }
    }
}
