using System;
using UnityEngine;

// Token: 0x0200004B RID: 75
[Serializable]
public class BloodPoolSpawnerScript : MonoBehaviour
{
	// Token: 0x06000206 RID: 518 RVA: 0x000262AC File Offset: 0x000244AC
	public virtual void Start()
	{
		if (Application.loadedLevel == 10)
		{
			this.GardenArea = (Collider)GameObject.Find("GardenArea").GetComponent(typeof(Collider));
			this.NEStairs = (Collider)GameObject.Find("NEStairs").GetComponent(typeof(Collider));
			this.NWStairs = (Collider)GameObject.Find("NWStairs").GetComponent(typeof(Collider));
			this.SEStairs = (Collider)GameObject.Find("SEStairs").GetComponent(typeof(Collider));
			this.SWStairs = (Collider)GameObject.Find("SWStairs").GetComponent(typeof(Collider));
		}
		this.BloodParent = GameObject.Find("BloodParent").transform;
		this.Positions = new Vector3[5];
		this.Positions[1] = new Vector3(0.5f, 0.012f, (float)0);
		this.Positions[2] = new Vector3(-0.5f, 0.012f, (float)0);
		this.Positions[3] = new Vector3((float)0, 0.012f, 0.5f);
		this.Positions[4] = new Vector3((float)0, 0.012f, -0.5f);
	}

	// Token: 0x06000207 RID: 519 RVA: 0x00026424 File Offset: 0x00024624
	public virtual void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.LastBloodPool = other.gameObject;
			this.NearbyBlood++;
		}
	}

	// Token: 0x06000208 RID: 520 RVA: 0x00026468 File Offset: 0x00024668
	public virtual void OnTriggerExit(Collider other)
	{
		if (other.gameObject.name == "BloodPool(Clone)")
		{
			this.NearbyBlood--;
		}
	}

	// Token: 0x06000209 RID: 521 RVA: 0x000264A0 File Offset: 0x000246A0
	public virtual void Update()
	{
		if (this.MyCollider.enabled)
		{
			if (this.Timer > (float)0)
			{
				this.Timer -= Time.deltaTime;
			}
			this.GetHeight();
			if (Application.loadedLevel == 10)
			{
				if (this.GardenArea.bounds.Contains(this.transform.position) || this.NEStairs.bounds.Contains(this.transform.position) || this.NWStairs.bounds.Contains(this.transform.position) || this.SEStairs.bounds.Contains(this.transform.position) || this.SWStairs.bounds.Contains(this.transform.position))
				{
					this.CanSpawn = false;
				}
				else
				{
					this.CanSpawn = true;
				}
			}
			else
			{
				this.CanSpawn = true;
			}
			if (this.CanSpawn && this.transform.position.y < this.Height + 0.33333f)
			{
				if (this.NearbyBlood > 0 && this.LastBloodPool == null)
				{
					this.NearbyBlood--;
				}
				if (this.NearbyBlood < 1 && this.Timer <= (float)0)
				{
					this.Timer = 0.1f;
					if (this.PoolsSpawned < 10)
					{
						GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, new Vector3(this.transform.position.x, this.Height + 0.012f, this.transform.position.z), Quaternion.identity);
						gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
						gameObject.transform.parent = this.BloodParent;
						this.PoolsSpawned++;
					}
					else if (this.PoolsSpawned < 20)
					{
						GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, new Vector3(this.transform.position.x, this.Height + 0.012f, this.transform.position.z), Quaternion.identity);
						gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
						gameObject.transform.parent = this.BloodParent;
						this.PoolsSpawned++;
						((BloodPoolScript)gameObject.GetComponent(typeof(BloodPoolScript))).TargetSize = (float)1 - (float)(this.PoolsSpawned - 10) * 0.1f;
					}
				}
			}
		}
	}

	// Token: 0x0600020A RID: 522 RVA: 0x000267AC File Offset: 0x000249AC
	public virtual void SpawnBigPool()
	{
		this.GetHeight();
		for (int i = 0; i < 5; i++)
		{
			GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, new Vector3(this.Hips.position.x, this.Height + 0.012f, this.Hips.position.z) + this.Positions[i], Quaternion.identity);
			gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
			gameObject.transform.parent = this.BloodParent;
		}
	}

	// Token: 0x0600020B RID: 523 RVA: 0x00026868 File Offset: 0x00024A68
	public virtual void SpawnRow(Transform Location)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, Location.position + Location.forward * 2f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
		gameObject.transform.parent = this.BloodParent;
		gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, Location.position + Location.forward * 2.5f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
		gameObject.transform.parent = this.BloodParent;
		gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, Location.position + Location.forward * 3f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
		gameObject.transform.parent = this.BloodParent;
	}

	// Token: 0x0600020C RID: 524 RVA: 0x000269A0 File Offset: 0x00024BA0
	public virtual void SpawnPool(Transform Location)
	{
		GameObject gameObject = (GameObject)UnityEngine.Object.Instantiate(this.BloodPool, Location.position + Location.forward * 1f, Quaternion.identity);
		gameObject.transform.localEulerAngles = new Vector3((float)90, UnityEngine.Random.Range((float)0, 360f), (float)0);
		gameObject.transform.parent = this.BloodParent;
	}

	// Token: 0x0600020D RID: 525 RVA: 0x00026A10 File Offset: 0x00024C10
	public virtual void GetHeight()
	{
		if (this.transform.position.y < (float)4)
		{
			this.Height = (float)0;
		}
		else if (this.transform.position.y < (float)8)
		{
			this.Height = (float)4;
		}
		else if (this.transform.position.y < (float)12)
		{
			this.Height = (float)8;
		}
		else
		{
			this.Height = (float)12;
		}
	}

	// Token: 0x0600020E RID: 526 RVA: 0x00026A9C File Offset: 0x00024C9C
	public virtual void Main()
	{
	}

	// Token: 0x04000446 RID: 1094
	public GameObject LastBloodPool;

	// Token: 0x04000447 RID: 1095
	public GameObject BloodPool;

	// Token: 0x04000448 RID: 1096
	public Transform BloodParent;

	// Token: 0x04000449 RID: 1097
	public Transform Hips;

	// Token: 0x0400044A RID: 1098
	public Collider MyCollider;

	// Token: 0x0400044B RID: 1099
	public Collider GardenArea;

	// Token: 0x0400044C RID: 1100
	public Collider NEStairs;

	// Token: 0x0400044D RID: 1101
	public Collider NWStairs;

	// Token: 0x0400044E RID: 1102
	public Collider SEStairs;

	// Token: 0x0400044F RID: 1103
	public Collider SWStairs;

	// Token: 0x04000450 RID: 1104
	public Vector3[] Positions;

	// Token: 0x04000451 RID: 1105
	public bool CanSpawn;

	// Token: 0x04000452 RID: 1106
	public int PoolsSpawned;

	// Token: 0x04000453 RID: 1107
	public int NearbyBlood;

	// Token: 0x04000454 RID: 1108
	public float Height;

	// Token: 0x04000455 RID: 1109
	public float Timer;
}
