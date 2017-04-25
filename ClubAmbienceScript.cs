using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
[Serializable]
public class ClubAmbienceScript : MonoBehaviour
{
	// Token: 0x0600027B RID: 635 RVA: 0x0002D56C File Offset: 0x0002B76C
	public virtual void Update()
	{
		if (this.Yandere.position.y > this.transform.position.y - 0.1f && this.Yandere.position.y < this.transform.position.y + 0.1f)
		{
			if (Vector3.Distance(this.transform.position, this.Yandere.position) < (float)4)
			{
				this.CreateAmbience = true;
				this.EffectJukebox = true;
			}
			else
			{
				this.CreateAmbience = false;
			}
		}
		if (this.EffectJukebox)
		{
			if (this.CreateAmbience)
			{
				this.audio.volume = Mathf.MoveTowards(this.audio.volume, this.MaxVolume, Time.deltaTime * 0.1f);
				this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, this.ClubDip, Time.deltaTime * 0.1f);
			}
			else
			{
				this.audio.volume = Mathf.MoveTowards(this.audio.volume, (float)0, Time.deltaTime * 0.1f);
				this.Jukebox.ClubDip = Mathf.MoveTowards(this.Jukebox.ClubDip, (float)0, Time.deltaTime * 0.1f);
				if (this.Jukebox.ClubDip == (float)0)
				{
					this.EffectJukebox = false;
				}
			}
		}
	}

	// Token: 0x0600027C RID: 636 RVA: 0x0002D6F8 File Offset: 0x0002B8F8
	public virtual void Main()
	{
	}

	// Token: 0x04000564 RID: 1380
	public JukeboxScript Jukebox;

	// Token: 0x04000565 RID: 1381
	public Transform Yandere;

	// Token: 0x04000566 RID: 1382
	public bool CreateAmbience;

	// Token: 0x04000567 RID: 1383
	public bool EffectJukebox;

	// Token: 0x04000568 RID: 1384
	public float ClubDip;

	// Token: 0x04000569 RID: 1385
	public float MaxVolume;
}
