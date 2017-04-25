using System;
using UnityEngine;

// Token: 0x02000082 RID: 130
[Serializable]
public class DoorGapScript : MonoBehaviour
{
	// Token: 0x06000319 RID: 793 RVA: 0x000410A4 File Offset: 0x0003F2A4
	public DoorGapScript()
	{
		this.Phase = 1;
	}

	// Token: 0x0600031A RID: 794 RVA: 0x000410B4 File Offset: 0x0003F2B4
	public virtual void Start()
	{
		this.Papers[1].active = false;
	}

	// Token: 0x0600031B RID: 795 RVA: 0x000410C4 File Offset: 0x0003F2C4
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount == (float)0)
		{
			if (this.Phase == 1)
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.Yandere.Inventory.AnswerSheet = false;
				this.Papers[1].gameObject.active = true;
				PlayerPrefs.SetInt("Scheme_5_Stage", 3);
				this.Schemes.UpdateInstructions();
				this.audio.Play();
			}
			else
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
				this.Prompt.Yandere.Inventory.AnswerSheet = true;
				this.Prompt.Yandere.Inventory.DuplicateSheet = true;
				this.Papers[2].gameObject.active = false;
				this.RummageSpot.Prompt.Label[0].text = "     " + "Return Answer Sheet";
				this.RummageSpot.Prompt.enabled = true;
				PlayerPrefs.SetInt("Scheme_5_Stage", 4);
				this.Schemes.UpdateInstructions();
			}
			this.Phase++;
		}
		if (this.Phase == 2)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)4)
			{
				this.Prompt.Label[0].text = "     " + "Pick Up Sheets";
				this.Prompt.enabled = true;
				this.Phase = 2;
			}
			else if (this.Timer > (float)3)
			{
				float z = Mathf.Lerp(this.Papers[2].localPosition.z, -0.166f, Time.deltaTime * (float)10);
				Vector3 localPosition = this.Papers[2].localPosition;
				float num = localPosition.z = z;
				Vector3 vector = this.Papers[2].localPosition = localPosition;
			}
			else if (this.Timer > (float)1)
			{
				float z2 = Mathf.Lerp(this.Papers[1].localPosition.z, 0.166f, Time.deltaTime * (float)10);
				Vector3 localPosition2 = this.Papers[1].localPosition;
				float num2 = localPosition2.z = z2;
				Vector3 vector2 = this.Papers[1].localPosition = localPosition2;
			}
		}
	}

	// Token: 0x0600031C RID: 796 RVA: 0x0004134C File Offset: 0x0003F54C
	public virtual void Main()
	{
	}

	// Token: 0x040007D8 RID: 2008
	public RummageSpotScript RummageSpot;

	// Token: 0x040007D9 RID: 2009
	public SchemesScript Schemes;

	// Token: 0x040007DA RID: 2010
	public PromptScript Prompt;

	// Token: 0x040007DB RID: 2011
	public Transform[] Papers;

	// Token: 0x040007DC RID: 2012
	public float Timer;

	// Token: 0x040007DD RID: 2013
	public int Phase;
}
