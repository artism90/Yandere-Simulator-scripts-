using System;
using UnityEngine;

// Token: 0x0200007D RID: 125
[Serializable]
public class DemonSlashScript : MonoBehaviour
{
	// Token: 0x06000305 RID: 773 RVA: 0x0003E52C File Offset: 0x0003C72C
	public virtual void Update()
	{
		if (this.MyCollider.enabled)
		{
			this.Timer += Time.deltaTime;
			if (this.Timer > 0.33333f)
			{
				this.MyCollider.enabled = false;
				this.Timer = (float)0;
			}
		}
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0003E580 File Offset: 0x0003C780
	public virtual void OnTriggerEnter(Collider other)
	{
		if ((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript)) != null && ((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).StudentID != 1 && !((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Dead)
		{
			((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Dead = true;
			if (!((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Male)
			{
				UnityEngine.Object.Instantiate(this.FemaleBloodyScream, other.gameObject.transform.root.transform.position + Vector3.up, Quaternion.identity);
			}
			else
			{
				UnityEngine.Object.Instantiate(this.MaleBloodyScream, other.gameObject.transform.root.transform.position + Vector3.up, Quaternion.identity);
			}
			((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).BecomeRagdoll();
			((StudentScript)other.gameObject.transform.root.gameObject.GetComponent(typeof(StudentScript))).Ragdoll.Dismember();
			this.audio.Play();
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0003E768 File Offset: 0x0003C968
	public virtual void Main()
	{
	}

	// Token: 0x040007A8 RID: 1960
	public GameObject FemaleBloodyScream;

	// Token: 0x040007A9 RID: 1961
	public GameObject MaleBloodyScream;

	// Token: 0x040007AA RID: 1962
	public Collider MyCollider;

	// Token: 0x040007AB RID: 1963
	public float Timer;
}
