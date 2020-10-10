using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillCooldown : MonoBehaviour
{
    PlayerController playerController;

    public string skillToCast = "Skill 1";
    public Image darkMask;
    public TextMeshProUGUI cooldownText;

    private Skill skill;
    private Image skillButtonImage;
    private string skillSound;
    private float skillCooldown;
    private float cooldownTimer;

    // Update is called once per frame
    void Update()
    {
        if(cooldownTimer <= 0)
        {
            cooldownTimer = 0;
            SkillReady();
        }

        else
            Cooldown();
    }

    public void Initialize(Skill skill)
    {
        this.skill = skill;
        skillButtonImage = GetComponent<Image>();
        skillSound = skill.skillSound;
        skillButtonImage.sprite = skill.skillSprite;
        darkMask.sprite = skill.skillSprite;
        skillCooldown = skill.cooldown;
        playerController = skill.playerController;
    }

    public void CanCastSkill()
    {
        if (cooldownTimer == 0 && !playerController.skillQueue.Contains(skill))
        {            
            if (playerController.skillQueue.Count == 0) 
                CastSkill();            
            playerController.skillQueue.Enqueue(skill);            
        }
    }

    private void SkillReady()
    {
        cooldownText.enabled = false;
        darkMask.enabled = false;
    }

    private void Cooldown()
    {
        cooldownTimer -= Time.deltaTime;
        cooldownText.text = cooldownTimer.ToString("F");
        darkMask.fillAmount = (cooldownTimer / skillCooldown);
    }

    public void CastSkill()
    {
        cooldownTimer = skillCooldown;
        darkMask.enabled = true;
        cooldownText.enabled = true;
        skill.CastSkill();
    }
}
