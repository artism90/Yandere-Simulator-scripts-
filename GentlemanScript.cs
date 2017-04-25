using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200009E RID: 158
[Serializable]
public class GentlemanScript : MonoBehaviour
{
	// Token: 0x06000392 RID: 914 RVA: 0x00049114 File Offset: 0x00047314
	public virtual void Update()
	{
		if (Input.GetButtonDown("RB") && !this.audio.isPlaying)
		{
			this.audio.clip = this.Clips[NGUITools.RandomRange(0, Extensions.get_length(this.Clips) - 1)];
			this.audio.Play();
			this.Yandere.Sanity = this.Yandere.Sanity + (float)10;
			this.Yandere.UpdateSanity();
		}
	}

	// Token: 0x06000393 RID: 915 RVA: 0x00049198 File Offset: 0x00047398
	public virtual void Main()
	{
	}

	// Token: 0x040008EC RID: 2284
	public YandereScript Yandere;

	// Token: 0x040008ED RID: 2285
	public AudioClip[] Clips;
}
