using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class SpineManager : MonoBehaviour
{
    // ������ �ִϸ��̼��� ���� ��
    //public SkeletonAnimation skeletonAnimation;
    public AnimationReferenceAsset[] animClip;
    public SkeletonGraphic sg;

    public string walk;
    public string dance;

    private void Start()
    {
        sg = GetComponent<SkeletonGraphic>();
    }

    // �ִϸ��̼ǿ� ���� Enum
    public enum AnimState
    {
        walk, dance
    }

    public void SetNormal()
    {
        sg.AnimationState.SetAnimation(0, walk, true);
    }

    // ���� �ִϸ��̼� ó���� ���������� ���� ����
    private AnimState animState;

    // ���� ����ǰ� �ִ� �ִϸ��̼�
    private string CurrentAnimation;

    Rigidbody2D rigd;
    private float xx;

    private void Awake()
    {
        rigd = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        xx = Input.GetAxisRaw("Horizontal");
        if (xx == 1)
        {
            animState = AnimState.walk;
        }
        else if(Input.GetKey(KeyCode.Alpha1))
        {
            animState = AnimState.dance;
            //transform.localScale = new Vector2(xx, 1);
        }
        else if(Input.GetKey(KeyCode.Alpha2))
        {
            animState = AnimState.walk;

        }
        // �ִϸ��̼� ����
        SetCurrentAnimation(animState);
    }

    private void AnimChange(AnimationReferenceAsset animClip, bool loop, float speed)
    {
        // ������ �ִϸ��̼��� ����ҷ��� �Ѵٸ� ����
        if (animClip.name.Equals(CurrentAnimation))
            return;

        // �ش� �ִϸ��̼����� �����Ѵ�.
        //skeletonAnimation.state.SetAnimation(0, animClip, loop).TimeScale = speed;
        //skeletonAnimation.loop = loop;
        //skeletonAnimation.timeScale = speed;

        // ���� ����ǰ� �ִ� �ִϸ��̼� ���� ����
        CurrentAnimation = animClip.name;
    }

    private void SetCurrentAnimation(AnimState state)
    {
        switch(state)
        {
            case AnimState.walk:
                AnimChange(animClip[(int)AnimState.walk], true, 1f);
                break;

            case AnimState.dance:
                AnimChange(animClip[(int)AnimState.dance], true, 1f);
                break;
        }
    }

}
