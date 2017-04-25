using System;
using UnityEngine;

// Token: 0x0200009B RID: 155
[Serializable]
public class GardeningClubMemberScript : MonoBehaviour
{
	// Token: 0x06000385 RID: 901 RVA: 0x00048330 File Offset: 0x00046530
	public GardeningClubMemberScript()
	{
		this.IdleAnim = string.Empty;
		this.WalkAnim = string.Empty;
		this.Phase = 1;
		this.ID = 1;
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00048368 File Offset: 0x00046568
	public virtual void Start()
	{
		this.animation["f02_angryFace_00"].layer = 2;
		this.animation.Play("f02_angryFace_00");
		this.animation["f02_angryFace_00"].weight = (float)0;
		if (!this.Leader && GameObject.Find("DetectionCamera") != null)
		{
			this.DetectionMarker = (DetectionMarkerScript)((GameObject)UnityEngine.Object.Instantiate(this.Marker, GameObject.Find("DetectionPanel").transform.position, Quaternion.identity)).GetComponent(typeof(DetectionMarkerScript));
			this.DetectionMarker.transform.parent = GameObject.Find("DetectionPanel").transform;
			this.DetectionMarker.Target = this.transform;
		}
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00048448 File Offset: 0x00046648
	public virtual void Update()
	{
		if (!this.Angry)
		{
			if (this.Phase == 1)
			{
				while (Vector3.Distance(this.transform.position, this.Destination.position) < (float)1)
				{
					if (this.ID == 1)
					{
						float x = UnityEngine.Random.Range(-60.75f, -73.25f);
						Vector3 position = this.Destination.position;
						float num = position.x = x;
						Vector3 vector = this.Destination.position = position;
						float z = UnityEngine.Random.Range(-14.25f, 14.25f);
						Vector3 position2 = this.Destination.position;
						float num2 = position2.z = z;
						Vector3 vector2 = this.Destination.position = position2;
					}
					else
					{
						float x2 = -25.5f + UnityEngine.Random.Range(-2.5f, 2.5f);
						Vector3 position3 = this.Destination.position;
						float num3 = position3.x = x2;
						Vector3 vector3 = this.Destination.position = position3;
						float z2 = (float)-11 + UnityEngine.Random.Range(-4f, 4f);
						Vector3 position4 = this.Destination.position;
						float num4 = position4.z = z2;
						Vector3 vector4 = this.Destination.position = position4;
					}
				}
				this.animation.CrossFade(this.WalkAnim);
				this.Pathfinding.enabled = true;
				if (this.Leader)
				{
					this.Prompt.Hide();
					this.Prompt.enabled = false;
					this.PickpocketPanel.enabled = false;
				}
				this.Phase++;
			}
			else if (this.Pathfinding.enabled)
			{
				if (Vector3.Distance(this.transform.position, this.Destination.position) < (float)1)
				{
					this.animation.CrossFade(this.IdleAnim);
					this.Pathfinding.enabled = false;
					if (this.Leader)
					{
						this.PickpocketPanel.enabled = true;
						this.Prompt.enabled = true;
					}
				}
			}
			else
			{
				this.Timer += Time.deltaTime;
				if (this.Leader)
				{
					this.TimeBar.fillAmount = (float)1 - this.Timer / this.animation[this.IdleAnim].length;
				}
				if (this.Timer > this.animation[this.IdleAnim].length)
				{
					if (this.Leader && this.Yandere.Pickpocketing && this.PickpocketMinigame.ID == this.ID)
					{
						this.PickpocketMinigame.End();
						this.Punish();
					}
					this.Timer = (float)0;
					this.Phase = 1;
				}
			}
			if (this.Leader)
			{
				if (this.Prompt.Circle[0].fillAmount == (float)0)
				{
					this.PickpocketMinigame.PickpocketSpot = this.PickpocketSpot;
					this.PickpocketMinigame.Show = true;
					this.PickpocketMinigame.ID = this.ID;
					this.Yandere.Character.animation.CrossFade("f02_pickpocketing_00");
					this.Yandere.Pickpocketing = true;
					this.Yandere.CanMove = false;
				}
				if (this.PickpocketMinigame.ID == this.ID)
				{
					if (this.PickpocketMinigame.Success)
					{
						this.PickpocketMinigame.Success = false;
						this.PickpocketMinigame.ID = 0;
						if (this.ID == 1)
						{
							this.ShedDoor.Prompt.Label[0].text = "     " + "Open";
							this.ShedDoor.Locked = false;
							this.Yandere.Inventory.ShedKey = true;
						}
						else
						{
							this.CabinetDoor.Prompt.Label[0].text = "     " + "Open";
							this.CabinetDoor.Locked = false;
							this.Yandere.Inventory.CabinetKey = true;
						}
						this.Prompt.gameObject.active = false;
						this.Key.active = false;
					}
					if (this.PickpocketMinigame.Failure)
					{
						this.PickpocketMinigame.Failure = false;
						this.PickpocketMinigame.ID = 0;
						this.Punish();
					}
				}
			}
			else
			{
				this.LookForYandere();
			}
		}
		else
		{
			Quaternion to = Quaternion.LookRotation(this.Yandere.transform.position - this.transform.position);
			this.transform.rotation = Quaternion.Slerp(this.transform.rotation, to, (float)10 * Time.deltaTime);
			this.Timer += Time.deltaTime;
			if (this.Timer > (float)10)
			{
				this.animation["f02_angryFace_00"].weight = (float)0;
				this.Angry = false;
				this.Timer = (float)0;
			}
			else if (this.Timer > (float)1 && this.Phase == 0)
			{
				this.Subtitle.UpdateLabel("Pickpocket Reaction", 0, (float)8);
				this.Phase++;
			}
		}
	}

	// Token: 0x06000388 RID: 904 RVA: 0x000489D4 File Offset: 0x00046BD4
	public virtual void Punish()
	{
		this.animation["f02_angryFace_00"].weight = (float)1;
		this.animation.CrossFade("idle_01");
		this.Reputation.PendingRep = this.Reputation.PendingRep - (float)10;
		this.CameraEffects.Alarm();
		this.Angry = true;
		this.Phase = 0;
		this.Timer = (float)0;
		this.Prompt.Hide();
		this.Prompt.enabled = false;
		this.PickpocketPanel.enabled = false;
	}

	// Token: 0x06000389 RID: 905 RVA: 0x00048A68 File Offset: 0x00046C68
	public virtual void LookForYandere()
	{
		float num = Vector3.Distance(this.transform.position, this.Yandere.transform.position);
		if (num < this.VisionCone.farClipPlane)
		{
			Plane[] planes = GeometryUtility.CalculateFrustumPlanes(this.VisionCone);
			if (GeometryUtility.TestPlanesAABB(planes, this.Yandere.collider.bounds))
			{
				RaycastHit raycastHit = default(RaycastHit);
				Debug.DrawLine(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), Color.green);
				if (Physics.Linecast(this.Eyes.transform.position, new Vector3(this.Yandere.transform.position.x, this.Yandere.Head.position.y, this.Yandere.transform.position.z), out raycastHit))
				{
					if (raycastHit.collider.gameObject == this.Yandere.gameObject)
					{
						if (this.Yandere.Pickpocketing)
						{
							if (!this.ClubLeader.Angry)
							{
								this.Alarm = Mathf.MoveTowards(this.Alarm, (float)100, Time.deltaTime * ((float)100 / num));
								if (this.Alarm == (float)100)
								{
									this.PickpocketMinigame.End();
									this.ClubLeader.Punish();
								}
							}
							else
							{
								this.Alarm = Mathf.MoveTowards(this.Alarm, (float)0, Time.deltaTime * (float)100);
							}
						}
						else
						{
							this.Alarm = Mathf.MoveTowards(this.Alarm, (float)0, Time.deltaTime * (float)100);
						}
					}
					else
					{
						this.Alarm = Mathf.MoveTowards(this.Alarm, (float)0, Time.deltaTime * (float)100);
					}
				}
				else
				{
					this.Alarm = Mathf.MoveTowards(this.Alarm, (float)0, Time.deltaTime * (float)100);
				}
			}
			else
			{
				this.Alarm = Mathf.MoveTowards(this.Alarm, (float)0, Time.deltaTime * (float)100);
			}
		}
		float y = this.Alarm / (float)100;
		Vector3 localScale = this.DetectionMarker.Tex.transform.localScale;
		float num2 = localScale.y = y;
		Vector3 vector = this.DetectionMarker.Tex.transform.localScale = localScale;
		if (this.Alarm > (float)0)
		{
			if (!this.DetectionMarker.Tex.enabled)
			{
				this.DetectionMarker.Tex.enabled = true;
			}
			float a = this.Alarm / (float)100;
			Color color = this.DetectionMarker.Tex.color;
			float num3 = color.a = a;
			Color color2 = this.DetectionMarker.Tex.color = color;
		}
		else if (this.DetectionMarker.Tex.color.a != (float)0)
		{
			this.DetectionMarker.Tex.enabled = false;
			int num4 = 0;
			Color color3 = this.DetectionMarker.Tex.color;
			float num5 = color3.a = (float)num4;
			Color color4 = this.DetectionMarker.Tex.color = color3;
		}
	}

	// Token: 0x0600038A RID: 906 RVA: 0x00048E1C File Offset: 0x0004701C
	public virtual void Main()
	{
	}

	// Token: 0x040008C9 RID: 2249
	public PickpocketMinigameScript PickpocketMinigame;

	// Token: 0x040008CA RID: 2250
	public DetectionMarkerScript DetectionMarker;

	// Token: 0x040008CB RID: 2251
	public CameraEffectsScript CameraEffects;

	// Token: 0x040008CC RID: 2252
	public CabinetDoorScript CabinetDoor;

	// Token: 0x040008CD RID: 2253
	public ReputationScript Reputation;

	// Token: 0x040008CE RID: 2254
	public SubtitleScript Subtitle;

	// Token: 0x040008CF RID: 2255
	public YandereScript Yandere;

	// Token: 0x040008D0 RID: 2256
	public PromptScript Prompt;

	// Token: 0x040008D1 RID: 2257
	public DoorScript ShedDoor;

	// Token: 0x040008D2 RID: 2258
	public AIPath Pathfinding;

	// Token: 0x040008D3 RID: 2259
	public UIPanel PickpocketPanel;

	// Token: 0x040008D4 RID: 2260
	public UISprite TimeBar;

	// Token: 0x040008D5 RID: 2261
	public Transform PickpocketSpot;

	// Token: 0x040008D6 RID: 2262
	public Transform Destination;

	// Token: 0x040008D7 RID: 2263
	public GameObject Marker;

	// Token: 0x040008D8 RID: 2264
	public GameObject Key;

	// Token: 0x040008D9 RID: 2265
	public bool Leader;

	// Token: 0x040008DA RID: 2266
	public bool Angry;

	// Token: 0x040008DB RID: 2267
	public string IdleAnim;

	// Token: 0x040008DC RID: 2268
	public string WalkAnim;

	// Token: 0x040008DD RID: 2269
	public float Timer;

	// Token: 0x040008DE RID: 2270
	public int Phase;

	// Token: 0x040008DF RID: 2271
	public int ID;

	// Token: 0x040008E0 RID: 2272
	public GardeningClubMemberScript ClubLeader;

	// Token: 0x040008E1 RID: 2273
	public Camera VisionCone;

	// Token: 0x040008E2 RID: 2274
	public Transform Eyes;

	// Token: 0x040008E3 RID: 2275
	public float Alarm;
}
