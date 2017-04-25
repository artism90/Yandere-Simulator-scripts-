using System;
using UnityEngine;

// Token: 0x0200004D RID: 77
[Serializable]
public class BloodyScreamScript : MonoBehaviour
{
	// Token: 0x06000213 RID: 531 RVA: 0x00026B14 File Offset: 0x00024D14
	public virtual void Start()
	{
		this.audio.clip = this.Screams[UnityEngine.Random.Range(0, this.Screams.Length)];
		this.audio.Play();
	}

	// Token: 0x06000214 RID: 532 RVA: 0x00026B50 File Offset: 0x00024D50
	public virtual void Main()
	{
	}

	// Token: 0x04000456 RID: 1110
	public AudioClip[] Screams;
}
