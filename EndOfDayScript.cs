using System;
using UnityEngine;
using UnityScript.Lang;

// Token: 0x0200008B RID: 139
[Serializable]
public class EndOfDayScript : MonoBehaviour
{
	// Token: 0x06000343 RID: 835 RVA: 0x00043D18 File Offset: 0x00041F18
	public EndOfDayScript()
	{
		this.VictimString = string.Empty;
		this.Phase = 1;
	}

	// Token: 0x06000344 RID: 836 RVA: 0x00043D34 File Offset: 0x00041F34
	public virtual void Start()
	{
		int num = 1;
		Color color = this.EndOfDayDarkness.color;
		float num2 = color.a = (float)num;
		Color color2 = this.EndOfDayDarkness.color = color;
		this.PreviouslyActivated = true;
		this.audio.volume = (float)0;
		this.UpdateScene();
	}

	// Token: 0x06000345 RID: 837 RVA: 0x00043D8C File Offset: 0x00041F8C
	public virtual void Update()
	{
		if (this.EndOfDayDarkness.color.a == (float)0 && Input.GetButtonDown("A"))
		{
			this.Darken = true;
		}
		if (this.Darken)
		{
			float a = Mathf.MoveTowards(this.EndOfDayDarkness.color.a, (float)1, Time.deltaTime);
			Color color = this.EndOfDayDarkness.color;
			float num = color.a = a;
			Color color2 = this.EndOfDayDarkness.color = color;
			if (this.EndOfDayDarkness.color.a == (float)1)
			{
				if (!this.GameOver)
				{
					this.Darken = false;
					this.UpdateScene();
				}
				else
				{
					this.Heartbroken.transform.parent.transform.parent = null;
					this.Heartbroken.transform.parent.active = true;
					this.Heartbroken.Noticed = false;
					this.Heartbroken.Arrested = true;
					this.MainCamera.active = false;
					this.active = false;
					Time.timeScale = (float)1;
				}
			}
		}
		else
		{
			float a2 = Mathf.MoveTowards(this.EndOfDayDarkness.color.a, (float)0, Time.deltaTime);
			Color color3 = this.EndOfDayDarkness.color;
			float num2 = color3.a = a2;
			Color color4 = this.EndOfDayDarkness.color = color3;
		}
		this.audio.volume = Mathf.MoveTowards(this.audio.volume, (float)1, Time.deltaTime);
	}

