using System;
using UnityEngine;

// Token: 0x02000040 RID: 64
[Serializable]
public class ArcScript : MonoBehaviour
{
	// Token: 0x060001D2 RID: 466 RVA: 0x00021B74 File Offset: 0x0001FD74
	public virtual void Update()
	{
		this.Timer += Time.deltaTime;
		if (this.Timer > (float)1)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.ArcTrail, this.transform.position, this.transform.rotation);
			gameObject.rigidbody.AddRelativeForce(Vector3.forward * (float)250);
			this.Timer = (float)0;
		}
	}

	// Token: 0x060001D3 RID: 467 RVA: 0x00021BEC File Offset: 0x0001FDEC
	public virtual void Main()
	{
	}

	// Token: 0x040003E7 RID: 999
	public GameObject ArcTrail;

	// Token: 0x040003E8 RID: 1000
	public float Timer;
}
