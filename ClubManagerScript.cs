using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x02000066 RID: 102
[Serializable]
public class ClubManagerScript : MonoBehaviour
{
	// Token: 0x0600027D RID: 637 RVA: 0x0002D6FC File Offset: 0x0002B8FC
	public ClubManagerScript()
	{
		this.Phase = 1;
	}

	// Token: 0x0600027E RID: 638 RVA: 0x0002D70C File Offset: 0x0002B90C
	public virtual void Start()
	{
		this.ClubWindow.ActivityWindow.localScale = new Vector3((float)0, (float)0, (float)0);
		this.ClubWindow.ActivityWindow.gameObject.active = false;
		this.ActivateClubBenefit();
	}

	// Token: 0x0600027F RID: 639 RVA: 0x0002D748 File Offset: 0x0002B948
	public virtual void Update()
	{
		if (this.Club != 0)
		{
			if (this.Phase == 1)
			{
				float a = Mathf.MoveTowards(this.Darkness.color.a, (float)0, Time.deltaTime);
				Color color = this.Darkness.color;
				float num = color.a = a;
				Color color2 = this.Darkness.color = color;
			}
			if (this.Darkness.color.a == (float)0)
			{
				if (this.Phase == 1)
				{
					this.PromptBar.ClearButtons();
					this.PromptBar.Label[0].text = "Continue";
					this.PromptBar.UpdateButtons();
					this.PromptBar.Show = true;
					this.ClubWindow.PerformingActivity = true;
					this.ClubWindow.ActivityWindow.gameObject.active = true;
					this.ClubWindow.ActivityLabel.text = this.ClubWindow.ActivityDescs[this.Club];
					this.Phase++;
				}
				else if (this.Phase == 2)
				{
					if (this.ClubWindow.ActivityWindow.localScale.x > 0.9f)
					{
						if (this.Club == 6)
						{
							if (this.ClubPhase == 0)
							{
								this.audio.clip = this.MotivationalQuotes[UnityEngine.Random.Range(0, Extensions.get_length(this.MotivationalQuotes))];
								this.audio.Play();
								this.ClubEffect = true;
								this.ClubPhase++;
								this.TimeLimit = this.audio.clip.length;
							}
							else if (this.ClubPhase == 1)
							{
								this.Timer += Time.deltaTime;
								if (this.Timer > this.TimeLimit)
								{
									this.ID = 0;
									while (this.ID < Extensions.get_length(this.Club6Students))
									{
										if (this.StudentManager.Students[this.ID] != null && !this.StudentManager.Students[this.ID].Tranquil)
										{
											this.StudentManager.Students[this.Club6Students[this.ID]].audio.volume = (float)1;
										}
										this.ID++;
									}
									this.ClubPhase++;
								}
							}
						}
						if (Input.GetButtonDown("A"))
						{
							this.ClubWindow.PerformingActivity = false;
							this.PromptBar.Show = false;
							this.Phase++;
						}
					}
				}
				else if (this.ClubWindow.ActivityWindow.localScale.x < 0.1f)
				{
					this.Police.Darkness.enabled = true;
					this.Police.ClubActivity = false;
					this.Police.FadeOut = true;
				}
			}
			if (this.Club == 3)
			{
				this.audio.volume = (float)1 - this.Darkness.color.a;
			}
		}
	}

