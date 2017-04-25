using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
[Serializable]
public class CheeseScript : MonoBehaviour
{
	// Token: 0x0600025B RID: 603 RVA: 0x0002B020 File Offset: 0x00029220
	public virtual void Update()
	{
		if (this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Subtitle.text = "Knowing the mouse might one day leave its hole and get the cheese...It fills you with determination.";
			this.Prompt.Hide();
			this.Prompt.enabled = false;
			this.GlowingEye.active = true;
			this.Timer = (float)5;
		}
		if (this.Timer > (float)0)
		{
			this.Timer -= Time.deltaTime;
			if (this.Timer <= (float)0)
			{
				this.Prompt.enabled = true;
				this.Subtitle.text = string.Empty;
			}
		}
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0002B0CC File Offset: 0x000292CC
	public virtual void Main()
	{
	}

	// Token: 0x04000514 RID: 1300
	public GameObject GlowingEye;

	// Token: 0x04000515 RID: 1301
	public PromptScript Prompt;

	// Token: 0x04000516 RID: 1302
	public UILabel Subtitle;

	// Token: 0x04000517 RID: 1303
	public float Timer;
}
