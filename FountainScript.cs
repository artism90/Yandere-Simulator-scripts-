using System;
using UnityEngine;

// Token: 0x02000097 RID: 151
[Serializable]
public class FountainScript : MonoBehaviour
{
	// Token: 0x06000374 RID: 884 RVA: 0x00047770 File Offset: 0x00045970
	public virtual void Start()
	{
		this.SpraySFX.volume = 0.1f;
		this.DropsSFX.volume = 0.1f;
	}

	// Token: 0x06000375 RID: 885 RVA: 0x000477A0 File Offset: 0x000459A0
	public virtual void Update()
	{
		if (this.StartTimer < (float)1)
		{
			this.StartTimer += Time.deltaTime;
			if (this.StartTimer > (float)1)
			{
				this.SpraySFX.gameObject.active = true;
				this.DropsSFX.gameObject.active = true;
			}
		}
		if (this.Drowning)
		{
			if (this.Timer == (float)0 && this.EventSubtitle.transform.localScale.x < (float)1)
			{
				this.EventSubtitle.transform.localScale = new Vector3((float)1, (float)1, (float)1);
				this.EventSubtitle.text = "Hey, what are you -";
				this.audio.Play();
			}
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)3 && this.EventSubtitle.transform.localScale.x > (float)0)
			{
				this.EventSubtitle.transform.localScale = new Vector3((float)0, (float)0, (float)0);
				this.EventSubtitle.text = string.Empty;
				this.Splashes.Play();
			}
			if (this.Timer > (float)9)
			{
				this.Drowning = false;
				this.Splashes.Stop();
				this.Timer = (float)0;
			}
		}
	}

	// Token: 0x06000376 RID: 886 RVA: 0x00047908 File Offset: 0x00045B08
	public virtual void Main()
	{
	}

	// Token: 0x040008A6 RID: 2214
	public ParticleSystem Splashes;

	// Token: 0x040008A7 RID: 2215
	public UILabel EventSubtitle;

	// Token: 0x040008A8 RID: 2216
	public Collider[] Colliders;

	// Token: 0x040008A9 RID: 2217
	public bool Drowning;

	// Token: 0x040008AA RID: 2218
	public AudioSource SpraySFX;

	// Token: 0x040008AB RID: 2219
	public AudioSource DropsSFX;

	// Token: 0x040008AC RID: 2220
	public float StartTimer;

	// Token: 0x040008AD RID: 2221
	public float Timer;
}
