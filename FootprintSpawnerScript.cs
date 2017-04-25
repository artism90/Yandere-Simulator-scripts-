using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000096 RID: 150
[Serializable]
public class FootprintSpawnerScript : MonoBehaviour
{
	// Token: 0x06000370 RID: 880 RVA: 0x000472AC File Offset: 0x000454AC
	public virtual void Start()
	{
		this.GardenArea = (Collider)GameObject.Find("GardenArea").GetComponent(typeof(Collider));
		this.NEStairs = (Collider)GameObject.Find("NEStairs").GetComponent(typeof(Collider));
		this.NWStairs = (Collider)GameObject.Find("NWStairs").GetComponent(typeof(Collider));
		this.SEStairs = (Collider)GameObject.Find("SEStairs").GetComponent(typeof(Collider));
		this.SWStairs = (Collider)GameObject.Find("SWStairs").GetComponent(typeof(Collider));
	}

	// Token: 0x06000371 RID: 881 RVA: 0x00047370 File Offset: 0x00045570
	public virtual void Update()
	{
		if (this.GardenArea.bounds.Contains(this.transform.position) || this.NEStairs.bounds.Contains(this.transform.position) || this.NWStairs.bounds.Contains(this.transform.position) || this.SEStairs.bounds.Contains(this.transform.position) || this.SWStairs.bounds.Contains(this.transform.position))
		{
			this.CanSpawn = false;
		}
		else
		{
			this.CanSpawn = true;
		}
		if (!this.FootUp)
		{
			if (this.transform.position.y > this.Yandere.transform.position.y + 0.1f)
			{
				this.FootUp = true;
			}
		}
		else if (this.transform.position.y < this.Yandere.transform.position.y + this.Threshold)
		{
			if (!this.Yandere.Crouching && !this.Yandere.Crawling && this.Yandere.CanMove && Input.GetButton("LB") && this.FootUp)
			{
				this.audio.clip = this.Footsteps[UnityEngine.Random.Range(0, Extensions.get_length(this.Footsteps))];
				this.audio.Play();
			}
			this.FootUp = false;
			if (this.CanSpawn && this.Bloodiness > 0)
			{
				if (this.transform.position.y > (float)-1 && this.transform.position.y < (float)1)
				{
					this.Height = (float)0;
				}
				else if (this.transform.position.y > (float)3 && this.transform.position.y < (float)5)
				{
					this.Height = (float)4;
				}
				else if (this.transform.position.y > (float)7 && this.transform.position.y < (float)9)
				{
					this.Height = (float)8;
				}
				else if (this.transform.position.y > (float)11 && this.transform.position.y < (float)13)
				{
					this.Height = (float)12;
				}
				GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodyFootprint, new Vector3(this.transform.position.x, this.Height + 0.012f, this.transform.position.z), Quaternion.identity);
				float y = this.transform.eulerAngles.y;
				Vector3 eulerAngles = gameObject.transform.eulerAngles;
				float num = eulerAngles.y = y;
				Vector3 vector = gameObject.transform.eulerAngles = eulerAngles;
				gameObject.transform.parent = this.BloodParent;
				if (this.LeftFoot)
				{
					int num2 = -1;
					Vector3 localScale = gameObject.transform.localScale;
					float num3 = localScale.x = (float)num2;
					Vector3 vector2 = gameObject.transform.localScale = localScale;
				}
				this.Bloodiness--;
			}
		}
	}

	// Token: 0x06000372 RID: 882 RVA: 0x00047764 File Offset: 0x00045964
	public virtual void Main()
	{
	}

	// Token: 0x04000896 RID: 2198
	public YandereScript Yandere;

	// Token: 0x04000897 RID: 2199
	public GameObject BloodyFootprint;

	// Token: 0x04000898 RID: 2200
	public AudioClip[] Footsteps;

	// Token: 0x04000899 RID: 2201
	public Transform BloodParent;

	// Token: 0x0400089A RID: 2202
	public Collider GardenArea;

	// Token: 0x0400089B RID: 2203
	public Collider NEStairs;

	// Token: 0x0400089C RID: 2204
	public Collider NWStairs;

	// Token: 0x0400089D RID: 2205
	public Collider SEStairs;

	// Token: 0x0400089E RID: 2206
	public Collider SWStairs;

	// Token: 0x0400089F RID: 2207
	public bool CanSpawn;

	// Token: 0x040008A0 RID: 2208
	public bool LeftFoot;

	// Token: 0x040008A1 RID: 2209
	public bool FootUp;

	// Token: 0x040008A2 RID: 2210
	public float Threshold;

	// Token: 0x040008A3 RID: 2211
	public float Height;

	// Token: 0x040008A4 RID: 2212
	public int Bloodiness;

	// Token: 0x040008A5 RID: 2213
	public int Collisions;
}
