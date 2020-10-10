using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Skill
{
    public PlayerController playerController;
    public string skillName = "New SKill";
    public Sprite skillSprite;
    public float cooldown = 1f;
    public string skillSound;
    public SkillCooldown skillCooldown;
    protected AnimationClip animation;

    public void OnSkillPressed() => skillCooldown.CanCastSkill();
    
    public abstract void CastSkill();

    //public abstract void OnSkillFinished();
}

