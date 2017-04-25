using System;
using UnityEngine;

// Token: 0x02000077 RID: 119
[Serializable]
public class DebugMenuScript : MonoBehaviour
{
	// Token: 0x060002EA RID: 746 RVA: 0x0003B0D4 File Offset: 0x000392D4
	public virtual void Start()
	{
		int num = 0;
		Vector3 localPosition = this.transform.localPosition;
		float num2 = localPosition.y = (float)num;
		Vector3 vector = this.transform.localPosition = localPosition;
		this.Window.active = false;
		if (PlayerPrefs.GetInt("MissionMode") == 1)
		{
			this.MissionMode = true;
		}
	}

	// Token: 0x060002EB RID: 747 RVA: 0x0003B134 File Offset: 0x00039334
	public virtual void Update()
	{
		if (!this.MissionMode)
		{
			if (!this.Yandere.InClass && !this.Yandere.Chased && this.Yandere.CanMove)
			{
				if (Input.GetKeyDown(KeyCode.Backslash) && this.Yandere.transform.position.y < (float)100)
				{
					this.EasterEggWindow.active = false;
					if (!this.Window.active)
					{
						this.Window.active = true;
					}
					else
					{
						this.Window.active = false;
					}
				}
			}
			else if (this.Window.active)
			{
				this.Window.active = false;
			}
			if (this.Window.active)
			{
				if (Input.GetKeyDown(KeyCode.F1))
				{
					PlayerPrefs.SetInt("FemaleUniform", 1);
					PlayerPrefs.SetInt("MaleUniform", 1);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F2))
				{
					PlayerPrefs.SetInt("FemaleUniform", 2);
					PlayerPrefs.SetInt("MaleUniform", 2);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F3))
				{
					PlayerPrefs.SetInt("FemaleUniform", 3);
					PlayerPrefs.SetInt("MaleUniform", 3);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F4))
				{
					PlayerPrefs.SetInt("FemaleUniform", 4);
					PlayerPrefs.SetInt("MaleUniform", 4);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F5))
				{
					PlayerPrefs.SetInt("FemaleUniform", 5);
					PlayerPrefs.SetInt("MaleUniform", 5);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown(KeyCode.F6))
				{
					PlayerPrefs.SetInt("FemaleUniform", 6);
					PlayerPrefs.SetInt("MaleUniform", 6);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown("1"))
				{
					PlayerPrefs.SetInt("Weekday", 1);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown("2"))
				{
					PlayerPrefs.SetInt("Weekday", 2);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown("3"))
				{
					PlayerPrefs.SetInt("Weekday", 3);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown("4"))
				{
					PlayerPrefs.SetInt("Weekday", 4);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown("5"))
				{
					PlayerPrefs.SetInt("Weekday", 5);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown("6"))
				{
					this.Yandere.transform.position = this.TeleportSpot[1].position;
					this.Window.active = false;
				}
				else if (Input.GetKeyDown("7"))
				{
					this.Yandere.transform.position = this.TeleportSpot[2].position;
					this.Window.active = false;
				}
				else if (Input.GetKeyDown("8"))
				{
					this.Yandere.transform.position = this.TeleportSpot[3].position;
					this.Window.active = false;
				}
				else if (Input.GetKeyDown("9"))
				{
					this.Yandere.transform.position = this.TeleportSpot[4].position;
					this.Window.active = false;
					if (this.Clock.HourTime < 7.1f)
					{
						this.Clock.PresentTime = 426f;
					}
					if (this.StudentManager.Students[7] != null)
					{
						if (this.StudentManager.Students[7].Phase < 2)
						{
							this.StudentManager.Students[7].ShoeRemoval.Start();
							this.StudentManager.Students[7].ShoeRemoval.PutOnShoes();
							this.StudentManager.Students[7].CanTalk = true;
							this.StudentManager.Students[7].Phase = 2;
							this.StudentManager.Students[7].CurrentDestination = this.StudentManager.Students[7].Destinations[2];
							this.StudentManager.Students[7].Pathfinding.target = this.StudentManager.Students[7].Destinations[2];
						}
						this.StudentManager.Students[7].transform.position = this.StudentManager.Students[7].Destinations[2].position;
					}
					if (this.StudentManager.Students[13] != null)
					{
						if (this.StudentManager.Students[13].Phase < 2)
						{
							this.StudentManager.Students[13].ShoeRemoval.Start();
							this.StudentManager.Students[13].ShoeRemoval.PutOnShoes();
							this.StudentManager.Students[13].Phase = 2;
							this.StudentManager.Students[13].CurrentDestination = this.StudentManager.Students[13].Destinations[2];
							this.StudentManager.Students[13].Pathfinding.target = this.StudentManager.Students[13].Destinations[2];
						}
						this.StudentManager.Students[13].transform.position = this.StudentManager.Students[13].Destinations[2].position;
					}
					if (this.StudentManager.Students[16] != null)
					{
						if (this.StudentManager.Students[16].Phase < 2)
						{
							this.StudentManager.Students[16].ShoeRemoval.Start();
							this.StudentManager.Students[16].ShoeRemoval.PutOnShoes();
							this.StudentManager.Students[16].Phase = 2;
							this.StudentManager.Students[16].CurrentDestination = this.StudentManager.Students[16].Destinations[2];
							this.StudentManager.Students[16].Pathfinding.target = this.StudentManager.Students[16].Destinations[2];
						}
						this.StudentManager.Students[16].transform.position = this.StudentManager.Students[16].Destinations[2].position;
					}
				}
				else if (Input.GetKeyDown("0"))
				{
					this.CameraEffects.DisableCamera();
					this.Window.active = false;
				}
				else if (Input.GetKeyDown("a"))
				{
					if (PlayerPrefs.GetFloat("SchoolAtmosphere") > 66.66666f)
					{
						PlayerPrefs.SetFloat("SchoolAtmosphere", (float)50);
					}
					else if (PlayerPrefs.GetFloat("SchoolAtmosphere") > 33.33333f)
					{
						PlayerPrefs.SetFloat("SchoolAtmosphere", (float)0);
					}
					else
					{
						PlayerPrefs.SetFloat("SchoolAtmosphere", (float)100);
					}
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown("c"))
				{
					this.ID = 1;
					while (this.ID < 11)
					{
						PlayerPrefs.SetInt("Tape_" + this.ID + "_Collected", 1);
						this.ID++;
					}
					this.Window.active = false;
				}
				else if (Input.GetKeyDown("f"))
				{
					this.FakeStudentSpawner.Spawn();
					this.Window.active = false;
				}
				else if (Input.GetKeyDown("g"))
				{
					if (this.Clock.HourTime < (float)15)
					{
						PlayerPrefs.SetInt("7_Friend", 1);
						this.Yandere.transform.position = this.RooftopSpot.position;
						if (this.StudentManager.Students[7] != null)
						{
							this.StudentManager.OfferHelp.UpdateLocation();
							this.StudentManager.OfferHelp.enabled = true;
							if (!this.StudentManager.Students[7].Indoors)
							{
								if (this.StudentManager.Students[7].ShoeRemoval.Locker == null)
								{
									this.StudentManager.Students[7].ShoeRemoval.Start();
								}
								this.StudentManager.Students[7].ShoeRemoval.PutOnShoes();
							}
							this.StudentManager.Students[7].transform.position = this.RooftopSpot.position;
							this.StudentManager.Students[7].Prompt.Label[0].text = "     " + "Push";
							this.StudentManager.Students[7].CurrentDestination = this.RooftopSpot;
							this.StudentManager.Students[7].Pathfinding.target = this.RooftopSpot;
							this.StudentManager.Students[7].Pathfinding.canSearch = true;
							this.StudentManager.Students[7].Pathfinding.canMove = true;
							this.StudentManager.Students[7].Meeting = true;
							this.StudentManager.Students[7].MeetTime = (float)0;
						}
						if (this.Clock.HourTime < 7.1f)
						{
							this.Clock.PresentTime = 426f;
						}
					}
					else
					{
						this.Clock.PresentTime = (float)960;
						this.StudentManager.Students[7].transform.position = this.Lockers.position;
					}
					this.Window.active = false;
				}
				else if (Input.GetKeyDown("k"))
				{
					PlayerPrefs.SetInt("KidnapVictim", 6);
					PlayerPrefs.SetInt("Student_6_Slave", 1);
					Application.LoadLevel("LoadingScene");
				}
				else if (Input.GetKeyDown("l"))
				{
					PlayerPrefs.SetInt("Event1", 1);
					this.Window.active = false;
				}
				else if (!Input.GetKeyDown("m"))
				{
					if (Input.GetKeyDown("o"))
					{
						this.Yandere.Inventory.RivalPhone = true;
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("p"))
					{
						PlayerPrefs.SetInt("PantyShots", PlayerPrefs.GetInt("PantyShots") + 20);
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("q"))
					{
						this.Censor();
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("r"))
					{
						if (PlayerPrefs.GetFloat("Reputation") != 66.66666f)
						{
							PlayerPrefs.SetFloat("Reputation", 66.66666f);
							this.Reputation.Reputation = PlayerPrefs.GetFloat("Reputation");
						}
						else
						{
							PlayerPrefs.SetFloat("Reputation", -66.66666f);
							this.Reputation.Reputation = PlayerPrefs.GetFloat("Reputation");
						}
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("s"))
					{
						PlayerPrefs.SetInt("PhysicalGrade", 5);
						PlayerPrefs.SetInt("Seduction", 5);
						this.ID = 1;
						while (this.ID < 101)
						{
							PlayerPrefs.SetInt("Student_" + this.ID + "_Photographed", 1);
							this.ID++;
						}
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("t"))
					{
						if (!this.Zoom.OverShoulder)
						{
							this.Zoom.OverShoulder = true;
						}
						else
						{
							this.Zoom.OverShoulder = false;
						}
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("u"))
					{
						PlayerPrefs.SetInt("7_Friend", 1);
						PlayerPrefs.SetInt("13_Friend", 1);
						this.ID = 1;
						while (this.ID < 26)
						{
							PlayerPrefs.SetInt("Topic_" + this.ID + "_Student_7_Learned", 1);
							PlayerPrefs.SetInt("Topic_" + this.ID + "_Discovered", 1);
							this.ID++;
						}
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("y"))
					{
						this.DelinquentManager.Delinquents.active = false;
						this.DelinquentManager.active = false;
					}
					else if (Input.GetKeyDown("z"))
					{
						this.ID = 1;
						while (this.ID < 101)
						{
							if (this.StudentManager.Students[this.ID] != null)
							{
								this.StudentManager.Students[this.ID].SpawnAlarmDisc();
								this.StudentManager.Students[this.ID].BecomeRagdoll();
								this.StudentManager.Students[this.ID].Dead = true;
								PlayerPrefs.SetInt("Student_" + this.ID + "_Dead", 1);
							}
							this.ID++;
						}
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("x"))
					{
						if (PlayerPrefs.GetInt("HighPopulation") == 0)
						{
							PlayerPrefs.SetInt("HighPopulation", 1);
						}
						else
						{
							PlayerPrefs.SetInt("HighPopulation", 0);
						}
						Application.LoadLevel("LoadingScene");
					}
					else if (Input.GetKeyDown("backspace"))
					{
						Time.timeScale = (float)1;
						this.Clock.PresentTime = (float)1079;
						this.Clock.HourTime = this.Clock.PresentTime / (float)60;
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("`"))
					{
						PlayerPrefs.DeleteAll();
						Application.LoadLevel("LoadingScene");
					}
					else if (Input.GetKeyDown("space"))
					{
						this.Yandere.transform.position = this.TeleportSpot[5].position;
						if (this.StudentManager.Students[21] != null)
						{
							this.StudentManager.Students[21].transform.position = this.TeleportSpot[5].position;
						}
						this.Clock.PresentTime = (float)1015;
						this.Clock.HourTime = this.Clock.PresentTime / (float)60;
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("left alt"))
					{
						this.Turtle.SpawnWeapons();
						this.Yandere.transform.position = this.TeleportSpot[6].position;
						this.Clock.PresentTime = (float)425;
						this.Clock.HourTime = this.Clock.PresentTime / (float)60;
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("left ctrl"))
					{
						this.Yandere.transform.position = this.TeleportSpot[7].position;
						if (this.StudentManager.Students[26] != null)
						{
							this.StudentManager.Students[26].transform.position = this.TeleportSpot[7].position;
						}
						this.Clock.PresentTime = (float)1015;
						this.Clock.HourTime = this.Clock.PresentTime / (float)60;
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("right ctrl"))
					{
						this.Yandere.transform.position = this.TeleportSpot[8].position;
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("="))
					{
						this.Clock.PresentTime = this.Clock.PresentTime + (float)30;
						this.Window.active = false;
					}
					else if (Input.GetKeyDown("enter"))
					{
						this.Yandere.transform.eulerAngles = this.TeleportSpot[10].eulerAngles;
						this.Yandere.transform.position = this.TeleportSpot[10].position;
						this.StudentManager.Students[1].ShoeRemoval.Start();
						this.StudentManager.Students[1].ShoeRemoval.PutOnShoes();
						this.StudentManager.Students[1].transform.position = new Vector3((float)0, 12.1f, (float)-25);
						this.StudentManager.Students[1].Alarmed = true;
						this.StudentManager.Students[33].Lethal = true;
						this.StudentManager.Students[33].ShoeRemoval.Start();
						this.StudentManager.Students[33].ShoeRemoval.PutOnShoes();
						this.StudentManager.Students[33].transform.position = new Vector3((float)0, 12.1f, (float)-25);
						this.Clock.PresentTime = (float)780;
						this.Clock.HourTime = this.Clock.PresentTime / (float)60;
						this.Window.active = false;
					}
				}
			}
			else if (Input.GetKeyDown("`"))
			{
				this.ID = 0;
				while (this.ID < this.StudentManager.NPCsTotal)
				{
					if (PlayerPrefs.GetInt("Student_" + this.ID + "_Dying") == 1)
					{
						PlayerPrefs.SetInt("Student_" + this.ID + "_Dying", 0);
					}
					this.ID++;
				}
				Application.LoadLevel("LoadingScene");
			}
		}
		else if (Input.GetKeyDown(KeyCode.Backslash))
		{
			this.Censor();
		}
	}

	// Token: 0x060002EC RID: 748 RVA: 0x0003C490 File Offset: 0x0003A690
	public virtual void Censor()
	{
		if (!this.StudentManager.Censor)
		{
			if (this.Yandere.Schoolwear == 1 && !this.Yandere.Sans)
			{
				if (!this.Yandere.FlameDemonic && !this.Yandere.TornadoHair.active)
				{
					this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", (float)1);
					this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", (float)1);
				}
				else
				{
					this.Yandere.MyRenderer.materials[2].SetTexture("_OverlayTex", this.PantyCensorTexture);
					this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", (float)0);
					this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", (float)0);
					this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", (float)1);
				}
			}
			this.StudentManager.Censor = true;
			this.StudentManager.CensorStudents();
		}
		else
		{
			this.Yandere.MyRenderer.materials[0].SetFloat("_BlendAmount", (float)0);
			this.Yandere.MyRenderer.materials[1].SetFloat("_BlendAmount", (float)0);
			this.Yandere.MyRenderer.materials[2].SetFloat("_BlendAmount", (float)0);
			this.StudentManager.Censor = false;
			this.StudentManager.CensorStudents();
		}
	}

	// Token: 0x060002ED RID: 749 RVA: 0x0003C640 File Offset: 0x0003A840
	public virtual void UpdateCensor()
	{
		this.Censor();
		this.Censor();
	}

	// Token: 0x060002EE RID: 750 RVA: 0x0003C650 File Offset: 0x0003A850
	public virtual void Main()
	{
	}

	// Token: 0x04000737 RID: 1847
	public FakeStudentSpawnerScript FakeStudentSpawner;

	// Token: 0x04000738 RID: 1848
	public DelinquentManagerScript DelinquentManager;

	// Token: 0x04000739 RID: 1849
	public StudentManagerScript StudentManager;

	// Token: 0x0400073A RID: 1850
	public CameraEffectsScript CameraEffects;

	// Token: 0x0400073B RID: 1851
	public ReputationScript Reputation;

	// Token: 0x0400073C RID: 1852
	public YandereScript Yandere;

	// Token: 0x0400073D RID: 1853
	public BentoScript Bento;

	// Token: 0x0400073E RID: 1854
	public ClockScript Clock;

	// Token: 0x0400073F RID: 1855
	public PrayScript Turtle;

	// Token: 0x04000740 RID: 1856
	public ZoomScript Zoom;

	// Token: 0x04000741 RID: 1857
	public GameObject EasterEggWindow;

	// Token: 0x04000742 RID: 1858
	public GameObject SacrificialArm;

	// Token: 0x04000743 RID: 1859
	public GameObject CircularSaw;

	// Token: 0x04000744 RID: 1860
	public GameObject Knife;

	// Token: 0x04000745 RID: 1861
	public Transform[] TeleportSpot;

	// Token: 0x04000746 RID: 1862
	public Transform RooftopSpot;

	// Token: 0x04000747 RID: 1863
	public Transform Lockers;

	// Token: 0x04000748 RID: 1864
	public GameObject Window;

	// Token: 0x04000749 RID: 1865
	public bool MissionMode;

	// Token: 0x0400074A RID: 1866
	public int ID;

	// Token: 0x0400074B RID: 1867
	public Texture PantyCensorTexture;
}
