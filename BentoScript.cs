using System;
using UnityEngine;

// Token: 0x02000046 RID: 70
[Serializable]
public class BentoScript : MonoBehaviour
{
	// Token: 0x060001F1 RID: 497 RVA: 0x00025980 File Offset: 0x00023B80
	public virtual void Update()
	{
		if (!this.Prompt.Yandere.Inventory.EmeticPoison && !this.Prompt.Yandere.Inventory.RatPoison)
		{
			this.Prompt.HideButton[0] = true;
		}
		else
		{
			this.Prompt.HideButton[0] = false;
		}
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			if (this.Prompt.Yandere.Inventory.EmeticPoison)
			{
				this.Prompt.Yandere.Inventory.EmeticPoison = false;
				this.Prompt.Yandere.PoisonType = 1;
			}
			else
			{
				this.Prompt.Yandere.Inventory.RatPoison = false;
				this.Prompt.Yandere.PoisonType = 3;
			}
			this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
			this.Prompt.Yandere.PoisonSpot = this.PoisonSpot;
			this.Prompt.Yandere.Poisoning = true;
			this.Prompt.Yandere.CanMove = false;
			this.enabled = false;
			this.Poison = 1;
			if (this.ID != 1)
			{
				this.StudentManager.Students[this.ID].Emetic = true;
			}
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.ID == 33)
		{
			if (this.Prompt.Yandere.Inventory.LethalPoison)
			{
				this.Prompt.HideButton[1] = false;
			}
			else
			{
				this.Prompt.HideButton[1] = true;
			}
			if (this.Prompt.Circle[1].fillAmount == (float)0)
			{
				this.Prompt.Yandere.CharacterAnimation.CrossFade("f02_poisoning_00");
				this.Prompt.Yandere.Inventory.LethalPoison = false;
				this.StudentManager.Students[this.ID].Lethal = true;
				this.Prompt.Yandere.PoisonSpot = this.PoisonSpot;
				this.Prompt.Yandere.Poisoning = true;
				this.Prompt.Yandere.CanMove = false;
				this.Prompt.Yandere.PoisonType = 2;
				this.enabled = false;
				this.Poison = 2;
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x00025C40 File Offset: 0x00023E40
	public virtual void Main()
	{
	}

	// Token: 0x04000430 RID: 1072
	public StudentManagerScript StudentManager;

	// Token: 0x04000431 RID: 1073
	public Transform PoisonSpot;

	// Token: 0x04000432 RID: 1074
	public PromptScript Prompt;

	// Token: 0x04000433 RID: 1075
	public int Poison;

	// Token: 0x04000434 RID: 1076
	public int ID;
}
