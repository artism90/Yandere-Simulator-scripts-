using System;
using UnityEngine;

// Token: 0x0200005D RID: 93
[Serializable]
public class ChangingBoothScript : MonoBehaviour
{
	// Token: 0x06000253 RID: 595 RVA: 0x0002A860 File Offset: 0x00028A60
	public virtual void Start()
	{
		this.CheckYandereClub();
	}

	// Token: 0x06000254 RID: 596 RVA: 0x0002A868 File Offset: 0x00028A68
	public virtual void Update()
	{
		if (!this.Occupied && this.Prompt.Circle[0].fillAmount <= (float)0)
		{
			this.Yandere.EmptyHands();
			this.Yandere.CanMove = false;
			this.YandereChanging = true;
			this.Occupied = true;
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
		if (this.Occupied)
		{
			if (this.OccupyTimer == (float)0)
			{
				if (this.Yandere.transform.position.y > this.transform.position.y - (float)1 && this.Yandere.transform.position.y < this.transform.position.y + (float)1)
				{
					this.audio.clip = this.CurtainSound;
					this.audio.Play();
				}
			}
			else if (this.OccupyTimer > (float)1 && this.Phase == 0)
			{
				if (this.Yandere.transform.position.y > this.transform.position.y - (float)1 && this.Yandere.transform.position.y < this.transform.position.y + (float)1)
				{
					this.audio.clip = this.ClothSound;
					this.audio.Play();
				}
				this.Phase++;
			}
			this.OccupyTimer += Time.deltaTime;
			if (this.YandereChanging)
			{
				if (this.OccupyTimer < (float)2)
				{
					this.Weight = Mathf.Lerp(this.Weight, (float)0, Time.deltaTime * (float)10);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					this.Yandere.MoveTowardsTarget(this.transform.position);
				}
				else if (this.OccupyTimer < (float)3)
				{
					this.Weight = Mathf.Lerp(this.Weight, (float)100, Time.deltaTime * (float)10);
					this.Curtains.SetBlendShapeWeight(0, this.Weight);
					if (this.Phase < 2)
					{
						this.audio.clip = this.CurtainSound;
						this.audio.Play();
						this.Yandere.ChangeClubwear();
						this.Phase++;
					}
					this.Yandere.transform.rotation = Quaternion.Slerp(this.Yandere.transform.rotation, this.transform.rotation, (float)10 * Time.deltaTime);
					this.Yandere.MoveTowardsTarget(this.ExitSpot.position);
				}
				else
				{
					this.YandereChanging = false;
					this.Yandere.CanMove = true;
					this.Prompt.enabled = true;
					this.Occupied = false;
					this.OccupyTimer = (float)0;
					this.Phase = 0;
				}
			}
			else if (this.OccupyTimer < (float)2)
			{
				this.Weight = Mathf.Lerp(this.Weight, (float)0, Time.deltaTime * (float)10);
				this.Curtains.SetBlendShapeWeight(0, this.Weight);
			}
			else if (this.OccupyTimer < (float)3)
			{
				this.Weight = Mathf.Lerp(this.Weight, (float)100, Time.deltaTime * (float)10);
				this.Curtains.SetBlendShapeWeight(0, this.Weight);
				if (this.Phase < 2)
				{
					if (this.Yandere.transform.position.y > this.transform.position.y - (float)1 && this.Yandere.transform.position.y < this.transform.position.y + (float)1)
					{
						this.audio.clip = this.CurtainSound;
						this.audio.Play();
					}
					this.Student.ChangeClubwear();
					this.Phase++;
				}
			}
			else
			{
				this.Occupied = false;
				this.OccupyTimer = (float)0;
				this.Student = null;
				this.Phase = 0;
				this.CheckYandereClub();
			}
		}
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0002ACF0 File Offset: 0x00028EF0
	public virtual void CheckYandereClub()
	{
		if (this.Yandere.Bloodiness == (float)0 && !this.CannotChange && this.Yandere.Schoolwear > 0)
		{
			if (!this.Occupied)
			{
				if (PlayerPrefs.GetInt("Club") != this.ClubID)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
				}
				else
				{
					this.Prompt.enabled = true;
				}
			}
			else
			{
				this.Prompt.Hide();
				this.Prompt.enabled = false;
			}
		}
		else
		{
			this.Prompt.Hide();
			this.Prompt.enabled = false;
		}
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0002ADAC File Offset: 0x00028FAC
	public virtual void Main()
	{
	}

	// Token: 0x040004F9 RID: 1273
	public YandereScript Yandere;

	// Token: 0x040004FA RID: 1274
	public StudentScript Student;

	// Token: 0x040004FB RID: 1275
	public PromptScript Prompt;

	// Token: 0x040004FC RID: 1276
	public SkinnedMeshRenderer Curtains;

	// Token: 0x040004FD RID: 1277
	public Transform ExitSpot;

	// Token: 0x040004FE RID: 1278
	public Transform[] WaitSpots;

	// Token: 0x040004FF RID: 1279
	public bool YandereChanging;

	// Token: 0x04000500 RID: 1280
	public bool CannotChange;

	// Token: 0x04000501 RID: 1281
	public bool Occupied;

	// Token: 0x04000502 RID: 1282
	public AudioClip CurtainSound;

	// Token: 0x04000503 RID: 1283
	public AudioClip ClothSound;

	// Token: 0x04000504 RID: 1284
	public float OccupyTimer;

	// Token: 0x04000505 RID: 1285
	public float Weight;

	// Token: 0x04000506 RID: 1286
	public int ClubID;

	// Token: 0x04000507 RID: 1287
	public int Phase;
}