	// Token: 0x06000346 RID: 838 RVA: 0x00043F3C File Offset: 0x0004213C
	public virtual void UpdateScene()
	{
		if (this.PoliceArrived)
		{
			if (Input.GetKeyDown("backspace"))
			{
				this.Police.KillStudents();
				Application.LoadLevel("HomeScene");
			}
			if (this.Phase == 1)
			{
				if (this.Police.PoisonScene)
				{
					this.Label.text = "The police and the paramedics arrive at school.";
					this.Phase = 103;
				}
				else if (this.Police.DrownScene)
				{
					this.Label.text = "The police arrive at school.";
					this.Phase = 104;
				}
				else if (this.Police.ElectroScene)
				{
					this.Label.text = "The police arrive at school.";
					this.Phase = 105;
				}
				else if (this.Police.MurderSuicideScene)
				{
					this.Label.text = "The police arrive at school, and discover what appears to be the scene of murder-suicide.";
					this.Phase++;
				}
				else
				{
					this.Label.text = "The police arrive at school.";
					if (this.Police.SuicideScene)
					{
						this.Phase = 102;
					}
					else
					{
						this.Phase++;
					}
				}
			}
			else if (this.Phase == 2)
			{
				if (this.Police.Corpses == 0)
				{
					if (!this.Police.PoisonScene && !this.Police.SuicideScene)
					{
						this.Label.text = "The police are unable to locate any corpses on school grounds.";
						this.Phase++;
					}
					else
					{
						this.Label.text = "The police are unable to locate any other corpses on school grounds.";
						this.Phase++;
					}
				}
				else
				{
					this.ID = 0;
					while (this.ID < Extensions.get_length(this.Police.CorpseList))
					{
						if (this.Police.CorpseList[this.ID] != null)
						{
							this.VictimArray[this.Corpses] = this.Police.CorpseList[this.ID].Student.StudentID;
							if (this.Corpses > 0)
							{
								this.VictimString += ", and ";
							}
							this.VictimString += this.Police.CorpseList[this.ID].Student.Name;
							this.Corpses++;
						}
						this.ID++;
					}
					if (this.Corpses == 1)
					{
						this.Label.text = "The police discover the corpse of " + this.VictimString + ".";
					}
					else
					{
						this.Label.text = "The police discover the corpses of " + this.VictimString + ".";
					}
					this.Phase++;
				}
			}
			else if (this.Phase == 3)
			{
				this.WeaponManager.CheckWeapons();
				if (this.WeaponManager.MurderWeapons == 0)
				{
					if (this.Weapons == 0)
					{
						this.Label.text = "The police are unable to locate any murder weapons.";
						this.Phase += 2;
					}
					else
					{
						this.Phase += 2;
						this.UpdateScene();
					}
				}
				else
				{
					this.ID = 0;
					this.MurderWeapon = null;
					while (this.ID < Extensions.get_length(this.WeaponManager.Weapons))
					{
						if (this.MurderWeapon == null && this.WeaponManager.Weapons[this.ID] != null && this.WeaponManager.Weapons[this.ID].Blood.enabled)
						{
							this.WeaponManager.Weapons[this.ID].Blood.enabled = false;
							this.MurderWeapon = this.WeaponManager.Weapons[this.ID];
							this.WeaponID = this.ID;
						}
						this.ID++;
					}
					this.ID = 0;
					this.Victims = 0;
					this.VictimString = string.Empty;
					while (this.ID < Extensions.get_length(this.MurderWeapon.Victims))
					{
						if (this.MurderWeapon.Victims[this.ID])
						{
							if (this.Victims > 0)
							{
								this.VictimString += ", and ";
							}
							this.VictimString += this.JSON.StudentNames[this.ID];
							this.Victims++;
						}
						this.ID++;
					}
					this.Label.text = "The police discover a " + this.MurderWeapon.Name + " that is stained with the blood of " + this.VictimString + ".";
					this.Weapons++;
					this.Phase++;
				}
			}
			else if (this.Phase == 4)
			{
				if (this.MurderWeapon.FingerprintID == 0)
				{
					this.Label.text = "The police find no fingerprints on the weapon.";
					this.Phase = 3;
				}
				else if (this.MurderWeapon.FingerprintID == 100)
				{
					this.Label.text = "The police find Yandere-chan's fingerprints on the weapon.";
					this.Phase = 100;
				}
				else
				{
					this.Label.text = "The police find the fingerprints of " + this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + " on the weapon.";
					this.Phase = 101;
				}
			}
			else if (this.Phase == 5)
			{
				if (this.Yandere.Sanity > 33.33333f)
				{
					if (this.Yandere.Bloodiness > (float)0 || (this.Yandere.Gloved && this.Yandere.Gloves.Blood.enabled))
					{
						if (this.Arrests == 0)
						{
							this.Label.text = "The police notice that Yandere-chan's clothing is bloody. They confirm that the blood is not hers. Yandere-chan is unable to convince the police that she did not commit murder.";
							this.Phase = 100;
						}
						else
						{
							this.Label.text = "The police notice that Yandere-chan's clothing is bloody. They confirm that the blood is not hers. Yandere-chan is able to convince the police that she was splashed with blood while witnessing a murder.";
							if (!this.TranqCase.Occupied)
							{
								this.Phase = 7;
							}
							else
							{
								this.Phase++;
							}
						}
					}
					else if (this.Police.BloodyClothing > 0)
					{
						this.Label.text = "The police find bloody clothing that has traces of Yandere-chan's DNA. Yandere-chan is unable to convince the police that she did not commit murder.";
						this.Phase = 100;
					}
					else
					{
						this.Label.text = "The police question Yandere-chan, but cannot link her to any crimes.";
						if (!this.TranqCase.Occupied)
						{
							this.Phase = 7;
						}
						else if (this.TranqCase.VictimID == this.ArrestID)
						{
							this.Phase = 7;
						}
						else
						{
							this.Phase++;
						}
					}
				}
				else if (this.Yandere.Bloodiness == (float)0)
				{
					this.Label.text = "The police question Yandere-chan, who exhibits extremely unusual behavior. The police decide to investigate Yandere-chan further, and eventually learn of her crimes.";
					this.Phase = 100;
				}
				else
				{
					this.Label.text = "The police notice that Yandere-chan is covered in blood and exhibiting extremely unusual behavior. The police decide to investigate Yandere-chan further, and eventually learn of her crimes.";
					this.Phase = 100;
				}
			}
			else if (this.Phase == 6)
			{
				this.Label.text = "The police discover " + this.JSON.StudentNames[this.TranqCase.VictimID] + " inside of a musical instrument case. However, she is unable to recall how she got inside of the case. The police are unable to determine what happened.";
				this.TranqCase.Occupied = false;
				this.Phase++;
			}
			else if (this.Phase == 7)
			{
				if (this.Police.MaskReported)
				{
					PlayerPrefs.SetInt("MasksBanned", 1);
					this.Label.text = "Witnesses state that the killer was wearing a mask. As a result, the police are unable to identify the murderer. To prevent this from ever happening again, the Headmaster decides to ban all masks from the school from this day forward.";
					this.Police.MaskReported = false;
					this.Phase++;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 8)
			{
				if (this.Arrests == 0)
				{
					if (this.DeadPerps == 0)
					{
						this.Label.text = "The police do not have enough evidence to perform an arrest. The police investigation ends, and students are free to leave.";
						this.Phase++;
					}
					else
					{
						this.Label.text = "The police conclude that a murder-suicide took place, but are unable to take any further action. The police investigation ends, and students are free to leave.";
						this.Phase++;
					}
				}
				else
				{
					this.Label.text = "The police believe that they have arrested the perpetrator of the crime. The police investigation ends, and students are free to leave.";
					this.Phase++;
				}
			}
			else if (this.Phase == 9)
			{
				this.Label.text = "Yandere-chan stalks Senpai until he has returned home safely, and then returns to her own home.";
				this.Phase++;
			}
			else if (this.Phase == 10)
			{
				if (PlayerPrefs.GetInt("Student_7_Dying") == 0 && PlayerPrefs.GetInt("Student_7_Dead") == 0 && PlayerPrefs.GetInt("Student_7_Arrested") == 0)
				{
					if (this.Counselor.LectureID > 0)
					{
						this.Counselor.Lecturing = true;
						this.enabled = false;
					}
					else
					{
						this.Phase++;
						this.UpdateScene();
					}
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 11)
			{
				Debug.Log("Phase 11.");
				if (PlayerPrefs.GetInt("Scheme_2_Stage") == 3)
				{
					if (PlayerPrefs.GetInt("Student_7_Dying") == 0 && PlayerPrefs.GetInt("Student_7_Dead") == 0 && PlayerPrefs.GetInt("Student_7_Arrested") == 0)
					{
						this.Label.text = "Kokona discovers Sakyu's ring inside of her book bag. She returns the ring to Sakyu, who decides to never let it out of her sight again.";
						PlayerPrefs.SetInt("Scheme_2_Stage", 100);
					}
				}
				else if (PlayerPrefs.GetInt("Scheme_5_Stage") > 1 && PlayerPrefs.GetInt("Scheme_5_Stage") < 5)
				{
					this.Label.text = "A teacher discovers that an answer sheet for an upcoming test is missing. She changes all of the questions for the test and keeps the new answer sheet with her at all times.";
					PlayerPrefs.SetInt("Scheme_5_Stage", 100);
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 12)
			{
				Debug.Log("Phase 12.");
				this.ClubClosed = false;
				this.ClubKicked = false;
				if (this.ClubID < Extensions.get_length(this.ClubArray))
				{
					if (PlayerPrefs.GetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed") == 0)
					{
						this.ClubManager.CheckClub(this.ClubArray[this.ClubID]);
						if (this.ClubManager.ClubMembers < 5)
						{
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed", 1);
							this.Label.text = "The " + this.ClubNames[this.ClubID] + " no longer has enough members to remain operational. The school forces the club to disband.";
							this.ClubClosed = true;
							if (PlayerPrefs.GetInt("Club") == this.ClubArray[this.ClubID])
							{
								PlayerPrefs.SetInt("Club", 0);
							}
						}
						if (this.ClubManager.LeaderMissing)
						{
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed", 1);
							this.Label.text = "The leader of the " + this.ClubNames[this.ClubID] + " has gone missing. The " + this.ClubNames[this.ClubID] + " cannot operate without its leader. The club disbands.";
							this.ClubClosed = true;
							if (PlayerPrefs.GetInt("Club") == this.ClubArray[this.ClubID])
							{
								PlayerPrefs.SetInt("Club", 0);
							}
						}
						else if (this.ClubManager.LeaderDead)
						{
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed", 1);
							this.Label.text = "The leader of the " + this.ClubNames[this.ClubID] + " is dead. The remaining members of the club decide to disband the club.";
							this.ClubClosed = true;
							if (PlayerPrefs.GetInt("Club") == this.ClubArray[this.ClubID])
							{
								PlayerPrefs.SetInt("Club", 0);
							}
						}
					}
					if (PlayerPrefs.GetInt("Club_" + this.ClubArray[this.ClubID] + "_Closed") == 0 && PlayerPrefs.GetInt("Club_" + this.ClubArray[this.ClubID] + "_Kicked") == 0 && PlayerPrefs.GetInt("Club") == this.ClubArray[this.ClubID])
					{
						this.ClubManager.CheckGrudge(this.ClubArray[this.ClubID]);
						if (this.ClubManager.LeaderGrudge)
						{
							this.Label.text = "Yandere-chan receives a text message from the president of the " + this.ClubNames[this.ClubID] + ". Yandere-chan is no longer a member of the " + this.ClubNames[this.ClubID] + ", and is not welcome in the " + this.ClubNames[this.ClubID] + " room.";
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Kicked", 1);
							PlayerPrefs.SetInt("Club", 0);
							this.ClubKicked = true;
						}
						else if (this.ClubManager.ClubGrudge)
						{
							this.Label.text = "Yandere-chan receives a text message from the president of the " + this.ClubNames[this.ClubID] + ". There is someone in the " + this.ClubNames[this.ClubID] + " who hates and fears Yandere-chan. Yandere-chan is no longer a member of the " + this.ClubNames[this.ClubID] + ", and is not welcome in the " + this.ClubNames[this.ClubID] + " room.";
							PlayerPrefs.SetInt("Club_" + this.ClubArray[this.ClubID] + "_Kicked", 1);
							PlayerPrefs.SetInt("Club", 0);
							this.ClubKicked = true;
						}
					}
					if (!this.ClubClosed && !this.ClubKicked)
					{
						this.ClubID++;
						this.UpdateScene();
					}
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 13)
			{
				Debug.Log("Phase 13.");
				if (this.TranqCase.Occupied)
				{
					this.Label.text = "Yandere-chan waits until the clock strikes midnight." + "\n" + "\n" + "Under the cover of darkness, Yandere-chan travels back to school and sneaks inside of the main school building." + "\n" + "\n" + "Yandere-chan returns to the instrument case that carries her unconscious victim." + "\n" + "\n" + "She pushes the case back to her house, pretending to be a young musician returning home from a late-night show." + "\n" + "\n" + "Yandere-chan drags the case down to her basement and ties up her victim." + "\n" + "\n" + "Exhausted, Yandere-chan goes to sleep.";
					this.Phase++;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 14)
			{
				Debug.Log("Phase 14.");
				if (this.ErectFence)
				{
					this.Label.text = "To prevent any other students from falling off of the school rooftop, the school erects a fence around the roof.";
					PlayerPrefs.SetInt("RoofFence", 1);
					this.ErectFence = false;
				}
				else
				{
					this.Phase++;
					this.UpdateScene();
				}
			}
			else if (this.Phase == 15)
			{
				PlayerPrefs.SetFloat("Reputation", this.Reputation.Reputation);
				PlayerPrefs.SetInt("Night", 1);
				this.Police.KillStudents();
				if (!this.TranqCase.Occupied)
				{
					Application.LoadLevel("HomeScene");
				}
				else
				{
					PlayerPrefs.SetInt("KidnapVictim", this.TranqCase.VictimID);
					PlayerPrefs.SetInt("Student_" + this.TranqCase.VictimID + "_Kidnapped", 1);
					PlayerPrefs.SetFloat("Student_" + this.TranqCase.VictimID + "_Sanity", 100f);
					Application.LoadLevel("CalendarScene");
				}
			}
			else if (this.Phase == 100)
			{
				this.Label.text = "Yandere-chan is arrested by the police. She will never have Senpai.";
				this.GameOver = true;
			}
			else if (this.Phase == 101)
			{
				if (!this.StudentManager.Students[this.WeaponManager.Weapons[this.WeaponID].FingerprintID].Dead)
				{
					if (!this.StudentManager.Students[this.WeaponManager.Weapons[this.WeaponID].FingerprintID].Tranquil)
					{
						this.Label.text = this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + " is arrested by the police.";
						PlayerPrefs.SetInt("Student_" + this.WeaponManager.Weapons[this.WeaponID].FingerprintID + "_Arrested", 1);
						this.Arrests++;
					}
					else
					{
						this.Label.text = this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + " is found asleep inside of a musical instrument case. The police assume that she hid herself inside of the box after committing murder, and arrest her.";
						PlayerPrefs.SetInt("Student_" + this.WeaponManager.Weapons[this.WeaponID].FingerprintID + "_Arrested", 1);
						this.ArrestID = this.WeaponManager.Weapons[this.WeaponID].FingerprintID;
						this.TranqCase.Occupied = false;
						this.Arrests++;
					}
				}
				else
				{
					this.ID = 0;
					bool flag;
					while (this.ID < Extensions.get_length(this.VictimArray))
					{
						if (this.VictimArray[this.ID] == this.WeaponManager.Weapons[this.WeaponID].FingerprintID && !this.StudentManager.Students[this.WeaponManager.Weapons[this.WeaponID].FingerprintID].MurderSuicide)
						{
							flag = true;
						}
						this.ID++;
					}
					if (!flag)
					{
						this.Label.text = this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + " is dead. The police cannot perform an arrest.";
						this.DeadPerps++;
					}
					else
					{
						this.Label.text = this.JSON.StudentNames[this.WeaponManager.Weapons[this.WeaponID].FingerprintID] + "'s fingerprints are on the same weapon that killed her. The police cannot solve this mystery.";
					}
				}
				this.Phase = 5;
			}
			else if (this.Phase == 102)
			{
				this.Label.text = "The police inspect the corpse of a student who appears to have fallen to their death from the school rooftop. The police treat the incident as a murder case, and search the school for any other victims.";
				this.ErectFence = true;
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Police.CorpseList))
				{
					if (this.Police.CorpseList[this.ID] != null && this.Police.CorpseList[this.ID].Suicide)
					{
						this.Police.CorpseList[this.ID] = null;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 103)
			{
				this.Label.text = "The paramedics attempt to resuscitate the poisoned student, but they are unable to revive her. The police treat the incident as a murder case, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Police.CorpseList))
				{
					if (this.Police.CorpseList[this.ID] != null && this.Police.CorpseList[this.ID].Poisoned)
					{
						this.Police.CorpseList[this.ID] = null;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 104)
			{
				this.Label.text = "The police determine that " + this.Police.DrownedStudentName + " died from drowning. The police treat her death as a possible murder, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Police.CorpseList))
				{
					if (this.Police.CorpseList[this.ID] != null && this.Police.CorpseList[this.ID].Drowned)
					{
						this.Police.CorpseList[this.ID] = null;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
			else if (this.Phase == 105)
			{
				this.Label.text = "The police determine that " + this.Police.ElectrocutedStudentName + " died from being electrocuted. The police treat her death as a possible murder, and search the school for any other victims.";
				this.ID = 0;
				while (this.ID < Extensions.get_length(this.Police.CorpseList))
				{
					if (this.Police.CorpseList[this.ID] != null && this.Police.CorpseList[this.ID].Electrocuted)
					{
						this.Police.CorpseList[this.ID] = null;
						this.Police.Corpses = this.Police.Corpses - 1;
					}
					this.ID++;
				}
				this.Phase = 2;
			}
		}
	}

	// Token: 0x06000347 RID: 839 RVA: 0x00045700 File Offset: 0x00043900
	public virtual void Main()
	{
	}

	// Token: 0x04000829 RID: 2089
	public StudentManagerScript StudentManager;

	// Token: 0x0400082A RID: 2090
	public WeaponManagerScript WeaponManager;

	// Token: 0x0400082B RID: 2091
	public ClubManagerScript ClubManager;

	// Token: 0x0400082C RID: 2092
	public HeartbrokenScript Heartbroken;

	// Token: 0x0400082D RID: 2093
	public ReputationScript Reputation;

	// Token: 0x0400082E RID: 2094
	public CounselorScript Counselor;

	// Token: 0x0400082F RID: 2095
	public WeaponScript MurderWeapon;

	// Token: 0x04000830 RID: 2096
	public TranqCaseScript TranqCase;

	// Token: 0x04000831 RID: 2097
	public YandereScript Yandere;

	// Token: 0x04000832 RID: 2098
	public RagdollScript Corpse;

	// Token: 0x04000833 RID: 2099
	public PoliceScript Police;

	// Token: 0x04000834 RID: 2100
	public JsonScript JSON;

	// Token: 0x04000835 RID: 2101
	public GameObject MainCamera;

	// Token: 0x04000836 RID: 2102
	public UISprite EndOfDayDarkness;

	// Token: 0x04000837 RID: 2103
	public UILabel Label;

	// Token: 0x04000838 RID: 2104
	public bool PreviouslyActivated;

	// Token: 0x04000839 RID: 2105
	public bool PoliceArrived;

	// Token: 0x0400083A RID: 2106
	public bool ClubClosed;

	// Token: 0x0400083B RID: 2107
	public bool ClubKicked;

	// Token: 0x0400083C RID: 2108
	public bool ErectFence;

	// Token: 0x0400083D RID: 2109
	public bool GameOver;

	// Token: 0x0400083E RID: 2110
	public bool Darken;

	// Token: 0x0400083F RID: 2111
	public string VictimString;

	// Token: 0x04000840 RID: 2112
	public int DeadPerps;

	// Token: 0x04000841 RID: 2113
	public int Arrests;

	// Token: 0x04000842 RID: 2114
	public int Corpses;

	// Token: 0x04000843 RID: 2115
	public int Victims;

	// Token: 0x04000844 RID: 2116
	public int Weapons;

	// Token: 0x04000845 RID: 2117
	public int Phase;

	// Token: 0x04000846 RID: 2118
	public int WeaponID;

	// Token: 0x04000847 RID: 2119
	public int ArrestID;

	// Token: 0x04000848 RID: 2120
	public int ClubID;

	// Token: 0x04000849 RID: 2121
	public int ID;

	// Token: 0x0400084A RID: 2122
	public string[] ClubNames;

	// Token: 0x0400084B RID: 2123
	public int[] VictimArray;

	// Token: 0x0400084C RID: 2124
	public int[] ClubArray;
}
