using System;
using UnityEngine;

// Token: 0x02000098 RID: 152
[Serializable]
public class FramerateScript : MonoBehaviour
{
	// Token: 0x06000377 RID: 887 RVA: 0x0004790C File Offset: 0x00045B0C
	public FramerateScript()
	{
		this.updateInterval = 0.5f;
	}

	// Token: 0x06000378 RID: 888 RVA: 0x00047920 File Offset: 0x00045B20
	public virtual void Start()
	{
		if (!this.guiText)
		{
			MonoBehaviour.print("FramesPerSecond needs a GUIText component!");
			this.enabled = false;
		}
		else
		{
			this.timeleft = this.updateInterval;
		}
	}

	// Token: 0x06000379 RID: 889 RVA: 0x00047960 File Offset: 0x00045B60
	public virtual void Update()
	{
		this.timeleft -= Time.deltaTime;
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames++;
		if (this.timeleft <= (float)0)
		{
			this.FPS = this.accum / (float)this.frames;
			this.guiText.text = "FPS: " + (this.accum / (float)this.frames).ToString("f0");
			this.timeleft = this.updateInterval;
			this.accum = (float)0;
			this.frames = 0;
		}
	}

	// Token: 0x0600037A RID: 890 RVA: 0x00047A14 File Offset: 0x00045C14
	public virtual void Main()
	{
	}

	// Token: 0x040008AE RID: 2222
	public float updateInterval;

	// Token: 0x040008AF RID: 2223
	private float accum;

	// Token: 0x040008B0 RID: 2224
	private int frames;

	// Token: 0x040008B1 RID: 2225
	private float timeleft;

	// Token: 0x040008B2 RID: 2226
	public float FPS;
}
