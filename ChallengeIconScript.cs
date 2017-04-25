using System;
using UnityEngine;

// Token: 0x02000059 RID: 89
[Serializable]
public class ChallengeIconScript : MonoBehaviour
{
	// Token: 0x06000242 RID: 578 RVA: 0x00029A90 File Offset: 0x00027C90
	public virtual void Update()
	{
		if (this.transform.position.x > -0.125f && this.transform.position.x < 0.125f)
		{
			if (this.Icon != null)
			{
				this.LargeIcon.mainTexture = this.Icon.mainTexture;
			}
			this.Dark -= Time.deltaTime * (float)10;
			if (this.Dark < (float)0)
			{
				this.Dark = (float)0;
			}
		}
		else
		{
			this.Dark += Time.deltaTime * (float)10;
			if (this.Dark > (float)1)
			{
				this.Dark = (float)1;
			}
		}
		this.IconFrame.color = new Color(this.Dark, this.Dark, this.Dark, (float)1);
		this.NameFrame.color = new Color(this.Dark, this.Dark, this.Dark, (float)1);
		this.Name.color = new Color(this.Dark, this.Dark, this.Dark, (float)1);
	}

	// Token: 0x06000243 RID: 579 RVA: 0x00029BC8 File Offset: 0x00027DC8
	public virtual void Main()
	{
	}

	// Token: 0x040004D5 RID: 1237
	public UITexture LargeIcon;

	// Token: 0x040004D6 RID: 1238
	public UISprite IconFrame;

	// Token: 0x040004D7 RID: 1239
	public UISprite NameFrame;

	// Token: 0x040004D8 RID: 1240
	public UITexture Icon;

	// Token: 0x040004D9 RID: 1241
	public UILabel Name;

	// Token: 0x040004DA RID: 1242
	public float Dark;
}