	// Token: 0x06000280 RID: 640 RVA: 0x0002DA98 File Offset: 0x0002BC98
	public virtual void ClubActivity()
	{
		this.StudentManager.StopMoving();
		this.ShoulderCamera.enabled = false;
		this.MainCamera.enabled = false;
		this.MainCamera.transform.position = this.ClubVantages[this.Club].position;
		this.MainCamera.transform.rotation = this.ClubVantages[this.Club].rotation;
		if (this.Club == 3)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Club3Students))
			{
				if (this.StudentManager.Students[this.Club3Students[this.ID]] != null && !this.StudentManager.Students[this.Club3Students[this.ID]].Tranquil)
				{
					this.StudentManager.Students[this.Club3Students[this.ID]].active = false;
				}
				this.ID++;
			}
			((AudioListener)this.MainCamera.GetComponent(typeof(AudioListener))).enabled = true;
			this.audio.clip = this.OccultAmbience;
			this.audio.loop = true;
			this.audio.volume = (float)0;
			this.audio.Play();
			this.Yandere.active = false;
			this.Ritual.active = true;
		}
		else if (this.Club == 6)
		{
			this.ID = 0;
			while (this.ID < Extensions.get_length(this.Club6Students))
			{
				if (this.StudentManager.Students[this.Club6Students[this.ID]] != null && !this.StudentManager.Students[this.Club6Students[this.ID]].Tranquil)
				{
					this.StudentManager.Students[this.Club6Students[this.ID]].transform.position = this.Club6ActivitySpots[this.ID].position;
					this.StudentManager.Students[this.Club6Students[this.ID]].transform.rotation = this.Club6ActivitySpots[this.ID].rotation;
					this.StudentManager.Students[this.Club6Students[this.ID]].ClubActivity = true;
					this.StudentManager.Students[this.Club6Students[this.ID]].audio.volume = 0.1f;
					if (!this.StudentManager.Students[this.Club6Students[this.ID]].ClubAttire)
					{
						this.StudentManager.Students[this.Club6Students[this.ID]].ChangeClubwear();
					}
				}
				this.ID++;
			}
			this.Yandere.CanMove = false;
			this.Yandere.ClubActivity = true;
			this.Yandere.transform.position = this.Club6ActivitySpots[5].position;
			this.Yandere.transform.rotation = this.Club6ActivitySpots[5].rotation;
			if (!this.Yandere.ClubAttire)
			{
				this.Yandere.ChangeClubwear();
			}
		}
		this.Clock.active = false;
		this.Reputation.active = false;
		this.Heartrate.active = false;
		this.Watermark.active = false;
	}

	// Token: 0x06000281 RID: 641 RVA: 0x0002DE34 File Offset: 0x0002C034
	public virtual void CheckClub(int Check)
	{
		if (Check == 3)
		{
			this.ClubIDs = this.Club3IDs;
		}
		else if (Check == 6)
		{
			this.ClubIDs = this.Club6IDs;
		}
		this.LeaderMissing = false;
		this.LeaderDead = false;
		this.ClubMembers = 0;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.ClubIDs))
		{
			if (PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Dead") == 0 && PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Dying") == 0 && PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Kidnapped") == 0 && PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Arrested") == 0 && PlayerPrefs.GetInt("Student_" + this.ClubIDs[this.ID] + "_Reputation") > -100)
			{
				this.ClubMembers++;
			}
			this.ID++;
		}
		if (PlayerPrefs.GetInt("Club") == Check)
		{
			this.ClubMembers++;
		}
		if (Check == 3)
		{
			if (PlayerPrefs.GetInt("Student_" + 26 + "_Dead") == 1 || PlayerPrefs.GetInt("Student_" + 26 + "_Dying") == 1 || PlayerPrefs.GetInt("Student_" + 26 + "_Arrested") == 1 || PlayerPrefs.GetInt("Student_" + 26 + "_Reputation") <= -100)
			{
				this.LeaderDead = true;
			}
			if (PlayerPrefs.GetInt("Student_" + 26 + "_Missing") == 1 || PlayerPrefs.GetInt("Student_" + 26 + "_Kidnapped") == 1 || this.TranqCase.VictimID == 26)
			{
				this.LeaderMissing = true;
			}
		}
		else if (Check == 6)
		{
			if (PlayerPrefs.GetInt("Student_" + 21 + "_Dead") == 1 || PlayerPrefs.GetInt("Student_" + 21 + "_Dying") == 1 || PlayerPrefs.GetInt("Student_" + 21 + "_Arrested") == 1 || PlayerPrefs.GetInt("Student_" + 21 + "_Reputation") <= -100)
			{
				this.LeaderDead = true;
			}
			if (PlayerPrefs.GetInt("Student_" + 21 + "_Missing") == 1 || PlayerPrefs.GetInt("Student_" + 21 + "_Kidnapped") == 1 || this.TranqCase.VictimID == 21)
			{
				this.LeaderMissing = true;
			}
		}
	}

	// Token: 0x06000282 RID: 642 RVA: 0x0002E1EC File Offset: 0x0002C3EC
	public virtual void CheckGrudge(int Check)
	{
		if (Check == 3)
		{
			this.ClubIDs = this.Club3IDs;
		}
		else if (Check == 6)
		{
			this.ClubIDs = this.Club6IDs;
		}
		this.LeaderGrudge = false;
		this.ClubGrudge = false;
		this.ID = 1;
		while (this.ID < Extensions.get_length(this.ClubIDs))
		{
			if (this.StudentManager.Students[this.ClubIDs[this.ID]] != null && this.StudentManager.Students[this.ClubIDs[this.ID]].Grudge)
			{
				this.ClubGrudge = true;
			}
			this.ID++;
		}
		if (Check == 3)
		{
			if (this.StudentManager.Students[26].Grudge)
			{
				this.LeaderGrudge = true;
			}
		}
		else if (Check == 6 && this.StudentManager.Students[21].Grudge)
		{
			this.LeaderGrudge = true;
		}
	}

	// Token: 0x06000283 RID: 643 RVA: 0x0002E304 File Offset: 0x0002C504
	public virtual void ActivateClubBenefit()
	{
		if (PlayerPrefs.GetInt("Club") == 1)
		{
			this.Refrigerator.enabled = true;
			this.Refrigerator.Prompt.enabled = true;
		}
		else if (PlayerPrefs.GetInt("Club") == 2)
		{
			this.ID = 1;
			while (this.ID < Extensions.get_length(this.Masks))
			{
				this.Masks[this.ID].enabled = true;
				this.Masks[this.ID].Prompt.enabled = true;
				this.ID++;
			}
			this.Gloves.enabled = true;
			this.Gloves.Prompt.enabled = true;
		}
		else if (PlayerPrefs.GetInt("Club") == 3)
		{
			this.StudentManager.UpdatePerception();
			this.Yandere.Numbness = this.Yandere.Numbness - 0.5f;
		}
		else if (PlayerPrefs.GetInt("Club") == 4)
		{
			this.StudentManager.UpdateBooths();
		}
		else if (PlayerPrefs.GetInt("Club") == 5)
		{
			this.Container.enabled = true;
			this.Container.Prompt.enabled = true;
		}
		else if (PlayerPrefs.GetInt("Club") == 6)
		{
			this.StudentManager.UpdateBooths();
		}
		else if (PlayerPrefs.GetInt("Club") != 7)
		{
			if (PlayerPrefs.GetInt("Club") == 8)
			{
				this.BloodCleaner.Prompt.enabled = true;
			}
			else if (PlayerPrefs.GetInt("Club") == 9)
			{
				this.Yandere.RunSpeed = this.Yandere.RunSpeed + (float)1;
				if (this.Yandere.Armed)
				{
					this.Yandere.Weapon[this.Yandere.Equipped].SuspicionCheck();
				}
			}
			else if (PlayerPrefs.GetInt("Club") == 10)
			{
				this.ShedDoor.Prompt.Label[0].text = "     " + "Open";
				this.ShedDoor.Locked = false;
				if (this.Yandere.Armed)
				{
					this.Yandere.Weapon[this.Yandere.Equipped].SuspicionCheck();
				}
			}
			else if (PlayerPrefs.GetInt("Club") == 11)
			{
				this.ComputerGames.EnableGames();
			}
		}
	}

	// Token: 0x06000284 RID: 644 RVA: 0x0002E5A8 File Offset: 0x0002C7A8
	public virtual void DeactivateClubBenefit()
	{
		if (PlayerPrefs.GetInt("Club") == 1)
		{
			this.Refrigerator.enabled = false;
			this.Refrigerator.Prompt.Hide();
			this.Refrigerator.Prompt.enabled = false;
		}
		else if (PlayerPrefs.GetInt("Club") == 2)
		{
			this.ID = 1;
			while (this.ID < Extensions.get_length(this.Masks))
			{
				this.Masks[this.ID].enabled = false;
				this.Masks[this.ID].Prompt.Hide();
				this.Masks[this.ID].Prompt.enabled = false;
				this.ID++;
			}
			this.Gloves.enabled = false;
			this.Gloves.Prompt.Hide();
			this.Gloves.Prompt.enabled = false;
		}
		else if (PlayerPrefs.GetInt("Club") == 3)
		{
			PlayerPrefs.SetInt("Club", 0);
			this.StudentManager.UpdatePerception();
			this.Yandere.Numbness = this.Yandere.Numbness + 0.5f;
		}
		else if (PlayerPrefs.GetInt("Club") == 4)
		{
			this.StudentManager.UpdateBooths();
		}
		else if (PlayerPrefs.GetInt("Club") == 5)
		{
			this.Container.enabled = false;
			this.Container.Prompt.Hide();
			this.Container.Prompt.enabled = false;
		}
		else if (PlayerPrefs.GetInt("Club") == 6)
		{
			this.StudentManager.UpdateBooths();
		}
		else if (PlayerPrefs.GetInt("Club") != 7)
		{
			if (PlayerPrefs.GetInt("Club") == 8)
			{
				this.BloodCleaner.enabled = false;
				this.BloodCleaner.Prompt.Hide();
				this.BloodCleaner.Prompt.enabled = false;
			}
			else if (PlayerPrefs.GetInt("Club") == 9)
			{
				this.Yandere.RunSpeed = this.Yandere.RunSpeed - (float)1;
				if (this.Yandere.Armed)
				{
					PlayerPrefs.SetInt("Club", 0);
					this.Yandere.Weapon[this.Yandere.Equipped].SuspicionCheck();
				}
			}
			else if (PlayerPrefs.GetInt("Club") == 10)
			{
				if (!this.Yandere.Inventory.ShedKey)
				{
					this.ShedDoor.Prompt.Label[0].text = "     " + "Locked";
					this.ShedDoor.Locked = true;
				}
				if (this.Yandere.Armed)
				{
					PlayerPrefs.SetInt("Club", 0);
					this.Yandere.Weapon[this.Yandere.Equipped].SuspicionCheck();
				}
			}
			else if (PlayerPrefs.GetInt("Club") == 11)
			{
				this.ComputerGames.DeactivateAllBenefits();
				this.ComputerGames.DisableGames();
			}
		}
	}

	// Token: 0x06000285 RID: 645 RVA: 0x0002E8F0 File Offset: 0x0002CAF0
	public virtual void UpdateMasks()
	{
		if (this.Yandere.Mask != null)
		{
			this.ID = 1;
			while (this.ID < Extensions.get_length(this.Masks))
			{
				this.Masks[this.ID].Prompt.HideButton[0] = true;
				this.ID++;
			}
		}
		else
		{
			this.ID = 1;
			while (this.ID < Extensions.get_length(this.Masks))
			{
				this.Masks[this.ID].Prompt.HideButton[0] = false;
				this.ID++;
			}
		}
	}

	// Token: 0x06000286 RID: 646 RVA: 0x0002E9C0 File Offset: 0x0002CBC0
	public virtual void Main()
	{
	}

	// Token: 0x0400056A RID: 1386
	public ShoulderCameraScript ShoulderCamera;

	// Token: 0x0400056B RID: 1387
	public StudentManagerScript StudentManager;

	// Token: 0x0400056C RID: 1388
	public ComputerGamesScript ComputerGames;

	// Token: 0x0400056D RID: 1389
	public BloodCleanerScript BloodCleaner;

	// Token: 0x0400056E RID: 1390
	public RefrigeratorScript Refrigerator;

	// Token: 0x0400056F RID: 1391
	public ClubWindowScript ClubWindow;

	// Token: 0x04000570 RID: 1392
	public ContainerScript Container;

	// Token: 0x04000571 RID: 1393
	public PromptBarScript PromptBar;

	// Token: 0x04000572 RID: 1394
	public TranqCaseScript TranqCase;

	// Token: 0x04000573 RID: 1395
	public YandereScript Yandere;

	// Token: 0x04000574 RID: 1396
	public RPG_Camera MainCamera;

	// Token: 0x04000575 RID: 1397
	public DoorScript ShedDoor;

	// Token: 0x04000576 RID: 1398
	public PoliceScript Police;

	// Token: 0x04000577 RID: 1399
	public GloveScript Gloves;

	// Token: 0x04000578 RID: 1400
	public UISprite Darkness;

	// Token: 0x04000579 RID: 1401
	public GameObject Reputation;

	// Token: 0x0400057A RID: 1402
	public GameObject Heartrate;

	// Token: 0x0400057B RID: 1403
	public GameObject Watermark;

	// Token: 0x0400057C RID: 1404
	public GameObject Ritual;

	// Token: 0x0400057D RID: 1405
	public GameObject Clock;

	// Token: 0x0400057E RID: 1406
	public AudioClip[] MotivationalQuotes;

	// Token: 0x0400057F RID: 1407
	public Transform[] ClubVantages;

	// Token: 0x04000580 RID: 1408
	public MaskScript[] Masks;

	// Token: 0x04000581 RID: 1409
	public Transform[] Club6ActivitySpots;

	// Token: 0x04000582 RID: 1410
	public int[] Club3Students;

	// Token: 0x04000583 RID: 1411
	public int[] Club6Students;

	// Token: 0x04000584 RID: 1412
	public bool ClubEffect;

	// Token: 0x04000585 RID: 1413
	public AudioClip OccultAmbience;

	// Token: 0x04000586 RID: 1414
	public int ClubPhase;

	// Token: 0x04000587 RID: 1415
	public int Phase;

	// Token: 0x04000588 RID: 1416
	public int Club;

	// Token: 0x04000589 RID: 1417
	public int ID;

	// Token: 0x0400058A RID: 1418
	public float TimeLimit;

	// Token: 0x0400058B RID: 1419
	public float Timer;

	// Token: 0x0400058C RID: 1420
	public bool LeaderMissing;

	// Token: 0x0400058D RID: 1421
	public bool LeaderDead;

	// Token: 0x0400058E RID: 1422
	public int ClubMembers;

	// Token: 0x0400058F RID: 1423
	public int[] Club3IDs;

	// Token: 0x04000590 RID: 1424
	public int[] Club6IDs;

	// Token: 0x04000591 RID: 1425
	public int[] ClubIDs;

	// Token: 0x04000592 RID: 1426
	public bool LeaderGrudge;

	// Token: 0x04000593 RID: 1427
	public bool ClubGrudge;
}
