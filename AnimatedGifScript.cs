using System;
using UnityEngine;

// Token: 0x02000039 RID: 57
[Serializable]
public class AnimatedGifScript : MonoBehaviour
{
	// Token: 0x060001B5 RID: 437 RVA: 0x000209A4 File Offset: 0x0001EBA4
	public AnimatedGifScript()
	{
		this.SpriteName = string.Empty;
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x000209B8 File Offset: 0x0001EBB8
	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > this.Framerate)
		{
			this.Sprite.spriteName = this.SpriteName + this.Frame;
			this.Timer = (float)0;
			this.Frame++;
			if (this.Frame > this.Limit)
			{
				this.Frame = this.Start;
			}
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x00020A3C File Offset: 0x0001EC3C
	public virtual void Main()
	{
	}

	// Token: 0x040003A7 RID: 935
	public UISprite Sprite;

	// Token: 0x040003A8 RID: 936
	public string SpriteName;

	// Token: 0x040003A9 RID: 937
	public int Start;

	// Token: 0x040003AA RID: 938
	public int Frame;

	// Token: 0x040003AB RID: 939
	public int Limit;

	// Token: 0x040003AC RID: 940
	public float Framerate;

	// Token: 0x040003AD RID: 941
	public float Timer;
}
