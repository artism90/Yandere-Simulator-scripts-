using System;
using UnityEngine;

// Token: 0x0200003B RID: 59
[Serializable]
public class AntiCheatScript : MonoBehaviour
{
	// Token: 0x060001BD RID: 445 RVA: 0x00020C20 File Offset: 0x0001EE20
	public virtual void Update()
	{
		if (this.Check && !this.audio.isPlaying)
		{
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	// Token: 0x060001BE RID: 446 RVA: 0x00020C54 File Offset: 0x0001EE54
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "YandereChan")
		{
			this.Jukebox.active = false;
			this.Check = true;
			this.audio.Play();
		}
	}

	// Token: 0x060001BF RID: 447 RVA: 0x00020C9C File Offset: 0x0001EE9C
	public virtual void Main()
	{
	}

	// Token: 0x040003B5 RID: 949
	public GameObject Jukebox;

	// Token: 0x040003B6 RID: 950
	public bool Check;
}
